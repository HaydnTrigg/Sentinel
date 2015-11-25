#include "StringID.hpp"

namespace Blam
{
	const StringID StringID::Null(0);

	StringID::StringID(const uint32_t value)
		: Value(value) {}

	StringID::StringID(const int32_t s, const int32_t i, const int32_t l)
		: Value(((l & 0xFF) << 24) | ((s & 0xFF) << 16) | (i & 0xFFFF)) {}

	int32_t StringID::GetLength() const
	{
		return ((Value >> 24) & 0xFF);
	}

	int32_t StringID::GetSet() const
	{
		return ((Value >> 16) & 0xFF);
	}

	int32_t StringID::GetIndex() const
	{
		return (Value & 0xFFFF);
	}

	bool StringID::operator==(const StringID &other) const
	{
		return Value == other.Value;
	}

	bool StringID::operator!=(const StringID &other) const
	{
		return Value != other.Value;
	}

	StringID::operator bool() const
	{
		return Value != Null.Value;
	}

	std::istream &operator>>(std::istream &in, StringID &stringID)
	{
		return in.read((char *)&stringID.Value, 4);
	}

	std::ostream &operator<<(std::ostream &out, StringID &stringID)
	{
		return out.write((char *)&stringID.Value, 4);
	}
}
