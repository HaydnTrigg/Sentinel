#pragma once
#include <cstdint>
#include <iostream>
#include <Blam\CSeries\Bounds.hpp>

namespace Blam
{
	template <typename Component>
	struct Rectangle3D
	{
		const size_t ComponentSize = sizeof(Component) / sizeof(char);

		Bounds<Component> X, Y, Z;

		Rectangle3D(const Bounds<Component> &x, const Bounds<Component> &y, const Bounds<Component> &z);
		inline Rectangle3D() : Rectangle3D(Bounds<Component>(), Bounds<Component>(), Bounds<Component>()) {}

		inline bool operator==(const Rectangle3D<Component> &other) const
		{
			return X == other.X &&
				Y == other.Y &&
				Z == other.Z;
		}

		inline bool operator!=(const Rectangle3D<Component> &other) const
		{
			return X != other.X ||
				Y != other.Y ||
				Z != other.Z;
		}

		inline friend std::istream &operator>>(std::istream &in, Rectangle3D<Component> &rectangle3D)
		{
			return in >>
				rectangle3D.X >>
				rectangle3D.Y >>
				rectangle3D.Z;
		}

		inline friend std::ostream &operator<<(std::ostream &out, Rectangle3D<Component> &rectangle3D)
		{
			return out <<
				rectangle3D.X <<
				rectangle3D.Y <<
				rectangle3D.Z;
		}
	};
}