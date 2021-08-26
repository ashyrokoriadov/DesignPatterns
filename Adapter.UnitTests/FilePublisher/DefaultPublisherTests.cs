using Adapter.FilePublisher;
using Adapter.UnitTests.Helpers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Adapter.UnitTests.FilePublisher
{
    [TestClass]
    public class DefaultPublisherTests
    {
        [TestMethod]
        public void GIVEN_not_empty_content_WHEN_publish_is_invoked_THEN_no_exception_is_thrown()
        {
            try
            {
                var systemUnderTests = new DefaultPublisher();           
                systemUnderTests.Publish(ContentHelper.GetFilled());
            }
            catch (Exception ex)
            {
                Assert.Fail("Expected no exception, but got: " + ex.Message);
            }
        }

        [TestMethod]
        public void GIVEN_empty_content_WHEN_publish_is_invoked_THEN_no_exception_is_thrown()
        {
            try
            {
                var systemUnderTests = new DefaultPublisher();
                systemUnderTests.Publish(ContentHelper.GetEmpty());
            }
            catch (Exception ex)
            {
                Assert.Fail("Expected no exception, but got: " + ex.Message);
            }
        }

        [TestMethod]
        public void GIVEN_null_content_WHEN_publish_is_invoked_THEN_exception_is_thrown()
        {
            var systemUnderTests = new DefaultPublisher();
            Action action = () => systemUnderTests.Publish(ContentHelper.GetNull());
            Assert.ThrowsException<NullReferenceException>(action);           
        }
    }
}
