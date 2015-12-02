using System.Collections.Generic;
using Blam.Tags;
using Blam.Common;

namespace Blam.Effects
{
    [TagDefinition(Name = "area_screen_effect", Group = "sefc", Size = 0xC)]
	public class AreaScreenEffect
	{
		public List<ScreenEffectBlock> ScreenEffect;

		[TagDefinition(Size = 0x9C)]
		public class ScreenEffectBlock
		{
			public StringID Name;
			public short Unknown;
			public short Unknown2;
			public uint Unknown3;
			public byte[] Function;
			public float Duration;
			public byte[] Function2;
			public byte[] Function3;
			public float LightIntensity;
			public float PrimaryHue;
			public float SecondaryHue;
			public float Saturation;
			public float ColorMuting;
			public float Brightness;
			public float Darkness;
			public float ShadowBrightness;
			public float TintR;
			public float TintG;
			public float TintB;
			public float ToneR;
			public float ToneG;
			public float ToneB;
			public float Tracing;
			public uint Unknown4;
			public TagInstance ScreenShader;
		}
	}
}
