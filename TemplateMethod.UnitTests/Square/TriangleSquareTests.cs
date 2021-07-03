using Microsoft.VisualStudio.TestTools.UnitTesting;
using TemplateMethod.Square;

namespace TemplateMethod.UnitTests.Square
{
    [TestClass]
    public class TriangleSquareTests
    {
        [TestMethod]
        public void GIVEN_side_and_height_are_greater_than_zero_WHEN_Calculate_is_ivoked_THEN_correct_value_is_returned()
        {
            var triangle = new TriangleSquare(5,10);
            triangle.Calculate();

            var expected = 25;
            var actual = triangle.Square;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void GIVEN_side_is_equal_to_zero_WHEN_Calculate_is_ivoked_THEN_zero_is_returned()
        {
            var triangle = new TriangleSquare(0, 10);
            triangle.Calculate();

            var expected = 0;
            var actual = triangle.Square;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void GIVEN_height_is_equal_to_zero_WHEN_Calculate_is_ivoked_THEN_zero_is_returned()
        {
            var triangle = new TriangleSquare(5, 0);
            triangle.Calculate();

            var expected = 0;
            var actual = triangle.Square;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void GIVEN_side_and_height_are_less_than_zero_WHEN_Calculate_is_ivoked_THEN_zero_is_returned()
        {
            var triangle = new TriangleSquare(-5, -10);
            triangle.Calculate();

            var expected = 0;
            var actual = triangle.Square;

            Assert.AreEqual(expected, actual);
        }
    }
}
