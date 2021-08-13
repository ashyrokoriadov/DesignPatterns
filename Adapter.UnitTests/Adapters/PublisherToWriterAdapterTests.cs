using Adapter.Adapters;
using Adapter.UnitTests.Helpers;
using Adapter.UnitTests.Mocks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Adapter.UnitTests.Adapters
{
    [TestClass]
    public class PublisherToWriterAdapterTests
    {
        [TestMethod]
        public void GIVEN_adapter_class_WHEN_inital_interface_is_invoked_and_exception_is_not_thrown_THEN_true_is_returned()
        {
            var systemUnderTests = new PublisherToWriterAdapter(new MockFilePublisher());

            var actual = systemUnderTests.Write(ContentHelper.GetFilled());

            Assert.IsTrue(actual);
        }

        [TestMethod]
        public void GIVEN_adapter_class_WHEN_inital_interface_is_invoked_and_exception_is_thrown_THEN_false_is_returned()
        {
            var systemUnderTests = new PublisherToWriterAdapter(new MockFilePublisherWithException());

            var actual = systemUnderTests.Write(ContentHelper.GetFilled());

            Assert.IsFalse(actual);
        }
    }
}
