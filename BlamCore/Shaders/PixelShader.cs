using System.Collections.Generic;
using Blam.Tags;
using Blam.Common;

namespace Blam.Shaders
{
    [TagDefinition(Name = "pixel_shader", Group = "pixl", Size = 0x20)]
	public class PixelShader
	{
		public uint Unknown;
		public List<DrawMode> DrawModes;
		public uint Unknown3;
		public List<PixelShader2> PixelShaders;

		[TagDefinition(Size = 0x2)]
		public class DrawMode
		{
			public byte Index;
			public byte Count;
		}

		[TagDefinition(Size = 0x50)]
		public class PixelShader2
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
			public uint PixelShader;

			[TagDefinition(Size = 0x8)]
			public class UnknownBlock
			{
				public StringID Unknown;
				public uint Unknown2;
			}
		}
	}
}
