#pragma once
#include <cstdint>
#include <iostream>

namespace Sentinel
{
	struct StringID
	{
		static const StringID Null;

		uint32_t Value;

		StringID(const uint32_t value = 0);
		StringID(int32_t set, int32_t index, int32_t length = 0);

		int32_t GetLength() const;
		int32_t GetSet() const;
		int32_t GetIndex() const;

		bool operator==(const StringID &other) const;
		bool operator!=(const StringID &other) const;

		explicit operator bool() const;

		friend std::istream &operator>>(std::istream &in, StringID &stringID);
		friend std::ostream &operator<<(std::ostream &out, StringID &string);
	};
}