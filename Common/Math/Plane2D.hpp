#pragma once
#include <cstdint>
#include <iostream>
#include <Common\Math\Vector2D.hpp>
#include <Common\Serialization\Serializable.hpp>

namespace Common
{
	namespace Math
	{
		template <typename Element>
		struct Plane2D : Serializable<Plane2D<Element>>
		{
			static const size_t ElementSize = sizeof(Element) / sizeof(char);

			Vector3D<Element> Normal;
			Element D;

			Plane2D(const Vector2D<Element> &normal = Vector2D<Element>(), const Element d = (Element)1) :
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