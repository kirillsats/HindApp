using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;

namespace Hind;

public class MainViewModel : INotifyPropertyChanged
{
    public ObservableCollection<Product> Products { get; set; }
    public ObservableCollection<Product> FilteredProducts { get; set; }

    private string searchQuery;
    public string SearchQuery
    {
        get => searchQuery;
        set
        {
            if (searchQuery != value)
            {
                searchQuery = value;
                OnPropertyChanged();
                FilterProducts();
            }
        }
    }
    
    public ICommand PerformSearchCommand { get; }

    public MainViewModel()
    {
        Products = new ObservableCollection<Product>
        {
            new Product { Name = "Piim 2.5%", Price = "1.39 €", Store = "Prisma" },
            new Product { Name = "Krõpsud", Price = "0.89 €", Store = "Rimi" },
            new Product { Name = "Juust", Price = "3.45 €", Store = "Selver" }
        };

        FilteredProducts = new ObservableCollection<Product>(Products);
        PerformSearchCommand = new Command(FilterProducts);
    }

    private void FilterProducts()
    {
        var lowerQuery = SearchQuery?.ToLower() ?? "";
        var results = Products.Where(p => p.Name.ToLower().Contains(lowerQuery)).ToList();

        FilteredProducts.Clear();
        foreach (var product in results)
            FilteredProducts.Add(product);
    }

    public event PropertyChangedEventHandler PropertyChanged;
    void OnPropertyChanged([CallerMemberName] string name = "") =>
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
}
   