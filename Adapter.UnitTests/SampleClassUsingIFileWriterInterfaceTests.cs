using Adapter.FileWriter;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Adapter.UnitTests
{
    [TestClass]
    public class SampleClassUsingIFileWriterInterfaceTests
    {
        [DataRow(-1)]
        [DataRow(0)]
        [DataRow(1)]
        [DataRow(10)]
        [TestMethod]
        public void GIVEN_an_object_WHEN_run_is_invoked_THEN_no_exception_is_thrown(int dataCount)
        {
            try
            {
                var systemUnderTests = new SampleClassUsingIFileWriterInterface(new TextFileWriter("test.txt"));
                systemUnderTests.Run(dataCount);
            }
            catch (Exception ex)
            {
                Assert.Fail("Expected no exception, but got: " + ex.Message);
            }
        }
    }
}
