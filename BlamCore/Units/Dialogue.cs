using System.Collections.Generic;
using Blam.Tags;
using Blam.Common;

namespace Blam.Units
{
    [TagDefinition(Name = "dialogue", Group = "udlg", Size = 0x30)]
	public class Dialogue
	{
		public TagInstance GlobalDialogueInfo;
		public uint Flags;
		public List<Vocalization> Vocalizations;
		public StringID MissionDialogueDesignator;
		public uint Unknown;
		public uint Unknown2;
		public uint Unknown3;

		[TagDefinition(Size = 0x18)]
		public class Vocalization
		{
			public ushort Flags;
			public short Unknown;
			public StringID Vocalization2;
			public TagInstance Sound;
		}
	}
}
