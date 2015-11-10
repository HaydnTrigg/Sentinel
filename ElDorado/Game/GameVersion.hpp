#pragma once
#include <cstdint>
#include <string>

namespace ElDorado
{
	namespace Game
	{
		class GameVersion
		{
		public:
			static const GameVersion Unknown;
			static const GameVersion V1_106708_cert_ms23;
			static const GameVersion V1_235640_cert_ms25;
			static const GameVersion V0_0_1_301003_cert_MS26_new;
			static const GameVersion V0_4_1_327043_cert_MS26_new;
			static const GameVersion V8_1_372731_Live;
			static const GameVersion V0_0_416097_Live;
			static const GameVersion V10_1_430475_Live;
			static const GameVersion V10_1_454665_Live;
			static const GameVersion V10_1_449175_Live;
			static const GameVersion V11_1_498295_Live;
			static const GameVersion V11_1_530605_Live;
			static const GameVersion V11_1_532911_Live;
			static const GameVersion V11_1_554482_Live;
			static const GameVersion V11_1_571627_Live;

			GameVersion(const std::string &name, const int64_t timestamp);
			GameVersion(const int64_t timestamp);

			std::string &GetName();
			int64_t GetTimestamp() const;

			bool operator==(const GameVersion &other);
			bool operator!=(const GameVersion &other);

			static GameVersion &Find(const int64_t timestamp);

		protected:
			std::string Name;
			int64_t Timestamp;
		};
	}
}