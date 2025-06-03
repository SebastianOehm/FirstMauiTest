using Maui.Biometric;
namespace FirstMauiTest;
public partial class MainPage : ContentPage
{
    public MainPage()
    {
        InitializeComponent();
    }

    private async void OnAuthenticateClicked(object sender, EventArgs e)
    {
        var result = await BiometricAuthentication.Current.AuthenticateAsync(
            new AuthenticationRequest(
                title: "Authenticate",
                reason: "Bitten authentifizieren Sie sich um fortzufahren"));

        if (result.IsSuccessful)
        {
            StatusLabel.Text = "";
            int erfolgsCount = Preferences.Get("ErfolgsCount", 0);
            erfolgsCount++;
            Preferences.Set("ErfolgsCount", erfolgsCount);

            await Shell.Current.GoToAsync("erfolg");
        } else
        {
            StatusLabel.Text = result.ErrorMessage;
        }
    }
    private async void OnBackClicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("..");
    }
}