using Microsoft.VisualStudio.TestTools.UnitTesting;
using TemplateMethod.Square;

namespace TemplateMethod.UnitTests.Square
{
    [TestClass]
    public class CircleSquareTests
    {
        [TestMethod]
        public void GIVEN_radius_greater_than_zero_WHEN_Calculate_is_ivoked_THEN_correct_value_is_returned()
        {
            var circle = new CircleSquare(10);
            circle.Calculate();

            var expected = 314.159;
            var actual = circle.Square;
            var delta = 0.001;

            Assert.AreEqual(expected, actual, delta);
        }

        [TestMethod]
        public void GIVEN_radius_is_equal_to_zero_WHEN_Calculate_is_ivoked_THEN_zero_is_returned()
        {
            var circle = new CircleSquare(0);
            circle.Calculate();

            var expected = 0;
            var actual = circle.Square;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void GIVEN_radius_is_less_than_zero_WHEN_Calculate_is_ivoked_THEN_zero_is_returned()
        {
            var circle = new CircleSquare(-10);
            circle.Calculate();

            var expected = 0;
            var actual = circle.Square;

            Assert.AreEqual(expected, actual);
        }
    }
}
