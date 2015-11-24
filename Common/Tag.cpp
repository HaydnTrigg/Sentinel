#include "Tag.hpp"

namespace Sentinel
{
	const Tag Tag::Null((uint32_t)-1);

	Tag::Tag(const uint32_t value)
		: Value(value) {}

	bool Tag::operator==(const Tag &other) const
	{
		return Value == other.Value;
	}

	bool Tag::operator!=(const Tag &other) const
	{
		return Value != other.Value;
	}

	Tag::operator bool() const
	{
		return Value != Null.Value;
	}

	std::istream &operator>>(std::istream &in, Tag &tag)
	{
		return in.read((char *)&tag.Value, 4);
	}

	std::ostream &operator<<(std::ostream &out, Tag &tag)
	{
		return out.write((char *)&tag.Value, 4);
	}
}