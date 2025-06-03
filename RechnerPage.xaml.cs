namespace FirstMauiTest;
public partial class RechnerPage : ContentPage
{
    public RechnerPage()
    {
        InitializeComponent();
    }
    private void OnAddClicked(object sender, EventArgs e)
    {
        if (double.TryParse(Number1Entry.Text, out double num1) &&
            double.TryParse(Number2Entry.Text, out double num2))
        {
            double result = num1 + num2;
            ResultLabel.Text = $"Ergebnis: {result}";
        }
        else
        {
            ResultLabel.Text = "Bitte gültige Zahlen eingeben.";
        }
    }
    private async void OnBackClicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("..");
    }
}
