#include "Vector2D.hpp"

namespace Blam
{
	const Vector2D<int32_t> Vector2D<int32_t>::Zero(0, 0);
	const Vector2D<int32_t> Vector2D<int32_t>::One(1, 1);
	const Vector2D<int32_t> Vector2D<int32_t>::UnitX(1, 0);
	const Vector2D<int32_t> Vector2D<int32_t>::UnitY(0, 1);

	template <>
	Vector2D<int32_t>::Vector2D(const int32_t x, const int32_t y)
	{
		X = x;
		Y = y;
	}
}