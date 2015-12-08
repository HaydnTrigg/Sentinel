using Blam.Game;
using Blam.Tags;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Blam.Tags
{
    /// <summary>
    /// Allows easy enumeration over a tag structure's elements and filtering by version.
    /// </summary>
    public class TagFieldEnumerator
    {
        private static readonly TagFieldAttribute DefaultFieldAttribute = new TagFieldAttribute();

        private readonly List<FieldInfo> _fields = new List<FieldInfo>();
        private int _nextIndex;

        /// <summary>
        /// Constructs an enumerator over a tag structure.
        /// </summary>
        /// <param name="info">The info for the structure. Only fields which match the version used to create the info will be enumerated over.</param>
        public TagFieldEnumerator(TagDefinition info)
        {
            Info = info;
            Begin();
        }

        /// <summary>
        /// Gets the info that was used to construct the enumerator.
        /// </summary>
        public TagDefinition Info { get; private set; }

        /// <summary>
        /// Gets information about the current field.
        /// </summary>
        public FieldInfo Field { get; private set; }

        /// <summary>
        /// Gets the current property's <see cref="TagFieldAttribute"/>.
        /// </summary>
        public TagFieldAttribute Attribute { get; private set; }

        /// <summary>
        /// Gets the lowest engine version which supports this property, or <see cref="GameVersion.Unknown"/> if unbounded.
        /// </summary>
        public GameVersion MinVersion { get; private set; }

        /// <summary>
        /// Gets the highest engine version which supports this property, or <see cref="GameVersion.Unknown"/> if unbounded.
        /// </summary>
        public GameVersion MaxVersion { get; private set; }

        /// <summary>
        /// Moves to the next tag field in the structure.
        /// This must be called before accessing any of the other properties.
        /// </summary>
        /// <returns><c>true</c> if the enumerator moved to a new element, or <c>false</c> if the end of the structure has been reached.</returns>
        public bool Next()
        {
            do
            {
                if (_fields == null || _nextIndex >= _fields.Count)
                    return false;
                Field = _fields[_nextIndex];
                _nextIndex++;
            } while (!GetCurrentPropertyInfo());
            return true;
        }

        private void Begin()
        {
            // Build the field list. Scan through the type's inheritance
            // hierarchy and add any fields belonging to parent classes that
            // also have TagStructure attributes.
            foreach (var type in Info.Types)
                _fields.InsertRange(0, type.GetFields(BindingFlags.Instance | BindingFlags.Public | BindingFlags.DeclaredOnly));

            // Order the field list in declaration order using the MetadataToken
            //_fields.Sort((x, y) => x.MetadataToken - y.MetadataToken);
        }

        private bool GetCurrentPropertyInfo()
        {
            // If the field has a TagFieldAttribute, use it, otherwise use the default
            Attribute = Field.GetCustomAttributes(typeof(TagFieldAttribute), false).FirstOrDefault() as TagFieldAttribute ?? DefaultFieldAttribute;
            if (Attribute.Offset >= Info.TotalSize)
                throw new InvalidOperationException("Offset for property \"" + Field.Name + "\" is outside of its structure");

            // Read version restrictions, if any
            var minVersionAttrib = Field.GetCustomAttributes(typeof(MinVersionAttribute), false).FirstOrDefault() as MinVersionAttribute;
            var maxVersionAttrib = Field.GetCustomAttributes(typeof(MaxVersionAttribute), false).FirstOrDefault() as MaxVersionAttribute;
            MinVersion = (minVersionAttrib != null) ? minVersionAttrib.Version : GameVersion.Unknown;
            MaxVersion = (maxVersionAttrib != null) ? maxVersionAttrib.Version : GameVersion.Unknown;
            return GameVersions.IsBetween(Info.Version, MinVersion, MaxVersion);
        }
    }
}