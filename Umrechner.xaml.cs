namespace FirstMauiTest;
public partial class UmrechnerPage : ContentPage
{
    public UmrechnerPage()
    {
        InitializeComponent();
    }
    private async void OnConvertClicked(object sender, EventArgs e)
    {
        if (!double.TryParse(InputValue.Text, out double inputVal))
        {
            ResultLabel.Text = "Ungültige Zahl.";
            return;
        }

        try
        {
            string from = InputUnit.Text?.Trim()?.ToLower() ?? string.Empty;
            string to = OutputUnit.Text?.Trim()?.ToLower() ?? string.Empty;

            double result = ConvertValue(inputVal, from, to);
            var fromSymbol = units[from].Symbol;
            var toSymbol = units[to].Symbol;
            ResultLabel.Text = $"{inputVal}{fromSymbol} = {result:F2}{toSymbol}";
            await TextToSpeech.Default.SpeakAsync(ResultLabel.Text);
        }
        catch (Exception ex)
        {
            ResultLabel.Text = ex.Message;
        }
    }
    private void OnClearClicked(object sender, EventArgs e)
    {
        InputValue.Text = "";
        InputUnit.Text = "";
        OutputUnit.Text = "";
        ResultLabel.Text = "";
    }
    private void OnCopyClicked(object sender, EventArgs e)
    {
        Clipboard.SetTextAsync(ResultLabel.Text);
    }
    private async void OnBackClicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("..");
    }

    double ConvertValue(double value, string fromUnitStr, string toUnitStr)
    {
        fromUnitStr = fromUnitStr.ToLower();
        toUnitStr = toUnitStr.ToLower();

        if (!units.ContainsKey(fromUnitStr) || !units.ContainsKey(toUnitStr))
            throw new Exception("Unbekannte Einheit.");

        var fromUnit = units[fromUnitStr];
        var toUnit = units[toUnitStr];

        if (fromUnit.Type != toUnit.Type)
            throw new Exception("Einheiten sind nicht kompatibel.");

        double baseValue = fromUnit.ToBase!(value);
        double result = toUnit.FromBase!(baseValue);
        return result;
    }
    readonly Dictionary<string, Unit> units = new()
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
