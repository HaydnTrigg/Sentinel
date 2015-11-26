#include "ColorARGB.hpp"

namespace Blam
{
	ColorARGB<uint8_t>::ColorARGB(const uint8_t alpha, const uint8_t red, const uint8_t green, const uint8_t blue)
	{
		Alpha = alpha;
		Red = red;
		Green = green;
		Blue = blue;
	}

	std::istream &operator>>(std::istream &in, ColorARGB<uint8_t> &colorARGB)
	{
		return in
			.read((char *)&colorARGB.Alpha, 1)
			.read((char *)&colorARGB.Red, 1)
			.read((char *)&colorARGB.Green, 1)
			.read((char *)&colorARGB.Blue, 1);
	}

	std::ostream &operator<<(std::ostream &out, ColorARGB<uint8_t> &colorARGB)
	{
		return out
			.write((char *)&colorARGB.Alpha, 1)
			.write((char *)&colorARGB.Red, 1)
			.write((char *)&colorARGB.Green, 1)
			.write((char *)&colorARGB.Blue, 1);
	}
}