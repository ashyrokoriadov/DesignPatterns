using Adapter.FileWriter;
using Adapter.UnitTests.Helpers;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Adapter.UnitTests.FileWriter
{
    [TestClass]
    public class TextFileWriterTests
    {
        [TestMethod]
        public void GIVEN_not_empty_content_WHEN_write_is_invoked_THEN_no_exception_is_thrown()
        {
            var systemUnderTests = new TextFileWriter("test.txt");
            var actual = systemUnderTests.Write(ContentHelper.GetFilled());
            Assert.IsTrue(actual);
        }

        [TestMethod]
        public void GIVEN_empty_content_WHEN_write_is_invoked_THEN_no_exception_is_thrown()
        {
            var systemUnderTests = new TextFileWriter("test.txt");
            var actual = systemUnderTests.Write(ContentHelper.GetEmpty());
            Assert.IsTrue(actual);
        }

        [TestMethod]
        public void GIVEN_null_content_WHEN_publish_is_invoked_THEN_exception_is_thrown()
        {
            var systemUnderTests = new TextFileWriter("test.txt");
            var actual = systemUnderTests.Write(ContentHelper.GetNull());
            Assert.IsFalse(actual);
        }
    }
}
