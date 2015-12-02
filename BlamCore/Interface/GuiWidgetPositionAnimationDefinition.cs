using System.Collections.Generic;
using Blam.Tags;

namespace Blam.Interface
{
    [TagDefinition(Name = "gui_widget_position_animation_definition", Group = "wpos", Size = 0x24)]
	public class GuiWidgetPositionAnimationDefinition
	{
		public uint AnimationFlags;
		public List<AnimationDefinitionBlock> AnimationDefinition;
		public byte[] Data;

		[TagDefinition(Size = 0x1C)]
		public class AnimationDefinitionBlock
		{
			public uint Frame;
			public float XPosition;
			public float YPosition;
			public float ZPosition;
			public uint Unknown;
			public uint Unknown2;
			public uint Unknown3;
		}
	}
}
