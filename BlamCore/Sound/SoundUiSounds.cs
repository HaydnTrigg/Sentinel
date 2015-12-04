using System.Collections.Generic;
using Blam.Tags;

namespace Blam.Sound
{
    [TagDefinition(Name = "sound_ui_sounds", Group = "sus!", Size = 0x10)]
	public class SoundUiSounds
	{
		public List<UiSound> UiSounds;
		public uint Unknown;

		[TagDefinition(Size = 0x10)]
		public class UiSound
		{
			public TagInstance Sound;
		}
	}
}
