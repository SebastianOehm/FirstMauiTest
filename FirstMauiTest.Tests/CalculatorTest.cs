using FirstMauiTest.Core;

namespace FirstMauiTest.Tests
{
    public class CalculatorTests
    {
        [Theory]
        [InlineData("2+3", 5)]
        [InlineData("5-3", 2)]
        [InlineData("4*2", 8)]
        [InlineData("10/2", 5)]
        [InlineData("2^3", 8)]
        [InlineData("10%3", 1)]
        public void CalculateValidOperationsReturnsExpectedResult(string expression, double expected)
        {
            Console.WriteLine("Test ValidOperations was executed");
            var result = Calculator.EvaluateExpression(expression);
            Assert.Equal(expected, result, 5); // 5 = Genauigkeit bei Double-Vergleich
        }

        [Fact]
        public void CalculateDivideByZeroReturnsNaN()
        {
            var result = Calculator.EvaluateExpression("3/0");
            Console.WriteLine("The result is: " + result);
            Assert.True(double.IsNaN(result));
        }
    }
}
