using System.Collections.Generic;
using Blam.Tags;

namespace Blam.Interface
{
    [TagDefinition(Name = "gui_widget_sprite_animation_definition", Group = "wspr", Size = 0x2C)]
	public class GuiWidgetSpriteAnimationDefinition
	{
		public uint AnimationFlags;
		public List<AnimationDefinitionBlock> AnimationDefinition;
		public byte[] Data;
		public uint Unknown;
		public uint Unknown2;

		[TagDefinition(Size = 0x14)]
		public class AnimationDefinitionBlock
		{
			public uint Frame;
			public short SpriteIndex;
			public short SpriteIndex2;
			public uint Unknown;
			public uint Unknown2;
			public uint Unknown3;
		}
	}
}
