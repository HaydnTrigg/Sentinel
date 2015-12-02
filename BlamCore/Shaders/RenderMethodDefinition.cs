using System.Collections.Generic;
using Blam.Tags;
using Blam.Common;

namespace Blam.Shaders
{
    [TagDefinition(Name = "render_method_definition", Group = "rmdf", Size = 0x5C)]
	public class RenderMethodDefinition
	{
		public TagInstance Unknown;
		public List<Method> Methods;
		public List<DrawMode> DrawModes;
		public List<UnknownBlock2> Unknown3;
		public TagInstance Unknown4;
		public TagInstance Unknown5;
		public uint Unknown6;
		public uint Unknown7;

		[TagDefinition(Size = 0x18)]
		public class Method
		{
			public StringID Type;
			public List<ShaderOption> ShaderOptions;
			public StringID Unknown;
			public StringID Unknown2;

			[TagDefinition(Size = 0x1C)]
			public class ShaderOption
			{
				public StringID Type;
				public TagInstance Option;
				public StringID Unknown;
				public StringID Unknown2;
			}
		}

		[TagDefinition(Size = 0x10)]
		public class DrawMode
		{
			public uint Mode;
			public List<UnknownBlock2> Unknown2;

			[TagDefinition(Size = 0x10)]
			public class UnknownBlock2
			{
				public uint Unknown;
				public List<UnknownBlock> Unknown2;

				[TagDefinition(Size = 0x4)]
				public class UnknownBlock
				{
					public uint Unknown;
				}
			}
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
}
