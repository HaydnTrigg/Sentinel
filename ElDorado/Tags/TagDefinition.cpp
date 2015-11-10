#include "TagDefinition.hpp"

namespace ElDorado
{
	namespace Tags
	{
		TagDefinition::TagDefinition() :
			GroupTag((Tag &)Tag::Null),
			ParentGroupTag((Tag &)Tag::Null),
			GrandparentGroupTag((Tag &)Tag::Null),
			GroupNameId((StringId &)StringId::Null)
		{
		}
	}
}