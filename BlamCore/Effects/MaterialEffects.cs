using System.Collections.Generic;
using Blam.Tags;
using Blam.Common;

namespace Blam.Effects
{
    [TagDefinition(Name = "material_effects", Group = "foot", Size = 0xC)]
	public class MaterialEffects
	{
		public List<Effect> Effects;

		[TagDefinition(Size = 0x24)]
		public class Effect
		{
			public List<OldMaterial> OldMaterials;
			public List<Sound> Sounds;
			public List<Effect2> Effects;

			[TagDefinition(Size = 0x2C)]
			public class OldMaterial
			{
				public TagInstance Effect;
				public TagInstance Sound;
				public StringID MaterialName;
				public short GlobalMaterialIndex;
				public SweetenerModeValue SweetenerMode;
				public sbyte Unknown;
				public uint Unknown2;

				public enum SweetenerModeValue : sbyte
				{
					SweetenerDefault,
					SweetenerEnabled,
					SweetenerDisabled,
				}
			}

			[TagDefinition(Size = 0x2C)]
			public class Sound
			{
				public TagInstance Tag;
				public TagInstance SecondaryTag;
				public StringID MaterialName;
				public short GlobalMaterialIndex;
				public SweetenerModeValue SweetenerMode;
				public sbyte Unknown;
				public uint Unknown2;

				public enum SweetenerModeValue : sbyte
				{
					SweetenerDefault,
					SweetenerEnabled,
					SweetenerDisabled,
				}
			}

			[TagDefinition(Size = 0x2C)]
			public class Effect2
			{
				public TagInstance Tag;
				public TagInstance SecondaryTag;
				public StringID MaterialName;
				public short GlobalMaterialIndex;
				public SweetenerModeValue SweetenerMode;
				public sbyte Unknown;
				public uint Unknown2;

				public enum SweetenerModeValue : sbyte
				{
					SweetenerDefault,
					SweetenerEnabled,
					SweetenerDisabled,
				}
			}
		}
	}
}
