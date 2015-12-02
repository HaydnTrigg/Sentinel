using System.Collections.Generic;
using Blam.Tags;
using Blam.Common;

namespace Blam.Interface
{
    [TagDefinition(Name = "gui_datasource_definition", Group = "dsrc", Size = 0x20)]
	public class GuiDatasourceDefinition
	{
		public StringID Name;
		public uint Unknown;
		public uint Unknown2;
		public uint Unknown3;
		public List<Datum> Data;
		public uint Unknown4;

		[TagDefinition(Size = 0x28)]
		public class Datum
		{
			public List<IntegerValue> IntegerValues;
			public List<StringValue> StringValues;
			public List<StringidValue> StringidValues;
			public StringID Unknown;

			[TagDefinition(Size = 0x8)]
			public class IntegerValue
			{
				public StringID DataType;
				public int Value;
			}

			[TagDefinition(Size = 0x24)]
			public class StringValue
			{
				public StringID DataType;
				[TagField(Length = 20)] public string Value;
			}

			[TagDefinition(Size = 0x8)]
			public class StringidValue
			{
				public StringID DataType;
				public StringID Value;
			}
		}
	}
}
