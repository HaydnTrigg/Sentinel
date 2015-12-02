using System.Collections.Generic;
using Blam.Common;
using Blam.Tags;

namespace Blam.Rasterizer
{
    [TagDefinition(Name = "texture_render_list", Group = "trdf", Size = 0x48)]
	public class TextureRenderList
	{
		public List<Bitmap> Bitmaps;
		public List<Light> Lights;
		public List<Bink> Binks;
		public List<Mannequin> Mannequins;
		public List<Weapon> Weapons;
		public uint Unknown;
		public uint Unknown2;
		public uint Unknown3;

		[TagDefinition(Size = 0x110)]
		public class Bitmap
		{
			public int Index;
			[TagField(Length = 256)] public string Filename;
			public int Unknown;
			public int Width;
			public int Height;
		}

		[TagDefinition(Size = 0x1C)]
		public class Light
		{
			public List<UnknownBlock> Unknown;
			public float Unknown2;
			public float Unknown3;
			public float Unknown4;
			public float Unknown5;

			[TagDefinition(Size = 0x28)]
			public class UnknownBlock
			{
				public float Unknown;
				public float Unknown2;
				public float Unknown3;
				public Angle Unknown4;
				public Angle Unknown5;
				public Angle Unknown6;
				public TagInstance Light;
			}
		}

		[TagDefinition(Size = 0x30)]
		public class Bink
		{
			[TagField(Length = 32)] public string Name;
			public TagInstance Bink2;
		}

		[TagDefinition(Size = 0x4C)]
		public class Mannequin
		{
			public int Unknown;
			public TagInstance Biped;
			public int Unknown2;
			public float Unknown3;
			public float Unknown4;
			public float Unknown5;
			public float Unknown6;
			public float Unknown7;
			public float Unknown8;
			public float Unknown9;
			public float Unknown10;
			public float Unknown11;
			public float Unknown12;
			public float Unknown13;
			public float Unknown14;
			public float Unknown15;
		}

		[TagDefinition(Size = 0x64)]
		public class Weapon
		{
			[TagField(Length = 32)] public string Name;
			public TagInstance Weapon2;
			public float Unknown;
			public float Unknown2;
			public float Unknown3;
			public float Unknown4;
			public float Unknown5;
			public float Unknown6;
			public float Unknown7;
			public float Unknown8;
			public float Unknown9;
			public float Unknown10;
			public float Unknown11;
			public float Unknown12;
			public float Unknown13;
		}
	}
}
