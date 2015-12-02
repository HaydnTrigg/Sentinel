using System.Collections.Generic;
using Blam.Common;
using Blam.Game;
using Blam.Tags;

namespace Blam.Objects
{
    [TagDefinition(Name = "object", Group = "obje", Size = 0x120)]
    public abstract class GameObject
    {
        [MaxVersion(GameVersion.V10_1_449175_Live)]
        public ObjectTypeValueOld ObjectTypeOld;
        [MinVersion(GameVersion.V11_1_498295_Live)]
        public ObjectTypeValueNew ObjectTypeNew;
        public byte Padding;
        public ushort Flags;
        public float BoundingRadius;
        public float BoundingOffsetX;
        public float BoundingOffsetY;
        public float BoundingOffsetZ;
        public float AccelerationScale;
        public LightmapShadowModeSizeValue LightmapShadowModeSize;
        public SweetenerSizeValue SweetenerSize;
        public WaterDensityValue WaterDensity;
        public int Unknown;
        public float DynamicLightSphereRadius;
        public float DynamicLightSphereOffsetX;
        public float DynamicLightSphereOffsetY;
        public float DynamicLightSphereOffsetZ;
        public StringID DefaultModelVariant;
        public TagInstance Model;
        [MaxVersion(GameVersion.V10_1_449175_Live)]
        public TagInstance CrateObject;
        public TagInstance CollisionDamage;
        public List<EarlyMoverProperty> EarlyMoverProperties;
        public TagInstance CreationEffect;
        public TagInstance MaterialEffects;
        public TagInstance ArmorSounds;
        public TagInstance MeleeImpact;
        public List<AiProperty> AiProperties;
        public List<Function> Functions;
        public short HudTextMessageIndex;
        public short Unknown2;
        public List<Attachment> Attachments;
        public List<Widget> Widgets;
        public List<ChangeColor> ChangeColors;
        public List<NodeMap> NodeMaps;
        public List<MultiplayerObjectProperty> MultiplayerObjectProperties;
        [MinVersion(GameVersion.V11_1_498295_Live)]
        public TagInstance UnknownTag;
        public uint Unknown3;
        public uint Unknown4;
        public uint Unknown5;
        public List<ModelObjectDatum> ModelObjectData;

        public enum ObjectTypeValueOld : sbyte
        {
            None = -1,
            Biped,
            Vehicle,
            Weapon,
            Equipment,
            ArgDevice,
            Terminal,
            Projectile,
            Scenery,
            Machine,
            Control,
            SoundScenery,
            Crate,
            Creature,
            Giant,
            EffectScenery,
        }

        public enum ObjectTypeValueNew : sbyte
        {
            None = -1,
            Biped,
            Vehicle,
            Weapon,
            Armor,
            Equipment,
            ArgDevice,
            Terminal,
            Projectile,
            Scenery,
            Machine,
            Control,
            SoundScenery,
            Crate,
            Creature,
            Giant,
            EffectScenery,
        }

        public enum LightmapShadowModeSizeValue : short
        {
            Default,
            Never,
            Always,
            Unknown,
        }

        public enum SweetenerSizeValue : sbyte
        {
            Small,
            Medium,
            Large,
        }

        public enum WaterDensityValue : sbyte
        {
            Default,
            Least,
            Some,
            Equal,
            More,
            MoreStill,
            LotsMore,
        }

        [TagDefinition(Size = 0x28)]
        public class EarlyMoverProperty
        {
            public StringID Name;
            public uint Unknown;
            public uint Unknown2;
            public uint Unknown3;
            public uint Unknown4;
            public uint Unknown5;
            public uint Unknown6;
            public uint Unknown7;
            public uint Unknown8;
            public uint Unknown9;
        }

        [TagDefinition(Size = 0xC)]
        public class AiProperty
        {
            public uint Flags;
            public StringID AiTypeName;
            public SizeValue Size;
            public LeapJumpSpeedValue LeapJumpSpeed;

            public enum SizeValue : short
            {
                Default,
                Tiny,
                Small,
                Medium,
                Large,
                Huge,
                Immobile,
            }

            public enum LeapJumpSpeedValue : short
            {
                None,
                Down,
                Step,
                Crouch,
                Stand,
                Storey,
                Tower,
                Infinite,
            }
        }

