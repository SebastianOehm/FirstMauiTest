namespace FirstMauiTest
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute("erfolg", typeof(ErfolgPage));
        }
    }
}
