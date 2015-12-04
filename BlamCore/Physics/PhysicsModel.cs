using System.Collections.Generic;
using Blam.Common;
using Blam.Tags;

namespace Blam.Physics
{
    [TagDefinition(Name = "physics_model", Group = "phmo", Size = 0x198)]
	public class PhysicsModel
	{
		public uint Unknown;
		public float Mass;
		public float LowFrequencyDecativationScale;
		public float HighFrequencyDecativationScale;
		public uint Unknown2;
		public uint Unknown3;
		public sbyte Unknown4;
		public sbyte Unknown5;
		public sbyte Unknown6;
		public sbyte Unknown7;
		public List<UnknownBlock> Unknown8;
		public List<UnknownBlock2> Unknown9;
		public List<PhantomType> PhantomTypes;
		public List<UnknownBlock3> Unknown10;
		public List<NodeEdge> NodeEdges;
		public List<RigidBody> RigidBodies;
		public List<Material> Materials;
		public List<Sphere> Spheres;
		public float MultiSpheresBlockHere;
		public float MultiSpheresBlockHere2;
		public float MultiSpheresBlockHere3;
		public List<Pill> Pills;
		public List<Box> Boxes;
		public List<Triangle> Triangles;
		public List<Polyhedron> Polyhedra;
		public List<PolyhedronFourVector> PolyhedronFourVectors;
		public List<PolyhedronPlaneEquation> PolyhedronPlaneEquations;
		public float MassDistributionsBlockHere;
		public float MassDistributionsBlockHere2;
		public float MassDistributionsBlockHere3;
		public List<List> Lists;
		public List<ListShape> ListShapes;
		public List<Mopp> Mopps;
		public byte[] MoppCodes;
		public List<HingeConstraint> HingeConstraints;
		public List<RagdollConstraint> RagdollConstraints;
		public List<Region> Regions;
		public List<Node> Nodes;
		public uint Unknown11;
		public uint Unknown12;
		public uint Unknown13;
		public uint Unknown14;
		public uint Unknown15;
		public uint Unknown16;
		public List<LimitedHingeConstraint> LimitedHingeConstraints;
		public float BallAndSocketConstraintBlock;
		public float BallAndSocketConstraintBlock2;
		public float BallAndSocketConstraintBlock3;
		public float StiffSpringConstraintBlock;
		public float StiffSpringConstraintBlock2;
		public float StiffSpringConstraintBlock3;
		public float PrismaticConstraintBlock;
		public float PrismaticConstraintBlock2;
		public float PrismaticConstraintBlock3;
		public List<Phantom> Phantoms;

		[TagDefinition(Size = 0x18)]
		public class UnknownBlock
		{
			public StringID Unknown;
			public uint Unknown2;
			public uint Unknown3;
			public uint Unknown4;
			public uint Unknown5;
			public uint Unknown6;
		}

		[TagDefinition(Size = 0x20)]
		public class UnknownBlock2
		{
			public StringID Name;
			public uint Unknown;
			public uint Unknown2;
			public uint Unknown3;
			public uint Unknown4;
			public uint Unknown5;
			public uint Unknown6;
			public uint Unknown7;
		}

		[TagDefinition(Size = 0x68)]
		public class PhantomType
		{
			public uint Flags; // NOTE: This has to be adjusted when converting because of the new armor object type. The "Ignores Armor" bit was inserted at position 8.
			public MinimumSizeValue MinimumSize;
			public MaximumSizeValue MaximumSize;
			public short Unknown;
			public StringID MarkerName;
			public StringID AlignmentMarkerName;
			public uint Unknown2;
			public uint Unknown3;
			public float HookeSLawE;
			public float LinearDeadRadius;
			public float CenterAcceleration;
			public float CenterMaxLevel;
			public float AxisAcceleration;
			public float AxisMaxVelocity;
			public float DirectionAcceleration;
			public float DirectionMaxVelocity;
			public uint Unknown4;
			public uint Unknown5;
			public uint Unknown6;
			public uint Unknown7;
			public uint Unknown8;
			public uint Unknown9;
			public uint Unknown10;
			public float AlignmentHookeSLawE;
			public Angle AlignmentAcceleration;
			public Angle AlignmentMaxVelocity;
			public uint Unknown11;
			public uint Unknown12;

			public enum MinimumSizeValue : sbyte
			{
				Default,
				Tiny,
				Small,
				Medium,
				Large,
				Huge,
				ExtraHuge,
			}

