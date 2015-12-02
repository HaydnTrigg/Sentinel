using System;
using static System.BitConverter;
using static System.Text.Encoding;

namespace Blam.Common
{
    /// <summary>
    /// Represents a tag; a 4-character identifier.
    /// </summary>
    public struct Tag : IComparable<Tag>, IEquatable<Tag>
    {
        public static Tag Null { get; } = new Tag("ÿÿÿÿ");

        /// <summary>
        /// The value of the tag.
        /// </summary>
        public UInt32 Value { get; }

        public Type DefinitionType { get; }

        /// <summary>
        /// Constructs a tag from a UInt32.
        /// </summary>
        /// <param name="value">The value of the tag.</param>
        public Tag(UInt32 value, Type definitionType = null)
		{
			Value = value;
            DefinitionType = definitionType;
		}

		/// <summary>
		/// Constructs a tag from a string representation.
		/// </summary>
		/// <param name="value">The representation of the tag.</param>
		public Tag(string value)
            : this(ToUInt32(ASCII.GetBytes(value), 0))
        {
        }
        
        public override string ToString() =>
            ASCII.GetString(GetBytes(Value));

        public bool Equals(Tag other) =>
            Value.Equals(other.Value);

        public override bool Equals(object obj) =>
            obj is Tag ?
                Equals((Tag)obj) :
            false;

        public static bool operator ==(Tag a, Tag b) =>
            a.Equals(b);

		public static bool operator !=(Tag a, Tag b) =>
            !a.Equals(b);

        public override int GetHashCode() =>
            Value.GetHashCode();

        public int CompareTo(Tag other) =>
            Value.CompareTo(other.Value);
    }
}