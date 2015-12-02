using System.Collections.Generic;
using Blam.Common;
using Blam.Tags;

namespace Blam.Rasterizer
{
    [TagDefinition(Name = "podium_settings", Group = "pdm!", Size = 0x3C)]
	public class PodiumSettings
	{
		public uint Unknown;
		public uint Unknown2;
		public uint Unknown3;
		public Angle Unknown4;
		public Angle Unknown5;
		public uint Unknown6;
		public Angle Unknown7;
		public int Unknown8;
		public TagInstance Unknown9;
		public List<UnknownBlock> Unknown10;

		[TagDefinition(Size = 0x2C)]
		public class UnknownBlock
		{
			public uint Unknown;
			public uint Unknown2;
			public uint Unknown3;
			public Angle Unknown4;
			public uint Unknown5;
			public uint Unknown6;
			public int Unknown7;
			public TagInstance Effect;
		}
	}
}