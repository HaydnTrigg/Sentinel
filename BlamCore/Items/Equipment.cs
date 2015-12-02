using System.Collections.Generic;
using Blam.Common;
using Blam.Tags;

namespace Blam.Items
{
    [TagDefinition(Name = "equipment", Group = "eqip", Size = 0x1B0)]
	public class Equipment : Item
	{
		public float UseDuration;
		public uint Unknown8;
		public short NumberOfUses;
		public ushort Flags3;
		public uint Unknown9;
		public uint Unknown10;
		public uint Unknown11;
		public List<EquipmentCameraBlock> EquipmentCamera;
		public List<HealthPackBlock> HealthPack;
		public List<PowerupBlock> Powerup;
		public List<ObjectCreationBlock> ObjectCreation;
		public List<DestructionBlock> Destruction;
		public List<RadarManipulationBlock> RadarManipulation;
		public uint Unknown12;
		public uint Unknown13;
		public uint Unknown14;
		public List<InvisibilityBlock> Invisibility;
		public List<InvincibilityBlock> Invincibility;
		public List<RegeneratorBlock> Regenerator;
		public uint Unknown15;
		public uint Unknown16;
		public uint Unknown17;
		public List<ForcedReloadBlock> ForcedReload;
		public List<ConcussiveBlastBlock> ConcussiveBlast;
		public List<TankModeBlock> TankMode;
		public List<MagPulseBlock> MagPulse;
		public List<HologramBlock> Hologram;
		public List<ReactiveArmorBlock> ReactiveArmor;
		public List<BombRunBlock> BombRun;
		public List<ArmorLockBlock> ArmorLock;
		public List<AdrenalineBlock> Adrenaline;
		public List<LightningStrikeBlock> LightningStrike;
		public List<ScramblerBlock> Scrambler;
		public List<WeaponJammerBlock> WeaponJammer;
		public List<AmmoPackBlock> AmmoPack;
		public List<VisionBlock> Vision;
		public TagInstance HudInterface;
		public TagInstance PickupSound;
		public TagInstance EmptySound;
		public TagInstance ActivationEffect;
		public TagInstance ActiveEffect;
		public TagInstance DeactivationEffect;
		public StringID EnterAnimation;
		public StringID IdleAnimation;
		public StringID ExitAnimation;

		[TagDefinition(Size = 0x3C)]
		public class EquipmentCameraBlock
		{
			public short Flags;
			public short Unknown;
			public StringID CameraMarkerName;
			public StringID CameraSubmergedMarkerName;
			public Angle PitchAutoLevel;
			public Angle PitchRangeMin;
			public Angle PitchRangeMax;
			public List<CameraTrack> CameraTracks;
			public Angle Unknown2;
			public Angle Unknown3;
			public Angle Unknown4;
			public List<UnknownBlock> Unknown5;

			[TagDefinition(Size = 0x10)]
			public class CameraTrack
			{
				public TagInstance Track;
			}

			[TagDefinition(Size = 0x4C)]
			public class UnknownBlock
			{
				public uint Unknown;
				public uint Unknown2;
				public uint Unknown3;
				public uint Unknown4;
				public uint Unknown5;
				public uint Unknown6;
				public uint Unknown7;
				public uint Unknown8;
				public uint Unknown9;
				public uint Unknown10;
				public uint Unknown11;
				public uint Unknown12;
				public uint Unknown13;
				public uint Unknown14;
				public uint Unknown15;
				public uint Unknown16;
				public uint Unknown17;
				public uint Unknown18;
				public uint Unknown19;
			}
		}

		[TagDefinition(Size = 0x3C)]
		public class HealthPackBlock
		{
			public uint Unknown;
			public uint Unknown2;
			public float ShieldsGiven;
			public TagInstance Unknown3;
			public TagInstance Unknown4;
			public TagInstance Unknown5;
		}

		[TagDefinition(Size = 0x4)]
		public class PowerupBlock
		{
			public PowerupTraitSetValue PowerupTraitSet;

			public enum PowerupTraitSetValue : int
			{
				Red,
				Blue,
				Yellow,
			}
		}

		[TagDefinition(Size = 0x34)]
		public class ObjectCreationBlock
		{
			public TagInstance Object;
			public TagInstance Unknown;
			public uint Unknown2;
			public uint Unknown3;
			public uint Unknown4;
			public float ObjectForce;
			public uint Unknown5;
		}

		[TagDefinition(Size = 0x30)]
		public class DestructionBlock
		{
			public TagInstance DestroyEffect;
			public TagInstance DestroyDamageEffect;
			public uint Unknown;
			public float SelfDestructionTime;
			public uint Unknown2;
			public uint Unknown3;
		}

