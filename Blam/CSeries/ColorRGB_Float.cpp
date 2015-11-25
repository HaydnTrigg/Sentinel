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
}