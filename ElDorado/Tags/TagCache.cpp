#include "TagCache.hpp"

namespace ElDorado
{
	namespace Tags
	{
		TagCache::TagCache()
		{
		}

		std::istream &operator>>(std::istream &in, TagCache &tagCache)
		{
			// Read tag list info
			in.seekg(0x4);
			in >> tagCache.TagListOffset;
			in >> tagCache.TagEntryCount;

			// Read the timestamp
			in.seekg(0x10);
			in >> tagCache.Timestamp;

			// Read the tag list
			in.seekg(tagCache.TagListOffset);
			for (auto i = 0; i < tagCache.TagEntryCount; i++)
			{
				uint32_t tagHeaderOffset;
				in >> tagHeaderOffset;
				tagCache.TagHeaderOffsets.push_back(tagHeaderOffset);
			}

			// Read each entry in the tag list
			for (auto i = 0; i < tagCache.TagEntryCount; i++)
			{
				TagEntry tagEntry(i);

				if (i != 0)
				{
					in.seekg(tagCache.TagHeaderOffsets[i]);
					in >> tagEntry;
				}

				tagCache.TagEntries.push_back(tagEntry);
			}

			return in;
		}
	}
}
