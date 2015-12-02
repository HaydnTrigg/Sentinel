using System;

namespace Blam.Game
{
    /// <summary>
    /// Attribute indicating the first engine version in which a tag element is present.
    /// </summary>
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field)]
	public class MinVersionAttribute : Attribute
	{
		public MinVersionAttribute(GameVersion version)
		{
			Version = version;
		}

		public GameVersion Version { get; set; }
	}
}
