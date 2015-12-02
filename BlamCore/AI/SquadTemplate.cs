using System.Collections.Generic;
using Blam.Tags;
using Blam.Common;

namespace Blam.AI
{
    [TagDefinition(Name = "squad_template", Group = "sqtm", Size = 0x10)]
	public class SquadTemplate
	{
		public StringID Name;
		public List<SquadBlock> Squad;

		[TagDefinition(Size = 0x60)]
		public class SquadBlock
		{
			public StringID Name;
			public ushort Difficulty;
			public short Unknown;
			public short MinimumRound;
			public short MaximumRound;
			public short Unknown2;
			public short Unknown3;
			public short Count;
			public short Unknown4;
			public List<Actor> Actors;
			public List<Weapon> Weapons;
			public List<SecondaryWeapon> SecondaryWeapons;
			public List<EquipmentBlock> Equipment;
			public uint Unknown5;
			public TagInstance Vehicle;
			public StringID VehicleVariant;
			public uint Unknown6;

			[TagDefinition(Size = 0x20)]
			public class Actor
			{
				public short Unknown;
				public short Unknown2;
				public short MinimumRound;
				public short MaximumRound;
				public uint Unknown3;
				public TagInstance Character;
				public short Probability;
				public short Unknown4;
			}

			[TagDefinition(Size = 0x20)]
			public class Weapon
			{
				public short Unknown;
				public short Unknown2;
				public short MinimumRound;
				public short MaximumRound;
				public uint Unknown3;
				public TagInstance Weapon2;
				public short Probability;
				public short Unknown4;
			}

			[TagDefinition(Size = 0x20)]
			public class SecondaryWeapon
			{
				public short Unknown;
				public short Unknown2;
				public short MinimumRound;
				public short MaximumRound;
				public uint Unknown3;
				public TagInstance Weapon;
				public short Probability;
				public short Unknown4;
			}

			[TagDefinition(Size = 0x20)]
			public class EquipmentBlock
			{
				public short Unknown;
				public short Unknown2;
				public short MinimumRound;
				public short MaximumRound;
				public uint Unknown3;
				public TagInstance Equipment;
				public short Probability;
				public short Unknown4;
			}
		}
	}
}
