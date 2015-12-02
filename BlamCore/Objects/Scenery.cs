using Blam.Tags;

namespace Blam.Objects
{
    [TagDefinition(Name = "scenery", Group = "scen", Size = 0x8)]
	public class Scenery : GameObject
	{
		public PathfindingPolicyValue PathfindingPolicy;
		public ushort Flags2;
		public LightmappingPolicyValue LightmappingPolicy;
		public short Unknown6;

		public enum PathfindingPolicyValue : short
		{
			CutOut,
			Static,
			Dynamic,
			None,
		}

		public enum LightmappingPolicyValue : short
		{
			PerVertex,
			PerPixelNotImplemented,
			Dynamic,
		}
	}
}
