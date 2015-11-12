#pragma once
#include <cstdint>
#include <iostream>
#include <Common\Math\Bounds.hpp>
#include <Common\Serialization\Serializable.hpp>

namespace Common
{
	namespace Math
	{
		using namespace Serialization;

		template <typename Element>
		struct Rectangle2D : Serializable<Rectangle2D<Element>>
		{
			static const size_t ElementSize = sizeof(Element) / sizeof(char);

			Bounds<Element> X, Y;

			Rectangle2D
			(
				const Bounds<Element> &x = Bounds<Element>(),
				const Bounds<Element> &y = Bounds<Element>()
			) :
				X(x), Y(y)
			{
			}

			void Serialize(std::ostream &out)
			{
				out << X << Y;
			}

			void Deserialize(std::istream &in)
			{
				in >> X >> Y;
			}
		};
	}
}