using System.Collections.Generic;
using Blam.Tags;
using Blam.Common;

namespace Blam.Structures
{
    [TagDefinition(Name = "scenario_lightmap", Group = "sLdT", Size = 0x50)]
	public class ScenarioLightmap
	{
		public uint Unknown;
		public List<LightmapDataReference> LightmapDataReferences;
		public List<UnknownBlock> Unknown2;
		public List<Airprobe> Airprobes;
		public List<UnknownBlock2> Unknown3;
		public List<UnknownBlock3> Unknown4;
		public uint Unknown5;
		public uint Unknown6;
		public uint Unknown7;
		public uint Unknown8;

		[TagDefinition(Size = 0x10)]
		public class LightmapDataReference
		{
			public TagInstance LightmapData;
		}

		[TagDefinition(Size = 0x10)]
		public class UnknownBlock
		{
			public TagInstance Unknown;
		}

		[TagDefinition(Size = 0x5C)]
		public class Airprobe
		{
			public float Unknown;
			public float Unknown2;
			public float Unknown3;
			public StringID Unknown4;
			public ushort Unknown5;
			public short Unknown6;
			public uint Unknown7;
			public uint Unknown8;
			public uint Unknown9;
			public uint Unknown10;
			public uint Unknown11;
			public uint Unknown12;
			public uint Unknown13;
			public uint Unknown14;
			public uint Unknown15;
			public uint Unknown16;
			public uint Unknown17;
			public uint Unknown18;
			public uint Unknown19;
			public uint Unknown20;
			public uint Unknown21;
			public uint Unknown22;
			public uint Unknown23;
			public uint Unknown24;
		}

		[TagDefinition(Size = 0x50)]
		public class UnknownBlock2
		{
			public uint Unknown;
			public uint Unknown2;
			public uint Unknown3;
			public uint Unknown4;
			public uint Unknown5;
			public uint Unknown6;
			public uint Unknown7;
			public uint Unknown8;
			public uint Unknown9;
			public uint Unknown10;
			public uint Unknown11;
			public uint Unknown12;
			public uint Unknown13;
			public uint Unknown14;
			public uint Unknown15;
			public uint Unknown16;
			public uint Unknown17;
			public uint Unknown18;
			public uint Unknown19;
			public uint Unknown20;
		}

		[TagDefinition(Size = 0x2C)]
		public class UnknownBlock3
		{
			public uint Unknown;
			public uint Unknown2;
			public uint Unknown3;
			public uint Unknown4;
			public uint Unknown5;
			public uint Unknown6;
			public uint Unknown7;
			public uint Unknown8;
			public List<UnknownBlock> Unknown9;

			[TagDefinition(Size = 0x54)]
			public class UnknownBlock
			{
				public uint Unknown;
				public uint Unknown2;
				public uint Unknown3;
				public uint Unknown4;
				public uint Unknown5;
				public uint Unknown6;
				public uint Unknown7;
				public uint Unknown8;
				public uint Unknown9;
				public uint Unknown10;
				public uint Unknown11;
				public uint Unknown12;
				public uint Unknown13;
				public uint Unknown14;
				public uint Unknown15;
				public uint Unknown16;
				public uint Unknown17;
				public uint Unknown18;
				public uint Unknown19;
				public uint Unknown20;
				public uint Unknown21;
			}
		}
	}
}