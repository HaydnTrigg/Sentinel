#pragma once
#include <cstdint>
#include <exception>
#include <iostream>
#include <vector>
#include <ElDorado\Common\Serializable.hpp>
#include <ElDorado\Tags\TagEntry.hpp>

namespace ElDorado
{
	namespace Tags
	{
		class TagCache : public Serializable<TagCache>
		{
		public:
			TagCache();

			int64_t GetTimestamp() const;

			void Serialize(std::ostream &out);
			void Deserialize(std::istream &in);

			TagEntry &operator[](const size_t index);

		protected:
			uint32_t TagListOffset;
			uint32_t TagEntryCount;
			int64_t Timestamp;
			std::vector<uint32_t> TagHeaderOffsets;
			std::vector<TagEntry> TagEntries;
		};
	}
}
