#pragma once
#include <iostream>
#include <vector>
#include <ElDorado\Tags\TagEntry.hpp>

namespace ElDorado
{
	namespace Tags
	{
		class TagCache
		{
		public:
			TagCache();

			friend std::istream &operator>>(std::istream &in, TagCache &tagCache);

		protected:
			int32_t TagListOffset;
			int32_t TagEntryCount;
			int64_t Timestamp;
			std::vector<uint32_t> TagHeaderOffsets;
			std::vector<TagEntry> TagEntries;
		};
	}
}
