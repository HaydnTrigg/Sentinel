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

		std::istream &operator>>(std::istream &in, TagEntry &tagEntry)
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

			in.read((char *)&tagEntry.Checksum, 4);
			in.read((char *)&totalSize, 4);
			in.read((char *)&dependencyCount, 2);
			in.read((char *)&dataFixupCount, 2);
			in.read((char *)&resourceFixupCount, 2);
			in.seekg(0x2, std::ios::cur);
			in.read((char *)&definitionOffset, 4);

			uint32_t value = 0;

			in.read((char *)&value, 4);
			tagEntry.GroupTag = Tag(value);

			in.read((char *)&value, 4);
			tagEntry.ParentGroupTag = Tag(value);

			in.read((char *)&value, 4);
			tagEntry.GrandparentGroupTag = Tag(value);

			in.read((char *)&value, 4);
			tagEntry.GroupNameId = StringId(value);

			uint32_t headerSize = (TagHeaderSize + dependencyCount * 4 + dataFixupCount * 4 + resourceFixupCount * 4);

			tagEntry.Address = headerOffset + headerSize;
			tagEntry.Offset = definitionOffset - headerSize;
			tagEntry.Size = totalSize - headerSize;

			//
			// Read tag dependencies
			//

			for (auto i = 0; i < dependencyCount; i++)
			{
				int32_t value = 0;
				in.read((char *)&value, 4);
				tagEntry.Dependencies.emplace(value);
			}

			//
			// Read data fixup pointers
			//

			uint32_t *dataFixups = new uint32_t[dataFixupCount];

			for (auto i = 0; i < dataFixupCount; i++)
				in.read((char *)&dataFixups[i], 4);

			//
			// Read resource fixup pointers
			//

			uint32_t *resourceFixups = new uint32_t[resourceFixupCount];

			for (auto i = 0; i < resourceFixupCount; i++)
				in.read((char *)&resourceFixups[i], 4);

			//
			// Read data fixup definitions
			//

			for (auto i = 0; i < dataFixupCount; i++)
			{
				uint32_t targetOffset = 0;
				auto fixupOffset = dataFixups[i] - FixupPointerBase;
				in.seekg(headerOffset + fixupOffset, std::ios::beg);
				in.read((char *)&targetOffset, 4);
				targetOffset -= FixupPointerBase;

				tagEntry.DataFixups.push_back(
					TagFixup(
						fixupOffset - headerSize,
						targetOffset - headerSize));
			}

			//
			// Read resource fixup definitions
			//

			for (auto i = 0; i < resourceFixupCount; i++)
			{
				uint32_t targetOffset = 0;
				auto fixupOffset = resourceFixups[i] - FixupPointerBase;
				in.seekg(headerOffset + fixupOffset, std::ios::beg);
				in.read((char *)&targetOffset, 4);
				targetOffset -= FixupPointerBase;

				tagEntry.ResourceFixups.push_back(
					TagFixup(
						fixupOffset - headerSize,
						targetOffset - headerSize));
			}

			//
			// Clean up
			//

			delete resourceFixups;
			delete dataFixups;

			return in;
		}
	}
}
