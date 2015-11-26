#include "ColorHSV.hpp"

namespace Blam
{
	ColorHSV<float>::ColorHSV(const float hue, const float saturation, const float value)
	{
		Hue = hue;
		Saturation = saturation;
		Value = value;
	}
}