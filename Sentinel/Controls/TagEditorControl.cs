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

namespace Sentinel.Controls
{
    public partial class TagEditorControl : UserControl
    {
        public OpenCacheInfo CacheInfo { get; set; }

        public TagInstance Instance { get; set; }
        
        public object Value { get; set; }

        public TagEditorControl(OpenCacheInfo cacheInfo, TagInstance instance)
        {
            CacheInfo = cacheInfo;
            Instance = instance;
            
            InitializeComponent();

            Load += TagEditorControl_Load;
        }

        private void TagEditorControl_Load(object sender, EventArgs e)
        {
            using (var cacheStream = CacheInfo.TagCacheInfo.OpenRead())
            {
                var context = new TagSerializationContext(cacheStream, CacheInfo.TagCacheData, CacheInfo.StringIDsCacheData, Instance);
                var deserializer = new TagDeserializer(CacheInfo.Version);
                var type = TagUtils.TagGroupTypes[Instance.GroupTag.ToString()];
                Value = deserializer.Deserialize(context, type);
            }

            var enumerator = new TagFieldEnumerator(Instance, CacheInfo.Version);
            
            var tagInfoControl = new Controls.TagInfoControl(
                string.Format("0x{0:X8}", Instance.Index),
                string.Format("0x{0:X8}", Instance.DataOffset),
                string.Format("0x{0:X8}", Instance.DataSize));

            controlPanel.Controls.Add(tagInfoControl);
            tagInfoControl.BringToFront();

            var currentPoint = new Point(0, tagInfoControl.Height);

            while (enumerator.Next())
            {
                Control control = null;

                if (enumerator.Field.FieldType == typeof(Angle))
                    control = new Controls.AngleControl(Value, enumerator.Field);
                else if (enumerator.Field.FieldType == typeof(Vector2))
                    control = new Controls.Vector2Control(Value, enumerator.Field);
                else if (enumerator.Field.FieldType == typeof(Vector3))
                    control = new Controls.Vector3Control(Value, enumerator.Field);
                else if (enumerator.Field.FieldType == typeof(Vector4))
                    control = new Controls.Vector4Control(Value, enumerator.Field);
                else
                    control = new Controls.NumberControl(Value, enumerator.Field);
                
                control.Location = currentPoint;
                currentPoint.Y += control.Height;
                controlPanel.Controls.Add(control);
                control.BringToFront();
            }
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
