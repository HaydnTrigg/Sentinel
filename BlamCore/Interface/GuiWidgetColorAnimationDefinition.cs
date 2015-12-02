using System.Collections.Generic;
using Blam.Tags;

namespace Blam.Interface
{
    [TagDefinition(Name = "gui_widget_color_animation_definition", Group = "wclr", Size = 0x24)]
	public class GuiWidgetColorAnimationDefinition
	{
		public uint AnimationFlags;
		public List<AnimationDefinitionBlock> AnimationDefinition;
		public byte[] Data;

		[TagDefinition(Size = 0x20)]
		public class AnimationDefinitionBlock
		{
			public uint Frame;
			public float ColorA;
			public float ColorR;
			public float ColorG;
			public float ColorB;
			public uint Unknown;
			public uint Unknown2;
			public uint Unknown3;
		}
	}
}
