#pragma once
#include <cstdint>
#include <iostream>
#include <ElDorado\Common\Serializable.hpp>

namespace ElDorado
{
	template <typename Element>
	struct Vector2D : Serializable<Vector2D<Element>>
	{
		static const size_t ElementSize = sizeof(Element) / sizeof(char);

		Element X, Y;

		Vector2D(const Element x = (Element)0, const Element y = (Element)0) :
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
