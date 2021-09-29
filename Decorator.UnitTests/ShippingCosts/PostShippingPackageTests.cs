using Decorator.Interfaces;
using Decorator.ShippingCosts;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Decorator.UnitTests.ShippingCosts
{

    [TestClass]
    public class PostShippingPackageTests
    {
        private IPackage _systemUnderTests;
        private IPackage _packageToBeDecorated;
        private PackageFactory _packageFactory = new PackageFactory();

        [TestInitialize]
        public void InitializeTest()
        {
            _packageToBeDecorated = _packageFactory.Order();
            _systemUnderTests = new PostShippingPackage(_packageToBeDecorated);
        }


        [TestMethod]
        public void GIVEN_Package_Decorator_WHEN_CalculateShippingCosts_is_invoked_THEN_correct_value_is_returned()
        {
            var actual = _systemUnderTests.CalculateShippingCosts();
            var expected = _packageToBeDecorated.CalculateShippingCosts() + PostShippingPackage.SHIPPING_COST;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void GIVEN_Package_Decorator_WHEN_decorator_is_used_THEN_it_should_not_affect_other_not_decorated_methods()
        {
            Assert.AreEqual(_packageToBeDecorated.CalculateValue(), _systemUnderTests.CalculateValue());
            Assert.AreEqual(_packageToBeDecorated.CalculateWeight(), _systemUnderTests.CalculateWeight());
            Assert.AreEqual(_packageToBeDecorated.CalculatePaymentCommision(), _systemUnderTests.CalculatePaymentCommision());
        }
    }
}
