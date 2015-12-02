using System.Collections.Generic;
using Blam.Tags;

namespace Blam.Rasterizer
{
    [TagDefinition(Name = "performance_throttles", Group = "perf", Size = 0x10)]
	public class PerformanceThrottles
	{
		public List<PerformanceBlock> Performance;
		public uint Unknown;

		[TagDefinition(Size = 0x38)]
		public class PerformanceBlock
		{
			public uint Flags;
			public float Water;
			public float Decorators;
			public float Effects;
			public float InstancedGeometry;
			public float ObjectFade;
			public float ObjectLod;
			public float Decals;
			public int CpuLightCount;
			public float CpuLightQuality;
			public int GpuLightCount;
			public float GpuLightQuality;
			public int ShadowCount;
			public float ShadowQuality;
		}
	}
}
