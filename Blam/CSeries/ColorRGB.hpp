#pragma once
#include <cstdint>
#include <iostream>

namespace Blam
{
	template <typename Value>
	struct ColorRGB
	{
		const size_t ValueSize = sizeof(Value) / sizeof(char);

		Value Red, Green, Blue;

		ColorRGB(const Value red, const Value green, const Value blue);
		inline ColorRGB() : ColorRGB((Value)0, (Value)0, (Value)0) {}

		inline bool operator==(const ColorRGB &other) const
		{
			return Red == other.Red &&
				Green == other.Green &&
				Blue == other.Blue;
		}

		inline bool operator!=(const ColorRGB &other) const
		{
			return Red != other.Red ||
				Green != other.Green ||
				Blue != other.Blue;
		}

		inline friend std::istream &operator>>(std::istream &in, ColorRGB<Value> &colorRGB)
		{
			return in
				.read((char *)&colorRGB.Red, ValueSize)
				.read((char *)&colorRGB.Green, ValueSize)
				.read((char *)&colorRGB.Blue, ValueSize)
				.seekg(ValueSize, in.cur);
		}
	};
}