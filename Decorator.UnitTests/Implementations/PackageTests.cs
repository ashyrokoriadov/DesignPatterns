using Decorator.Implementations;
using Decorator.Interfaces;
using Decorator.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;

namespace Decorator.UnitTests.Implementations
{
    [TestClass]
    public class PackageTests
    {
        private IPackage _systemUnderTests;
        private IList<OrderItem> _orderItems = new List<OrderItem>();
        private PackageFactory _packageFactory = new PackageFactory();

        public PackageTests()
        {
            _orderItems.Add(new OrderItem() { Name = "MacBook", Quantity = 1, Price = 2.999M, Weight = 3.0M });
            _orderItems.Add(new OrderItem() { Name = "iPhone", Quantity = 2, Price = 1.499M, Weight = 0.2M });
        }

        [TestInitialize]
        public void InitializeTest()
        {
            _systemUnderTests = _packageFactory.Order(_orderItems);
        }

        [TestMethod]
        public void GIVEN_Package_WHEN_CalculateValue_is_invoked_THEN_correct_value_is_returned()
        {
            var actual = _systemUnderTests.CalculateValue();
            var expected = _orderItems.Sum(item => item.TotalPrice);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void GIVEN_Package_WHEN_CalculateWeight_is_invoked_THEN_correct_value_is_returned()
        {
            var actual = _systemUnderTests.CalculateWeight();
            var expected = _orderItems.Sum(item => item.TotalWeight) + Package<OrderItem>.PACKAGE_MATERIAL_WEIGHT;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void GIVEN_Package_WHEN_CalculateShippingCosts_is_invoked_THEN_default_value_is_returned()
        {
            var actual = _systemUnderTests.CalculateShippingCosts();
            Assert.AreEqual(0.0M, actual);
        }

        [TestMethod]
        public void GIVEN_Package_WHEN_CalculatePaymentCommision_is_invoked_THEN_default_value_is_returned()
        {
            var actual = _systemUnderTests.CalculatePaymentCommision();
            Assert.AreEqual(0.0M, actual);
        }

        [TestMethod]
        public void GIVEN_Package_WHEN_AddItem_is_invoked_THEN_item_is_added_to_package()
        {
            var item = new OrderItem() { Name = "iPhone", Quantity = 2, Price = 1.499M, Weight = 0.2M };
            var systemUnderTests = new Package<OrderItem>();

            systemUnderTests.AddItem(item);

            var actual = systemUnderTests.CalculateValue();
            var expected = item.TotalPrice;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void GIVEN_Package_WHEN_RemoveItem_is_invoked_THEN_item_is_removed_from_package()
        {
            var item = new OrderItem() { Name = "iPhone", Quantity = 2, Price = 1.499M, Weight = 0.2M };
            var systemUnderTests = new Package<OrderItem>();

            systemUnderTests.AddItem(item);

            var actual = systemUnderTests.CalculateValue();
            var expected = item.TotalPrice;
            Assert.AreEqual(expected, actual);

            systemUnderTests.Remove(item);

            actual = systemUnderTests.CalculateValue();
            Assert.AreEqual(0.0M, actual);
        }
    }
}
