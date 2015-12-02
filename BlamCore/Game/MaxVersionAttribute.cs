using System;

namespace Blam.Game
{
    /// <summary>
    /// Attribute indicating the last engine version in which a tag element is present.
    /// </summary>
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field)]
	public class MaxVersionAttribute : Attribute
	{
		public MaxVersionAttribute(GameVersion version)
		{
			Version = version;
		}

		public GameVersion Version { get; set; }
	}
}
