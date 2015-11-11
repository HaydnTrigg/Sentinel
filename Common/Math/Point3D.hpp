#pragma once
#include <cstdint>
#include <iostream>
#include <Common\Serialization\Serializable.hpp>

namespace Common
{
	namespace Math
	{
		template <typename Element>
		struct Point3D : Serializable<Point3D<Element>>
		{
			static const size_t ElementSize = sizeof(Element) / sizeof(char);

			Element X, Y, Z;

			Point3D(const Element x = (Element)0, const Element y = (Element)0, const Element z = (Element)0) :
				X(x), Y(y), Z(z)
			{
			}

			void Serialize(std::ostream &out)
			{
				out << X << Y << Z;
			}

			void Deserialize(std::istream &in)
			{
				in.read((char *)&X, ElementSize);
				in.read((char *)&Y, ElementSize);
				in.read((char *)&Z, ElementSize);
			}
		};
	}
}
