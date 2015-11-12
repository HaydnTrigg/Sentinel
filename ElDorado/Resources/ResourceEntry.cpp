#include "ResourceEntry.hpp"

namespace ElDorado
{
	namespace Resources
	{
		ResourceEntry::ResourceEntry(const uint32_t offset, const uint32_t size) :
			Offset(offset), Size(size)
		{
		}

		uint32_t ResourceEntry::GetOffset() const
		{
			return Offset;
		}

		uint32_t ResourceEntry::GetSize() const
		{
			return Size;
		}
	}
}