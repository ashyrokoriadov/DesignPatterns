using Decorator.BadExample;
using Decorator.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Globalization;

namespace Decorator.UnitTests.BadExample
{
    [TestClass]
    public class AllInOnePackageTests
    {
        private AllInOnePackage<OrderItem> _systemUnderTests;

        [TestMethod]
        public void GIVEN_AllInOnePackage_WHEN_AddItem_is_invoked_THEN_item_is_added_to_package()
        {
            var item = new OrderItem() { Name = "iPhone", Quantity = 2, Price = 1.499M, Weight = 0.2M };
            _systemUnderTests = new AllInOnePackage<OrderItem>(PackageType.NONE, PaymentType.NONE);

            _systemUnderTests.AddItem(item);

            var actual = _systemUnderTests.CalculateValue();
            var expected = item.TotalPrice;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void GIVEN_AllInOnePackage_WHEN_RemoveItem_is_invoked_THEN_item_is_removed_from_package()
        {
            var item = new OrderItem() { Name = "iPhone", Quantity = 2, Price = 1.499M, Weight = 0.2M };
            _systemUnderTests = new AllInOnePackage<OrderItem>(PackageType.NONE, PaymentType.NONE);

            _systemUnderTests.AddItem(item);

            var actual = _systemUnderTests.CalculateValue();
            var expected = item.TotalPrice;
            Assert.AreEqual(expected, actual);

            _systemUnderTests.Remove(item);

            actual = _systemUnderTests.CalculateValue();
            Assert.AreEqual(0.0M, actual);
        }

        [TestMethod]
        public void GIVEN_AllInOnePackage_WHEN_CalculateValue_is_invoked_THEN_correct_value_is_returned()
        {
            var item1 = new OrderItem() { Name = "iPhone", Quantity = 2, Price = 1.499M, Weight = 0.2M };
            var item2 = new OrderItem() { Name = "MacBook", Quantity = 1, Price = 2.999M, Weight = 3.0M };

            _systemUnderTests = new AllInOnePackage<OrderItem>(PackageType.NONE, PaymentType.NONE);

            _systemUnderTests.AddItem(item1);
            _systemUnderTests.AddItem(item2);

            var actual = _systemUnderTests.CalculateValue();
            var expected = item1.TotalPrice + item2.TotalPrice;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void GIVEN_AllInOnePackage_WHEN_CalculateWeight_is_invoked_THEN_correct_value_is_returned()
        {
            var item1 = new OrderItem() { Name = "iPhone", Quantity = 2, Price = 1.499M, Weight = 0.2M };
            var item2 = new OrderItem() { Name = "MacBook", Quantity = 1, Price = 2.999M, Weight = 3.0M };

            _systemUnderTests = new AllInOnePackage<OrderItem>(PackageType.NONE, PaymentType.NONE);

            _systemUnderTests.AddItem(item1);
            _systemUnderTests.AddItem(item2);

            var actual = _systemUnderTests.CalculateWeight();
            var expected = item1.TotalWeight + item2.TotalWeight + AllInOnePackage<OrderItem>.PACKAGE_MATERIAL_WEIGHT;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        [DataRow(PackageType.DHL, PaymentType.MONEYGRAM, "20.0")]
        [DataRow(PackageType.POST, PaymentType.NONE, "10.0")]
        [DataRow(PackageType.NONE, PaymentType.WESTERN_UNION, "0.0")]
        public void GIVEN_AllInOnePackage_WHEN_CalculateShippingCosts_is_invoked_THEN_correct_value_is_returned(PackageType packageType, PaymentType paymentType, string expectedString)
        {
            var item = new OrderItem() { Name = "iPhone", Quantity = 2, Price = 1.499M, Weight = 0.2M };

            _systemUnderTests = new AllInOnePackage<OrderItem>(packageType, paymentType);

            _systemUnderTests.AddItem(item);

            var actual = _systemUnderTests.CalculateShippingCosts();
            var expected = Convert.ToDecimal(expectedString, new NumberFormatInfo() { NumberDecimalSeparator = "." });
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        [DataRow(PackageType.DHL, PaymentType.WESTERN_UNION, "17.0")]
        [DataRow(PackageType.NONE, PaymentType.MONEYGRAM, "12.0")]
        [DataRow(PackageType.POST, PaymentType.NONE, "0.0")]
        public void GIVEN_AllInOnePackage_WHEN_CalculatePaymentCommision_is_invoked_THEN_correct_value_is_returned(PackageType packageType, PaymentType paymentType, string expectedString)
        {
            var item = new OrderItem() { Name = "iPhone", Quantity = 2, Price = 1.499M, Weight = 0.2M };

            _systemUnderTests = new AllInOnePackage<OrderItem>(packageType, paymentType);

            _systemUnderTests.AddItem(item);

            var actual = _systemUnderTests.CalculatePaymentCommision();
            var expected = Convert.ToDecimal(expectedString, new NumberFormatInfo() { NumberDecimalSeparator = "." });
            Assert.AreEqual(expected, actual);
        }
    }
}
