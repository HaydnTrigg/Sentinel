#pragma once
#include <cstdint>
#include <exception>
#include <iostream>
#include <Common\StringID.hpp>
#include <Common\Tag.hpp>
#include <Tags\TagFixup.hpp>

namespace Sentinel
{
	struct TagInstance
	{
		int32_t Index;
		Tag GroupTag;
		Tag ParentGroupTag;
		Tag GrandparentGroupTag;
		StringID GroupName;
		uint32_t DataOffset;
		uint32_t DataSize;
		uint32_t DefinitionOffset;
		uint32_t Checksum;
		int16_t DependencyCount;
		int32_t *Dependencies;
		int16_t DataFixupCount;
		TagFixup *DataFixups;
		int16_t ResourceFixupCount;
		TagFixup *ResourceFixups;

		TagInstance();

		bool InGroup(const Tag &groupTag) const;

		bool operator==(const TagInstance &other) const;
		bool operator!=(const TagInstance &other) const;

		explicit operator bool() const;

		friend std::istream &operator>>(std::istream &in, TagInstance &tagInstance);
		friend std::ostream &operator<<(std::ostream &out, TagInstance &tagInstance);
	};
}
