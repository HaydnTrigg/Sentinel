#pragma once
#include <iostream>
#include <Blam\CSeries\Vector3D.hpp>
#include <Blam\CSeries\Quaternion.hpp>

namespace Blam
{
	struct Orientation3D
	{
		Quaternion Rotation;
		Vector3D<float> Translation;
		float Scale;

		Orientation3D(const Quaternion &rotation, const Vector3D<float> &translation, const float scale);
		inline Orientation3D() : Orientation3D(Quaternion(), Vector3D<float>(), 1.0f) {}

		bool operator==(const Orientation3D &other) const;
		bool operator!=(const Orientation3D &other) const;

		friend std::istream &operator>>(std::istream &in, Orientation3D &orientation3D);
		friend std::ostream &operator<<(std::ostream &out, Orientation3D &orientation3D);
	};
}