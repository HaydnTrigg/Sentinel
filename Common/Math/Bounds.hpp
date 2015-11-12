#pragma once
#include <cstdint>
#include <iostream>
#include <Common\Serialization\Serializable.hpp>

namespace Common
{
	namespace Math
	{
		using namespace Serialization;

		template <typename Element>
		struct Bounds : Serializable<Bounds<Element>>
		{
			static const size_t ElementSize = sizeof(Element) / sizeof(char);

			Element Lower, Upper;

			Bounds
			(
				const Element lower = (Element)0,
				const Element upper = (Element)1
			) :
				Lower(lower), Upper(upper)
			{
			}

			void Serialize(std::ostream &out)
			{
				out << Lower << Upper;
			}

			void Deserialize(std::istream &in)
			{
				in.read((char *)&Lower, ElementSize);
				in.read((char *)&Upper, ElementSize);
			}
		};
	}
}