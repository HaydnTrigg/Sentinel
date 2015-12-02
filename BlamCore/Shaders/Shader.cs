using Blam.Common;
using Blam.Tags;

namespace Blam.Shaders
{
    [TagDefinition(Name = "shader", Group = "rmsh", Size = 0x4)]
	public class Shader : RenderMethod
	{
		public StringID Material;
	}
}
