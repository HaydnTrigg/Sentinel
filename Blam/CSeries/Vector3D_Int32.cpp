#include "Vector3D.hpp"

namespace Blam
{
	const Vector3D<int32_t> Vector3D<int32_t>::Zero(0, 0, 0);
	const Vector3D<int32_t> Vector3D<int32_t>::One(1, 1, 1);
	const Vector3D<int32_t> Vector3D<int32_t>::UnitX(1, 0, 0);
	const Vector3D<int32_t> Vector3D<int32_t>::UnitY(0, 1, 0);
	const Vector3D<int32_t> Vector3D<int32_t>::UnitZ(0, 0, 1);

	template <>
	Vector3D<int32_t>::Vector3D(const int32_t x, const int32_t y, const int32_t z)
	{
		X = x;
		Y = y;
		Z = z;
	}
}