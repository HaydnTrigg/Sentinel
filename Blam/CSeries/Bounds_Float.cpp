#include "Bounds.hpp"

namespace Blam
{
	Bounds<float>::Bounds(const float lower, const float upper)
	{
		Lower = lower;
		Upper = upper;
	}

	std::istream &operator>>(std::istream &in, Bounds<float> &bounds)
	{
		return in
			.read((char *)&bounds.Lower, 4)
			.read((char *)&bounds.Upper, 4);
	}

	std::ostream &operator<<(std::ostream &out, Bounds<float> &bounds)
	{
		return out
			.write((char *)&bounds.Lower, 4)
			.write((char *)&bounds.Upper, 4);
	}
}
