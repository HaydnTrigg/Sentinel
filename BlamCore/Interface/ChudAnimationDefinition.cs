using System.Collections.Generic;
using Blam.Common;
using Blam.Tags;

namespace Blam.Interface
{
    [TagDefinition(Name = "chud_animation_definition", Group = "chad", Size = 0x5C)]
	public class ChudAnimationDefinition
	{
		public ushort Flags;
		public short Unknown;
		public List<PositionBlock> Position;
		public List<RotationBlock> Rotation;
		public List<SizeBlock> Size;
		public List<ColorBlock> Color;
		public List<AlphaBlock> Alpha;
		public List<AlphaUnknownBlock> AlphaUnknown;
		public List<BitmapBlock> Bitmap;
		public int NumberOfFrames;

		[TagDefinition(Size = 0x20)]
		public class PositionBlock
		{
			public List<AnimationBlock> Animation;
			public byte[] Function;

			[TagDefinition(Size = 0x10)]
			public class AnimationBlock
			{
				public int FrameNumber;
				public float PositionX;
				public float PositionY;
				public float PositionZ;
			}
		}

		[TagDefinition(Size = 0x20)]
		public class RotationBlock
		{
			public List<AnimationBlock> Animation;
			public byte[] Function;

			[TagDefinition(Size = 0x10)]
			public class AnimationBlock
			{
				public int FrameNumber;
				public Angle XAngle;
				public Angle YAngle;
				public Angle ZAngle;
			}
		}

		[TagDefinition(Size = 0x20)]
		public class SizeBlock
		{
			public List<AnimationBlock> Animation;
			public byte[] Unknown;

			[TagDefinition(Size = 0xC)]
			public class AnimationBlock
			{
				public int FrameNumber;
				public float StretchX;
				public float StretchY;
			}
		}

		[TagDefinition(Size = 0x20)]
		public class ColorBlock
		{
			public List<AnimationBlock> Animation;
			public byte[] Function;

			[TagDefinition(Size = 0x8)]
			public class AnimationBlock
			{
				public int FrameNumber;
				public uint Unknown;
			}
		}

		[TagDefinition(Size = 0x20)]
		public class AlphaBlock
		{
			public List<AnimationBlock> Animation;
			public byte[] Function;

			[TagDefinition(Size = 0x8)]
			public class AnimationBlock
			{
				public int FrameNumber;
				public float Alpha;
			}
		}

		[TagDefinition(Size = 0x20)]
		public class AlphaUnknownBlock
		{
			public List<AnimationBlock> Animation;
			public byte[] Function;

			[TagDefinition(Size = 0x8)]
			public class AnimationBlock
			{
				public int FrameNumber;
				public float Alpha;
			}
		}

		[TagDefinition(Size = 0x20)]
		public class BitmapBlock
		{
			public List<AnimationBlock> Animation;
			public byte[] Function;

			[TagDefinition(Size = 0x14)]
			public class AnimationBlock
			{
				public int FrameNumber;
				public float Movement1X;
				public float Movement1Y;
				public float Movement2X;
				public float Movement2Y;
			}
		}
	}
}
