#include "ColorRGB.hpp"

namespace Blam
{
	template <>
	ColorRGB<float>::ColorRGB(const float red, const float green, const float blue)
	{
		Red = red;
		Green = green;
		Blue = blue;
	}

	std::istream &operator>>(std::istream &in, ColorRGB<float> &colorRGB)
	{
		return in
			.read((char *)&colorRGB.Red, 4)
			.read((char *)&colorRGB.Green, 4)
			.read((char *)&colorRGB.Blue, 4);
	}

	std::ostream &operator<<(std::ostream &out, ColorRGB<float> &colorRGB)
	{
		return out
			.write((char *)&colorRGB.Red, 4)
			.write((char *)&colorRGB.Green, 4)
			.write((char *)&colorRGB.Blue, 4);
	}
}