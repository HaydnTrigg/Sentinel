#include "StringIdResolverBase.hpp"

namespace ElDorado
{
	namespace Strings
	{
		int32_t StringIdResolver::StringIdToIndex(const StringId &stringId) const
		{
			auto setMin = GetMinSetStringIndex();
			auto setMax = GetMaxSetStringIndex();
			auto setOffsets = GetSetOffsets();

			auto set = stringId.GetSet();
			auto index = stringId.GetIndex();

			if (set == 0 && (index < setMin || index > setMax))
				return index;

			if (set < 0 || set >= setOffsets.size())
				return -1;

			if (set == 0)
				index -= setMin;

			return index + setOffsets[set];
		}

		StringId StringIdResolver::IndexToStringId(const int32_t index) const
		{
			if (index < 0)
				return StringId::Null;

			auto setMin = GetMinSetStringIndex();
			auto setMax = GetMaxSetStringIndex();
			auto setOffsets = GetSetOffsets();

			if (index < setMin || index > setMax)
				return StringId(0, index);

			auto set = 0;
			auto minDistance = INT32_MAX;

			for (auto i = 0; i < setOffsets.size(); i++)
			{
				if (index < setOffsets[i])
					continue;
				auto distance = index - setOffsets[i];
				if (distance >= minDistance)
					continue;
				set = i;
				minDistance = distance;
			}

			auto idIndex = index - setOffsets[set];

			if (set == 0)
				idIndex += setMin;

			return StringId(set, idIndex);
		}
	}
}
