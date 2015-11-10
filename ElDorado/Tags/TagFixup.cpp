#include "TagFixup.hpp"

namespace ElDorado
{
	namespace Tags
	{
		TagFixup::TagFixup(const uint32_t writeOffset, const uint32_t targetOffset) :
			WriteOffset(writeOffset), TargetOffset(targetOffset)
		{
		}

		uint32_t TagFixup::GetWriteOffset() const
		{
			return WriteOffset;
		}

		uint32_t TagFixup::GetTargetOffset() const
		{
			return TargetOffset;
		}
	}
}