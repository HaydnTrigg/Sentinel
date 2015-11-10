#pragma once
#include <cstdint>

namespace ElDorado
{
	namespace Tags
	{
		class TagFixup
		{
		public:
			TagFixup(const uint32_t writeOffset = 0, const uint32_t targetOffset = 0);

			uint32_t GetWriteOffset() const;
			uint32_t GetTargetOffset() const;

		protected:
			uint32_t WriteOffset;
			uint32_t TargetOffset;
		};
	}
}