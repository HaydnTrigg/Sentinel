#pragma once
#include <cstdint>

namespace Blam
{
	template <typename Value>
	struct ColorARGB
	{
		static const size_t ValueSize = sizeof(Value) / sizeof(char);

		Value Alpha, Red, Green, Blue;

		ColorARGB(const Value alpha, const Value red, const Value green, const Value blue);
		inline ColorARGB() : ColorARGB((Value)1, (Value)0, (Value)0, (Value)0) {}

		inline bool operator==(const ColorARGB<Value> &other) const
		{
			return Alpha == other.Alpha &&
				Red == other.Red &&
				Green == other.Green &&
				Blue == other.Blue;
		}

		inline bool operator!=(const ColorARGB<Value> &other) const
		{
			return Alpha != other.Alpha ||
				Red != other.Red ||
				Green != other.Green ||
				Blue != other.Blue;
		}
	};
}