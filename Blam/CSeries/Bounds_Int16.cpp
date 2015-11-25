#include "Bounds.hpp"

namespace Blam
{
	Bounds<int16_t>::Bounds(const int16_t lower, const int16_t upper)
	{
		Lower = lower;
		Upper = upper;
	}
}
