using NCalc;
using System.Text.RegularExpressions;
namespace FirstMauiTest.Core;


public static class Calculator
{
    public static double EvaluateExpression(string input)
    {
        // Ersetze alle a^b durch pow(a,b)
        input = Regex.Replace(input, @"(\d+(?:\.\d+)?)\s*\^\s*(\d+(?:\.\d+)?)", "pow($1,$2)");

        var expr = new Expression(input);

        expr.EvaluateFunction += (name, args) =>
        {
            if (name == "pow" && args.Parameters.Length == 2)
            {
                var baseNum = Convert.ToDouble(args.Parameters[0].Evaluate());
                var exponent = Convert.ToDouble(args.Parameters[1].Evaluate());
                args.Result = Math.Pow(baseNum, exponent);
            }
        };

        object result = expr.Evaluate();
        double val = Convert.ToDouble(result);

        return double.IsInfinity(val) ? double.NaN : val;
    }
}