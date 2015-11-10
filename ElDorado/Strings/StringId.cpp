#include "StringId.hpp"

namespace ElDorado
{
	namespace Strings
	{
		const StringId StringId::Null(0);

		StringId::StringId(const uint32_t value) :
			Value(value)
		{
		}

		StringId::StringId(const int32_t l, const int32_t s, const int32_t i) :
			StringId((uint32_t)(((l & 0xFF) << 24) | ((s & 0xFF) << 16) | (i & 0xFFFF)))
		{
		}

		StringId::StringId(const int32_t set, const int32_t index) :
			StringId(0, set, index)
		{
		}

		uint32_t StringId::GetValue() const
		{
			return Value;
		}

		int32_t StringId::GetLength() const
		{
			return ((Value >> 24) & 0xFF);
		}

		int32_t StringId::GetSet() const
		{
			return ((Value >> 16) & 0xFF);
		}

		int32_t StringId::GetIndex() const
		{
			return (Value & 0xFFFF);
		}

		bool StringId::operator==(const StringId &other)
		{
			return Value == other.Value;
		}

		bool StringId::operator!=(const StringId &other)
		{
			return Value != other.Value;
		}

		std::istream &operator>>(std::istream &in, StringId &stringId)
		{
			return in.read((char *)stringId.Value, 4);
		}
	}
}
