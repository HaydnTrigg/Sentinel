#pragma once
#include <iostream>

namespace Blam
{
	struct Quaternion
	{
		float X, Y, Z, W;

		Quaternion(const float x, const float y, const float z, const float w);
		inline Quaternion() : Quaternion(0.0f, 0.0f, 0.0f, 1.0f) {}

		bool operator==(const Quaternion &other) const;
		bool operator!=(const Quaternion &other) const;

		friend std::istream &operator>>(std::istream &in, Quaternion &quaternion);
		friend std::ostream &operator<<(std::ostream &out, Quaternion &quaternion);
	};
}