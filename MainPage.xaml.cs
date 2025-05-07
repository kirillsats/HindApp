namespace Hind;

public partial class MainPage : ContentPage
{
    public MainPage()
    {
        InitializeComponent();
    }

    private async void OnFavoritesClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new FavoritesPage());
    }

    private async void OnCategoriesClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new CategoriesPage());
    }

    private async void OnScannerClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new ScannerPage());
    }
}
