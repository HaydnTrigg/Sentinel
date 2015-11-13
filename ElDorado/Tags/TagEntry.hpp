#pragma once
#include <cstdint>
#include <exception>
#include <iostream>
#include <unordered_set>
#include <vector>
#include <Common\Serialization\Serializable.hpp>
#include <ElDorado\Strings\StringId.hpp>
#include <ElDorado\Tags\Tag.hpp>
#include <ElDorado\Tags\TagFixup.hpp>

namespace ElDorado
{
	using namespace Strings;

	namespace Tags
	{
		using namespace Common::Serialization;

		class TagEntry : public Serializable<TagEntry>
		{
			friend class TagCache;
			friend class TagFixup;

		public:
			TagEntry(const int32_t index = 0);

			void Serialize(std::ostream &out);
			void Deserialize(std::istream &in);

		protected:
			int32_t Index;
			Tag GroupTag;
			Tag ParentGroupTag;
			Tag GrandparentGroupTag;
			StringId GroupNameId;
			uint32_t Address;
			uint32_t Size;
			uint32_t Offset;
			uint32_t Checksum;
			std::unordered_set<int32_t> Dependencies;
			std::vector<TagFixup> DataFixups;
			std::vector<TagFixup> ResourceFixups;
		};
	}
}
