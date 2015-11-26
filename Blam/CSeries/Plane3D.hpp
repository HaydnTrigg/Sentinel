#pragma once
#include <iostream>
#include <Blam\CSeries\Vector3D.hpp>

namespace Blam
{
	struct Plane3D
	{
		Vector3D<float> Normal;
		float Distance;

		Plane3D();
		Plane3D(const Vector3D<float> &normal, const float distance);
		Plane3D(const float x, const float y, const float z, const float distance);

		bool operator==(const Plane3D &other) const;
		bool operator!=(const Plane3D &other) const;

		friend std::istream &operator>>(std::istream &in, Plane3D &plane3D);
		friend std::ostream &operator<<(std::ostream &out, Plane3D &plane3D);
	};
}