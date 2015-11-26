#pragma once
#include <cstdint>
#include <iostream>

namespace Blam
{
	template <typename Component>
	struct Bounds
	{
		static const size_t ValueSize = sizeof(Component) / sizeof(char);

		Component Lower, Upper;

		Bounds(const Component lower, const Component upper);
		inline Bounds() : Bounds((Component)0, (Component)1) {}

		inline bool operator==(const Bounds<Component> &other) const
		{
			return Lower == other.Lower &&
				Upper == other.Upper;
		}

		inline bool operator!=(const Bounds<Component> &other) const
		{
			return Lower != other.Lower ||
				Upper != other.Upper;
		}

		friend std::istream &operator>>(std::istream &in, Bounds<Component> &bounds);
		friend std::ostream &operator<<(std::ostream &out, Bounds<Component> &bounds);
	};
}