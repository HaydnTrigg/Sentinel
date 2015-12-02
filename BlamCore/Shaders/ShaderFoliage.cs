using Blam.Common;
using Blam.Tags;

namespace Blam.Shaders
{
    [TagDefinition(Name = "shader_foliage", Group = "rmfl", Size = 0x4)]
	public class ShaderFoliage : RenderMethod
	{
		public StringID Material;
	}
}
