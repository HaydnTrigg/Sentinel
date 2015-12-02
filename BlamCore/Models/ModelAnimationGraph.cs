using System.Collections.Generic;
using Blam.Common;
using Blam.Tags;
using Blam.Cache;

namespace Blam.Models
{
    [TagDefinition(Name = "model_animation_graph", Group = "jmad", Size = 0x104)]
	public class ModelAnimationGraph
	{
		public TagInstance ParentAnimationGraph;
		public byte InheritanceFlags;
		public byte PrivateFlags;
		public short AnimationCodecPack;
		public List<SkeletonNode> SkeletonNodes;
		public List<SoundReference> SoundReferences;
		public List<EffectReference> EffectReferences;
		public List<BlendScreen> BlendScreens;
		public List<Leg> Legs;
		public List<Animation> Animations;
		public List<Mode> Modes;
		public List<VehicleSuspensionBlock> VehicleSuspension;
		public List<ObjectOverlay> ObjectOverlays;
		public List<InheritanceListBlock> InheritanceList;
		public List<WeaponListBlock> WeaponList;
		public uint UnknownArmNodes1;
		public uint UnknownArmNodes2;
		public uint UnknownArmNodes3;
		public uint UnknownArmNodes4;
		public uint UnknownArmNodes5;
		public uint UnknownArmNodes6;
		public uint UnknownArmNodes7;
		public uint UnknownArmNodes8;
		public uint UnknownNodes1;
		public uint UnknownNodes2;
		public uint UnknownNodes3;
		public uint UnknownNodes4;
		public uint UnknownNodes5;
		public uint UnknownNodes6;
		public uint UnknownNodes7;
		public uint UnknownNodes8;
		public byte[] LastImportResults;
		public uint Unknown;
		public uint Unknown2;
		public uint Unknown3;
		public List<ResourceGroup> ResourceGroups;

		[TagDefinition(Size = 0x20)]
		public class SkeletonNode
		{
			public StringID Name;
			public short NextSiblingNodeIndex;
			public short FirstChildNodeIndex;
			public short ParentNodeIndex;
			public byte ModelFlags;
			public byte NodeJointFlags;
            public Vector3 BaseVector;
			public float VectorRange;
			public float ZPosition;
		}

		[TagDefinition(Size = 0x14)]
		public class SoundReference
		{
			public TagInstance Sound;
			public ushort Flags;
			public short Unknown;
		}

		[TagDefinition(Size = 0x14)]
		public class EffectReference
		{
			public TagInstance Effect;
			public ushort Flags;
			public short Unknown;
		}

		[TagDefinition(Size = 0x1C)]
		public class BlendScreen
		{
			public StringID Label;
			public Angle RightYawPerFrame;
			public Angle LeftYawPerFrame;
			public short RightFrameCount;
			public short LeftFrameCount;
			public Angle DownPitchPerFrame;
			public Angle UpPitchPerFrame;
			public short DownPitchFrameCount;
			public short UpPitchFrameCount;
		}

		[TagDefinition(Size = 0x1C)]
		public class Leg
		{
			public StringID FootMarker;
			public float FootMin;
			public float FootMax;
			public StringID AnkleMarker;
			public float AnkleMin;
			public float AnkleMax;
			public AnchorsValue Anchors;
			public short Unknown;

			public enum AnchorsValue : short
			{
				False,
				True,
			}
		}

		[TagDefinition(Size = 0x88)]
		public class Animation
		{
			public StringID Name;
			public float Weight;
			public short LoopFrameIndex;
			public ushort PlaybackFlags;
			public sbyte BlendScreen;
			public DesiredCompressionValue DesiredCompression;
			public CurrentCompressionValue CurrentCompression;
			public sbyte NodeCount;
			public short FrameCount;
			public TypeValue Type;
			public FrameInfoTypeValue FrameInfoType;
			public ushort ProductionFlags;
			public ushort InternalFlags;
			public int NodeListChecksum;
			public int ProductionChecksum;
			public short Unknown;
			public short Unknown2;
			public short PreviousVariantSibling;
			public short NextVariantSibling;
			public short RawInformationGroupIndex;
			public short RawInformationMemberIndex;
			public List<FrameEvent> FrameEvents;
			public List<SoundEvent> SoundEvents;
			public List<EffectEvent> EffectEvents;
			public List<UnknownBlock> Unknown3;
			public List<ObjectSpaceParentNode> ObjectSpaceParentNodes;
			public List<LegAnchoringBlock> LegAnchoring;
			public float Unknown4;
			public float Unknown5;
			public float Unknown6;
			public float Unknown7;
			public float Unknown8;

