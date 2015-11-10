#pragma once
#include <cstdint>
#include <vector>
#include <ElDorado\Strings\StringId.hpp>

namespace ElDorado
{
	namespace Strings
	{
		class StringIdResolver
		{
		public:
			int StringIdToIndex(const StringId &stringId) const;
			StringId IndexToStringId(const int32_t index) const;

			virtual int32_t GetMinSetStringIndex() const = 0;
			virtual int32_t GetMaxSetStringIndex() const = 0;
			virtual std::vector<int32_t> &GetSetOffsets() const = 0;

		protected:

		};
	}
}