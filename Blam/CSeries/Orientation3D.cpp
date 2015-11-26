#include "Orientation3D.hpp"

namespace Blam
{
	Orientation3D::Orientation3D(const Quaternion &rotation, const Vector3D<float> &translation, const float scale)
	{
		Rotation = rotation;
		Translation = translation;
		Scale = scale;
	}

	bool Orientation3D::operator==(const Orientation3D &other) const
	{
		return Rotation == other.Rotation &&
			Translation == other.Translation &&
			Scale == other.Scale;
	}

	bool Orientation3D::operator!=(const Orientation3D &other) const
	{
		return Rotation != other.Rotation ||
			Translation != other.Translation ||
			Scale != other.Scale;
	}

	std::istream &operator>>(std::istream &in, Orientation3D &orientation3D)
	{
		return (in >>
			orientation3D.Rotation >>
			orientation3D.Translation)
			.read((char *)&orientation3D.Scale, 4);
	}

	std::ostream &operator<<(std::ostream &out, Orientation3D &orientation3D)
	{
		return (out <<
			orientation3D.Rotation <<
			orientation3D.Translation)
			.write((char *)&orientation3D.Scale, 4);
	}
}