#include "Bounds.hpp"

namespace Blam
{
	Bounds<uint8_t>::Bounds(const uint8_t lower, const uint8_t upper)
	{
		Lower = lower;
		Upper = upper;
	}
}
