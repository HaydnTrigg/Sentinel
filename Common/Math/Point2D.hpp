#pragma once
#include <cstdint>
#include <iostream>
#include <Common\Serialization\Serializable.hpp>

namespace Common
{
	namespace Math
	{
		template <typename Element>
		struct Point2D : Serializable<Point2D<Element>>
		{
			static const size_t ElementSize = sizeof(Element) / sizeof(char);

			Element X, Y, Z;

			Point2D
			(
				const Element x = (Element)0,
				const Element y = (Element)0
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
				in.read((char *)&X, ElementSize);
				in.read((char *)&Y, ElementSize);
			}
		};
	}
}
