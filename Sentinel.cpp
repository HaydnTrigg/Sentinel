#include <iostream>
#include <fstream>
#include <ElDorado\Tags\TagCache.hpp>

using namespace ElDorado::Tags;

int main(int argc, char **argv)
{
	TagCache tagCache;

	std::ifstream in;
	in.open("C:\\Halo Online\\maps\\tags.dat", std::ios::in | std::ios::binary);

	if (!in)
	{
		std::cerr << "Whoops!" << std::endl;
		return 1;
	}

	in >> tagCache;

	return 0;
}
