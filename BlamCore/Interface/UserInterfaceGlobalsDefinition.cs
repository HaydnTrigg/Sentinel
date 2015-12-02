using System.Collections.Generic;
using Blam.Tags;
using Blam.Game;

namespace Blam.Interface
{
    [TagDefinition(Name = "user_interface_globals_definition", Group = "wgtz", Size = 0x50, MaxVersion = GameVersion.V10_1_449175_Live)]
	[TagDefinition(Name = "user_interface_globals_definition", Group = "wgtz", Size = 0x60, MinVersion = GameVersion.V11_1_498295_Live)]
	public class UserInterfaceGlobalsDefinition
	{
		public TagInstance SharedUiGlobals;
		public TagInstance EditableSettings;
		public TagInstance MatchmakingHopperStrings;
		public List<ScreenWidget> ScreenWidgets;
		public TagInstance TextureRenderList;
		[MinVersion(GameVersion.V11_1_498295_Live)] public TagInstance SwearFilter; // TODO: Version number
		public uint Unknown;

		[TagDefinition(Size = 0x10)]
		public class ScreenWidget
		{
			public TagInstance Widget;
		}
	}
}
