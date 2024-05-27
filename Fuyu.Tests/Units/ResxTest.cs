using System;
using System.IO;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using Fuyu.Platform.Common.IO;

namespace Fuyu.Tests.Units
{
    [TestClass]
    public class ResxTest
    {
        private const string _assemblyId = "resx_test";

        public ResxTest()
        {
            Resx.SetSource(_assemblyId, typeof(ResxTest).Assembly);
        }

        [TestMethod]
        public void TestGetStream()
        {
            // set expected info
            var expectedText = "Hello, world!";
            var expectedData = Encoding.UTF8.GetBytes(expectedText);

            // get resource
            byte[] data;

            using (var ms = new MemoryStream())
            {
                using (var rs = Resx.GetStream(_assemblyId, "test.txt"))
                {
                    rs.CopyTo(ms);
                }

                data = ms.ToArray();
            }

            var result = data.SequenceEqual(expectedData);
            Assert.IsTrue(result);
        }

        [TestMethod]
        [ExpectedException(typeof(FileNotFoundException))]
        public void TestGetStreamException()
        {
            using (var rs = Resx.GetStream(_assemblyId, "not.existing.file.txt"))
            {
            }
        }

        [TestMethod]
        public void TestGetText()
        {
            // set expected info
            var expectedText = "Hello, world!";

            // get resource
            var data = Resx.GetText(_assemblyId, "test.txt");
            Assert.IsTrue(data == expectedText);
        }
    }
}