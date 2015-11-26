#include "ColorARGB.hpp"

namespace Blam
{
	ColorARGB<float>::ColorARGB(const float alpha, const float red, const float green, const float blue)
	{
		Alpha = alpha;
		Red = red;
		Green = green;
		Blue = blue;
	}

	std::istream &operator>>(std::istream &in, ColorARGB<float> &colorARGB)
	{
		return in
			.read((char *)&colorARGB.Alpha, 4)
			.read((char *)&colorARGB.Red, 4)
			.read((char *)&colorARGB.Green, 4)
			.read((char *)&colorARGB.Blue, 4);
	}

	std::ostream &operator<<(std::ostream &out, ColorARGB<float> &colorARGB)
	{
		return out
			.write((char *)&colorARGB.Alpha, 4)
			.write((char *)&colorARGB.Red, 4)
			.write((char *)&colorARGB.Green, 4)
			.write((char *)&colorARGB.Blue, 4);
	}
}