#pragma once
#include <cstdint>
#include <iostream>

namespace Sentinel
{
	template <typename Element>
	struct TagData
	{
		static const size_t ElementSize = sizeof(Element) / sizeof(char);

		int32_t Size;
		union
		{
			uint8_t *Data;
			Element *Elements;
		};

		TagData(const int32_t size = 0, const uint8_t *data = nullptr)
			: Size(size), Data(data) {}

		TagData(const int32_t count, const Element *elements = nullptr)
			: Size(count * ElementSize), Elements(elements) {}

		inline Element *begin() const
		{
			return &Elements[0];
		}

		inline Element *end() const
		{
			return &Elements[Size / ElementSize];
		}

		inline Element &operator[](const size_t index)
		{
			return Elements[index];
		}

		inline explicit operator bool() const
		{
			return Elements != nullptr;
		}

		friend std::istream &operator>>(std::istream &in, TagData<Element> &tagData)
		{
			auto headerOffset = in.tellg();
			uint32_t dataOffset = 0;

			// Read the tag data header
			in.read((char *)&tagData.Size, 4);
			in.seekg(8, in.cur);
			in.read((char *)&dataOffset, 4);

			// Seek to the address of the tag data
			in.seekg(dataOffset - 0x40000000, in.beg);

			// Free and previously allocated data
			if (tagData.Data != nullptr)
				delete tagData.Data;

			// Allocate and read the tag data
			tagData.Data = new uint8_t[tagData.Size];
			in.read(tagData.Data, tagData.Size);

			// Seek to the end of the tag data header
			in.seekg(headerOffset + 20, in.beg);

			return in;
		}

		friend std::ostream &operator<<(std::ostream &out, TagData<Element> &tagData)
		{
			throw std::exception("TagData<Element> operator<< not implemented");
		}
	};
}