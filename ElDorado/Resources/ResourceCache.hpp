#pragma once
#include <exception>
#include <iostream>
#include <vector>
#include <Common\Serialization\Serializable.hpp>
#include <ElDorado\Resources\ResourceEntry.hpp>

namespace ElDorado
{
	namespace Resources
	{
		using namespace Common::Serialization;

		class ResourceCache : public Serializable<ResourceCache>
		{
			friend class ResourceEntry;

		public:
			ResourceCache();

			size_t GetCount() const;

			void Serialize(std::ostream &out);
			void Deserialize(std::istream &in);

			ResourceEntry &operator[](const size_t index);

		protected:
			std::vector<ResourceEntry> Entries;
		};
	}
}
