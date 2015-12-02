using Blam.Common;
using Blam.Tags;

namespace Blam.Shaders
{
    [TagDefinition(Name = "shader_terrain", Group = "rmtr", Size = 0x1C)]
	public class ShaderTerrain : RenderMethod
	{
		public StringID Material1;
		public StringID Material2;
		public StringID Material3;
		public StringID Material4;
		public short GlobalMaterialIndex1;
		public short GlobalMaterialIndex2;
		public short GlobalMaterialIndex3;
		public short GlobalMaterialIndex4;
		public uint Unknown8;
	}
}
