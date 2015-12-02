using Blam.Tags;

namespace Blam.Effects
{
    [TagDefinition(Name = "breakable_surface", Group = "bsdt", Size = 0x60)]
	public class BreakableSurface
	{
		public float MaximumVitality;
		public TagInstance Effect;
		public TagInstance Sound;
		public uint Unknown;
		public uint Unknown2;
		public uint Unknown3;
		public uint Unknown4;
		public TagInstance CrackBitmap;
		public TagInstance HoleBitmap;
		public uint Unknown5;
		public uint Unknown6;
		public uint Unknown7;
	}
}
