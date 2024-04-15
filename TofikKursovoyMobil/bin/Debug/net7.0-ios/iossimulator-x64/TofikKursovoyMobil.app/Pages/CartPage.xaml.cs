
using TofikKursovoyMobil.Resources;
using TofikKursovoyModels;
using TofikKursovoyModels.ClassesCombine;

namespace TofikKursovoyMobil.Pages;

public partial class CartPage : ContentPage
{
	public CartPage()
	{
		InitializeComponent();
        if (Helper.GetCart() != null)
        {
            ProductStackLayout.IsVisible = false;
            ItemsStackLayout.IsVisible = true;
            BindingContext = new CartViewModel();
        }
	}
    protected override void OnAppearing()
    {
        base.OnAppearing();
    }

 
}