        [TagDefinition(Size = 0x2C)]
        public class Function
        {
            public uint Flags;
            public StringID ImportName;
            public StringID ExportName;
            public StringID TurnOffWith;
            public float MinimumValue;
            public byte[] DefaultFunction;
            public StringID ScaleBy;
        }

        [TagDefinition(Size = 0x24)]
        public class Attachment
        {
            public uint AtlasFlags;
            public TagInstance Attachment2;
            public StringID Marker;
            public ChangeColorValue ChangeColor;
            public short Unknown;
            public StringID PrimaryScale;
            public StringID SecondaryScale;

            public enum ChangeColorValue : short
            {
                None,
                Primary,
                Secondary,
                Tertiary,
                Quaternary,
            }
        }

        [TagDefinition(Size = 0x10)]
        public class Widget
        {
            public TagInstance Type;
        }

        [TagDefinition(Size = 0x18)]
        public class ChangeColor
        {
            public List<InitialPermutation> InitialPermutations;
            public List<Function> Functions;

            [TagDefinition(Size = 0x20)]
            public class InitialPermutation
            {
                public float Weight;
                public float ColorLowerBoundR;
                public float ColorLowerBoundG;
                public float ColorLowerBoundB;
                public float ColorUpperBoundR;
                public float ColorUpperBoundG;
                public float ColorUpperBoundB;
                public StringID VariantName;
            }

            [TagDefinition(Size = 0x20)]
            public class Function
            {
                public uint ScaleFlags;
                public float ColorLowerBoundR;
                public float ColorLowerBoundG;
                public float ColorLowerBoundB;
                public float ColorUpperBoundR;
                public float ColorUpperBoundG;
                public float ColorUpperBoundB;
                public StringID DarkenBy;
                public StringID ScaleBy;
            }
        }

        [TagDefinition(Size = 0x1)]
        public class NodeMap
        {
            public sbyte TargetNode;
        }

        [TagDefinition(Size = 0xC4)]
        public class MultiplayerObjectProperty
        {
            public ushort EngineFlags;
            public ObjectTypeValue ObjectType;
            public byte TeleporterFlags;
            public sbyte Unknown;
            public byte Flags;
            public ShapeValue Shape;
            public SpawnTimerModeValue SpawnTimerMode;
            public short SpawnTime;
            public short UnknownSpawnTime;
            public float RadiusWidth;
            public float Length;
            public float Top;
            public float Bottom;
            public uint Unknown2;
            public uint Unknown3;
            public uint Unknown4;
            public int Unknown5;
            public int Unknown6;
            public TagInstance ChildObject;
            public int Unknown7;
            public TagInstance ShapeShader;
            public TagInstance UnknownShader;
            public TagInstance Unknown8;
            public TagInstance Unknown9;
            public TagInstance Unknown10;
            public TagInstance Unknown11;
            public TagInstance Unknown12;
            public TagInstance Unknown13;

            public enum ObjectTypeValue : sbyte
            {
                Ordinary,
                Weapon,
                Grenade,
                Projectile,
                Powerup,
                Equipment,
                LightLandVehicle,
                HeavyLandVehicle,
                FlyingVehicle,
                Teleporter2way,
                TeleporterSender,
                TeleporterReceiver,
                PlayerSpawnLocation,
                PlayerRespawnZone,
                HoldSpawnObjective,
                CaptureSpawnObjective,
                HoldDestinationObjective,
                CaptureDestinationObjective,
                HillObjective,
                InfectionHavenObjective,
                TerritoryObjective,
                VipBoundaryObjective,
                VipDestinationObjective,
                JuggernautDestinationObjective,
            }

            public enum ShapeValue : sbyte
            {
                None,
                Sphere,
                Cylinder,
                Box,
            }

            public enum SpawnTimerModeValue : sbyte
            {
                DefaultOne,
                Multiple,
            }
        }

        [TagDefinition(Size = 0x14)]
        public class ModelObjectDatum
        {
            public TypeValue Type;
            public short Unknown;
            public float OffsetX;
            public float OffsetY;
            public float OffsetZ;
            public float Radius;

            public enum TypeValue : short
            {
                NotSet,
                UserDefined,
                AutoGenerated,
            }
        }
    }
}
