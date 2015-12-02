using System.Collections.Generic;
using Blam.Common;
using Blam.Tags;

namespace Blam.Interface
{
    [TagDefinition(Name = "gui_skin_definition", Group = "skn3", Size = 0x28)]
	public class GuiSkinDefinition
	{
		public uint Unknown;
		public List<TextWidget> TextWidgets;
		public List<BitmapWidget> BitmapWidgets;
		public List<ModelWidget> ModelWidgets;

		[TagDefinition(Size = 0x4C)]
		public class TextWidget
		{
			public TagInstance Parent;
			public uint Flags;
			public StringID Name;
			public short Unknown;
			public short Layer;
			public short WidescreenYBoundsMin;
			public short WidescreenXBoundsMin;
			public short WidescreenYBoundsMax;
			public short WidescreenXBoundsMax;
			public short StandardYBoundsMin;
			public short StandardXBoundsMin;
			public short StandardYBoundsMax;
			public short StandardXBoundsMax;
			public TagInstance Animation;
			public StringID DataSourceName;
			public StringID TextString;
			public StringID TextColor;
			public short TextFont;
			public short Unknown2;
		}

		[TagDefinition(Size = 0x6C)]
		public class BitmapWidget
		{
			public TagInstance Parent;
			public uint Flags;
			public StringID Name;
			public short Unknown;
			public short Layer;
			public short WidescreenYBoundsMin;
			public short WidescreenXBoundsMin;
			public short WidescreenYBoundsMax;
			public short WidescreenXBoundsMax;
			public short StandardYBoundsMin;
			public short StandardXBoundsMin;
			public short StandardYBoundsMax;
			public short StandardXBoundsMax;
			public TagInstance Animation;
			public TagInstance Bitmap;
			public TagInstance Unknown2;
			public BlendMethodValue BlendMethod;
			public short Unknown3;
			public short SpriteIndex;
			public short Unknown4;
			public StringID DataSourceName;
			public StringID SpriteDataSourceName;

			public enum BlendMethodValue : short
			{
				Standard,
				Unknown,
				Unknown2,
				Alpha,
				Overlay,
				Unknown3,
				LighterColor,
				Unknown4,
				Unknown5,
				Unknown6,
				InvertedAlpha,
				Unknown7,
				Unknown8,
				Unknown9,
			}
		}

		[TagDefinition(Size = 0x94)]
		public class ModelWidget
		{
			public TagInstance Parent;
			public uint Flags;
			public StringID Name;
			public short Unknown;
			public short Unknown2;
			public short WidescreenYBoundsMin;
			public short WidescreenXBoundsMin;
			public short WidescreenYBoundsMax;
			public short WidescreenXBoundsMax;
			public short StandardYBoundsMin;
			public short StandardXBoundsMin;
			public short StandardYBoundsMax;
			public short StandardXBoundsMax;
			public TagInstance Animation;
			public List<UnknownBlock> Unknown3;
			public uint Unknown4;
			public uint Unknown5;
			public uint Unknown6;
			public uint Unknown7;
			public uint Unknown8;
			public uint Unknown9;
			public uint Unknown10;
			public List<UnknownBlock2> Unknown11;
			public short Unknown12;
			public short Unknown13;
			public short Unknown14;
			public short Unknown15;
			public short Unknown16;
			public short Unknown17;
			public short Unknown18;
			public short Unknown19;
			public short Unknown20;
			public short Unknown21;
			public short Unknown22;
			public short Unknown23;
			public List<UnknownBlock3> Unknown24;

			[TagDefinition(Size = 0xA0)]
			public class UnknownBlock
			{
				public StringID Biped;
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
				public uint Unknown22;
				public uint Unknown23;
				public uint Unknown24;
				public List<UnknownBlock2> Unknown25;
				public uint Unknown26;
				public uint Unknown27;
				public Angle Unknown28;
				public uint Unknown29;
				public Angle Unknown30;
				public uint Unknown31;
				public uint Unknown32;
				public TagInstance Unknown33;
				public uint Unknown34;

				[TagDefinition(Size = 0x14)]
				public class UnknownBlock2
				{
					public byte[] Unknown;
				}
			}

			[TagDefinition(Size = 0x14)]
			public class UnknownBlock2
			{
				public byte[] Unknown;
			}

			[TagDefinition(Size = 0x14)]
			public class UnknownBlock3
			{
				public StringID Unknown;
				public uint Unknown2;
				public uint Unknown3;
				public uint Unknown4;
				public uint Unknown5;
			}
		}
	}
}
