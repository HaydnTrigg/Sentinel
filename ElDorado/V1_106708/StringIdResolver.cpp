#include "StringIdResolver.hpp"

namespace ElDorado
{
	namespace V1_106708
	{
		StringIdResolver::StringIdResolver() {}

		int32_t StringIdResolver::GetMinSetStringIndex() const
		{
			return 0x1;
		}

		int32_t StringIdResolver::GetMaxSetStringIndex() const
		{
			return 0xF1E;
		}

		static std::vector<int32_t> SetOffsets;

		std::vector<int32_t> &StringIdResolver::GetSetOffsets() const
		{
			return SetOffsets;
		}
	}
}
