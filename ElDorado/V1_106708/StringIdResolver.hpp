#pragma once
#include <cstdint>
#include <vector>
#include <ElDorado\Strings\StringIdResolverBase.hpp>

namespace ElDorado
{
	namespace V1_106708
	{
		class StringIdResolver : public Strings::StringIdResolver
		{
		public:
			StringIdResolver();

			int32_t GetMinSetStringIndex() const;
			int32_t GetMaxSetStringIndex() const;
			std::vector<int32_t> &GetSetOffsets() const;
		};
	}
}
