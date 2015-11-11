#pragma once
#include <cstdint>
#include <iostream>
#include <ElDorado\Common\Serializable.hpp>

namespace ElDorado
{
	template <typename Element>
	struct EulerAngles2D : Serializable<EulerAngles2D<Element>>
	{
		static const size_t ElementSize = sizeof(Element) / sizeof(char);

		Element Yaw, Pitch;

		EulerAngles2D(const Element yaw, const Element pitch) :
			Yaw(yaw), Pitch(pitch)
		{
		}

		void Serialize(std::ostream &out)
		{
			out << Yaw << Pitch;
		}

		void Deserialize(std::istream &in)
		{
			in.read((char *)&Yaw, ElementSize);
			in.read((char *)&Pitch, ElementSize);
		}
	};
}
