#include "Rectangle3D.hpp"

namespace Blam
{
	template <>
	Rectangle3D<float>::Rectangle3D(const Bounds<float> &x, const Bounds<float> &y, const Bounds<float> &z)
	{
		X = x;
		Y = y;
		Z = z;
	}
}