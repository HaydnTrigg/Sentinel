#include "ColorRGB.hpp"

namespace Blam
{
	template <>
	ColorRGB<uint8_t>::ColorRGB(const uint8_t red, const uint8_t green, const uint8_t blue)
	{
		Red = red;
		Green = green;
		Blue = blue;
	}

	std::istream &operator>>(std::istream &in, ColorRGB<uint8_t> &colorRGB)
	{
		return in
			.seekg(1, in.cur)
			.read((char *)&colorRGB.Red, 1)
			.read((char *)&colorRGB.Green, 1)
			.read((char *)&colorRGB.Blue, 1);
	}

	std::ostream &operator<<(std::ostream &out, ColorRGB<uint8_t> &colorRGB)
	{
		return out
			.write('\0', 1)
			.write((char *)&colorRGB.Red, 1)
			.write((char *)&colorRGB.Green, 1)
			.write((char *)&colorRGB.Blue, 1);
	}
}