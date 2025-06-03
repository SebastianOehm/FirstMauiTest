namespace FirstMauiTest
{
    public enum UnitType
    {
        Length,
        Temperature
    }
    class Unit
    {
        public string Symbol { get; set; }
        public UnitType Type { get; set; }
        public Func<double, double>? ToBase { get; set; }
        public Func<double, double>? FromBase { get; set; }
    }
}
