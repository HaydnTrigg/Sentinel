#pragma once
#include <cstdint>
#include <iostream>
#include <Common\Math\Vector3D.hpp>
#include <Common\Serialization\Serializable.hpp>

namespace Common
{
	namespace Math
	{
		template <typename Element>
		struct Plane3D : Serializable<Plane3D<Element>>
		{
			static const size_t ElementSize = sizeof(Element) / sizeof(char);

			Vector3D<Element> Normal;
			Element D;

			Plane3D(const Vector3D<Element> &normal = Vector3D<Element>(), const Element d = (Element)1) :
				Normal(normal), D(d)
			{
			}

			void Serialize(std::ostream &out)
			{
				out << Normal << D;
			}

			void Deserialize(std::istream &in)
			{
				in >> Normal;
				in.read((char *)&D, ElementSize);
			}
		};
	}
}