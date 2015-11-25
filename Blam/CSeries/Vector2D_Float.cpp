#include "Vector2D.hpp"

namespace Blam
{
	const Vector2D<float> Vector2D<float>::Zero(0, 0);
	const Vector2D<float> Vector2D<float>::One(1, 1);
	const Vector2D<float> Vector2D<float>::UnitX(1, 0);
	const Vector2D<float> Vector2D<float>::UnitY(0, 1);

	template <>
	Vector2D<float>::Vector2D(const float x, const float y)
	{
		X = x;
		Y = y;
	}
}