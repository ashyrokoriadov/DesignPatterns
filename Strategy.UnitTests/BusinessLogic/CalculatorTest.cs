using Microsoft.VisualStudio.TestTools.UnitTesting;
using Strategy.BusinessLogic;
using Strategy.UnitTests.Mocks;

namespace Startegy.UnitTests
{
    [TestClass]
    public class CalculatorTest
    {
        [TestMethod]
        public void GIVEN_calculator_WHEN_add_is_ivoked_THEN_correct_value_is_returned()
        {
            var systemUnderTests = new Calculator(new MockLoggingStrategy());
            var actual = systemUnderTests.Add(-1.0M, -2.0M);
            var expected = -3.0M;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void GIVEN_calculator_WHEN_subtract_is_ivoked_THEN_correct_value_is_returned()
        {
            var systemUnderTests = new Calculator(new MockLoggingStrategy());
            var actual = systemUnderTests.Subtract(-1.0M, -2.0M);
            var expected = 1.0M;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void GIVEN_calculator_WHEN_multiply_is_ivoked_THEN_correct_value_is_returned()
        {
            var systemUnderTests = new Calculator(new MockLoggingStrategy());
            var actual = systemUnderTests.Multiply(-1.0M, -2.0M);
            var expected = 2.0M;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void GIVEN_calculator_WHEN_divide_is_ivoked_THEN_correct_value_is_returned()
        {
            var systemUnderTests = new Calculator(new MockLoggingStrategy());
            var actual = systemUnderTests.Divide(-1.0M, -2.0M);
            var expected = 0.5M;
            Assert.AreEqual(expected, actual);
        }


        [TestMethod]
        public void GIVEN_calculator_WHEN_divide_is_ivoked__and_dividor_is_zero_THEN_no_exception_is_thrown_and_zero_is_returned()
        {
            var systemUnderTests = new Calculator(new MockLoggingStrategy());
            var actual = systemUnderTests.Divide(2.0M, 0.0M);
            var expected = 0;
            Assert.AreEqual(expected, actual);
        }
    }
}
