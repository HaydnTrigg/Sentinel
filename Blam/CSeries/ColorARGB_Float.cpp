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
}