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

		std::istream &operator>>(std::istream &in, TagCache &tagCache)
		{
			in.seekg(4, std::ios::beg);

			//
			// Read tag list info
			//

			in.read((char *)&tagCache.TagListOffset, 4);
			in.read((char *)&tagCache.TagEntryCount, 4);

			in.seekg(0x10, std::ios::beg);
			in.read((char *)&tagCache.Timestamp, 8);

			//
			// Read the tag list
			//

			in.seekg(tagCache.TagListOffset, std::ios::beg);
			for (uint32_t i = 0; i < tagCache.TagEntryCount; i++)
			{
				uint32_t offset;
				in.read((char *)&offset, 4);
				tagCache.TagHeaderOffsets.push_back(offset);
			}

			//
			// Read each entry in the tag list
			//

			tagCache.TagEntries = std::vector<TagEntry>(tagCache.TagEntryCount);

			for (uint32_t i = 0; i < tagCache.TagEntryCount; i++)
			{
				TagEntry tagEntry(i);

				if (i != 0)
				{
					in.seekg(tagCache.TagHeaderOffsets[i], std::ios::beg);
					in >> tagEntry;
				}

				tagCache.TagEntries[i] = tagEntry;
			}

			return in;
		}
	}
}