		[TagDefinition(Size = 0x10)]
		public class RadarManipulationBlock
		{
			public uint Unknown;
			public float FakeBlipRadius;
			public int FakeBlipCount;
			public uint Unknown2;
		}

		[TagDefinition(Size = 0x8)]
		public class InvisibilityBlock
		{
			public uint Unknown;
			public uint Unknown2;
		}

		[TagDefinition(Size = 0x2C)]
		public class InvincibilityBlock
		{
			public StringID NewPlayerMaterial;
			public short NewPlayerMaterialGlobalIndex;
			public short Unknown;
			public uint Unknown2;
			public TagInstance Unknown3;
			public TagInstance Unknown4;
		}

		[TagDefinition(Size = 0x10)]
		public class RegeneratorBlock
		{
			public TagInstance RegeneratingEffect;
		}

		[TagDefinition(Size = 0x14)]
		public class ForcedReloadBlock
		{
			public TagInstance Effect;
			public uint Unknown;
		}

		[TagDefinition(Size = 0x20)]
		public class ConcussiveBlastBlock
		{
			public TagInstance Unknown;
			public TagInstance Unknown2;
		}

		[TagDefinition(Size = 0x28)]
		public class TankModeBlock
		{
			public StringID NewPlayerMaterial;
			public uint Unknown;
			public uint Unknown2;
			public uint Unknown3;
			public uint Unknown4;
			public uint Unknown5;
			public TagInstance ActiveHud;
		}

		[TagDefinition(Size = 0x34)]
		public class MagPulseBlock
		{
			public TagInstance Unknown;
			public TagInstance Unknown2;
			public TagInstance Unknown3;
			public uint Unknown4;
		}

		[TagDefinition(Size = 0x6C)]
		public class HologramBlock
		{
			public uint Unknown;
			public TagInstance ActiveEffect;
			public TagInstance Unknown2;
			public uint Unknown3;
			public uint Unknown4;
			public uint Unknown5;
			public TagInstance DeathEffect;
			public uint Unknown6;
			public uint Unknown7;
			public byte[] Function;
			public TagInstance NavPointHud;
		}

		[TagDefinition(Size = 0x4C)]
		public class ReactiveArmorBlock
		{
			public uint Unknown;
			public uint Unknown2;
			public uint Unknown3;
			public TagInstance Unknown4;
			public TagInstance Unknown5;
			public TagInstance Unknown6;
			public TagInstance Unknown7;
		}

		[TagDefinition(Size = 0x34)]
		public class BombRunBlock
		{
			public int Unknown;
			public uint Unknown2;
			public uint Unknown3;
			public uint Unknown4;
			public uint Unknown5;
			public TagInstance Projectile;
			public TagInstance ThrowSound;
		}

		[TagDefinition(Size = 0x20)]
		public class ArmorLockBlock
		{
			public TagInstance Unknown;
			public TagInstance Unknown2;
		}

		[TagDefinition(Size = 0x24)]
		public class AdrenalineBlock
		{
			public uint Unknown;
			public TagInstance Unknown2;
			public TagInstance Unknown3;
		}

		[TagDefinition(Size = 0x14)]
		public class LightningStrikeBlock
		{
			public uint Unknown;
			public TagInstance Unknown2;
		}

		[TagDefinition(Size = 0x24)]
		public class ScramblerBlock
		{
			public uint Unknown;
			public TagInstance Unknown2;
			public int Unknown3;
			public int Unknown4;
			public int Unknown5;
			public int Unknown6;
		}

		[TagDefinition(Size = 0x24)]
		public class WeaponJammerBlock
		{
			public uint Unknown;
			public TagInstance Unknown2;
			public int Unknown3;
			public int Unknown4;
			public int Unknown5;
			public int Unknown6;
		}

		[TagDefinition(Size = 0x34)]
		public class AmmoPackBlock
		{
			public uint Unknown;
			public int Unknown2;
			public int Unknown3;
			public uint Unknown4;
			public int Unknown5;
			public int Unknown6;
			public List<Weapon> Weapons;
			public TagInstance Unknown7;

			[TagDefinition(Size = 0x18)]
			public class Weapon
			{
				public StringID Name;
				public TagInstance WeaponObject;
				public int Unknown;
			}
		}

		[TagDefinition(Size = 0x20)]
		public class VisionBlock
		{
			public TagInstance ScreenEffect;
			public TagInstance Unknown;
		}
	}
}
