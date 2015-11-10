#pragma once
#include <cstdint>

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

		protected:
			uint32_t Value;
		};
	}
}
