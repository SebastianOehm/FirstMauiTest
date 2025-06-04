namespace FirstMauiTest
{
    public enum UnitType
    {
        Length,
        Temperature,
        Mass
    }
    class Unit
    {
        public string Symbol { get; set; }

        public string Name { get; set; }
        public UnitType Type { get; set; }
        public Func<double, double>? ToBase { get; set; }
        public Func<double, double>? FromBase { get; set; }
    }
}
