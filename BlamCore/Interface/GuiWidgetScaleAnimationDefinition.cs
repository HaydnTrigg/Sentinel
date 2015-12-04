using System.Collections.Generic;
using Blam.Tags;
using Blam.Common;

namespace Blam.Interface
{
    [TagDefinition(Name = "gui_widget_scale_animation_definition", Group = "wscl", Size = 0x24)]
	public class GuiWidgetScaleAnimationDefinition
	{
		public uint AnimationFlags;
		public List<AnimationDefinitionBlock> AnimationDefinition;
		public byte[] Data;

		[TagDefinition(Size = 0x24)]
		public class AnimationDefinitionBlock
		{
			public uint Frame;
			public AnchorValue Anchor;
			public short Unknown;
            public Vector2 CustomAnchor;
			public Vector2 Scale;
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
