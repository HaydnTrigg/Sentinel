using Blam.Cache;
using Blam.Tags;

namespace Blam.Sound
{
    /// <summary>
    /// Resource definition data for sounds.
    /// </summary>
    [TagDefinition(Size = 0x14)]
	public class SoundResourceDefinition
	{
		/// <summary>
		/// Gets or sets the reference to the sound data.
		/// </summary>
		public ResourceDataReference Data;
	}
}
