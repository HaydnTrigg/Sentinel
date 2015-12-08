using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Windows.Forms;

using Blam.Cache;
using Blam.Common;
using Blam.Game;
using Blam.Scenario;
using Blam.Tags;

namespace Sentinel.Controls
{
    public partial class MapControl : UserControl
    {
        public FileInfo MapInfo { get; set; }
        public List<FileInfo> DatFiles { get; set; }
        
        public OpenCacheInfo CacheInfo { get; set; }

        public MapControl()
        {
            MapInfo = null;
            InitializeComponent();
        }

        public MapControl(FileInfo mapInfo)
        {
            MapInfo = mapInfo;
            InitializeComponent();
            LoadCache();
        }

        public void LoadCache()
        {
            var directory = MapInfo.Directory;

            DatFiles = directory.GetFiles("*.dat").ToList();

            var tagsCacheInfo = DatFiles.Find(file => file.Name == "tags.dat");

            TagCache tagsData;
            using (var tagCacheStream = tagsCacheInfo.OpenRead())
                tagsData = new TagCache(tagCacheStream);

            GameVersion closestVersion;
            var version = GameVersions.DetectVersion(tagsData, out closestVersion);

            if (version != GameVersion.Unknown)
            {
                var buildDate = DateTime.FromFileTime(tagsData.Timestamp);
                engineVersionLabel.Text = string.Format("Halo Online {0} {1} ({2})",
                    GameVersions.GetVersionString(version),
                    buildDate.ToShortDateString(),
                    buildDate.ToShortTimeString());
            }
            else
            {
                engineVersionLabel.Text = string.Format("Halo Online UNKNOWN ({0}?)",
                    GameVersions.GetVersionString(closestVersion));
                version = closestVersion;
            }

            var stringIDsCacheInfo = DatFiles.Find(file => file.Name == "string_ids.dat");

            StringIDResolverBase stringIDsResolver = null;

            if (GameVersions.Compare(version, GameVersion.V11_1_498295_Live) >= 0)
                stringIDsResolver = new Blam.Game.V11_1_498295.StringIDResolver();
            else
                stringIDsResolver = new Blam.Game.V1_106708.StringIDResolver();

            StringIDsCache stringIDsData;
            using (var stringIDsCacheStream = stringIDsCacheInfo.OpenRead())
                stringIDsData = new StringIDsCache(stringIDsCacheStream, stringIDsResolver);

            Int32 scenarioIndex = -1;

            using (var reader = new BinaryReader(MapInfo.OpenRead()))
            {
                reader.BaseStream.Seek(4, SeekOrigin.Current);

                // Check map file version
                if (reader.ReadInt32() != 18)
                    throw new NotImplementedException("Only Halo Online maps are supported.");

                reader.BaseStream.Seek(0x2DF0, SeekOrigin.Begin);
                scenarioIndex = reader.ReadInt32();
            }

            var tagNames = GetTagNames(version);

            CacheInfo = new OpenCacheInfo
            {
                TagCacheInfo = tagsCacheInfo,
                TagCacheData = tagsData,
                TagNames = tagNames,
                StringIDsCacheInfo = stringIDsCacheInfo,
                StringIDsCacheData = stringIDsData,
                Version = version
            };

            var mapTags = new Dictionary<int, TagInstance>();
            LoadDependencies(scenarioIndex, ref mapTags);
            LoadDependencies(tagsData.Tags.FindFirstInGroup(new Tag("cfgt")).Index, ref mapTags);

            var groupNodes = new Dictionary<Tag, TreeNode>();

            tagTreeView.SuspendLayout();

            foreach (var entry in mapTags)
            {
                var instance = entry.Value;

                if (instance == null)
                    continue;

                if (!groupNodes.ContainsKey(instance.GroupTag))
                    groupNodes[instance.GroupTag] = new TreeNode($"{instance.GroupTag} - {stringIDsData.GetString(instance.GroupName)}");

                if (!tagNames.ContainsKey(entry.Value.Index))
                    tagNames[instance.Index] = string.Format("0x{0:X8}", instance.Index);

                var instanceNode = new TreeNode(tagNames[instance.Index]);
                instanceNode.Tag = instance;

                groupNodes[instance.GroupTag].Nodes.Add(instanceNode);
            }

            groupNodes.ToList().ForEach(entry => tagTreeView.Nodes.Add(entry.Value));

            tagTreeView.Sort();
            tagTreeView.ResumeLayout(false);
        }

        public Dictionary<int, string> GetTagNames(GameVersion version)
        {
            FileInfo csvFile = null;

            if (GameVersions.Compare(version, GameVersion.V11_1_498295_Live) >= 0)
                csvFile = new FileInfo(Application.StartupPath + "\\tagnames_11.1.498295 Live.csv");
            else
                csvFile = new FileInfo(Application.StartupPath + "\\tagnames_1.106708 cert_ms23.csv");

            var result = new Dictionary<int, string>();
            
            using (var streamReader = new StreamReader(csvFile.OpenRead()))
            {
                while (!streamReader.EndOfStream)
                {
                    var line = streamReader.ReadLine().Split(',');
                    int tagIndex;
                    if (!int.TryParse(line[0].Replace("0x", ""), NumberStyles.HexNumber, null, out tagIndex))
                        continue;
                    result[tagIndex] = line[1];
                }
            }

            return result;
        }
        
        private void LoadDependencies(int index, ref Dictionary<int, TagInstance> tags)
        {
            var queue = new List<int> { index };

            while (queue.Count != 0)
            {
                var nextQueue = new List<int>();

                foreach (var entry in queue)
                {
                    if (!tags.ContainsKey(entry))
                    {
                        tags[entry] = CacheInfo.TagCacheData.Tags[entry];
                        foreach (var dependency in tags[entry].Dependencies)
                            if (!nextQueue.Contains(dependency))
                                nextQueue.Add(dependency);
                    }
                }

                queue = nextQueue;
            }
        }

        private void tagTreeView_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (e.Node.Tag == null)
                return;

            SuspendLayout();

            var tagInstance = (TagInstance)e.Node.Tag;

            foreach (var entry in toolTabControl.TabPages)
            {
                var tabPage = (TabPage)entry;
                if (tabPage.Tag == tagInstance)
                {
                    toolTabControl.SelectedTab = tabPage;
                    return;
                }
            }

            var tagName = CacheInfo.TagNames[tagInstance.Index];

            if (tagName.Contains('\\'))
            {
                var index = tagName.LastIndexOf('\\') + 1;
                tagName = tagName.Substring(index, tagName.Length - index);
            }

            var tagEditPage = new TabPage(tagName + "." + CacheInfo.StringIDsCacheData.GetString(tagInstance.GroupName));
            tagEditPage.BackColor = System.Drawing.Color.White;
            tagEditPage.Tag = tagInstance;
            
            toolTabControl.TabPages.Add(tagEditPage);
            toolTabControl.SelectedTab = tagEditPage;

            var tagEditor = new TagEditorControl(CacheInfo, tagInstance);
            tagEditor.Dock = DockStyle.Fill;
            
            tagEditPage.Controls.Add(tagEditor);
            ResumeLayout(false);
        }

        private void tagTreeView_DoubleClick(object sender, EventArgs e)
        {
            tagTreeView_AfterSelect(sender, new TreeViewEventArgs(tagTreeView.SelectedNode));
        }
    }
}
