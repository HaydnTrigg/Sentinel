using System.Collections.Generic;
using Blam.Tags;
using Blam.Cache;

namespace Blam.Models
{
    /// <summary>
    /// A reference to geometry data from a tag.
    /// </summary>
    [TagDefinition(Size = 0x84)]
	public class GeometryReference
	{
		public int Unknown;

		/// <summary>
		/// The meshes in the geometry.
		/// </summary>
		public List<Mesh> Meshes;

		/// <summary>
		/// Compression info for the geometry.
		/// </summary>
		public List<GeometryCompressionInfo> Compression;

		public List<UnknownNodeyBlock> UnknownNodey;
		public List<UnknownBlock> Unknown2;
		public uint Unknown3;
		public uint Unknown4;
		public uint Unknown5;
		public List<UnknownSection> UnknownSections;
		public List<NodeMap> NodeMaps;
		public List<UnknownBlock2> Unknown6;
		public uint Unknown7;
		public uint Unknown8;
		public uint Unknown9;
		public List<UnknownYoBlock> UnknownYo;

		/// <summary>
		/// The resource containing the raw geometry data.
		/// </summary>
		public ResourceReference Resource;

		public int Padding;

		[TagDefinition(Size = 0x30)]
		public class UnknownNodeyBlock
		{
			public uint Unknown;
			public uint Unknown2;
			public uint Unknown3;
			public uint Unknown4;
			public uint Unknown5;
			public uint Unknown6;
			public uint Unknown7;
			public uint Unknown8;
			public sbyte NodeIndex;
			public sbyte NodeIndex2;
			public sbyte NodeIndex3;
			public sbyte NodeIndex4;
			public uint Unknown9;
			public uint Unknown10;
			public uint Unknown11;
		}

		[TagDefinition(Size = 0x18)]
		public class UnknownBlock
		{
			public short Unknown;
			public short Unknown2;
			public byte[] Unknown3;
		}

		[TagDefinition(Size = 0x20)]
		public class UnknownSection
		{
			public byte[] Unknown;
			public List<short> Unknown2;
		}

		[TagDefinition(Size = 0xC)]
		public class NodeMap
		{
			public List<byte> Nodes;
		}

		[TagDefinition(Size = 0xC)]
		public class UnknownBlock2
		{
			public List<UnknownBlock> Unknown;

			[TagDefinition(Size = 0x30)]
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
			}
		}

		[TagDefinition(Size = 0x10)]
		public class UnknownYoBlock
		{
			public uint Unknown;
			public uint Unknown2;
			public uint Unknown3;
			public short UnknownIndex;
			public short Unknown4;
		}
	}

	/// <summary>
	/// Contains information about how geometry is compressed.
	/// </summary>
	[TagDefinition(Size = 0x2C)]
	public class GeometryCompressionInfo
	{
		public short Unknown0;
		public short Unknown2;

		/// <summary>
		/// The minimum X value in the uncompressed geometry.
		/// </summary>
		public float PositionMinX;

		/// <summary>
		/// The maximum X value in the uncompressed geometry.
		/// </summary>
		public float PositionMaxX;

		/// <summary>
		/// The minimum Y value in the uncompressed geometry.
		/// </summary>
		public float PositionMinY;

		/// <summary>
		/// The maximum Y value in the uncompressed geometry.
		/// </summary>
		public float PositionMaxY;

		/// <summary>
		/// The minimum Z value in the uncompressed geometry.
		/// </summary>
		public float PositionMinZ;

		/// <summary>
		/// The maximum Z value in the uncompressed geometry.
		/// </summary>
		public float PositionMaxZ;

		/// <summary>
		/// The minimum U value in the uncompressed geometry.
		/// </summary>
		public float TextureMinU;

		/// <summary>
		/// The maximum U value in the uncompressed geometry.
		/// </summary>
		public float TextureMaxU;

		/// <summary>
		/// The minimum V value in the uncompressed geometry.
		/// </summary>
		public float TextureMinV;

		/// <summary>
		/// The maximum V value in the uncompressed geometry.
		/// </summary>
		public float TextureMaxV;
	}
}
