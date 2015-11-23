#pragma once
#include <cstdint>
#include <exception>
#include <iostream>

namespace Sentinel
{
	template <typename Element>
	struct TagBlock
	{
		const size_t ElementSize = sizeof(Element) / sizeof(char);

		int32_t Count;
		Element *Elements;

		TagBlock()
			: Count(0), Elements(nullptr) {}

		inline Element *begin() const
		{
			return &Elements[0];
		}

		inline Element *end() const
		{
			return &Elements[Count];
		}

		inline Element &operator[](const size_t index)
		{
			return Elements[index];
		}

		inline explicit operator bool() const
		{
			return Elements != nullptr;
		}

		friend std::istream &operator>>(std::istream &in, TagBlock<Element> &tagBlock)
		{
			uint32_t headerOffset = in.tellg();
			uint32_t dataOffset = 0;

			// Read the tag block header
			in.read((char *)&tagBlock.Count, 4);
			in.read((char *)&dataOffset, 4);

			// Seek to the tag block data
			in.seekg(dataOffset - 0x40000000, in.beg);

			// Free the tag block's previously allocated elements
			if (tagBlock.Elements != nullptr)
				delete tagBlock.Elements;

			// Allocate the tag block's elements
			tagBlock.Elements = new Element[tagBlock.Count];

			// Read each tag block element
			for (auto element : tagBlock)
				in.read((char *)&element, ElementSize);

			// Seek to the end of the tag block header
			in.seekg(headerOffset + 12, in.beg);

			return in;
		}

		friend std::ostream &operator<<(std::ostream &out, TagBlock<Element> &tagBlock)
		{
			throw std::exception("TagBlock<Element> operator<< not implemented");
		}
	};
}