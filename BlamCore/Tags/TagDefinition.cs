using Blam.Common;
using Blam.Game;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Blam.Tags
{
    /// <summary>
    /// Utility class for analyzing a tag structure type's inheritance hierarchy.
    /// </summary>
    public class TagDefinition
    {
        /// <summary>
        /// Gets the engine version that was used to construct the info object.
        /// </summary>
        public GameVersion Version { get; } = GameVersion.Unknown;

        /// <summary>
        /// Gets the structure types in the structure's inheritance hierarchy in order from child to base.
        /// Types which do not have a matching TagStructure attribute will not be included in this list.
        /// </summary>
        public List<Type> Types { get; } = new List<Type>();

        /// <summary>
        /// Gets the total size of the structure, including parent structures.
        /// </summary>
        public uint TotalSize { get; private set; } = 0;

        /// <summary>
        /// Gets the current <see cref="TagDefinitionAttribute"/>.
        /// </summary>
        public TagDefinitionAttribute Structure { get; }

        /// <summary>
        /// Gets the group tag for the structure, or -1 if none.
        /// </summary>
        public Tag GroupTag { get; private set; } = Tag.Null;

        /// <summary>
        /// Gets the parent group tag for the structure, or -1 if none.
        /// </summary>
        public Tag ParentGroupTag { get; private set; } = Tag.Null;

        /// <summary>
        /// Gets the grandparent group tag for the structure, or -1 if none.
        /// </summary>
        public Tag GrandparentGroupTag { get; private set; } = Tag.Null;

        /// <summary>
        /// Constructs a <see cref="TagDefinition"/> object which contains info about a tag structure type.
        /// </summary>
        /// <param name="structureType">The tag structure type to analyze.</param>
        public TagDefinition(Type structureType)
			: this(structureType, GameVersion.Unknown)
		{
		}

		/// <summary>
		/// Constructs a <see cref="TagDefinition"/> object which contains info about a tag structure type.
		/// </summary>
		/// <param name="structureType">The tag structure type to analyze.</param>
		/// <param name="version">The engine version to compare attributes against.</param>
		public TagDefinition(Type structureType, GameVersion version)
		{
			Version = version;
			Analyze(structureType, version);
            Structure = GetStructureAttribute(structureType, version);

            if (Structure == null)
                throw new InvalidOperationException("No TagStructure attribute which matches the target version was found on " + structureType.Name);
        }

        private void Analyze(Type mainType, GameVersion version)
		{
            for (var type = mainType; type != null; type = type.BaseType)
            {
                var attrib = (type != mainType) ? GetStructureAttribute(type, version) : Structure;

                if (attrib == null)
                    continue;

                Types.Add(type);
                TotalSize += attrib.Size;

                if (attrib.Group == null)
                    continue;

                if (GroupTag == Tag.Null)
                    GroupTag = new Tag(attrib.Group);
                else if (ParentGroupTag == Tag.Null)
                    ParentGroupTag = new Tag(attrib.Group);
                else if (GrandparentGroupTag == Tag.Null)
                    GrandparentGroupTag = new Tag(attrib.Group);
            }
		}

		private static TagDefinitionAttribute GetStructureAttribute(Type type, GameVersion version)
		{
			// First match against any TagStructureAttributes that have version restrictions
			var attrib = type.GetCustomAttributes(typeof(TagDefinitionAttribute), false)
				.Cast<TagDefinitionAttribute>()
				.Where(a => a.MinVersion != GameVersion.Unknown || a.MaxVersion != GameVersion.Unknown)
				.FirstOrDefault(a => GameVersions.IsBetween(version, a.MinVersion, a.MaxVersion));

			// If nothing was found, find the first attribute without any version restrictions
			return attrib ?? type.GetCustomAttributes(typeof(TagDefinitionAttribute), false)
				.Cast<TagDefinitionAttribute>()
				.FirstOrDefault(a => a.MinVersion == GameVersion.Unknown && a.MaxVersion == GameVersion.Unknown);
		}
	}
}
