using System.Collections.Generic;
using Blam.Tags;

namespace Blam.Bitmaps
{
    [TagDefinition(Name = "color_table", Group = "colo", Size = 0x10)]
	public class ColorTable
	{
		public List<ColorTableBlock> ColorTable2;
		public uint Unknown;

		[TagDefinition(Size = 0x30)]
		public class ColorTableBlock
		{
			[TagField(Length = 32)] public string String;
			public float ColorA;
			public float ColorR;
			public float ColorG;
			public float ColorB;
		}
	}
}
