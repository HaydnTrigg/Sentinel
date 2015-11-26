#include "Quaternion.hpp"

namespace Blam
{
	Quaternion::Quaternion(const float x, const float y, const float z, const float w)
	{
		X = x;
		Y = y;
		Z = z;
		W = w;
	}

	bool Quaternion::operator==(const Quaternion &other) const
	{
		return X == other.X &&
			Y == other.Y &&
			Z == other.Z &&
			W == other.W;
	}

	bool Quaternion::operator!=(const Quaternion &other) const
	{
		return X != other.X ||
			Y != other.Y ||
			Z != other.Z ||
			W != other.W;
	}

	std::istream &operator>>(std::istream &in, Quaternion &quaternion)
	{
		return in
			.read((char *)&quaternion.X, 4)
			.read((char *)&quaternion.Y, 4)
			.read((char *)&quaternion.Z, 4)
			.read((char *)&quaternion.W, 4);
	}

	std::ostream &operator<<(std::ostream &out, Quaternion &quaternion)
	{
		return out
			.write((char *)&quaternion.X, 4)
			.write((char *)&quaternion.Y, 4)
			.write((char *)&quaternion.Z, 4)
			.write((char *)&quaternion.W, 4);
	}
}