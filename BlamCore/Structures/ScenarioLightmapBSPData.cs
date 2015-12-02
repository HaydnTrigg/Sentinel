using System.Collections.Generic;
using Blam.Models;
using Blam.Tags;
using Blam.Game;

namespace Blam.Structures
{
    [TagDefinition(Name = "scenario_lightmap_bsp_data", Group = "Lbsp", Size = 0x1E4, MaxVersion = GameVersion.V10_1_449175_Live)]
	[TagDefinition(Name = "scenario_lightmap_bsp_data", Group = "Lbsp", Size = 0x1E8, MinVersion = GameVersion.V11_1_498295_Live)]
	public class ScenarioLightmapBSPData
	{
		public short Unknown;
		public short BspIndex;
		public int StructureChecksum;
		public float Shadows;
		public uint Unknown2;
		public uint Unknown3;
		public uint Unknown4;
		public uint Unknown5;
		public uint Unknown6;
		public float Midtones;
		public uint Unknown7;
		public uint Unknown8;
		public uint Unknown9;
		public uint Unknown10;
		public uint Unknown11;
		public float Highlights;
		public uint Unknown12;
		public uint Unknown13;
		public uint Unknown14;
		public uint Unknown15;
		public uint Unknown16;
		public float TopDownWhites;
		public uint Unknown17;
		public uint Unknown18;
		public uint Unknown19;
		public uint Unknown20;
		public uint Unknown21;
		public float TopDownBlacks;
		public uint Unknown22;
		public uint Unknown23;
		public uint Unknown24;
		public uint Unknown25;
		public uint Unknown26;
		public uint Unknown27;
		public uint Unknown28;
		public uint Unknown29;
		public uint Unknown30;
		public uint Unknown31;
		public uint Unknown32;
		public uint Unknown33;
		public uint Unknown34;
		public uint Unknown35;
		public uint Unknown36;
		public uint Unknown37;
		public uint Unknown38;
		public uint Unknown39;
		public uint Unknown40;
		public uint Unknown41;
		public uint Unknown42;
		public uint Unknown43;
		public uint Unknown44;
		public uint Unknown45;
		public uint Unknown46;
		public uint Unknown47;
		public uint Unknown48;
		public uint Unknown49;
		public uint Unknown50;
		public TagInstance PrimaryMap;
		public TagInstance IntensityMap;
		public List<InstancedMesh> InstancedMeshes;
		public List<UnknownBlock> Unknown51;
		public List<InstancedGeometryBlock> InstancedGeometry;
		public List<UnknownBBlock> UnknownB;
		public GeometryReference Geometry;
		public uint Unknown61;
		public uint Unknown62;
		public uint Unknown63;
		public List<UnknownBlock4> Unknown64;
		public List<UnknownBlock5> Unknown65;
		public uint Unknown66;
		public uint Unknown67;
		public uint Unknown68;
		[MinVersion(GameVersion.V11_1_498295_Live)] public uint Unknown69; // TODO: Version number

		[TagDefinition(Size = 0x10)]
		public class InstancedMesh
		{
			public uint Unknown;
			public uint Unknown2;
			public uint Unknown3;
			public int UnknownIndex;
		}

		[TagDefinition(Size = 0x4)]
		public class UnknownBlock
		{
			public short Unknown;
			public short Unknown2;
		}

		[TagDefinition(Size = 0x8)]
		public class InstancedGeometryBlock
		{
			public short Unknown;
			public short InstancedMeshIndex;
			public short UnknownBIndex;
			public short Unknown2;
		}

		[TagDefinition(Size = 0x48)]
		public class UnknownBBlock
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
		}

		[TagDefinition(Size = 0x50)]
		public class UnknownBlock4
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
		public class UnknownBlock5
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
