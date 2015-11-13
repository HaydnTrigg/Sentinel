#include "TagCache.hpp"

namespace ElDorado
{
	namespace Tags
	{
		TagCache::TagCache() :
			TagHeaderOffsets(),
			TagEntries()
		{
		}

		int64_t TagCache::GetTimestamp() const
		{
			return Timestamp;
		}

		void TagCache::Serialize(std::ostream &out)
		{
			throw std::exception("TagCache::Serialize is not yet implemented");
		}

		void TagCache::Deserialize(std::istream &in)
		{
			in.seekg(4, std::ios::beg);

			//
			// Read tag list info
			//

			in.read((char *)&TagListOffset, 4);
			in.read((char *)&TagEntryCount, 4);

			in.seekg(0x10, std::ios::beg);
			in.read((char *)&Timestamp, 8);

			//
			// Read the tag list
			//

			in.seekg(TagListOffset, std::ios::beg);
			for (uint32_t i = 0; i < TagEntryCount; i++)
			{
				uint32_t offset;
				in.read((char *)&offset, 4);
				TagHeaderOffsets.push_back(offset);
			}

			//
			// Read each entry in the tag list
			//

			TagEntries = std::vector<TagEntry>(TagEntryCount);

			for (uint32_t i = 1; i < TagEntryCount; i++)
			{
				in.seekg(TagHeaderOffsets[i], std::ios::beg);
				in >> TagEntries[i];
				TagEntries[i].Index = i;
			}
		}

		TagEntry &TagCache::operator[](const size_t index)
		{
			return TagEntries[index];
		}
	}
}
