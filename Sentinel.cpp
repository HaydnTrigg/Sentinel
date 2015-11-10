#include <iostream>
#include <fstream>
#include <ElDorado\Game\GameVersion.hpp>
#include <ElDorado\Strings\StringIdResolverBase.hpp>
#include <ElDorado\Tags\TagCache.hpp>
#include <ElDorado\V1_106708\StringIdResolver.hpp>

using namespace ElDorado;
using namespace ElDorado::Game;
using namespace ElDorado::Strings;
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
		"Written by Camden Smallwood <camden.smallwood@outlook.com>" << std::endl <<
		"Thanks to Shockfire & the Members of #ElDorito on Snoonet" << std::endl;

	//
	// Read the tags cache
	//

	std::ifstream in;
	in.open(argv[1], std::ios::in | std::ios::binary);

	if (!in)
	{
		std::cerr << "ERROR: Failed to open tag cache file: " << argv[1] << std::endl;
		return 1;
	}

	in >> tagCache;
	in.close();

	//
	// Detect the game version
	//

	auto gameVersion = GameVersion::Find(tagCache.GetTimestamp());

	if (gameVersion == GameVersion::Unknown)
	{
		std::cout << "ERROR: The game version of the tag cache was not recognized." << std::endl;
		return 1;
	}
	
	std::cout << "Game Version: " << gameVersion.GetName() << std::endl;

	//
	// Read the string_ids cache
	//

	if (gameVersion.GetTimestamp() >= GameVersion::V11_1_498295_Live.GetTimestamp())
	{
		std::cout << "ERROR: The game version's string_ids format is not supported." << std::endl;
		return 1;
	}

	auto resolver = new V1_106708::StringIdResolver();

	return 0;
}
