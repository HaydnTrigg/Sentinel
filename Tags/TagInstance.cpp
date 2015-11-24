#include "TagInstance.hpp"

namespace Sentinel
{
	TagInstance::TagInstance()
		: Index(-1),
		GroupTag(Tag::Null),
		ParentGroupTag(Tag::Null),
		GrandparentGroupTag(Tag::Null),
		DependencyCount(-1),
		Dependencies(nullptr),
		DataFixupCount(-1),
		DataFixups(nullptr),
		ResourceFixupCount(-1),
		ResourceFixups(nullptr) {}

	bool TagInstance::InGroup(const Tag &groupTag) const
	{
		return groupTag == GroupTag ||
			groupTag == ParentGroupTag ||
			groupTag == GrandparentGroupTag;
	}

	bool TagInstance::operator==(const TagInstance &other) const
	{
		// TODO: Determine
		return false;
	}

	bool TagInstance::operator!=(const TagInstance &other) const
	{
		// TODO: Determine
		return true;
	}

	TagInstance::operator bool() const
	{
		// TODO: Verify the tag instance
		return Index != -1;
	}

	std::istream &operator>>(std::istream &in, TagInstance &tagInstance)
	{
		uint32_t headerOffset = (uint32_t)in.tellg();

		// Read the tag instance header
		in.read((char *)&tagInstance.Checksum, 4);
		in.read((char *)&tagInstance.DataSize, 4);
		in.read((char *)&tagInstance.DependencyCount, 2);
		in.read((char *)&tagInstance.DataFixupCount, 2);
		in.read((char *)&tagInstance.ResourceFixupCount, 2);
		in.seekg(2, in.cur);
		in.read((char *)&tagInstance.DefinitionOffset, 4) >>
			tagInstance.GroupTag >>
			tagInstance.ParentGroupTag >>
			tagInstance.GrandparentGroupTag >>
			tagInstance.GroupName;

		// Calculate the size of the tag instance header
		uint32_t tagHeaderSize = 36 +
			tagInstance.DependencyCount * 4 +
			tagInstance.DataFixupCount * 4 +
			tagInstance.ResourceFixupCount * 4;

		// Adjust the tag instance's offsets and size
		tagInstance.DefinitionOffset -= tagHeaderSize;
		tagInstance.DataOffset = headerOffset + tagHeaderSize;
		tagInstance.DataSize -= tagHeaderSize;

		// Free the tag instance's previously allocated dependencies
		if (tagInstance.Dependencies != nullptr)
			delete tagInstance.Dependencies;

		// Allocate the tag instance's dependencies
		tagInstance.Dependencies = new int32_t[tagInstance.DependencyCount];

		// Read the tag instance's dependencies
		for (auto i = 0; i < tagInstance.DependencyCount; i++)
			in.read((char *)&tagInstance.Dependencies[i], 4);

		// Free the tag instance's previously allocated data fixups
		if (tagInstance.DataFixups != nullptr)
			delete tagInstance.DataFixups;

		// Allocate the tag instance's data fixups
		tagInstance.DataFixups = new TagFixup[tagInstance.DataFixupCount];

		// Read the tag instance's data fixups
		for (auto i = 0; i < tagInstance.DataFixupCount; i++)
		{
			uint32_t fixupHeaderOffset = (uint32_t)in.tellg();

			in.read((char *)&tagInstance.DataFixups[i].WriteOffset, 4);
			tagInstance.DataFixups[i].WriteOffset -= 0x40000000 + tagHeaderSize;

			in.seekg(headerOffset + tagHeaderSize + tagInstance.DataFixups[i].WriteOffset, in.beg);
			in.read((char *)&tagInstance.DataFixups[i].TargetOffset, 4);
			tagInstance.DataFixups[i].TargetOffset -= 0x40000000 + tagHeaderSize;

			in.seekg(fixupHeaderOffset + 4, in.beg);
		}

		// Free the tag instance's previously allocated resource fixups
		if (tagInstance.ResourceFixups != nullptr)
			delete tagInstance.ResourceFixups;

		// Allocate the tag instance's resource fixups
		tagInstance.ResourceFixups = new TagFixup[tagInstance.ResourceFixupCount];

		// Read the tag instance's resource fixups
		for (auto i = 0; i < tagInstance.ResourceFixupCount; i++)
		{
			uint32_t fixupHeaderOffset = (uint32_t)in.tellg();

			in.read((char *)&tagInstance.ResourceFixups[i].WriteOffset, 4);
			tagInstance.ResourceFixups[i].WriteOffset -= 0x40000000 + tagHeaderSize;

			in.seekg(headerOffset + tagHeaderSize + tagInstance.ResourceFixups[i].WriteOffset, in.beg);
			in.read((char *)&tagInstance.ResourceFixups[i].TargetOffset, 4);
			tagInstance.ResourceFixups[i].TargetOffset -= 0x40000000 + tagHeaderSize;

			in.seekg(fixupHeaderOffset + 4, in.beg);
		}

		return in;
	}

	std::ostream &operator<<(std::ostream &out, TagInstance &tagInstance)
	{
		throw std::exception("Sentinel::TagInstance operator<< is not implemented");
	}
}