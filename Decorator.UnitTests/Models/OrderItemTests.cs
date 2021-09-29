using Decorator.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Decorator.UnitTests.Models
{
    [TestClass]
    public class OrderItemTests
    {
        private OrderItem _systemUnderTests;

        [TestInitialize]
        public void InitializeTest()
        {
            _systemUnderTests = new OrderItem() { Name = "iPhone", Quantity = 2, Price = 1.499M, Weight = 0.2M };
        }

        [TestMethod]
        public void GIVEN_OrderItem_WHEN_TotalWeight_is_invoked_THEN_correct_value_is_returned()
        {
            var actual = _systemUnderTests.TotalWeight;
            var expected = _systemUnderTests.Quantity * _systemUnderTests.Weight;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void GIVEN_OrderItem_WHEN_TotalPrice_is_invoked_THEN_correct_value_is_returned()
        {
            var actual = _systemUnderTests.TotalPrice;
            var expected = _systemUnderTests.Quantity * _systemUnderTests.Price;
            Assert.AreEqual(expected, actual);
        }
    }
}
