namespace FirstMauiTest;

public partial class ErfolgPage : ContentPage
{
    public ErfolgPage()
    {
        InitializeComponent();
    }

    private async void OnBackClicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("..");
    }
}