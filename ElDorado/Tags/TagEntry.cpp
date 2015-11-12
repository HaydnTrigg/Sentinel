#include "TagEntry.hpp"

namespace ElDorado
{
	namespace Tags
	{
		TagEntry::TagEntry(const int32_t index) :
			Index(index),
			GroupTag((Tag &)Tag::Null),
			ParentGroupTag((Tag &)Tag::Null),
			GrandparentGroupTag((Tag &)Tag::Null),
			GroupNameId((StringId &)StringId::Null)
		{
		}

		const uint32_t TagHeaderSize = 0x24;
		const uint32_t FixupPointerBase = 0x40000000;

		void TagEntry::Serialize(std::ostream &out)
		{
			throw std::exception("TagEntry::Serialize is not yet implemented");
		}

		void TagEntry::Deserialize(std::istream &in)
		{
			uint32_t totalSize = 0;
			int16_t dependencyCount = 0;
			int16_t dataFixupCount = 0;
			int16_t resourceFixupCount = 0;
			uint32_t definitionOffset = 0;

			auto headerOffset = (uint32_t)in.tellg();

			//
			// Read tag entry structure
			//

			in.read((char *)&Checksum, 4);
			in.read((char *)&totalSize, 4);
			in.read((char *)&dependencyCount, 2);
			in.read((char *)&dataFixupCount, 2);
			in.read((char *)&resourceFixupCount, 2);
			in.seekg(0x2, std::ios::cur);
			in.read((char *)&definitionOffset, 4);
			in >> GroupTag;
			in >> ParentGroupTag;
			in >> GrandparentGroupTag;
			in >> GroupNameId;

			uint32_t headerSize = (TagHeaderSize + dependencyCount * 4 + dataFixupCount * 4 + resourceFixupCount * 4);

			Address = headerOffset + headerSize;
			Offset = definitionOffset - headerSize;
			Size = totalSize - headerSize;

			//
			// Read tag dependencies
			//

			for (auto i = 0; i < dependencyCount; i++)
			{
				int32_t value = 0;
				in.read((char *)&value, 4);
				Dependencies.emplace(value);
			}

			//
			// Read data and resource fixup pointers
			//

			DataFixups = std::vector<TagFixup>(dataFixupCount);
			ResourceFixups = std::vector<TagFixup>(resourceFixupCount);

			for (auto i = 0; i < dataFixupCount; i++)
				in.read((char *)&DataFixups[i].WriteOffset, 4);

			for (auto i = 0; i < resourceFixupCount; i++)
				in.read((char *)&ResourceFixups[i].WriteOffset, 4);

			//
			// Read data fixup definitions
			//

			for (auto i = 0; i < dataFixupCount; i++)
			{
				uint32_t targetOffset = 0;
				auto fixupOffset = DataFixups[i].WriteOffset - FixupPointerBase;
				in.seekg(headerOffset + fixupOffset, std::ios::beg);
				in.read((char *)&targetOffset, 4);
				targetOffset -= FixupPointerBase;

				DataFixups[i].WriteOffset = fixupOffset - headerSize;
				DataFixups[i].TargetOffset = targetOffset - headerSize;
			}

			//
			// Read resource fixup definitions
			//

			for (auto i = 0; i < resourceFixupCount; i++)
			{
				uint32_t targetOffset = 0;
				auto fixupOffset = ResourceFixups[i].WriteOffset - FixupPointerBase;
				in.seekg(headerOffset + fixupOffset, std::ios::beg);
				in.read((char *)&targetOffset, 4);
				targetOffset -= FixupPointerBase;

				ResourceFixups[i].WriteOffset = fixupOffset - headerSize;
				ResourceFixups[i].TargetOffset = targetOffset - headerSize;
			}
		}
	}
}
