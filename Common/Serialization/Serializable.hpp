#pragma once
#include <iostream>

namespace Common
{
	namespace Serialization
	{
		template <typename Type>
		struct Serializable
		{
			virtual void Serialize(std::ostream &out) = 0;
			virtual void Deserialize(std::istream &in) = 0;

			inline friend std::ostream &operator<<(std::ostream &out, Type &value)
			{
				value.Serialize(out);
				return out;
			}

			friend std::istream &operator>>(std::istream &in, Type &value)
			{
				value.Deserialize(in);
				return in;
			}
		};
	}
}