			public enum DesiredCompressionValue : sbyte
			{
				BestScore,
				BestCompression,
				BestAccuracy,
				BestFullframe,
				BestSmallKeyframe,
				BestLargeKeyframe,
			}

			public enum CurrentCompressionValue : sbyte
			{
				BestScore,
				BestCompression,
				BestAccuracy,
				BestFullframe,
				BestSmallKeyframe,
				BestLargeKeyframe,
			}

			public enum TypeValue : sbyte
			{
				Base,
				Overlay,
				Replacement,
			}

			public enum FrameInfoTypeValue : sbyte
			{
				None,
				DxDy,
				DxDyDyaw,
				DxDyDzDyaw,
			}

			[TagDefinition(Size = 0x4)]
			public class FrameEvent
			{
				public TypeValue Type;
				public short Frame;

				public enum TypeValue : short
				{
					PrimaryKeyframe,
					SecondaryKeyframe,
					LeftFoot,
					RightFoot,
					AllowInterruption,
					TransitionA,
					TransitionB,
					TransitionC,
					TransitionD,
					BothFeetShuffle,
					BodyImpact,
				}
			}

			[TagDefinition(Size = 0x8)]
			public class SoundEvent
			{
				public short Sound;
				public short Frame;
				public StringID MarkerName;
			}

			[TagDefinition(Size = 0x8)]
			public class EffectEvent
			{
				public short Effect;
				public short Frame;
				public StringID MarkerName;
			}

			[TagDefinition(Size = 0x4)]
			public class UnknownBlock
			{
				public short Unknown;
				public short Unknown2;
			}

			[TagDefinition(Size = 0x1C)]
			public class ObjectSpaceParentNode
			{
				public short NodeIndex;
				public ushort ComponentFlags;
				public short RotationX;
				public short RotationY;
				public short RotationZ;
				public short RotationW;
				public float DefaultTranslationX;
				public float DefaultTranslationY;
				public float DefaultTranslationZ;
				public float DefaultScale;
			}

			[TagDefinition(Size = 0x10)]
			public class LegAnchoringBlock
			{
				public short LegIndex;
				public short Unknown;
				public List<UnknownBlock> Unknown2;

				[TagDefinition(Size = 0x14)]
				public class UnknownBlock
				{
					public short Frame1a;
					public short Frame2a;
					public short Frame1b;
					public short Frame2b;
					public uint Unknown;
					public uint Unknown2;
					public uint Unknown3;
				}
			}
		}

		[TagDefinition(Size = 0x28)]
		public class Mode
		{
			public StringID Label;
			public List<WeaponClassBlock> WeaponClass;
			public List<ModeIkBlock> ModeIk;
			public uint Unknown;
			public uint Unknown2;
			public uint Unknown3;

			[TagDefinition(Size = 0x28)]
			public class WeaponClassBlock
			{
				public StringID Label;
				public List<WeaponTypeBlock> WeaponType;
				public List<WeaponIkBlock> WeaponIk;
				public List<SyncAction> SyncActions;

				[TagDefinition(Size = 0x34)]
				public class WeaponTypeBlock
				{
					public StringID Label;
					public List<Action> Actions;
					public List<Overlay> Overlays;
					public List<DeathAndDamageBlock> DeathAndDamage;
					public List<Transition> Transitions;

					[TagDefinition(Size = 0x8)]
					public class Action
					{
						public StringID Label;
						public short GraphIndex;
						public short Animation;
					}

