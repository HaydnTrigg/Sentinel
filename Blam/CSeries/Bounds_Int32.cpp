#include "Bounds.hpp"

namespace Blam
{
	Bounds<int32_t>::Bounds(const int32_t lower, const int32_t upper)
	{
		Lower = lower;
		Upper = upper;
	}
}
