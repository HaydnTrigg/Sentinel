using System.Collections.Generic;
using Blam.Tags;

namespace Blam.Effects
{
    [TagDefinition(Name = "effect_globals", Group = "effg", Size = 0x10)]
	public class EffectGlobals
	{
		public List<UnknownBlock> Unknown;
		public uint Unknown2;

		[TagDefinition(Size = 0x14)]
		public class UnknownBlock
		{
			public uint Unknown;
			public uint Unknown2;
			public List<UnknownBlock2> Unknown3;

			[TagDefinition(Size = 0x10)]
			public class UnknownBlock2
			{
				public uint Unknown;
				public uint Unknown2;
				public uint Unknown3;
				public uint Unknown4;
			}
		}
	}
}
