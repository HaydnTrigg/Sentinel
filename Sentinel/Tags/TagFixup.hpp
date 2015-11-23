#pragma once
#include <cstdint>

namespace Sentinel
{
	struct TagFixup
	{
		uint32_t WriteOffset;
		uint32_t TargetOffset;

		TagFixup(const uint32_t writeOffset = 0, const uint32_t targetOffset = 0);

		bool operator==(const TagFixup &other) const;
		bool operator!=(const TagFixup &other) const;
	};
}