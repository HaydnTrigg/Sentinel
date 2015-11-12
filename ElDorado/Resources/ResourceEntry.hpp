#pragma once
#include <cstdint>

namespace ElDorado
{
	namespace Resources
	{
		class ResourceEntry
		{
			friend class ResourceCache;

		public:
			ResourceEntry(const uint32_t offset = 0, const uint32_t size = 0);

			uint32_t GetOffset() const;
			uint32_t GetSize() const;

		protected:
			uint32_t Offset;
			uint32_t Size;
		};
	}
}