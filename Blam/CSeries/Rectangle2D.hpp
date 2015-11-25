#pragma once
#include <cstdint>

namespace Blam
{
	template <typename Component>
	struct Rectangle2D
	{
		static const size_t ComponentSize = sizeof(Component) / sizeof(char);

		Component Top, Left, Bottom, Right;

		Rectangle2D(const Component top, const Component left, const Component bottom, const Component right);
		inline Rectangle2D() : Rectangle2D((Component)0, (Component)0, (Component)0, (Component)0) {}

		inline bool operator==(const Rectangle2D<Component> &other) const
		{
			return Top == other.Top &&
				Left == other.Left &&
				Bottom == other.Bottom &&
				Right == other.Right;
		}

		inline bool operator!=(const Rectangle2D<Component> &other) const
		{
			return Top != other.Top ||
				Left != other.Left ||
				Bottom != other.Bottom ||
				Right != other.Right;
		}
	};
}