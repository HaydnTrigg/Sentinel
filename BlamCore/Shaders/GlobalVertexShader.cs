using System.Collections.Generic;
using Blam.Tags;
using Blam.Common;

namespace Blam.Shaders
{
    [TagDefinition(Name = "global_vertex_shader", Group = "glvs", Size = 0x1C)]
	public class GlobalVertexShader
	{
		public List<VertexTypeShaders> VertexTypes;
		public uint Unknown2;
		public List<VertexShader> VertexShaders;

		[TagDefinition(Size = 0xC)]
		public class VertexTypeShaders
		{
			public List<DrawMode> DrawModes;

			[TagDefinition(Size = 0x10)]
			public class DrawMode
			{
				public uint Unknown;
				public uint Unknown2;
				public uint Unknown3;
				public int ShaderIndex;
			}
		}

		[TagDefinition(Size = 0x50)]
		public class VertexShader
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
			public uint VertexShader2;

			[TagDefinition(Size = 0x8)]
			public class UnknownBlock
			{
				public StringID Unknown;
				public uint Unknown2;
			}
		}
	}
}
