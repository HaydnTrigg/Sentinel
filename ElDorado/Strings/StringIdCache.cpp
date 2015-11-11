#include "StringIdCache.hpp"

namespace ElDorado
{
	namespace Strings
	{
		StringIdCache::StringIdCache(StringIdResolver &resolver) :
			Strings(), Resolver(resolver)
		{
		}

		const std::string &StringIdCache::GetString(const StringId &stringId)
		{
			auto index = Resolver.StringIdToIndex(stringId);
			if (index < 0 || index <= Strings.size())
				throw std::exception("Invalid StringId supplied to StringIdCache::GetString");
			return *std::next(Strings.begin(), index);
		}

		StringId StringIdCache::GetStringId(const size_t index)
		{
			if (index < 0 || index >= Strings.size())
				return StringId::Null;
			return Resolver.IndexToStringId((int32_t)index);
		}

		StringId StringIdCache::GetStringId(const std::string &string)
		{
			auto i = std::find(Strings.begin(), Strings.end(), string);
			if (i == Strings.end())
				throw std::exception("String not found in StringIdCache::GetStringId");
			return GetStringId(std::distance(Strings.begin(), i));
		}

		void StringIdCache::Serialize(std::ostream &out)
		{
			throw std::exception("StringIdCache::Serialize is not yet implemented");
		}

		std::string ReadString(std::istream &in)
		{
			std::stringstream ss;

			while (true)
			{
				char c;
				in.read(&c, 1);
				if (c == 0)
					break;
				ss << c;
			}

			return ss.str();
		}

		void StringIdCache::Deserialize(std::istream &in)
		{
			//
			// Read the header
			//

			int32_t stringCount = 0;
			int32_t dataSize = 0;

			in.read((char *)&stringCount, 4);
			in.read((char *)&dataSize, 4);

			//
			// Read the string offsets
			//

			auto stringOffsets = new int32_t[stringCount];

			for (auto i = 0; i < stringCount; i++)
				in.read((char *)&stringOffsets[i], 4);

			//
			// Read each string from its location
			//

			size_t dataOffset = in.tellg();

			for (auto i = 0; i < stringCount; i++)
			{
				auto offset = stringOffsets[i];

				if (offset == -1 || offset >= dataSize)
				{
					Strings.push_back("");
					continue;
				}

				in.seekg(dataOffset + offset, std::ios::beg);
				Strings.push_back(ReadString(in));
			}

			//
			// Clean up
			//

			delete stringOffsets;
		}

		const std::string &StringIdCache::operator[](const StringId &stringId)
		{
			return GetString(stringId);
		}
	}
}