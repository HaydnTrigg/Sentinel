#include "Bounds.hpp"

namespace Blam
{
	Bounds<uint32_t>::Bounds(const uint32_t lower, const uint32_t upper)
	{
		Lower = lower;
		Upper = upper;
	}
}
