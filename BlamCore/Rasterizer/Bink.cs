using Blam.Cache;
using Blam.Tags;

namespace Blam.Rasterizer
{
    [TagDefinition(Name = "bink", Group = "bink", Size = 0x18)]
	public class Bink
	{
		public int FrameCount;
		public ResourceReference Resource;
		public int UselessPadding;
		public uint Unknown;
		public uint Unknown2;
		public uint Unknown3;
	}
}
