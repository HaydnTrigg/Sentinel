using System.Collections.Generic;
using Blam.Tags;

namespace Blam.Structures
{
    [TagDefinition(Name = "chocolate_mountain_new", Group = "chmt", Size = 0xC)]
	public class ChocolateMountainNew
	{
		public List<LightingVariable> LightingVariables;

		[TagDefinition(Size = 0x4)]
		public class LightingVariable
		{
			public float LightmapBrightnessOffset;
		}
	}
}
