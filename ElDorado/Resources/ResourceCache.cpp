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

		}

		void ResourceCache::Deserialize(std::istream &in)
		{

		}
	}
}
