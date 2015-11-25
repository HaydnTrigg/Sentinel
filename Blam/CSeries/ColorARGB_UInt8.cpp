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
}