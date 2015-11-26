#include "Angle.hpp"
#include "Bounds.hpp"

namespace Blam
{
	Bounds<Angle>::Bounds(const Angle lower, const Angle upper)
	{
		Lower = lower;
		Upper = upper;
	}
}