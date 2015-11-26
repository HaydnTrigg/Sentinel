#pragma once
#include <cstdint>
#include <iostream>

namespace Blam
{
	template <typename Component>
	struct ColorHSV
	{
		static const size_t ComponentSize = sizeof(Component) / sizeof(char);

		Component Hue, Saturation, Value;

		ColorHSV(const Component hue, const Component saturation, const Component value);
		inline ColorHSV() : ColorHSV((Component)0, (Component)0, (Component)0) {}

		inline bool operator==(const ColorHSV<Component> &other) const
		{
			return Hue == other.Hue &&
				Saturation == other.Saturation &&
				Value == other.Value;
		}

		inline bool operator!=(const ColorHSV<Component> &other) const
		{
			return Hue != other.Hue ||
				Saturation != other.Saturation ||
				Value != other.Value;
		}

		inline friend std::istream &operator>>(std::istream &in, ColorHSV<Component> &colorHSV)
		{
			return in
				.seekg(ComponentSize, in.cur)
				.read((char *)&colorHSV.Hue, ComponentSize)
				.read((char *)&colorHSV.Saturation, ComponentSize)
				.read((char *)&colorHSV.Value, ComponentSize)
		}

		inline friend std::ostream &operator<<(std::ostream &out, ColorHSV<Component> &colorHSV)
		{
			return out
				.write('\0', ComponentSize)
				.write((char *)&colorHSV.Hue, ComponentSize)
				.write((char *)&colorHSV.Saturation, ComponentSize)
				.write((char *)&colorHSV.Value, ComponentSize)
		}
	};
}