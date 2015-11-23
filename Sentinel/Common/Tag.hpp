#pragma once
#include <cstdint>
#include <iostream>

namespace Sentinel
{
	struct Tag
	{
		static const Tag Null;

		uint32_t Value;

		Tag(const uint32_t value);

		bool operator==(const Tag &other) const;
		bool operator!=(const Tag &other) const;

		explicit operator bool() const;

		friend std::istream &operator>>(std::istream &in, Tag &tag);
		friend std::ostream &operator<<(std::ostream &out, Tag &tag);
	};
}
