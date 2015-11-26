#pragma once
#include <iostream>
#include <Blam\CSeries\Vector2D.hpp>

namespace Blam
{
	struct Plane2D
	{
		Vector2D<float> Normal;
		float Distance;

		Plane2D();
		Plane2D(const Vector2D<float> &normal, const float distance);
		Plane2D(const float x, const float y, const float distance);

		bool operator==(const Plane2D &other) const;
		bool operator!=(const Plane2D &other) const;

		friend std::istream &operator>>(std::istream &in, Plane2D &plane2D);
		friend std::ostream &operator<<(std::ostream &out, Plane2D &plane2D);
	};
}