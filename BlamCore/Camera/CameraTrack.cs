using System.Collections.Generic;
using Blam.Tags;
using Blam.Common;

namespace Blam.Camera
{
    [TagDefinition(Name = "camera_track", Group = "trak", Size = 0x14)]
	public class CameraTrack
	{
		public uint Unknown;
		public List<CameraPoint> CameraPoints;
		public uint Unknown2;

		[TagDefinition(Size = 0x1C)]
		public class CameraPoint
		{
            public Vector3 Position;
            public Vector4 Orientation;
		}
	}
}
