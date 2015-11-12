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
		struct Quaternion : Serializable<Quaternion<Element>>
		{
			static const size_t ElementSize = sizeof(Element) / sizeof(char);

			Vector3D<Element> Vector;
			Element W;

			Quaternion
			(
				const Vector3D<Element> &vector = Vector3D<Element>(),
				const Element w = (Element)1
			) :
				Vector(vector), W(w)
			{
			}

			void Serialize(std::ostream &out)
			{
				out << Vector << W;
			}

			void Deserialize(std::istream &in)
			{
				in >> Vector;
				in.read((char *)&W, size);
			}
		};
	}
}
