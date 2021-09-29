using Decorator.Interfaces;
using Decorator.PaymentComissions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Decorator.UnitTests.PaymentComissions
{
    [TestClass]
    public class MoneyGramPaymentComissionPackageTests
    {
        private IPackage _systemUnderTests;
        private IPackage _packageToBeDecorated;
        private PackageFactory _packageFactory = new PackageFactory();

        [TestInitialize]
        public void InitializeTest()
        {
            _packageToBeDecorated = _packageFactory.Order();
            _systemUnderTests = new MoneyGramPaymentComissionPackage(_packageToBeDecorated);
        }


        [TestMethod]
        public void GIVEN_Package_Decorator_WHEN_CalculatePaymentCommision_is_invoked_THEN_correct_value_is_returned()
        {
            var actual = _systemUnderTests.CalculatePaymentCommision();
            var expected = _packageToBeDecorated.CalculatePaymentCommision() + MoneyGramPaymentComissionPackage.COMISSION;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void GIVEN_Package_Decorator_WHEN_decorator_is_used_THEN_it_should_not_affect_other_not_decorated_methods()
        {
            Assert.AreEqual(_packageToBeDecorated.CalculateValue(), _systemUnderTests.CalculateValue());
            Assert.AreEqual(_packageToBeDecorated.CalculateWeight(), _systemUnderTests.CalculateWeight());
            Assert.AreEqual(_packageToBeDecorated.CalculateShippingCosts(), _systemUnderTests.CalculateShippingCosts());
        }
    }
}
