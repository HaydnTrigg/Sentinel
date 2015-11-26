#include "Rectangle2D.hpp"

namespace Blam
{
	Rectangle2D<int16_t>::Rectangle2D(const Bounds<int16_t> &x, const Bounds<int16_t> &y)
	{
		X = x;
		Y = y;
	}

	std::istream &operator>>(std::istream &in, Rectangle2D<int16_t> &rectangle2D)
	{
		return in
			.read((char *)&rectangle2D.X.Lower, 2)
			.read((char *)&rectangle2D.Y.Lower, 2)
			.read((char *)&rectangle2D.X.Upper, 2)
			.read((char *)&rectangle2D.Y.Upper, 2);
	}

	std::ostream &operator<<(std::ostream &out, Rectangle2D<int16_t> &rectangle2D)
	{
		return out
			.write((char *)&rectangle2D.X.Lower, 2)
			.write((char *)&rectangle2D.Y.Lower, 2)
			.write((char *)&rectangle2D.X.Upper, 2)
			.write((char *)&rectangle2D.Y.Upper, 2);
	}
}