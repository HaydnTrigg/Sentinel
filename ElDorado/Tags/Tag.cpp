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

		void Tag::Serialize(std::ostream &out)
		{
			out << Value;
		}

		void Tag::Deserialize(std::istream &in)
		{
			in.read((char *)&Value, 4);
		}

		bool Tag::operator==(const Tag &other)
		{
			return Value == other.Value;
		}

		bool Tag::operator!=(const Tag &other)
		{
			return Value != other.Value;
		}
	}
}
