using TofikKursovoyModels;
using TofikKursovoyModels.ClassesCombine;

namespace TofikKursovoyMobil.Pages;

public partial class ProductInfo : ContentPage
{
	public DiscountCombiner item;
	public ProductInfo(DiscountCombiner selectedItem)
	{
		InitializeComponent();
		item = selectedItem;
		BindingContext = selectedItem;
	}

    async void Back_Clicked(System.Object sender, System.EventArgs e)
    {
		await Navigation.PopModalAsync();
	}

    async void AddToCart_Clicked(System.Object sender, System.EventArgs e)
    {
		Helper.AddToCart(item.ID);
		await DisplayAlert("Acces", "Товар добавлен в корзину", "Ok");
    }
}
