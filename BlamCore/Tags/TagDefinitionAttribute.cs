using Blam.Game;
using System;

namespace Blam.Tags
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = true)]
	public class TagDefinitionAttribute : Attribute
	{
		/// <summary>
		/// Gets or sets the internal name of the tag definition.
		/// </summary>
		public string Name { get; set; }

		/// <summary>
		/// Gets or sets the string represention of the group tag that the tag definition applies to.
		/// </summary>
		public string Group { get; set; }

		/// <summary>
		/// Gets or sets the size of the tag definition in bytes, NOT including parent definitions.
		/// </summary>
		public uint Size { get; set; }

        /// <summary>
        /// Gets or sets the minimum game version which the tag definition applies to.
        /// Can be <see cref="GameVersion.Unknown"/> (default) if unbounded.
        /// </summary>
        public GameVersion MinVersion { get; set; } = GameVersion.Unknown;

        /// <summary>
        /// Gets or sets the maximum game version which the tag definition applies to.
        /// Can be <see cref="GameVersion.Unknown"/> (default) if unbounded.
        /// </summary>
        public GameVersion MaxVersion { get; set; } = GameVersion.Unknown;
	}
}
