#include <iostream>
#include <fstream>
#include <ElDorado\Game\GameVersion.hpp>
#include <ElDorado\Tags\TagCache.hpp>

using namespace ElDorado::Game;
using namespace ElDorado::Tags;

int main(int argc, char **argv)
{
	TagCache tagCache;

	if (argc != 2)
	{
		std::cout <<
			"Usage:" << std::endl <<
			argv[0] << ' ' << "<tag cache file>" << std::endl;

		return 1;
	}

	std::cout <<
		"Sentinel - A tool for Halo Online content development" << std::endl <<
		"Written by Camden Smallwood" << std::endl <<
		"Thanks to Shockfire & the Halo Online IRC" << std::endl <<
		std::endl;

	std::ifstream in;
	in.open(argv[1], std::ios::in | std::ios::binary);

	if (!in)
	{
		std::cerr << "ERROR: Failed to open tag cache file: " << argv[1] << std::endl;
		return 1;
	}

	in >> tagCache;

	auto gameVersion = GameVersion::Find(tagCache.GetTimestamp());

	if (gameVersion == GameVersion::Unknown)
	{

	}
	else
	{

	}

	return 0;
}
