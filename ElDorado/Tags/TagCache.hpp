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

			int64_t GetTimestamp() const;

			friend std::istream &operator>>(std::istream &in, TagCache &tagCache);

		protected:
			uint32_t TagListOffset;
			uint32_t TagEntryCount;
			int64_t Timestamp;
			std::vector<uint32_t> TagHeaderOffsets;
			std::vector<TagEntry> TagEntries;
		};
	}
}
