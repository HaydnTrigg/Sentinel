#include "Bounds.hpp"

namespace Blam
{
	Bounds<int8_t>::Bounds(const int8_t lower, const int8_t upper)
	{
		Lower = lower;
		Upper = upper;
	}
}
