#include "Tag.hpp"

namespace ElDorado
{
	namespace Tags
	{
		const Tag Tag::Null('ÿÿÿÿ');

		Tag::Tag(const uint32_t value) :
			Value(value)
		{
		}

		uint32_t Tag::GetValue() const
		{
			return Value;
		}

		bool Tag::operator==(const Tag &other)
		{
			return Value == other.Value;
		}

		bool Tag::operator!=(const Tag &other)
		{
			return Value != other.Value;
		}

		std::istream &operator>>(std::istream &in, Tag &tag)
		{
			return in.read((char *)&tag.Value, 4);
		}
	}
}
