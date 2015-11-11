#pragma once
#include <cstdint>
#include <iostream>
#include <Common\Serialization\Serializable.hpp>

namespace Common
{
	namespace Math
	{
		template <typename Element>
		struct EulerAngles3D : Serializable<EulerAngles3D<Element>>
		{
			static const size_t ElementSize = sizeof(Element) / sizeof(char);

			Element Yaw, Pitch, Roll;

			EulerAngles3D(const Element yaw, const Element pitch, const Element roll) :
				Yaw(yaw), Pitch(pitch), Roll(roll)
			{
			}

			void Serialize(std::ostream &out)
			{
				out << Yaw << Pitch << Roll;
			}

			void Deserialize(std::istream &in)
			{
				in.read((char *)&Yaw, ElementSize);
				in.read((char *)&Pitch, ElementSize);
				in.read((char *)&Roll, ElementSize);
			}
		};
	}
}