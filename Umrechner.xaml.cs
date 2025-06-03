namespace FirstMauiTest;
public partial class UmrechnerPage : ContentPage
{
    public UmrechnerPage()
    {
        InitializeComponent();
    }
    private void OnConvertClicked(object sender, EventArgs e)
    {
        if (!double.TryParse(InputValue.Text, out double inputVal))
        {
            ResultLabel.Text = "Ungültige Zahl.";
            return;
        }

        try
        {
            string from = InputUnit.Text?.Trim().ToLower();
            string to = OutputUnit.Text?.Trim().ToLower();

            double result = ConvertValue(inputVal, from, to);
            var fromSymbol = units[from].Symbol;
            var toSymbol = units[to].Symbol;
            ResultLabel.Text = $"{inputVal} {fromSymbol} = {result:F2} {toSymbol}";
        }
        catch (Exception ex)
        {
            ResultLabel.Text = ex.Message;
        }
    }
    private void OnClearClicked(object sender, EventArgs e)
    {
        InputValue.Text = ""; // Reset input value
        InputUnit.Text = ""; // Reset input unit
        OutputUnit.Text = ""; // Reset output value
        ResultLabel.Text = ""; // Reset result label
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
    { "mm", new Unit { Symbol = "mm", Type = UnitType.Length, ToBase = v => v * 0.001, FromBase = v => v / 0.001 } },
    { "cm", new Unit { Symbol = "cm", Type = UnitType.Length, ToBase = v => v * 0.01, FromBase = v => v / 0.01 } },
    { "m",  new Unit { Symbol = "m",  Type = UnitType.Length, ToBase = v => v,        FromBase = v => v } },
    { "km", new Unit { Symbol = "km", Type = UnitType.Length, ToBase = v => v * 1000, FromBase = v => v / 1000 } },
    { "in", new Unit { Symbol = "in", Type = UnitType.Length, ToBase = v => v * 0.0254, FromBase = v => v / 0.0254 } },
    { "ft", new Unit { Symbol = "ft", Type = UnitType.Length, ToBase = v => v * 0.3048, FromBase = v => v / 0.3048 } },

    // Temperature (base: Celsius)
    { "c", new Unit { Symbol = "°C", Type = UnitType.Temperature, ToBase = v => v,               FromBase = v => v } },
    { "f", new Unit { Symbol = "°F", Type = UnitType.Temperature, ToBase = v => (v - 32) * 5/9,  FromBase = v => (v * 9/5) + 32 } },
    { "k", new Unit { Symbol = "K", Type = UnitType.Temperature, ToBase = v => v - 273.15,      FromBase = v => v + 273.15 } }
    };
}
