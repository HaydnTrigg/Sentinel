#pragma once
#include <cstdint>
#include <iostream>

namespace ElDorado
{
	namespace Tags
	{
		class Tag
		{
		public:
			static const Tag Null;

			Tag(const uint32_t value);

			uint32_t GetValue() const;

			bool operator==(const Tag &other);
			bool operator!=(const Tag &other);

			friend std::istream &operator>>(std::istream &in, Tag &tag);

		protected:
			uint32_t Value;
		};
	}
}
