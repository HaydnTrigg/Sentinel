#pragma once
#include <iostream>

namespace Blam
{
	struct Angle
	{
		float Radians;

		Angle(const float radians = 0.0f);

		bool operator==(const Angle &other) const;
		bool operator!=(const Angle &other) const;

		friend std::istream &operator>>(std::istream &in, Angle &angle);
		friend std::ostream &operator<<(std::ostream &out, Angle &angle);
	};
}