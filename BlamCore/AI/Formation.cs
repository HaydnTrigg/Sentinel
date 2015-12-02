using System.Collections.Generic;
using Blam.Common;
using Blam.Tags;

namespace Blam.AI
{
    [TagDefinition(Name = "formation", Group = "form", Size = 0x18)]
	public class Formation
	{
		public StringID Name;
		public List<UnknownBlock> Unknown;
		public uint Unknown2;
		public uint Unknown3;

		[TagDefinition(Size = 0x24)]
		public class UnknownBlock
		{
			public short Unknown;
			public short Unknown2;
			public short Unknown3;
			public short Unknown4;
			public float Unknown5;
			public float Unknown6;
			public float Unknown7;
			public float Unknown8;
			public List<UnknownBlock2> Unknown9;

			[TagDefinition(Size = 0x8)]
			public class UnknownBlock2
			{
				public Angle Unknown;
				public float Unknown2;
			}
		}
	}
}
