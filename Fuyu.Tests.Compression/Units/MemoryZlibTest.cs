using System;
using System.IO;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using Fuyu.Compression;
using Fuyu.Tests.Compression;

namespace Fuyu.Tests.Compression.Units
{
    [TestClass]
    public class MemoryZlibTest
    {
        [TestMethod]
        [DataRow(CompressionLevel.Level1)]
        [DataRow(CompressionLevel.Level2)]
        [DataRow(CompressionLevel.Level3)]
        [DataRow(CompressionLevel.Level4)]
        [DataRow(CompressionLevel.Level5)]
        [DataRow(CompressionLevel.Level6)]
        [DataRow(CompressionLevel.Level7)]
        [DataRow(CompressionLevel.Level8)]
        [DataRow(CompressionLevel.Level9)]
        public void TestIsCompressed(CompressionLevel level)
        {
            var data = TestData.Deflated[level];

            if (!MemoryZlib.IsCompressed(data))
            {
                Assert.Fail($"Level {level}");
            }
        }

        [TestMethod]
        [DataRow(CompressionLevel.Level1)]
        [DataRow(CompressionLevel.Level2)]
        [DataRow(CompressionLevel.Level3)]
        [DataRow(CompressionLevel.Level4)]
        [DataRow(CompressionLevel.Level5)]
        [DataRow(CompressionLevel.Level6)]
        [DataRow(CompressionLevel.Level7)]
        [DataRow(CompressionLevel.Level8)]
        [DataRow(CompressionLevel.Level9)]
        public void TestDeflate(CompressionLevel level)
        {
            // compress
            var result = MemoryZlib.Compress(TestData.Inflated, level);

            // validate
            var data = TestData.Deflated[level];

            if (!result.SequenceEqual(data))
            {
                Assert.Fail($"Level {level}");
            }
        }

        [TestMethod]
        [DataRow(CompressionLevel.Level1)]
        [DataRow(CompressionLevel.Level2)]
        [DataRow(CompressionLevel.Level3)]
        [DataRow(CompressionLevel.Level4)]
        [DataRow(CompressionLevel.Level5)]
        [DataRow(CompressionLevel.Level6)]
        [DataRow(CompressionLevel.Level7)]
        [DataRow(CompressionLevel.Level8)]
        [DataRow(CompressionLevel.Level9)]
        public void TestInflate(CompressionLevel level)
        {
            var data = TestData.Deflated[level];

            // decompress
            var result = MemoryZlib.Decompress(data);

            // validate
            if (!result.SequenceEqual(TestData.Inflated))
            {
                Assert.Fail($"Level {level}");
            }
        }
    }
}