#pragma once
#include <cstdint>

namespace Blam
{
	template <typename Value>
	struct Bounds
	{
		static const size_t ValueSize = sizeof(Value) / sizeof(char);

		Value Lower, Upper;

		Bounds(const Value lower, const Value upper);
		inline Bounds() : Bounds((Value)0, (Value)1) {}

		inline bool operator==(const Bounds<Value> &other) const
		{
			return Lower == other.Lower &&
				Upper == other.Upper;
		}

		inline bool operator!=(const Bounds<Value> &other) const
		{
			return Lower != other.Lower ||
				Upper != other.Upper;
		}
	};
}