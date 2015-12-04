using Blam.Cache;
using Blam.Game;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sentinel
{
    public class OpenCacheInfo
    {
        public FileInfo TagCacheInfo { get; set; }
        public TagCache TagCacheData { get; set; }
        public Dictionary<int, string> TagNames { get; set; }
        public FileInfo StringIDsCacheInfo { get; set; }
        public StringIDsCache StringIDsCacheData { get; set; }
        public GameVersion Version { get; set; }
    }
}
