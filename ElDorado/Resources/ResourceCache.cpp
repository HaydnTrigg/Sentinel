#include "ResourceCache.hpp"

namespace ElDorado
{
	namespace Resources
	{
		ResourceCache::ResourceCache()
		{
		}

		size_t ResourceCache::GetCount() const
		{
			return Entries.size();
		}

		void ResourceCache::Serialize(std::ostream &out)
		{
			throw std::exception("ResourceCache::Serialize is not yet implemented");
		}

		void ResourceCache::Deserialize(std::istream &in)
		{
			//
			// Read the header
			//

			uint32_t tableOffset = 0;
			uint32_t resourceCount = 0;

			in.seekg(0x4, std::ios::beg);
			in.read((char *)&tableOffset, 4);
			in.read((char *)&resourceCount, 4);

			//
			// Read each resource entry
			//

			in.seekg(tableOffset, std::ios::beg);
			Entries = std::vector<ResourceEntry>(resourceCount);

			for (uint32_t i = 0; i < resourceCount; i++)
			{
				// Read the offset of the current resource entry
				in.read((char *)&Entries[i].Offset, 4);

				// Compute the source of the previous resource entry
				if (i > 0)
					Entries[i - 1].Size = Entries[i].Offset - Entries[i - 1].Offset;
			}

			// Compute the size of the last resource entry
			Entries[resourceCount - 1].Size = tableOffset - Entries[resourceCount - 1].Offset;
		}

		ResourceEntry &ResourceCache::operator[](const size_t index)
		{
			return Entries[index];
		}
	}
}
