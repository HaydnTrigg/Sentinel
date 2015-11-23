#include "TagFixup.hpp"

namespace Sentinel
{
	TagFixup::TagFixup(const uint32_t writeOffset, const uint32_t targetOffset)
		: WriteOffset(writeOffset), TargetOffset(targetOffset) {}

	bool TagFixup::operator==(const TagFixup &other) const
	{
		return WriteOffset == other.WriteOffset &&
			TargetOffset == other.TargetOffset;
	}

	bool TagFixup::operator!=(const TagFixup &other) const
	{
		return WriteOffset != other.WriteOffset ||
			TargetOffset != other.TargetOffset;
	}
}