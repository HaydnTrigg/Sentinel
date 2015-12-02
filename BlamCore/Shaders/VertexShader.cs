using System.Collections.Generic;
using Blam.Tags;
using Blam.Common;

namespace Blam.Shaders
{
    [TagDefinition(Name = "vertex_shader", Group = "vtsh", Size = 0x20)]
	public class VertexShader
	{
		public uint Unknown;
		public List<UnknownBlock> Unknown2;
		public uint Unknown3;
		public List<VertexShader2> VertexShaders;

		[TagDefinition(Size = 0xC)]
		public class UnknownBlock
		{
			public List<DrawMode> DrawModes;

			[TagDefinition(Size = 0x2)]
			public class DrawMode
			{
				public short Unknown;
			}
		}

		[TagDefinition(Size = 0x50)]
		public class VertexShader2
		{
			public byte[] Unknown;
			public byte[] Unknown2;
			public uint Unknown3;
			public uint Unknown4;
			public uint Unknown5;
			public uint Unknown6;
			public List<UnknownBlock> Unknown7;
			public uint Unknown8;
			public uint Unknown9;
			public uint VertexShader;

			[TagDefinition(Size = 0x8)]
			public class UnknownBlock
			{
				public StringID Unknown;
				public uint Unknown2;
			}
		}
	}
}
