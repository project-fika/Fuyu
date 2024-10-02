namespace Zlib.Managed
{
    /// <summary>
    /// Compression levels for zlib.
    /// </summary>
    public enum CompressionLevel
    {
        /// <summary>
        /// No compression.
        /// </summary>
        NoCompression = 0,

        /// <summary>
        /// Compression level 1. Best speed.
        /// </summary>
        Level1 = 1,

        /// <summary>
        /// Compression level 2.
        /// </summary>
        Level2 = 2,

        /// <summary>
        /// Compression level 3.
        /// </summary>
        Level3 = 3,

        /// <summary>
        /// Compression level 4.
        /// </summary>
        Level4 = 4,

        /// <summary>
        /// Compression level 5.
        /// </summary>
        Level5 = 5,

        /// <summary>
        /// Compression level 6. Default.
        /// </summary>
        Level6 = 6,

        /// <summary>
        /// Compression level 7.
        /// </summary>
        Level7 = 7,

        /// <summary>
        /// Compression level 8.
        /// </summary>
        Level8 = 8,

        /// <summary>
        /// Compression level 9. Highest compression.
        /// </summary>
        Level9 = 9,

        /// <summary>
        /// Optimal balance.
        /// </summary>
        DefaultCompression = Level6,

        /// <summary>
        /// Best speed.
        /// </summary>
        BestSpeed = Level1,

        /// <summary>
        /// Highest compression.
        /// </summary>
        BestCompression = Level9
    }
}