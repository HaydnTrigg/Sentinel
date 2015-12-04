using Blam.Common;

namespace Blam.Models
{
    /// <summary>
    /// Compresses and decompresses vertex data.
    /// </summary>
    public class VertexCompressor
	{
		private readonly GeometryCompressionInfo _info;
		private readonly float _xScale;
		private readonly float _yScale;
		private readonly float _zScale;
		private readonly float _uScale;
		private readonly float _vScale;

		/// <summary>
		/// Initializes a new instance of the <see cref="VertexCompressor"/> class.
		/// </summary>
		/// <param name="info">The compression info to use.</param>
		public VertexCompressor(GeometryCompressionInfo info)
		{
			_info = info;
            _xScale = info.XRange.Max - info.XRange.Min;
			_yScale = info.YRange.Max - info.YRange.Min;
            _zScale = info.ZRange.Max - info.ZRange.Min;
            _uScale = info.URange.Max - info.URange.Min;
            _vScale = info.VRange.Max - info.VRange.Min;
        }

		/// <summary>
		/// Compresses a position so that its components are between 0 and 1.
		/// </summary>
		/// <param name="pos">The position to compress.</param>
		/// <returns>The compressed position.</returns>
		public Vector4 CompressPosition(Vector4 pos)
		{
			var newX = (pos.X - _info.XRange.Min) / _xScale;
			var newY = (pos.Y - _info.YRange.Min) / _yScale;
			var newZ = (pos.Z - _info.ZRange.Min) / _zScale;
			return new Vector4(newX, newY, newZ, pos.W);
		}

		/// <summary>
		/// Decompresses a position so that its components are in model space.
		/// </summary>
		/// <param name="pos">The position to decompress.</param>
		/// <returns>The decompressed position.</returns>
		public Vector4 DecompressPosition(Vector4 pos)
		{
            var newX = pos.X * _xScale + _info.XRange.Min;
			var newY = pos.Y * _yScale + _info.YRange.Min;
			var newZ = pos.Z * _zScale + _info.ZRange.Min;
			return new Vector4(newX, newY, newZ, pos.W);
		}

		/// <summary>
		/// Compresses texture coordinates so that the components are between 0 and 1.
		/// </summary>
		/// <param name="uv">The texture coordinates to compress.</param>
		/// <returns>The compressed coordinates.</returns>
		public Vector2 CompressUv(Vector2 uv)
		{
			var newU = (uv.X - _info.URange.Min) / _uScale;
			var newV = (uv.Y - _info.VRange.Min) / _vScale;
			return new Vector2(newU, newV);
		}

		/// <summary>
		/// Decompresses texture coordinates.
		/// </summary>
		/// <param name="uv">The texture coordinates to decompress.</param>
		/// <returns>The decompressed coordinates.</returns>
		public Vector2 DecompressUv(Vector2 uv)
		{
			var newU = uv.X * _uScale + _info.URange.Min;
			var newV = uv.Y * _vScale + _info.VRange.Min;
			return new Vector2(newU, newV);
		}
	}
}
