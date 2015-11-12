#pragma once
#include <iostream>
#include <Common\Serialization\Serializable.hpp>

namespace Common
{
	namespace Math
	{
		using namespace Serialization;

		class Angle : Serializable<Angle>
		{
		protected:
			float Radians;

		public:
			Angle(const float radians = 0) :
				Radians(radians)
			{
			}

			inline float GetDegrees() const
			{
				return Radians;
			}

			inline float GetRadians() const
			{
				return Radians;
			}

			void Serialize(std::ostream &out)
			{
				out << Radians;
			}

			void Deserialize(std::istream &in)
			{
				in.read((char *)&Radians, 4);
			}
		};
	}
}