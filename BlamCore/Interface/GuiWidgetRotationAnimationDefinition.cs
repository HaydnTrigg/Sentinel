using System.Collections.Generic;
using Blam.Tags;
using Blam.Common;

namespace Blam.Interface
{
    [TagDefinition(Name = "gui_widget_rotation_animation_definition", Group = "wrot", Size = 0x2C)]
	public class GuiWidgetRotationAnimationDefinition
	{
		public uint AnimationFlags;
		public List<AnimationDefinitionBlock> AnimationDefinition;
		public byte[] Date;
		public uint Unknown;
		public uint Unknown2;

		[TagDefinition(Size = 0x20)]
		public class AnimationDefinitionBlock
		{
			public uint Frame;
			public AnchorValue Anchor;
			public short Unknown;
			public Vector2 CustomAnchor;
			public float RotationAmount;
			public uint Unknown2;
			public uint Unknown3;
			public uint Unknown4;

			public enum AnchorValue : short
			{
				Custom,
				Center,
				TopCenter,
				BottomCenter,
				LeftCenter,
				RightCenter,
				TopLeft,
				TopRight,
				BottomRight,
				BottomLeft,
			}
		}
	}
}
