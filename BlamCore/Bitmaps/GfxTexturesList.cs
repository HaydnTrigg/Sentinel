using System.Collections.Generic;
using Blam.Tags;

namespace Blam.Bitmaps
{
    [TagDefinition(Name = "gfx_textures_list", Group = "gfxt", Size = 0x10)]
	public class GfxTexturesList
	{
		public List<Texture> Textures;
		public uint Unknown;

		[TagDefinition(Size = 0x110)]
		public class Texture
		{
			[TagField(Length = 256)] public string FileName;
			public TagInstance Bitmap;
		}
	}
}
