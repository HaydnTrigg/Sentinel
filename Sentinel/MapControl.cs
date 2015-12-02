using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.BitConverter;
using static System.Text.Encoding;

using Blam.Cache;
using Blam.Common;
using Blam.Game;
using Blam.Tags;
using System.Globalization;

namespace Sentinel
{
    public partial class MapControl : UserControl
    {
        public FileInfo MapInfo { get; set; }
        public List<FileInfo> DatFiles { get; set; }
        public GameVersion Version { get; set; }

        public FileInfo TagsCacheInfo { get; set; }
        public TagCache TagsData { get; set; }

        public FileInfo StringIDsCacheInfo { get; set; }
        public StringIDsCache StringIDsData { get; set; }
        
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

            var tagCacheInfo = DatFiles.Find(file => file.Name == "tags.dat");

            using (var tagCacheStream = tagCacheInfo.OpenRead())
                TagsData = new TagCache(tagCacheStream);

            GameVersion closestVersion;
            Version = GameVersions.DetectVersion(TagsData, out closestVersion);

            if (Version != GameVersion.Unknown)
            {
                var buildDate = DateTime.FromFileTime(TagsData.Timestamp);
                engineVersionLabel.Text = string.Format("Halo Online {0} {1} ({2})",
                    GameVersions.GetVersionString(Version),
                    buildDate.ToShortDateString(),
                    buildDate.ToShortTimeString());
            }
            else
            {
                engineVersionLabel.Text = string.Format("Halo Online UNKNOWN ({0}?)",
                    GameVersions.GetVersionString(closestVersion));
                Version = closestVersion;
            }

            var stringIDsCacheInfo = DatFiles.Find(file => file.Name == "string_ids.dat");

            StringIDResolverBase stringIDsResolver = null;

            if (GameVersions.Compare(Version, GameVersion.V11_1_498295_Live) >= 0)
                stringIDsResolver = new Blam.Game.V11_1_498295.StringIDResolver();
            else
                stringIDsResolver = new Blam.Game.V1_106708.StringIDResolver();

            using (var stringIDsCacheStream = stringIDsCacheInfo.OpenRead())
                StringIDsData = new StringIDsCache(stringIDsCacheStream, stringIDsResolver);

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

            var mapTags = new Dictionary<int, TagInstance>();
            LoadDependencies(scenarioIndex, ref mapTags);
            LoadDependencies(TagsData.Tags.FindFirstInGroup(new Tag("matg")).Index, ref mapTags);
            LoadDependencies(TagsData.Tags.FindFirstInGroup(new Tag("mulg")).Index, ref mapTags);
            
            var tagGroups = new Dictionary<Tag, List<TagInstance>>();

            foreach (var entry in mapTags)
            {
                var tag = entry.Value;

                if (tag == null)
                    continue;

                if (!tagGroups.ContainsKey(tag.GroupTag))
                    tagGroups[tag.GroupTag] = new List<TagInstance>();

                tagGroups[tag.GroupTag].Add(tag);
            }

            var tagNames = GetTagNames();

            foreach (var entry in tagGroups)
            {
                var groupNode = new TreeNode(entry.Key.ToString());
                bool groupNameSet = false;

                foreach (var instance in entry.Value)
                {
                    if (!tagNames.ContainsKey(instance.Index))
                        tagNames[instance.Index] = string.Format("0x{0:X8}", instance.Index);
                    if (!groupNameSet)
                    {
                        groupNameSet = true;
                        groupNode.Text += string.Format(" - {0}",
                            StringIDsData.GetString(instance.GroupName));
                    }
                    var instanceNode = new TreeNode(tagNames[instance.Index]);
                    instanceNode.Tag = instance;
                    groupNode.Nodes.Add(instanceNode);
                }
                tagTreeView.Nodes.Add(groupNode);
            }

            tagTreeView.Sort();
        }

        public Dictionary<int, string> GetTagNames()
        {
            FileInfo csvFile = null;

            if (GameVersions.Compare(Version, GameVersion.V11_1_498295_Live) >= 0)
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
                        tags[entry] = TagsData.Tags[entry];
                        foreach (var dependency in tags[entry].Dependencies)
                            if (!nextQueue.Contains(dependency))
                                nextQueue.Add(dependency);
                    }
                }

                queue = nextQueue;
            }
        }
    }
}
