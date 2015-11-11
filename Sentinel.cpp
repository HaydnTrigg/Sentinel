#include <iostream>
#include <fstream>
#include <ElDorado\Game\GameVersion.hpp>
#include <ElDorado\Strings\StringIdCache.hpp>
#include <ElDorado\Strings\StringIdResolverBase.hpp>
#include <ElDorado\Tags\TagCache.hpp>
#include <ElDorado\V1_106708\StringIdResolver.hpp>

using namespace ElDorado;
using namespace ElDorado::Game;
using namespace ElDorado::Strings;
using namespace ElDorado::Tags;

int main(int argc, char **argv)
{
	/*
	if (argc != 2)
	{
		std::cout <<
			"Usage:" << std::endl <<
			argv[0] << ' ' << "<tag cache file>" << std::endl;

		return 1;
	}
	*/
	std::cout <<
		"Sentinel - A tool for Halo Online content development" << std::endl <<
		"Written by Camden Smallwood <camden.smallwood@outlook.com>" << std::endl <<
		"Thanks to Shockfire & the Members of #ElDorito on Snoonet" << std::endl;

	//
	// Find cache files
	//

	std::string tagsCacheFile("C:/Halo Online/maps/tags.dat");
	auto lastSlash = tagsCacheFile.find_last_of("/\\");

	std::string cacheDirectory = lastSlash < tagsCacheFile.length() ?
		tagsCacheFile.substr(0, lastSlash + 1) : "";

	std::string stringIdsCacheFile = cacheDirectory + "string_ids.dat";
	std::string resourcesCacheFile = cacheDirectory + "resources.dat";

	//
	// Read the tags cache
	//

	std::ifstream in;
	in.open(tagsCacheFile, std::ios::in | std::ios::binary);

	if (!in)
	{
		std::cerr << "ERROR: Failed to open tags cache file: " << tagsCacheFile << std::endl;
		return 1;
	}

	std::cout << "Reading tags cache..." << std::endl;
	TagCache tagCache;
	in >> tagCache;
	in.close();

	//
	// Detect the game version
	//

	auto gameVersion = GameVersion::Find(tagCache.GetTimestamp());

	if (gameVersion == GameVersion::Unknown)
	{
		std::cout << "ERROR: The game version of the tags cache was not recognized." << std::endl;
		return 1;
	}
	
	std::cout << "Game Version: " << gameVersion.GetName() << std::endl;

	//
	// Read the string_ids cache
	//

	if (gameVersion.GetTimestamp() >= GameVersion::V11_1_498295_Live.GetTimestamp())
	{
		std::cout << "ERROR: The version of the string_ids cache is not supported." << std::endl;
		return 1;
	}

	V1_106708::StringIdResolver resolver;

	in.open(stringIdsCacheFile, std::ios::in | std::ios::binary);

	if (!in)
	{
		std::cerr << "ERROR: Failed to open string_ids cache file: " << stringIdsCacheFile << std::endl;
		return 1;
	}

	std::cout << "Reading string_ids cache..." << std::endl;
	StringIdCache stringIdsCache(resolver);
	in >> stringIdsCache;
	in.close();

	return 0;
}
