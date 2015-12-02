using System.Collections.Generic;
using Blam.Tags;

namespace Blam.Units
{
    [TagDefinition(Name = "armor_sounds", Group = "arms", Size = 0x10)]
	public class ArmorSounds
	{
		public List<ArmorSound> ArmorSounds2;
		public uint Unknown;

		[TagDefinition(Size = 0x24)]
		public class ArmorSound
		{
			public List<UnknownBlock> Unknown;
			public List<UnknownBlock2> Unknown2;
			public List<UnknownBlock3> Unknown3;

			[TagDefinition(Size = 0x10)]
			public class UnknownBlock
			{
				public TagInstance Unknown;
			}

			[TagDefinition(Size = 0x10)]
			public class UnknownBlock2
			{
				public TagInstance Unknown;
			}

			[TagDefinition(Size = 0x10)]
			public class UnknownBlock3
			{
				public TagInstance Unknown;
			}
		}
	}
}
