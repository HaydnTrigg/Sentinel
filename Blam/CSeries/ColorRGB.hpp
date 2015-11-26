#pragma once
#include <cstdint>
#include <iostream>

namespace Blam
{
	template <typename Component>
	struct ColorRGB
	{
		Component Red, Green, Blue;

		ColorRGB(const Component red, const Component green, const Component blue);
		inline ColorRGB() : ColorRGB((Component)0, (Component)0, (Component)0) {}

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

		friend std::istream &operator>>(std::istream &in, ColorRGB<Component> &colorRGB);
		friend std::ostream &operator<<(std::ostream &out, ColorRGB<Component> &colorRGB);
	};
}