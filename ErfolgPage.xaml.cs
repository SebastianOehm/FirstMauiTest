namespace FirstMauiTest;

public partial class ErfolgPage : ContentPage
{
    public ErfolgPage()
    {
        InitializeComponent();
        int erfolgsCount = Preferences.Get("ErfolgsCount", 0);
        ErfolgLabel.Text = $"Erfolgreich angemeldet: {erfolgsCount} mal";
    }
    private async void OnRechnerClicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("rechner");
    }

    private async void OnBackClicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("..");
    }
}