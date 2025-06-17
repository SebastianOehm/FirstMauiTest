using static FirstMauiTest.Core.Calculator;
using System.Text;

namespace FirstMauiTest;
public partial class RechnerPage : ContentPage
{
    private string _currentInput = "";
    public RechnerPage()
    {
        InitializeComponent();
    }
    private void OnButtonClicked(object sender, EventArgs e)
    {
        if (sender is Button btn)
        {
            _currentInput += btn.Text;
            ResultLabel.Text = _currentInput;
        }
    }
    private void OnDeleteClicked(object sender, EventArgs e)
    {
        if (!string.IsNullOrEmpty(_currentInput))
        {
            _currentInput = _currentInput[..^1];
            ResultLabel.Text = _currentInput;
        }
    }
    private void OnEqualsClicked(object sender, EventArgs e)
    {
        try
        {
            // Basic calculation using the same core logic (if possible)
            double result = EvaluateExpression(_currentInput);
            ResultLabel.Text = $"{_currentInput} = {result}";
            _currentInput = result.ToString();
        }
        catch
        {
            ResultLabel.Text = "Fehlerhafte Eingabe";
            _currentInput = "";
        }
    }
    private async void OnBackClicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("..");
    }
}