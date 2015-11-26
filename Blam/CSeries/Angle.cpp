#include "Angle.hpp"

namespace Blam
{
	Angle::Angle(const float radians)
	{
		Radians = radians;
	}

	bool Angle::operator==(const Angle &other) const
	{
		return Radians == other.Radians;
	}

	bool Angle::operator!=(const Angle &other) const
	{
		return Radians != other.Radians;
	}

	std::istream &operator>>(std::istream &in, Angle &angle)
	{
		return in.read((char *)&angle.Radians, 4);
	}

	std::ostream &operator<<(std::ostream &out, Angle &angle)
	{
		return out.write((char *)&angle.Radians, 4);
	}
}