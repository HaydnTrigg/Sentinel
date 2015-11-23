#include "TagReference.hpp"

namespace Sentinel
{
	TagReference::TagReference(const Tag &groupTag, const uint32_t tagIndex)
		: GroupTag(groupTag), TagIndex(tagIndex) {}

	bool TagReference::operator==(const TagReference &other) const
	{
		return GroupTag == other.GroupTag &&
			TagIndex == other.TagIndex;
	}

	bool TagReference::operator!=(const TagReference &other) const
	{
		return GroupTag != other.GroupTag ||
			TagIndex != other.TagIndex;
	}

	TagReference::operator bool() const
	{
		return GroupTag != Tag::Null && TagIndex != 0;
	}

	std::istream &operator>>(std::istream &in, TagReference &tagReference)
	{
		in >> tagReference.GroupTag;
		in.seekg(4, in.cur); // unused32 @ 0x4
		in.seekg(4, in.cur); // unused32 @ 0x8
		in.read((char *)&tagReference.TagIndex, 4);
		return in;
	}

	std::ostream &operator<<(std::ostream &out, TagReference &tagReference)
	{
		out << tagReference.GroupTag;
		out.write('\0\0\0\0', 4); // unused32 @ 0x4
		out.write('\0\0\0\0', 4); // unused32 @ 0x8
		out.write((char *)&tagReference.TagIndex, 4);
		return out;
	}
}