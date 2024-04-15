using System.Collections.ObjectModel;
using TofikKursovoyMobil.Resources;
using TofikKursovoyModels;
using TofikKursovoyModels.ClassesCombine;

namespace TofikKursovoyMobil.Pages;

public partial class AllProducts : ContentPage
{
	public AllProducts(int IdType)
	{
		InitializeComponent();
        BindingContext = new AllProductsViewModel(IdType);
	}
    

    async void Back_Clicked(System.Object sender, System.EventArgs e)
    {
        await Navigation.PopModalAsync();
    }

    async void GetProduct_Tapped(System.Object sender, Microsoft.Maui.Controls.TappedEventArgs e)
    {
        var product = ((sender as StackLayout).BindingContext as DiscountCombiner);

        await Navigation.PushModalAsync(new ProductInfo(product));
    }
}
