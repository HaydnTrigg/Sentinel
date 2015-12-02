using System.Collections.Generic;
using Blam.Tags;
using Blam.Common;

namespace Blam.Shaders
{
    [TagDefinition(Name = "render_method_option", Group = "rmop", Size = 0x10)]
	public class RenderMethodOption
	{
		public List<UnknownBlock> Unknown;
		public uint Unknown2;

		[TagDefinition(Size = 0x48)]
		public class UnknownBlock
		{
			public StringID Type;
			public uint Unknown;
			public uint Unknown2;
			public TagInstance Unknown3;
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
		}
	}
}
