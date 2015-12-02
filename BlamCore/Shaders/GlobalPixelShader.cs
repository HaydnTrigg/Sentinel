using System.Collections.Generic;
using Blam.Tags;
using Blam.Common;

namespace Blam.Shaders
{
    [TagDefinition(Name = "global_pixel_shader", Group = "glps", Size = 0x1C)]
	public class GlobalPixelShader
	{
		public List<DrawMode> DrawModes;
		public uint Unknown2;
		public List<PixelShader> PixelShaders;

		[TagDefinition(Size = 0x10)]
		public class DrawMode
		{
			public List<UnknownBlock2> Unknown;
			public uint Unknown2;

			[TagDefinition(Size = 0x10)]
			public class UnknownBlock2
			{
				public uint Unknown;
				public List<UnknownBlock> Unknown2;

				[TagDefinition(Size = 0x4)]
				public class UnknownBlock
				{
					public uint Unknown;
				}
			}
		}

		[TagDefinition(Size = 0x50)]
		public class PixelShader
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
			public uint PixelShader2;

			[TagDefinition(Size = 0x8)]
			public class UnknownBlock
			{
				public StringID Unknown;
				public uint Unknown2;
			}
		}
	}
}