			public enum MaximumSizeValue : sbyte
			{
				Default,
				Tiny,
				Small,
				Medium,
				Large,
				Huge,
				ExtraHuge,
			}
		}

		[TagDefinition(Size = 0x18)]
		public class UnknownBlock3
		{
			public List<UnknownBlock> Unknown;
			public List<UnknownBlock2> Unknown2;

			[TagDefinition(Size = 0x2)]
			public class UnknownBlock
			{
				public short Unknown;
			}

			[TagDefinition(Size = 0x10)]
			public class UnknownBlock2
			{
				public uint Unknown;
				public uint Unknown2;
				public uint Unknown3;
				public uint Unknown4;
			}
		}

		[TagDefinition(Size = 0x1C)]
		public class NodeEdge
		{
			public short NodeAGlobalMaterialIndex;
			public short NodeBGlobalMaterialIndex;
			public short NodeA;
			public short NodeB;
			public List<Constraint> Constraints;
			public StringID NodeAMaterial;
			public StringID NodeBMaterial;

			[TagDefinition(Size = 0x24)]
			public class Constraint
			{
				public TypeValue Type;
				public short Index;
				public uint Flags;
				public float Friction;
				public List<UnknownBlock> Unknown;
				public List<UnknownBlock2> Unknown2;

				public enum TypeValue : short
				{
					Hinge,
					LimitedHinge,
					Ragdoll,
					StiffSpring,
					BallAndSocket,
					Prismatic,
				}

				[TagDefinition(Size = 0xC)]
				public class UnknownBlock
				{
					public short Unknown;
					public short Unknown2;
					public short Unknown3;
					public short Unknown4;
					public short Unknown5;
					public short Unknown6;
				}

				[TagDefinition(Size = 0x4)]
				public class UnknownBlock2
				{
					public short Unknown;
					public short Unknown2;
				}
			}
		}

		[TagDefinition(Size = 0xB0)]
		public class RigidBody
		{
			public short Node;
			public short Region;
			public short Permutations;
			public short Unknown;
            public Vector3 BoundingSphereOffset;
			public float BoundingSphereRadius;
			public ushort Flags;
			public MotionTypeValue MotionType;
			public short NoPhantomPowerAltRigidBody;
			public SizeValue Size;
			public float InertiaTensorScale;
			public float LinearDampening;
			public float AngularDampening;
            public Vector3 CenterOfMassOffset;
			public uint Unknown2;
			public uint Unknown3;
			public uint Unknown4;
			public uint Unknown5;
			public uint Unknown6;
			public uint Unknown7;
			public uint Unknown8;
			public uint Unknown9;
			public ShapeTypeValue ShapeType;
			public short ShapeIndex;
			public float Mass;
            public Vector3 CenterOfMass;
			public float CenterOfMassRadius;
            public Vector3 InertiaTensorX;
			public float InertiaTensorXRadius;
            public Vector3 InertiaTensorY;
			public float InertiaTensorYRadius;
            public Vector3 InertiaTensorZ;
			public float InertiaTensorZRadius;
			public float BoundingSpherePad;
			public uint Unknown10;
			public uint Unknown11;
			public uint Unknown12;

			public enum MotionTypeValue : short
			{
				Sphere,
				StabilizedSphere,
				Box,
				StabilizedBox,
				Keyframed,
				Fixed,
			}

			public enum SizeValue : short
			{
				Default,
				Tiny,
				Small,
				Medium,
				Large,
				Huge,
				ExtraHuge,
			}

			public enum ShapeTypeValue : short
			{
				Sphere,
				Pill,
				Box,
				Triangle,
				Polyhedron,
				MultiSphere,
				Unused0,
				Unused1,
				Unused2,
				Unused3,
				Unused4,
				Unused5,
				Unused6,
				Unused7,
				List,
				Mopp,
			}
		}

		[TagDefinition(Size = 0xC)]
		public class Material
		{
			public StringID Name;
			public StringID MaterialName;
			public short PhantomType;
			public short Flags;
		}

