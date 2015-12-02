using System.Collections.Generic;
using Blam.Tags;

namespace Blam.Cache
{
    [TagDefinition(Name = "cache_file_global_tags", Group = "cfgt", Size = 0x10)]
	public class CacheFileGlobalTags
	{
		public List<TagInstance> GlobalTags;
		public uint Unknown;
	}
}
