namespace Fuyu.Platform.Common.Compression
{
    /// <summary>
    /// Compression levels for zlib.
    /// </summary>
    public enum ZlibCompression
    {
        /// <summary>
        /// No compression.
        /// </summary>
        NoCompression,

        /// <summary>
        /// Compression level 1. Best speed.
        /// </summary>
        Level1,

        /// <summary>
        /// Compression level 2.
        /// </summary>
        Level2,

        /// <summary>
        /// Compression level 3.
        /// </summary>
        Level3,

        /// <summary>
        /// Compression level 4.
        /// </summary>
        Level4,

        /// <summary>
        /// Compression level 5.
        /// </summary>
        Level5,

        /// <summary>
        /// Compression level 6. Default.
        /// </summary>
        Level6,

        /// <summary>
        /// Compression level 7.
        /// </summary>
        Level7,

        /// <summary>
        /// Compression level 8.
        /// </summary>
        Level8,

        /// <summary>
        /// Compression level 9. Highest compression.
        /// </summary>
        Level9
    }
}