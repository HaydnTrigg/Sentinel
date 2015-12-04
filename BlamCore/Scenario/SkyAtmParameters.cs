using System.Collections.Generic;
using Blam.Tags;
using Blam.Common;
using Blam.Game;

namespace Blam.Scenario
{
    [TagDefinition(Name = "sky_atm_parameters", Group = "skya", Size = 0x4C, MaxVersion = GameVersion.V10_1_449175_Live)]
	[TagDefinition(Name = "sky_atm_parameters", Group = "skya", Size = 0x54, MinVersion = GameVersion.V11_1_498295_Live)]
	public class SkyAtmParameters
	{
		public int Unknown;
		public TagInstance FogBitmap;
		public float Unknown2;
		public float Unknown3;
		public float Unknown4;
		public float Unknown5;
		public float Unknown6;
		public float Unknown7;
		public float Unknown8;
		public int Unknown9;
		[MinVersion(GameVersion.V11_1_498295_Live)] public float Unknown10;
		[MinVersion(GameVersion.V11_1_498295_Live)] public int Unknown11;
		public List<AtmosphereProperty> AtmosphereProperties;
		public List<UnderwaterBlock> Underwater;

		[TagDefinition(Size = 0xA4)]
		public class AtmosphereProperty
		{
			public short Unknown;
			public short Unknown2;
			public StringID Name;
			public float LightSourceY;
			public float LightSourceX;
			public float FogColorR;
			public float FogColorG;
			public float FogColorB;
			public float Brightness;
			public float FogGradientThreshold;
			public float LightIntensity;
			public float SkyInvisiblilityThroughFog;
			public float Unknown3;
			public float Unknown4;
			public float LightSourceSpread;
			public uint Unknown5;
			public float FogIntensity;
			public float Unknown6;
			public float TintCyan;
			public float TintMagenta;
			public float TintYellow;
			public float FogIntensityCyan;
			public float FogIntensityMagenta;
			public float FogIntensityYellow;
			public float BackgroundColorRed;
			public float BackgroundColorGreen;
			public float BackgroundColorBlue;
			public float TintRed;
			public float Tint2Green;
			public float Tint2Blue;
			public float FogIntensity2;
			public float StartDistance;
			public float EndDistance;
            public Vector3 FogVelocity;
			public TagInstance WeatherEffect;
			public uint Unknown7;
			public uint Unknown8;
		}

		[TagDefinition(Size = 0x14)]
		public class UnderwaterBlock
		{
			public StringID Name;
			public float ColorA;
			public float ColorR;
			public float ColorG;
			public float ColorB;
		}
	}
}
