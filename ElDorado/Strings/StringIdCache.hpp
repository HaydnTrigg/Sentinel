#pragma once
#include <exception>
#include <iostream>
#include <sstream>
#include <string>
#include <list>
#include <Common\Serialization\Serializable.hpp>
#include <ElDorado\Strings\StringId.hpp>
#include <ElDorado\Strings\StringIdResolverBase.hpp>

namespace ElDorado
{
	namespace Strings
	{
		using namespace Common::Serialization;

		class StringIdCache : public Serializable<StringIdCache>
		{
		public:
			StringIdCache(StringIdResolver &resolver);

			const std::string &GetString(const StringId &stringId);
			StringId GetStringId(const size_t index);
			StringId GetStringId(const std::string &string);

			void Serialize(std::ostream &out);
			void Deserialize(std::istream &in);

			const std::string &operator[](const StringId &stringId);

		protected:
			std::list<std::string> Strings;
			StringIdResolver &Resolver;
		};
	}
}
