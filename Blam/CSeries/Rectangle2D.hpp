#pragma once
#include <cstdint>
#include <iostream>
#include <Blam\CSeries\Bounds.hpp>

namespace Blam
{
	template <typename Component>
	struct Rectangle2D
	{
		static const size_t ComponentSize = sizeof(Component) / sizeof(char);

		Bounds<Component> X, Y;

		Rectangle2D(const Bounds<Component> &x, const Bounds<Component> &y);
		inline Rectangle2D() : Rectangle2D(Bounds<Component>(), Bounds<Component>()) {}

		inline bool operator==(const Rectangle2D<Component> &other) const
		{
			return X == other.X &&
				Y == other.Y;
		}

		inline bool operator!=(const Rectangle2D<Component> &other) const
		{
			return X != other.X ||
				Y != other.Y;
		}

		friend std::istream &operator>>(std::istream &in, Rectangle2D<Component> &rectangle2D);
		friend std::ostream &operator<<(std::ostream &out, Rectangle2D<Component> &rectangle2D);
	};
}