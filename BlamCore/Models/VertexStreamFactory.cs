using Blam.Game;
using System.IO;

namespace Blam.Models
{
    public static class VertexStreamFactory
	{
		/// <summary>
		/// Creates a vertex stream for a given engine version.
		/// </summary>
		/// <param name="version">The engine version.</param>
		/// <param name="stream">The base stream.</param>
		/// <returns>The created vertex stream.</returns>
		public static IVertexStream Create(GameVersion version, Stream stream)
		{
			if (GameVersions.Compare(version, GameVersion.V1_235640_cert_ms25) >= 0)
				return new Game.V1_235640.VertexStream(stream);
			return new Game.V1_106708.VertexStream(stream);
		}
	}
}
