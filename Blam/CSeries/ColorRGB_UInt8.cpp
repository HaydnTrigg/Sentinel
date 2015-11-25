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
}