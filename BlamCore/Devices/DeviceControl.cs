using Blam.Common;
using Blam.Tags;

namespace Blam.Devices
{
    [TagDefinition(Name = "device_control", Group = "ctrl", Size = 0x44)]
	public class DeviceControl : Device
	{
		public TypeValue Type;
		public TriggersWhenValue TriggersWhen;
		public float CallValue;
		public StringID ActionString;
		public TagInstance On;
		public TagInstance Off;
		public TagInstance Deny;
		public uint Unknown8;
		public uint Unknown9;

		public enum TypeValue : short
		{
			Toggle,
			On,
			Off,
			Call,
			Generator,
		}

		public enum TriggersWhenValue : short
		{
			TouchedByPlayer,
			Destroyed,
		}
	}
}
