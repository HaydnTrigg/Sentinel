using Blam.Common;
using Blam.Tags;

namespace Blam.Shaders
{
    [TagDefinition(Name = "shader_custom", Group = "rmcs", Size = 0x4)]
	public class ShaderCustom : RenderMethod
	{
		public StringID Material;
	}
}
