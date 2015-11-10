#include "GameVersion.hpp"

namespace ElDorado
{
	namespace Game
	{
		const GameVersion GameVersion::V1_106708_cert_ms23
			("1.106708 cert_ms23", 130713360239499012);

		const GameVersion GameVersion::V1_235640_cert_ms25
			("1.235640 cert_ms25", 130772932862346058);

		const GameVersion GameVersion::V0_0_1_301003_cert_MS26_new
			("0.0.1.301003 cert_MS26_new", 130785901486445524);

		const GameVersion GameVersion::V0_4_1_327043_cert_MS26_new
			("0.4.1.327043 cert_MS26_new", 130800445160458507);

		const GameVersion GameVersion::V8_1_372731_Live
			("8.1.372731 Live", 130814318396118255);

		const GameVersion GameVersion::V0_0_416097_Live
			("0.0.416097 Live", 130829123589114103);

		const GameVersion GameVersion::V10_1_430475_Live
			("10.1.430475 Live", 130834294034159845);

		const GameVersion GameVersion::V10_1_454665_Live
			("10.1.454665 Live", 130844512316254660);

		const GameVersion GameVersion::V10_1_449175_Live
			("10.1.449175 Live", 130851642645809862);

		const GameVersion GameVersion::V11_1_498295_Live
			("11.1.498295 Live", 130858473716879375);

		const GameVersion GameVersion::V11_1_530605_Live
			("11.1.530605 Live", 130868891945946004);

		const GameVersion GameVersion::V11_1_532911_Live
			("11.1.532911 Live", 130869644198634503);

		const GameVersion GameVersion::V11_1_554482_Live
			("11.1.554482 Live", 130879952719550501);

		const GameVersion GameVersion::V11_1_571627_Live
			("11.1.571627 Live", 130881889330693956);

		GameVersion::GameVersion(const std::string &name, const int64_t timestamp) :
			Name(name), Timestamp(timestamp)
		{
		}

		GameVersion::GameVersion(const int64_t timestamp) :
			GameVersion("Unknown", timestamp)
		{
		}

		std::string &GameVersion::GetName()
		{
			return Name;
		}

		int64_t GameVersion::GetTimestamp() const
		{
			return Timestamp;
		}
	}
}