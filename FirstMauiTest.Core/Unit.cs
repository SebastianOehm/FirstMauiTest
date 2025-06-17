namespace FirstMauiTest.Core;
public enum UnitType
{
    Length,
    Temperature,
    Mass
}
public class Unit
{
    public required string Symbol { get; set; }
    public required string Name { get; set; }
    public UnitType Type { get; set; }
    public Func<double, double>? ToBase { get; set; }
    public Func<double, double>? FromBase { get; set; }
}