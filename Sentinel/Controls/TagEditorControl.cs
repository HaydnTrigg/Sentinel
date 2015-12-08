using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Blam.Tags;
using Blam.Common;
using Blam.Game;
using Blam.Cache;
using System.IO;
using System.Collections;

namespace Sentinel.Controls
{
    public partial class TagEditorControl : UserControl
    {
        public OpenCacheInfo CacheInfo { get; set; }

        public TagInstance Instance { get; set; }
        
        public TagDefinition Definition { get; set; }

        public object Value { get; set; }

        public TagEditorControl(OpenCacheInfo cacheInfo, TagInstance instance)
        {
            CacheInfo = cacheInfo;
            Instance = instance;
            
            InitializeComponent();

            Load += TagEditorControl_Load;
        }

        public Panel ControlPanel => controlPanel;

        public void TagEditorControl_Load(object sender, EventArgs e)
        {
            using (var cacheStream = CacheInfo.TagCacheInfo.OpenRead())
            {
                var context = new TagSerializationContext(cacheStream, CacheInfo.TagCacheData, CacheInfo.StringIDsCacheData, Instance);
                var deserializer = new TagDeserializer(CacheInfo.Version);
                var type = TagUtils.TagGroupTypes[Instance.GroupTag.ToString()];
                Value = deserializer.Deserialize(context, type);
            }

            Definition = new TagDefinition(Value.GetType(), CacheInfo.Version);

            AddTagDefinitionControls(
                Definition,
                Value,
                new Point(),
                controlPanel);
        }

        public static void AddTagDefinitionControls(TagDefinition definition, object value, Point baseLocation, Control parent)
        {
            parent.SuspendLayout();

            var enumerator = new TagFieldEnumerator(definition);

            var panel = new TableLayoutPanel();
            panel.AutoSize = true;
            panel.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            panel.SuspendLayout();
            
            if (parent.Parent is TagEditorControl)
            {
                TagEditorControl editor = parent.Parent as TagEditorControl;

                panel.RowCount++;
                panel.RowStyles.Add(new RowStyle());

                var tagInfoControl = new Controls.TagInfoControl(
                    string.Format("0x{0:X8}", editor.Instance.Index),
                    string.Format("0x{0:X8}", editor.Instance.DataOffset),
                    string.Format("0x{0:X8}", editor.Instance.DataSize));

                panel.Controls.Add(tagInfoControl);
                tagInfoControl.BringToFront();
            }

            while (enumerator.Next())
            {
                Control control = null;

                panel.RowCount++;

                if (enumerator.Field.FieldType == typeof(Angle))
                    control = new Controls.AngleControl(value, enumerator.Field);
                else if (enumerator.Field.FieldType == typeof(Vector2))
                    control = new Controls.Vector2Control(value, enumerator.Field);
                else if (enumerator.Field.FieldType == typeof(Vector3))
                    control = new Controls.Vector3Control(value, enumerator.Field);
                else if (enumerator.Field.FieldType == typeof(Vector4))
                    control = new Controls.Vector4Control(value, enumerator.Field);
                else if (enumerator.Field.FieldType.IsArray == false &&
                         enumerator.Field.FieldType.GetInterface("IList") != null)
                    control = new Controls.BlockControl(value, enumerator.Field,
                        new TagDefinition(
                            enumerator.Field.FieldType.GenericTypeArguments[0],
                            definition.Version));
                else
                    control = new Controls.NumberControl(value, enumerator.Field);

                panel.RowStyles.Add(new RowStyle());
                panel.Controls.Add(control, 0, panel.RowCount - 1);
                control.BringToFront();

                Application.DoEvents();
            }

            panel.ResumeLayout();
            parent.Controls.Add(panel);
            parent.ResumeLayout();
        }
        
        private void saveChangesButton_Click(object sender, EventArgs e)
        {
            using (var cacheStream = CacheInfo.TagCacheInfo.Open(FileMode.Open, FileAccess.ReadWrite))
            {
                var context = new TagSerializationContext(cacheStream, CacheInfo.TagCacheData, CacheInfo.StringIDsCacheData, Instance);
                var serializer = new TagSerializer(CacheInfo.Version);
                serializer.Serialize(context, Value);
            }

            MessageBox.Show("Done!");
        }
    }
}
