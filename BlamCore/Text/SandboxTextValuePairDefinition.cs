using System.Collections.Generic;
using Blam.Tags;
using Blam.Common;

namespace Blam.Text
{
    [TagDefinition(Name = "sandbox_text_value_pair_definition", Group = "jmrq", Size = 0xC)]
	public class SandboxTextValuePairDefinition
	{
		public List<SandboxTextValuePair> SandboxTextValuePairs;

		[TagDefinition(Size = 0x10)]
		public class SandboxTextValuePair
		{
			public StringID ParameterName;
			public List<TextValuePari> TextValueParis;

			[TagDefinition(Size = 0x14)]
			public class TextValuePari
			{
				public byte Flags;
				public ExpectedValueTypeValue ExpectedValueType;
				public short Unknown;
				public int IntValue;
				public StringID RefName;
				public StringID Name;
				public StringID Description;

				public enum ExpectedValueTypeValue : sbyte
				{
					IntegerIndex,
					StringidReference,
					Incremental,
				}
			}
		}
	}
}
