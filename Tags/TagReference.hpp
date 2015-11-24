#pragma once
#include <cstdint>
#include <iostream>
#include <Common\Tag.hpp>

namespace Sentinel
{
	struct TagReference
	{
		Tag GroupTag;
		uint32_t TagIndex;

		TagReference(const Tag &groupTag = Tag::Null, const uint32_t tagIndex = 0);

		bool operator==(const TagReference &other) const;
		bool operator!=(const TagReference &other) const;

		explicit operator bool() const;

		friend std::istream &operator>>(std::istream &in, TagReference &tagReference);
		friend std::ostream &operator<<(std::ostream &out, TagReference &tagReference);
	};
}