		[TagDefinition(Size = 0x70)]
		public class Sphere
		{
			public StringID Name;
			public sbyte MaterialIndex;
			public sbyte Unknown;
			public short GlobalMaterialIndex;
			public float RelativeMassScale;
			public float Friction;
			public float Restitution;
			public float Volume;
			public float Mass;
			public short OverallShapeIndex;
			public sbyte PhantomIndex;
			public sbyte InteractionUnknown;
			public int Unknown2;
			public short Size;
			public short Count;
			public int Offset;
			public int Unknown3;
			public float Radius;
			public uint Unknown4;
			public uint Unknown5;
			public uint Unknown6;
			public int Unknown7;
			public short Size2;
			public short Count2;
			public int Offset2;
			public int Unknown8;
			public float Radius2;
			public uint Unknown9;
			public uint Unknown10;
			public uint Unknown11;
            public Vector3 Translation;
			public float TranslationRadius;
		}

		[TagDefinition(Size = 0x60)]
		public class Pill
		{
			public StringID Name;
			public sbyte MaterialIndex;
			public sbyte Unknown;
			public short GlobalMaterialIndex;
			public float RelativeMassScale;
			public float Friction;
			public float Restitution;
			public float Volume;
			public float Mass;
			public short Index;
			public sbyte PhantomIndex;
			public sbyte InteractionUnknown;
			public int Unknown2;
			public short Size;
			public short Count;
			public int Offset;
			public int Unknown3;
			public float Radius;
			public uint Unknown4;
			public uint Unknown5;
			public uint Unknown6;
            public Vector3 Bottom;
			public float BottomRadius;
            public Vector3 Top;
			public float TopRadius;
		}

		[TagDefinition(Size = 0xB0)]
		public class Box
		{
			public StringID Name;
			public sbyte MaterialIndex;
			public sbyte Unknown;
			public short GlobalMaterialIndex;
			public float RelativeMassScale;
			public float Friction;
			public float Restitution;
			public float Volume;
			public float Mass;
			public short Index;
			public sbyte PhantomIndex;
			public sbyte InteractionUnknown;
			public int Unknown2;
			public short Size;
			public short Count;
			public int Offset;
			public int Unknown3;
			public float Radius;
			public uint Unknown4;
			public uint Unknown5;
			public uint Unknown6;
            public Vector3 HalfExtents;
			public float HalfExtentsRadius;
			public int Unknown7;
			public short Size2;
			public short Count2;
			public int Offset2;
			public int Unknown8;
			public float Radius2;
			public uint Unknown9;
			public uint Unknown10;
			public uint Unknown11;
            public Vector3 RotationI;
			public float RotationIRadius;
            public Vector3 RotationJ;
			public float RotationJRadius;
            public Vector3 RotationK;
			public float RotationKRadius;
            public Vector3 Translation;
			public float TranslationRadius;
		}

		[TagDefinition(Size = 0x80)]
		public class Triangle
		{
			public StringID Name;
			public sbyte MaterialIndex;
			public sbyte Unknown;
			public short GlobalMaterialIndex;
			public float RelativeMassScale;
			public float Friction;
			public float Restitution;
			public float Volume;
			public float Mass;
			public short OverallShapeIndex;
			public sbyte PhantomIndex;
			public sbyte InteractionUnknown;
			public int Unknown2;
			public short Size;
			public short Count;
			public int Offset;
			public int Unknown3;
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
			public uint Unknown20;
			public uint Unknown21;
			public uint Unknown22;
			public uint Unknown23;
		}

		[TagDefinition(Size = 0x80)]
		public class Polyhedron
		{
			public StringID Name;
			public sbyte MaterialIndex;
			public sbyte Unknown;
			public short GlobalMaterialIndex;
			public float RelativeMassScale;
			public float Friction;
			public float Restitution;
			public float Volume;
			public float Mass;
			public short OverallShapeIndex;
			public sbyte PhantomIndex;
			public sbyte InteractionUnknown;
			public int Unknown2;
			public short Size;
			public short Count;
			public int Offset;
			public int Unknown3;
			public float Radius;
			public uint Unknown4;
			public uint Unknown5;
			public uint Unknown6;
            public Vector3 AABBHalfExtents;
			public float AABBHalfExtentsRadius;
            public Vector3 AABBCenter;
			public float AABBCenterRadius;
			public uint Unknown7;
			public int FourVectorsSize;
			public uint FourVectorsCapacity;
			public int Unknown8;
			public uint Unknown9;
			public int PlaneEquationsSize;
			public uint PlaneEquationsCapacity;
			public uint Unknown10;
		}

