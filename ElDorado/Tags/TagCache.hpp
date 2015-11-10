#pragma once
#include <vector>
#include <ElDorado\Tags\TagDefinition.hpp>

namespace ElDorado
{
	namespace Tags
	{
		class TagCache
		{
		public:
			TagCache();

		protected:
			std::vector<TagDefinition> TagDefinitions;

		};
	}
}
