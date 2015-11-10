#pragma once
#include <cstdint>
#include <iostream>

namespace ElDorado
{
	namespace Strings
	{
		class StringId
		{
		public:
			static const StringId Null;

			StringId(const uint32_t value);
			StringId(const int32_t length, const int32_t set, const int32_t index);
			StringId(const int32_t set, const int32_t index);

			uint32_t GetValue() const;
			int32_t GetLength() const;
			int32_t GetSet() const;
			int32_t GetIndex() const;

			bool operator==(const StringId &other);
			bool operator!=(const StringId &other);

			friend std::istream &operator>>(std::istream &in, StringId &stringId);

		protected:
			uint32_t Value;
		};
	}
}