		[TagDefinition(Size = 0x30)]
		public class PolyhedronFourVector
		{
            public Vector3 FourVectorsX;
			public float FourVectorsXRadius;
            public Vector3 FourVectorsY;
            public float FourVectorsYRadius;
            public Vector3 FourVectorsZ;
            public float FourVectorsZRadius;
		}

		[TagDefinition(Size = 0x10)]
		public class PolyhedronPlaneEquation
		{
			public float Unknown;
			public float Unknown2;
			public float Unknown3;
			public float Unknown4;
		}

		[TagDefinition(Size = 0x50)]
		public class List
		{
			public int Unknown;
			public short Size;
			public short Count;
			public int Offset;
			public int Unknown2;
			public uint Unknown3;
			public uint Unknown4;
			public uint Unknown5;
			public int ChildShapesSize;
			public uint ChildShapesCapacity;
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
		}

		[TagDefinition(Size = 0x10)]
		public class ListShape
		{
			public ShapeTypeValue ShapeType;
			public short ShapeIndex;
			public uint Unknown;
			public uint Unknown2;
			public int Unknown3;

			public enum ShapeTypeValue : short
			{
				Sphere,
				Pill,
				Box,
				Triangle,
				Polyhedron,
				MultiSphere,
				UnknownShape,
				Unused1,
				Unused2,
				Unused3,
				Unused4,
				Unused5,
				Unused6,
				Unused7,
				List,
				Mopp,
			}
		}

		[TagDefinition(Size = 0x20)]
		public class Mopp
		{
			public int Unknown;
			public short Size;
			public short Count;
			public int Offset;
			public int Unknown2;
			public uint Unknown3;
			public ShapeTypeValue ShapeType;
			public short ShapeIndex;
			public uint Unknown4;
			public uint Unknown5;

			public enum ShapeTypeValue : short
			{
				Sphere,
				Pill,
				Box,
				Triangle,
				Polyhedron,
				MultiSphere,
				UnknownShape,
				Unused1,
				Unused2,
				Unused3,
				Unused4,
				Unused5,
				Unused6,
				Unused7,
				List,
				Mopp,
			}
		}

		[TagDefinition(Size = 0x78)]
		public abstract class Constraint
		{
			public StringID Name;
			public short NodeA;
			public short NodeB;
			public float AScale;
            public Vector3 AForward;
            public Vector3 ALeft;
            public Vector3 AUp;
            public Vector3 APosition;
			public float BScale;
            public Vector3 BForward;
            public Vector3 BLeft;
            public Vector3 BUp;
            public Vector3 BPosition;
			public short EdgeIndex;
			public short Unknown;
			public uint Unknown2;
		}

        [TagDefinition(Size = 0x78)]
        public class HingeConstraint : Constraint
        {
        }

		[TagDefinition(Size = 0x94)]
		public class RagdollConstraint
        {
            public Range<float> Twist;
            public Range<float> Cone;
            public Range<float> Plane;
			public float MaxFrictionTorque;
		}

		[TagDefinition(Size = 0x10)]
		public class Region
		{
			public StringID Name;
			public List<Permutation> Permutations;

			[TagDefinition(Size = 0x10)]
			public class Permutation
			{
				public StringID Name;
				public List<RigidBody> RigidBodies;

				[TagDefinition(Size = 0x2)]
				public class RigidBody
				{
					public short RigidBodyIndex;
				}
			}
		}

		[TagDefinition(Size = 0xC)]
		public class Node
		{
			public StringID Name;
			public ushort Flags;
			public short Parent;
			public short Sibling;
			public short Child;
		}

		[TagDefinition(Size = 0x84)]
		public class LimitedHingeConstraint : Constraint
		{
			public float LimitFriction;
			public Range<Angle> LimitAngles;
		}

		[TagDefinition(Size = 0x2C)]
		public class Phantom
		{
			public int Unknown;
			public short Size;
			public short Count;
			public int Offset;
			public int Unknown2;
			public ShapeTypeValue ShapeType;
			public short ShapeIndex;
			public uint Unknown3;
			public uint Unknown4;
			public int Unknown5;
			public short Size2;
			public short Count2;
			public int Offset2;
			public int Unknown6;

			public enum ShapeTypeValue : short
			{
				Sphere,
				Pill,
				Box,
				Triangle,
				Polyhedron,
				MultiSphere,
				UnknownShape,
				Unused1,
				Unused2,
				Unused3,
				Unused4,
				Unused5,
				Unused6,
				Unused7,
				List,
				Mopp,
			}
		}
	}
}
