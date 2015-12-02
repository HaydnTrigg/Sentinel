using System.Collections.Generic;
using Blam.Tags;
using Blam.Common;

namespace Blam.Rasterizer
{
    [TagDefinition(Name = "achievements", Group = "achi", Size = 0x18)]
	public class Achievements
	{
		public List<AchievementInformationBlock> AchievementInformation;
		public uint Unknown;
		public uint Unknown2;
		public uint Unknown3;

		[TagDefinition(Size = 0x18)]
		public class AchievementInformationBlock
		{
			public int Unknown;
			public int Unknown2;
			public StringID LevelName;
			public int Unknown3;
			public int Unknown4;
			public int Unknown5;
		}
	}
}
