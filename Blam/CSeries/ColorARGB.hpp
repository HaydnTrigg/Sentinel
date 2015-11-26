#pragma once
#include <cstdint>
#include <iostream>

namespace Blam
{
	template <typename Component>
	struct ColorARGB
	{
		static const size_t ValueSize = sizeof(Component) / sizeof(char);

		Component Alpha, Red, Green, Blue;

		ColorARGB(const Component alpha, const Component red, const Component green, const Component blue);
		inline ColorARGB() : ColorARGB((Component)1, (Component)0, (Component)0, (Component)0) {}

		inline bool operator==(const ColorARGB<Component> &other) const
		{
			return Alpha == other.Alpha &&
				Red == other.Red &&
				Green == other.Green &&
				Blue == other.Blue;
		}

		inline bool operator!=(const ColorARGB<Component> &other) const
		{
			return Alpha != other.Alpha ||
				Red != other.Red ||
				Green != other.Green ||
				Blue != other.Blue;
		}

		friend std::istream &operator>>(std::istream &in, ColorARGB<Component> &colorARGB);
		friend std::ostream &operator<<(std::ostream &out, ColorARGB<Component> &colorARGB);
	};
}