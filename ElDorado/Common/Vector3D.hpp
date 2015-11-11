#pragma once
#include <cstdint>
#include <iostream>
#include <ElDorado\Common\Serializable.hpp>

namespace ElDorado
{
	template <typename Element>
	struct Vector3D : Serializable<Vector3D<Element>>
	{
		static const size_t ElementSize = sizeof(Element) / sizeof(char);

		Element I, J, K;

		Vector3D(const Element i = (Element)0, const Element j = (Element)0, const Element k = (Element)0) :
			I(i), J(j), K(k)
		{
		}

		void Serialize(std::ostream &out)
		{
			out << I << J << K;
		}

		void Deserialize(std::istream &in)
		{
			in.read((char *)&I, ElementSize);
			in.read((char *)&J, ElementSize);
			in.read((char *)&K, ElementSize);
		}
	};
}