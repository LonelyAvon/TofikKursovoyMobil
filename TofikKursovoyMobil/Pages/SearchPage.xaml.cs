using System.Collections.ObjectModel;
using TofikKursovoyMobil.Resources;
using TofikKursovoyModels;
using TofikKursovoyModels.ClassesCombine;

namespace TofikKursovoyMobil.Pages;

public partial class SearchPage : ContentPage
{
    public ObservableCollection<DiscountCombiner> combiners = new ObservableCollection<DiscountCombiner>();
	public SearchPage()
	{
		InitializeComponent();
        CategoriesCollectionView.ItemsSource = Helper.GetAllTypes();
        GetProductsTypes();
    }
    protected override void OnAppearing()
    {
        base.OnAppearing();


    }
    async void Back_Clicked(System.Object sender, System.EventArgs e)
    {
        await Navigation.PopModalAsync();
    }

    async void CategoriesCollectionView_SelectionChanged(System.Object sender, Microsoft.Maui.Controls.SelectionChangedEventArgs e)
    {
        var type = (sender as CollectionView).SelectedItem as Typeoftechnic;
        await Navigation.PushModalAsync(new AllProducts(type.Id));
    }

    void BrandSearch_TextChanged(System.Object sender, Microsoft.Maui.Controls.TextChangedEventArgs e)
    {
        if (string.IsNullOrEmpty(BrandSearch.Text))
        {
            CategoriesCollectionView.IsVisible = true;
            flexLayout.IsVisible = false;
        }
        else
        {
            flexLayout.IsVisible = true;
            BindingContext = new SearchViewModel(combiners.Where(x => x.Name.Contains(BrandSearch.Text)).ToList());
            CategoriesCollectionView.IsVisible = false;
        }
    }

    async void GetProduct_Tapped(System.Object sender, Microsoft.Maui.Controls.TappedEventArgs e)
    {
        var product = ((sender as StackLayout).BindingContext as DiscountCombiner);

        await Navigation.PushModalAsync(new ProductInfo(product));
    }
    public async void GetProductsTypes()
    {
        List<Product> products = Helper.GetAllProducts();
        List<Brand> brands = Helper.GetAllBrands();

        foreach (var product in products)
        {
            var brandname = brands.Where(b => b.Id == Convert.ToInt32(product.Brandname)).FirstOrDefault();
            string existance = "";
            switch (product.Existance)
            {
                case true:
                    existance = "В наличии";
                    break;
                case false:
                    existance = "Нет в наличии";
                    break;
            }
            string typeOfTechnic = "";
            switch (product.Typeoftechnic)
            {
                case 1:
                    typeOfTechnic = "Guitars";
                    break;
                case 2:
                    typeOfTechnic = "Beat";
                    break;
                case 3:
                    typeOfTechnic = "Key";
                    break;
                case 4:
                    typeOfTechnic = "Fuu";
                    break;
                case 5:
                    typeOfTechnic = "MusicHelpers";
                    break;
                case 6:
                    typeOfTechnic = "Accessories";
                    break;
            }
            combiners.Add(new DiscountCombiner
            {
                ID = product.Id,
                Name = brandname.Name + " " + product.Name,
                PhotoName = $"Images/{typeOfTechnic}/{product.Photoname}.png",
                ShortDescription = product.ShortDescription,
                Description = product.Description,
                NewCost = product.Cost,
                Existance = existance,
            });
        }
    }

}
