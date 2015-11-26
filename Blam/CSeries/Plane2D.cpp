#include "Plane2D.hpp"

namespace Blam
{
	Plane2D::Plane2D()
		: Plane2D(0.0f, 0.0f, 0.0f) {}

	Plane2D::Plane2D(const Vector2D<float> &normal, const float distance)
		: Normal(normal), Distance(distance) {}

	Plane2D::Plane2D(const float x, const float y, const float distance)
		: Normal(x, y), Distance(distance) {}

	bool Plane2D::operator==(const Plane2D &other) const
	{
		return Normal == other.Normal &&
			Distance == other.Distance;
	}

	bool Plane2D::operator!=(const Plane2D &other) const
	{
		return Normal != other.Normal ||
			Distance != other.Distance;
	}

	std::istream &operator>>(std::istream &in, Plane2D &plane2D)
	{
		return (in >> plane2D.Normal).read((char *)&plane2D.Distance, 4);
	}

	std::ostream &operator<<(std::ostream &out, Plane2D &plane2D)
	{
		return (out << plane2D.Normal).write((char *)&plane2D.Distance, 4);
	}
}