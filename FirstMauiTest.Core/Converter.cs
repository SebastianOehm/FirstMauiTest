namespace FirstMauiTest.Core
{
    public class Converter
    {
        public static double ConvertValue(double value, string fromUnitStr, string toUnitStr)
        {
            fromUnitStr = fromUnitStr.ToLower();
            toUnitStr = toUnitStr.ToLower();

            if (!units.TryGetValue(fromUnitStr, out var fromUnit) || !units.TryGetValue(toUnitStr, out var toUnit))
            {
                throw new Exception("Unbekannte Einheit.");
            }

            if (fromUnit.Type != toUnit.Type)
            {
                throw new Exception("Einheiten sind nicht kompatibel.");
            }

            double baseValue = fromUnit.ToBase!(value);
            double result = toUnit.FromBase!(baseValue);
            return result;
        }

        public static readonly Dictionary<string, Unit> units = new()
        {
            // Length (base: meter)
            { "mm", new Unit { Symbol = "mm", Name = "Millimeter", Type = UnitType.Length, ToBase = v => v * 0.001, FromBase = v => v / 0.001 } },
            { "cm", new Unit { Symbol = "cm", Name = "Zentimeter", Type = UnitType.Length, ToBase = v => v * 0.01, FromBase = v => v / 0.01 } },
            { "m", new Unit { Symbol = "m", Name = "Meter", Type = UnitType.Length, ToBase = v => v, FromBase = v => v } },
            { "km", new Unit { Symbol = "km", Name = "Kilometer", Type = UnitType.Length, ToBase = v => v * 1000, FromBase = v => v / 1000 } },
            { "in", new Unit { Symbol = "\"", Name = "Zoll", Type = UnitType.Length, ToBase = v => v * 0.0254, FromBase = v => v / 0.0254 } },
            { "ft", new Unit { Symbol = "'", Name = "Fuß", Type = UnitType.Length, ToBase = v => v * 0.3048, FromBase = v => v / 0.3048 } },

            // Temperature (base: Celsius)
            { "c", new Unit { Symbol = "°C", Name = "Grad Celsius", Type = UnitType.Temperature, ToBase = v => v, FromBase = v => v } },
            { "f", new Unit { Symbol = "°F", Name = "Grad Fahrenheit", Type = UnitType.Temperature, ToBase = v => (v - 32) * 5 / 9, FromBase = v => (v * 9 / 5) + 32 } },
            { "k", new Unit { Symbol = "K", Name = "Kelvin", Type = UnitType.Temperature, ToBase = v => v - 273.15, FromBase = v => v + 273.15 } },

            // Mass (base: kilogram)
            { "µg", new Unit { Symbol = "µg", Name = "Mikrogramm", Type = UnitType.Mass, ToBase = v => v * 1e-9, FromBase = v => v / 1e-9 } },
            { "mg", new Unit { Symbol = "mg", Name = "Milligramm", Type = UnitType.Mass, ToBase = v => v * 1e-6, FromBase = v => v / 1e-6 } },
            { "g", new Unit { Symbol = "g", Name = "Gramm", Type = UnitType.Mass, ToBase = v => v * 1e-3, FromBase = v => v / 1e-3 } },
            { "kg", new Unit { Symbol = "kg", Name = "Kilogramm", Type = UnitType.Mass, ToBase = v => v, FromBase = v => v } },
            { "t", new Unit { Symbol = "t", Name = "Tonne", Type = UnitType.Mass, ToBase = v => v * 1000, FromBase = v => v / 1000 } },

            // Imperial Mass
            { "oz", new Unit { Symbol = "oz", Name = "Unze", Type = UnitType.Mass, ToBase = v => v * 0.0283495, FromBase = v => v / 0.0283495 } },
            { "lb", new Unit { Symbol = "lb", Name = "Pfund", Type = UnitType.Mass, ToBase = v => v * 0.453592, FromBase = v => v / 0.453592 } },
            { "st", new Unit { Symbol = "st", Name = "Stone", Type = UnitType.Mass, ToBase = v => v * 6.35029, FromBase = v => v / 6.35029 } }
        };
    }
}