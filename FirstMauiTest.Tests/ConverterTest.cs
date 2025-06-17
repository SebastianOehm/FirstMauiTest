using FirstMauiTest.Core;

namespace FirstMauiTest.Tests
{
    public class ConverterTests
    {
        [Theory]
        [InlineData(12, "in", "ft", 1)]
        [InlineData(10, "mm", "cm", 1)]
        [InlineData(0, "K", "C", -273.15)]
        [InlineData(5000, "kg", "t", 5)]
        [InlineData(0.5, "lb", "oz", 8)]
        [InlineData(39.2, "F", "C", 4)]
        public void ConversionReturnsExpectedResult(double value, string fromUnit, string toUnit, double expected)
        {
            Console.WriteLine("Test ValidOperations was executed");
            var result = Converter.ConvertValue(value, fromUnit, toUnit);
            Assert.Equal(expected, result, 5); // 5 = Genauigkeit bei Double-Vergleich
        }

        [Fact]
        public void ImpossibleConversionReturnsNotCompatible()
        {
            try { 
                var result = Converter.ConvertValue(100, "in", "K");
                Assert.Fail("Expected exception was not thrown.");
            }
            catch (Exception ex)
            {
                Assert.Equal("Einheiten sind nicht kompatibel.", ex.Message);
            }
        }
    }
}
