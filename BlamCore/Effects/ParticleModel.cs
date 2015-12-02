using System.Collections.Generic;
using Blam.Models;
using Blam.Tags;

namespace Blam.Effects
{
    [TagDefinition(Name = "particle_model", Group = "pmdf", Size = 0x90)]
	public class ParticleModel
	{
		public GeometryReference Geometry;
		public List<UnknownBlock3> Unknown10;

		[TagDefinition(Size = 0x10)]
		public class UnknownBlock3
		{
			public uint Unknown;
			public uint Unknown2;
			public uint Unknown3;
			public uint Unknown4;
		}
	}
}
