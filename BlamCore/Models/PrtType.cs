namespace Blam.Models
{
    /// <summary>
    /// Precomputed radiance transfer (PRT) types.
    /// </summary>
    public enum PrtType : byte
	{
		None,
		Ambient,
		Linear,
		Quadratic
	}
}
