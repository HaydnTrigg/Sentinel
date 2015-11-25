#include "Vector3D.hpp"

namespace Blam
{
	const Vector3D<float> Vector3D<float>::Zero(0.0f, 0.0f, 0.0f);
	const Vector3D<float> Vector3D<float>::One(1.0f, 1.0f, 1.0f);
	const Vector3D<float> Vector3D<float>::UnitX(1.0f, 0.0f, 0.0f);
	const Vector3D<float> Vector3D<float>::UnitY(0.0f, 1.0f, 0.0f);
	const Vector3D<float> Vector3D<float>::UnitZ(0.0f, 0.0f, 1.0f);

	template <>
	Vector3D<float>::Vector3D(const float x, const float y, const float z)
	{
		X = x;
		Y = y;
		Z = z;
	}
}