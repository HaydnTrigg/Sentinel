using System.Collections.Generic;
using Blam.Tags;
using Blam.Common;

namespace Blam.AI
{
    [TagDefinition(Name = "ai_dialogue_globals", Group = "adlg", Size = 0x5C)]
	public class AiDialogueGlobals
	{
		public uint Unknown;
		public uint Unknown2;
		public uint Unknown3;
		public uint Unknown4;
		public uint Unknown5;
		public List<Vocalization> Vocalizations;
		public List<Pattern> Patterns;
		public uint Unknown6;
		public uint Unknown7;
		public uint Unknown8;
		public List<DialogDatum> DialogData;
		public List<InvoluntaryDatum> InvoluntaryData;
		public uint Unknown9;
		public uint Unknown10;
		public uint Unknown11;

		[TagDefinition(Size = 0x60)]
		public class Vocalization
		{
			public StringID Vocalization2;
			public short ParentIndex;
			public short Priority;
			public uint Flags;
			public short GlanceBehavior;
			public short GlanceRecipient;
			public PerceptionTypeValue PerceptionType;
			public short MaxCombatStatus;
			public short AnimationImpulse;
			public short OverlapPriority;
			public float SoundRepetitionDelay;
			public float AllowableQueueDelay;
			public float PreVocalizationDelay;
			public float NotificationDelay;
			public float PostVocalizationDelay;
			public float RepeatDelay;
			public float Weight;
			public float SpeakerFreezeTime;
			public float ListenerFreezeTime;
			public short SpeakerEmotion;
			public short ListenerEmotion;
			public float SkipFraction1;
			public float SkipFraction2;
			public float SkipFraction3;
			public float SkipFraction4;
			public StringID SampleLine;
			public List<Respons> Responses;

			public enum PerceptionTypeValue : short
			{
				None,
				Speaker,
				Listener,
			}

			[TagDefinition(Size = 0xC)]
			public class Respons
			{
				public StringID VocalizationName;
				public ushort Flags;
				public short VocalizationIndex;
				public short ResponseType;
				public short ImportDialogueIndex;
			}
		}

		[TagDefinition(Size = 0x34)]
		public class Pattern
		{
			public short DialogueType;
			public short VocalizationsIndex;
			public StringID VocalizationName;
			public short SpeakerType;
			public ushort Flags;
			public short Hostility;
			public ushort Unknown;
			public short Unknown2;
			public short CauseType;
			public StringID CauseAiTypeName;
			public uint Unknown3;
			public short Unknown4;
			public short Unknown5;
			public short Attitude;
			public short Unknown6;
			public uint Conditions;
			public short SpacialRelationship;
			public short DamageType;
			public short Unknown7;
			public short SubjectType;
			public StringID SubjectAiTypeName;
		}

		[TagDefinition(Size = 0x4)]
		public class DialogDatum
		{
			public short StartIndex;
			public short Length;
		}

		[TagDefinition(Size = 0x4)]
		public class InvoluntaryDatum
		{
			public short InvoluntaryVocalizationIndex;
			public short Unknown;
		}
	}
}
