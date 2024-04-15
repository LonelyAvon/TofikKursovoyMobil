
using System.Collections.ObjectModel;
using TofikKursovoyMobil.Resources;
using TofikKursovoyModels;
using TofikKursovoyModels.ClassesCombine;

namespace TofikKursovoyMobil.Pages;

public partial class Cart : ContentPage
{
    public List<DiscountCombiner> cartproducts;
	public Cart()
	{
		InitializeComponent();
    }
    protected override void OnAppearing()
    {
        base.OnAppearing();
        if (Helper.GetCart()!=null)
        {

            ProductStackLayout.IsVisible = false;
            ItemsStackLayout.IsVisible = true;
            ClearAllCart.IsVisible = true;
            Products.IsVisible = true;
            ItemsStackLayout.ItemsSource = GetProductOrder();
        }
    }

    async void Back_Clicked(System.Object sender, System.EventArgs e)
    {
        await Navigation.PopModalAsync();
    }

    async void Home_Clicked(System.Object sender, System.EventArgs e)
    {
        await Navigation.PushModalAsync(new MainPage());
    }

    async void ToSearch_Clicked(System.Object sender, System.EventArgs e)
    {
        await Navigation.PushModalAsync(new SearchPage());
    }

    async void ToProfile_Clicked(System.Object sender, System.EventArgs e)
    {
        await Navigation.PushModalAsync(new ProfilePage());

    }

    void ClearAllCart_Clicked(System.Object sender, System.EventArgs e)
    {
        List<DiscountCombiner> context = cartproducts;
        List<int> ids = new List<int>();

        foreach(var c in context)
        {
            Helper.RemoveProduct(c.ID);
        }
        ProductStackLayout.IsVisible = true;
        ItemsStackLayout.IsVisible = false;
        ClearAllCart.IsVisible = false;
        Products.IsVisible = false;
    }
    public List<DiscountCombiner> GetProductOrder()
    {
        cartproducts = new List<DiscountCombiner>();
        var brands = Helper.GetAllBrands();
        List<Product> products = Helper.GetCart();
        var _products = Helper.GetAllProducts();

        foreach (var p in products)
        {
            var brandname = brands.Where(b => b.Id == p.Brandname).FirstOrDefault().Name;
            string existance = "";
            switch (p.Existance)
            {
                case true:
                    existance = "В наличии";
                    break;
                case false:
                    existance = "Нет в наличии";
                    break;
            }
            string typeOfTechnic = "";
            switch (p.Typeoftechnic)
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
            cartproducts.Add(new DiscountCombiner
            {
                ID = p.Id,
                Name = brandname + " " + p.Name,
                PhotoName = $"Images/{typeOfTechnic}/{p.Photoname}.png",
                ShortDescription = p.ShortDescription,
                OldCost = p.Cost,
                Existance = existance,
                Description = p.Description
            });
        }
        return cartproducts;

    }

    async void ItemsStackLayout_SelectionChanged(System.Object sender, Microsoft.Maui.Controls.SelectionChangedEventArgs e)
    {
        var product = (sender as CollectionView).SelectedItem as DiscountCombiner;

        await Navigation.PushModalAsync(new ProductInfo(product));
    }
}
