namespace HindApp;

public partial class App : Application
{
    public App()
    {
        InitializeComponent();

        // Навигация через NavigationPage
        MainPage = new NavigationPage(new MainPage());
    }
}
