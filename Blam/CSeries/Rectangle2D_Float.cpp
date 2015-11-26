#include "Rectangle2D.hpp"

namespace Blam
{
	Rectangle2D<float>::Rectangle2D(const Bounds<float> &x, const Bounds<float> &y)
	{
		X = x;
		Y = y;
	}

	std::istream &operator>>(std::istream &in, Rectangle2D<float> &rectangle2D)
	{
		return in >>
			rectangle2D.X >>
			rectangle2D.Y;
	}

	std::ostream &operator<<(std::ostream &out, Rectangle2D<float> &rectangle2D)
	{
		return out <<
			rectangle2D.X <<
			rectangle2D.Y;
	}
}