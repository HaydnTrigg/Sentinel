using System.Collections.Generic;
using Blam.Tags;

namespace Blam.Interface
{
    [TagDefinition(Name = "gui_widget_texture_coordinate_animation_definition", Group = "wtuv", Size = 0x2C)]
	public class GuiWidgetTextureCoordinateAnimationDefinition
	{
		public uint AnimationFlags;
		public List<AnimationDefinitionBlock> AnimationDefinition;
		public byte[] Data;
		public uint Unknown;
		public uint Unknown2;

		[TagDefinition(Size = 0x18)]
		public class AnimationDefinitionBlock
		{
			public uint Frame;
			public float CoordinateX;
			public float CoordinateY;
			public uint Unknown;
			public uint Unknown2;
			public uint Unknown3;
		}
	}
}
