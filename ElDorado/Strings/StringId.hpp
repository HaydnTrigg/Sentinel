#pragma once
#include <cstdint>
#include <iostream>
#include <Common\Serialization\Serializable.hpp>

namespace ElDorado
{
	namespace Strings
	{
		using namespace Common::Serialization;

		class StringId : public Serializable<StringId>
		{
		public:
			static const StringId Null;

			StringId(const uint32_t value);
			StringId(const int32_t length, const int32_t set, const int32_t index);
			StringId(const int32_t set, const int32_t index);

			uint32_t GetValue() const;
			int32_t GetLength() const;
			int32_t GetSet() const;
			int32_t GetIndex() const;

			bool operator==(const StringId &other);
			bool operator!=(const StringId &other);

			void Serialize(std::ostream &out);
			void Deserialize(std::istream &in);

		protected:
			uint32_t Value;
		};
	}
}
