#include "Bounds.hpp"

namespace Blam
{
	Bounds<uint16_t>::Bounds(const uint16_t lower, const uint16_t upper)
	{
		Lower = lower;
		Upper = upper;
	}
}
