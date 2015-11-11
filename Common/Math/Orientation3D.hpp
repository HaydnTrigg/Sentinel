#pragma once
#include <cstdint>
#include <iostream>
#include <Common\Serialization\Serializable.hpp>
#include <ElDorado\Common\Point3D.hpp>
#include <ElDorado\Common\Quaternion.hpp>

namespace Common
{
	namespace Math
	{
		template <typename Element>
		struct Orientation3D : Serializable<Orientation3D<Element>>
		{
			static const size_t ElementSize = sizeof(Element) / sizeof(char);

			Quaternion<Element> Rotation;
			Point3D<Element> Translation;
			Element Scale;

			Orientation3D(
				const Quaternion<Element> &rotation = Quaternion<Element>(),
				const Point3D<Element> &translation = Point3D<Element>(),
				const Element scale = (Element)1) :
				Rotation(rotation), Translation(translation), Scale(scale)
			{
			}

			void Serialize(std::ostream &out)
			{
				out << Rotation << Translation << Scale;
			}

			void Deserialize(std::istream &in)
			{
				in >> Rotation >> Translation;
				in.read((char *)&Scale, ElementSize);
			}
		};
	}
}