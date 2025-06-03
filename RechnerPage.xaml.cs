namespace FirstMauiTest;
public partial class RechnerPage : ContentPage
{
    public RechnerPage()
    {
        InitializeComponent();
    }
    private void OnCalculateClicked(object sender, EventArgs e)
    {
        if (double.TryParse(Number1Entry.Text, out double num1) &&
             double.TryParse(Number2Entry.Text, out double num2))
        {
            string op = OperatorPicker.SelectedItem as string;
            double result = op switch
            {
                "+" => num1 + num2,
                "-" => num1 - num2,
                "*" => num1 * num2,
                "/" => num2 != 0 ? num1 / num2 : double.NaN,
                "^" => Math.Pow(num1, num2),
                "%" => num1 % num2,
                _ => 0
            };
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
