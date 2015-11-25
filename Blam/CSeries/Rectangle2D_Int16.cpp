#include "Rectangle2D.hpp"

namespace Blam
{
	Rectangle2D<int16_t>::Rectangle2D(const int16_t top, const int16_t left, const int16_t bottom, const int16_t right)
	{
		Top = top;
		Left = left;
		Bottom = bottom;
		Right = right;
	}
}