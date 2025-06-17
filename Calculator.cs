namespace FirstMauiTest;

public static class Calculator
{
    public static double Calculate(double num1, double num2, string op)
    {
        return op switch
        {
            "+" => num1 + num2,
            "-" => num1 - num2,
            "*" => num1 * num2,
            "/" => num2 != 0 ? num1 / num2 : double.NaN,
            "^" => Math.Pow(num1, num2),
            "%" => num1 % num2,
            _ => 0
        };
    }
}