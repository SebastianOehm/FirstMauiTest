using static FirstMauiTest.Core.Converter;

namespace FirstMauiTest;
public partial class UmrechnerPage : ContentPage
{
    public UmrechnerPage()
    {
        InitializeComponent();
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();
        var unitList = units.Keys.ToList();
        FromUnitPicker.ItemsSource = unitList;
        ToUnitPicker.ItemsSource = unitList;
        InputDisplay.Text = "0";
        ResultLabel.Text = "";
    }

    private void OnConvertClicked(object sender, EventArgs e)
    {
        if (!double.TryParse(InputDisplay.Text, out double inputVal))
        {
            ResultLabel.Text = "Ungültige Zahl.";
            return;
        }

        string? from = FromUnitPicker.SelectedItem as string;
        string? to = ToUnitPicker.SelectedItem as string;

        if (string.IsNullOrWhiteSpace(from) || string.IsNullOrWhiteSpace(to))
        {
            ResultLabel.Text = "Bitte beide Einheiten wählen.";
            return;
        }

        try
        {
            double result = ConvertValue(inputVal, from, to);
            string fromSymbol = units[from].Symbol;
            string toSymbol = units[to].Symbol;
            ResultLabel.Text = $"{inputVal}{fromSymbol} = {result:F2}{toSymbol}";
        }
        catch (Exception ex)
        {
            ResultLabel.Text = ex.Message;
        }
    }

    private void OnKeypadClicked(object sender, EventArgs e)
    {
        if (sender is Button btn)
        {
            if (InputDisplay.Text == "0")
                InputDisplay.Text = btn.Text;
            else
                InputDisplay.Text += btn.Text;
        }
    }

    private void OnBackspaceClicked(object sender, EventArgs e)
    {
        if (!string.IsNullOrEmpty(InputDisplay.Text))
        {
            InputDisplay.Text = InputDisplay.Text.Length == 1
                ? "0"
                : InputDisplay.Text[..^1];
        }
    }

    private void OnClearClicked(object sender, EventArgs e)
    {
        InputDisplay.Text = "0";
        FromUnitPicker.SelectedIndex = -1;
        ToUnitPicker.SelectedIndex = -1;
        ResultLabel.Text = "";
    }

    private void OnCopyClicked(object sender, EventArgs e)
    {
        if (!string.IsNullOrWhiteSpace(ResultLabel.Text))
            Clipboard.SetTextAsync(ResultLabel.Text);
    }

    private async void OnBackClicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("..");
    }
}