					[TagDefinition(Size = 0x8)]
					public class Overlay
					{
						public StringID Label;
						public short GraphIndex;
						public short Animation;
					}

					[TagDefinition(Size = 0x10)]
					public class DeathAndDamageBlock
					{
						public StringID Label;
						public List<Direction> Directions;

						[TagDefinition(Size = 0xC)]
						public class Direction
						{
							public List<Region> Regions;

							[TagDefinition(Size = 0x4)]
							public class Region
							{
								public short GraphIndex;
								public short Animation;
							}
						}
					}

					[TagDefinition(Size = 0x18)]
					public class Transition
					{
						public StringID FullName;
						public StringID StateName;
						public short Unknown;
						public sbyte IndexA;
						public sbyte IndexB;
						public List<Destination> Destinations;

						[TagDefinition(Size = 0x14)]
						public class Destination
						{
							public StringID FullName;
							public StringID ModeName;
							public StringID StateName;
							public FrameEventLinkValue FrameEventLink;
							public sbyte Unknown;
							public sbyte IndexA;
							public sbyte IndexB;
							public short GraphIndex;
							public short Animation;

							public enum FrameEventLinkValue : sbyte
							{
								NoKeyframe,
								KeyframeTypeA,
								KeyframeTypeB,
								KeyframeTypeC,
								KeyframeTypeD,
							}
						}
					}
				}

				[TagDefinition(Size = 0x8)]
				public class WeaponIkBlock
				{
					public StringID Marker;
					public StringID AttachToMarker;
				}

				[TagDefinition(Size = 0x10)]
				public class SyncAction
				{
					public StringID Label;
					public List<ClassBlock> Class;

					[TagDefinition(Size = 0x1C)]
					public class ClassBlock
					{
						public StringID Label;
						public List<UnknownBlock> Unknown;
						public List<SyncBipedBlock> SyncBiped;

						[TagDefinition(Size = 0x30)]
						public class UnknownBlock
						{
							public int Unknown;
							public short GraphIndex;
							public short Animation;
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
						}

						[TagDefinition(Size = 0x14)]
						public class SyncBipedBlock
						{
							public int Unknown;
							public TagInstance Biped;
						}
					}
				}
			}

			[TagDefinition(Size = 0x8)]
			public class ModeIkBlock
			{
				public StringID Marker;
				public StringID AttachToMarker;
			}
		}

		[TagDefinition(Size = 0x28)]
		public class VehicleSuspensionBlock
		{
			public StringID Label;
			public short GraphIndex;
			public short Animation;
			public StringID MarkerName;
			public float MassPointOffset;
			public float FullExtensionGroundDepth;
			public float FullCompressionGroundDepth;
			public StringID RegionName;
			public float MassPointOffset2;
			public float ExpressionGroundDepth;
			public float CompressionGroundDepth;
		}

		[TagDefinition(Size = 0x14)]
		public class ObjectOverlay
		{
			public StringID Label;
			public short GraphIndex;
			public short Animation;
			public short Unknown;
			public FunctionControlsValue FunctionControls;
			public StringID Function;
			public uint Unknown2;

			public enum FunctionControlsValue : short
			{
				Frame,
				Scale,
			}
		}

		[TagDefinition(Size = 0x30)]
		public class InheritanceListBlock
		{
			public TagInstance InheritedGraph;
			public List<NodeMapBlock> NodeMap;
			public List<NodeMapFlag> NodeMapFlags;
			public float RootZOffset;
			public uint InheritanceFlags;

			[TagDefinition(Size = 0x2)]
			public class NodeMapBlock
			{
				public short LocalNode;
			}

			[TagDefinition(Size = 0x4)]
			public class NodeMapFlag
			{
				public uint LocalNodeFlags;
			}
		}

		[TagDefinition(Size = 0x8)]
		public class WeaponListBlock
		{
			public StringID WeaponName;
			public StringID WeaponClass;
		}

		[TagDefinition(Size = 0xC)]
		public class ResourceGroup
		{
			public int MemberCount;
			public ResourceReference Resource;
			public int UselessPadding;
		}
	}
}
