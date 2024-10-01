namespace Elskom.Generic.Libs
{
    internal enum CompressionStrategy
    {
        /// <summary>
        /// The default compression. Used for normal data.
        /// </summary>
        DefaultStrategy = 0,

        /// <summary>
        /// Filtered compression. Used for data produced by a filter (or predictor).
        /// </summary>
        Filtered = 1,

        /// <summary>
        /// Force Huffman encoding only (no string match).
        /// </summary>
        HuffmanOnly = 2
    }
}