#include "TagEntry.hpp"

namespace ElDorado
{
	namespace Tags
	{
		TagEntry::TagEntry(const int32_t index) :
			Index(index),
			GroupTag((Tag &)Tag::Null),
			ParentGroupTag((Tag &)Tag::Null),
			GrandparentGroupTag((Tag &)Tag::Null),
			GroupNameId((StringId &)StringId::Null)
		{
		}

		std::istream &operator>>(std::istream &in, TagEntry &tagEntry)
		{
			return in;
		}
	}
}