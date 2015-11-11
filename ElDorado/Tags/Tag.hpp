#pragma once
#include <cstdint>
#include <iostream>
#include <Common\Serialization\Serializable.hpp>

namespace ElDorado
{
	namespace Tags
	{
		using namespace Common::Serialization;

		class Tag : public Serializable<Tag>
		{
		public:
			static const Tag Null;

			Tag(const uint32_t value);

			uint32_t GetValue() const;

			void Serialize(std::ostream &out);
			void Deserialize(std::istream &in);

			bool operator==(const Tag &other);
			bool operator!=(const Tag &other);

		protected:
			uint32_t Value;
		};
	}
}
