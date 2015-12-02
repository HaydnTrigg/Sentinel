using System.Collections.Generic;
using Blam.Tags;
using Blam.Common;

namespace Blam.Rasterizer
{
    [TagDefinition(Name = "sound_effect_template", Group = "<fx>", Size = 0x20)]
	public class SoundEffectTemplate
	{
		public float TemplateCollectionBlock;
		public float TemplateCollectionBlock2;
		public float TemplateCollectionBlock3;
		public int InputEffectName;
		public List<AdditionalSoundInput> AdditionalSoundInputs;
		public uint Unknown;

		[TagDefinition(Size = 0x1C)]
		public class AdditionalSoundInput
		{
			public StringID DspEffect;
			public byte[] LowFrequencySoundFunction;
			public float TimePeriod;
		}
	}
}
