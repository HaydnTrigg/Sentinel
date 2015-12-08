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

        public TagFieldPanel Panel =>
            tagFieldPanel;

        public TagEditorControl(OpenCacheInfo cacheInfo, TagInstance instance)
        {
            CacheInfo = cacheInfo;
            Instance = instance;
            
            InitializeComponent();

            SuspendLayout();
            var type = TagUtils.TagGroupTypes[instance.GroupTag.ToString()];
            tagFieldPanel.Definition = new TagDefinition(type);
            ResumeLayout(false);

            Load += TagEditorControl_Load;
        }

        public void TagEditorControl_Load(object sender, EventArgs e)
        {
            using (var cacheStream = CacheInfo.TagCacheInfo.OpenRead())
            {
                var context = new TagSerializationContext(cacheStream, CacheInfo.TagCacheData, CacheInfo.StringIDsCacheData, Instance);
                var deserializer = new TagDeserializer(CacheInfo.Version);
                var type = TagUtils.TagGroupTypes[Instance.GroupTag.ToString()];
                Value = deserializer.Deserialize(context, type);
            }

            tagFieldPanel.GetValues(Value);
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
