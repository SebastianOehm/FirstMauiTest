using FirstMauiTest.Core;

namespace FirstMauiTest.Tests
{
    public class CalculatorTests
    {
        [Theory]
        [InlineData(2, 3, "+", 5)]
        [InlineData(5, 3, "-", 2)]
        [InlineData(4, 2, "*", 8)]
        [InlineData(10, 2, "/", 5)]
        [InlineData(2, 3, "^", 8)]
        [InlineData(10, 3, "%", 1)]
        public void CalculateValidOperationsReturnsExpectedResult(double num1, double num2, string op, double expected)
        {
            Console.WriteLine("Test ValidOperations was executed");
            var result = Calculator.Calculate(num1, num2, op);
            Assert.Equal(expected, result, 5); // 5 = Genauigkeit bei Double-Vergleich
        }

        [Fact]
        public void CalculateDivideByZeroReturnsNaN()
        {
            var result = Calculator.Calculate(5, 0, "/");
            Assert.True(double.IsNaN(result));
        }

        [Fact]
        public void CalculateInvalidOperatorReturnsZero()
        {
            var result = Calculator.Calculate(5, 3, "?");
            Assert.Equal(0, result);
        }
    }

}
