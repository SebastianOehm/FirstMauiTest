using static FirstMauiTest.Core.Converter;

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
            string from = InputUnit.Text?.Trim()?.ToLower() ?? string.Empty;
            string to = OutputUnit.Text?.Trim()?.ToLower() ?? string.Empty;

            double result = ConvertValue(inputVal, from, to);
            var fromSymbol = units[from].Symbol;
            var toSymbol = units[to].Symbol;
            ResultLabel.Text = $"{inputVal}{fromSymbol} = {result:F2}{toSymbol}";
            // await TextToSpeech.Default.SpeakAsync(ResultLabel.Text);
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
}
