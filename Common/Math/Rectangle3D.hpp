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
		struct Rectangle3D : Serializable<Rectangle3D<Element>>
		{
			static const size_t ElementSize = sizeof(Element) / sizeof(char);

			Bounds<Element> X, Y, Z;

			Rectangle3D
			(
				const Bounds<Element> &x = Bounds<Element>(),
				const Bounds<Element> &y = Bounds<Element>(),
				const Bounds<Element> &z = Bounds<Element>()
			) :
				X(x), Y(y) Z(z)
			{
			}

			void Serialize(std::ostream &out)
			{
				out << X << Y << Z;
			}

			void Deserialize(std::istream &in)
			{
				in >> X >> Y >> Z;
			}
		};
	}
}