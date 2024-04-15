using TofikKursovoyModels.ClassesCombine;
namespace TofikKursovoyMobil
{
    using TofikKursovoyMobil.Pages;
    using TofikKursovoyMobil.Resources;
    using TofikKursovoyModels;
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
			BindingContext = new MainViewModel();
			InitializeComponent();
		}

        async void GetProduct_Tapped(System.Object sender, Microsoft.Maui.Controls.TappedEventArgs e)
        {
            var product = ((sender as StackLayout).BindingContext as DiscountCombiner);

            await Navigation.PushModalAsync(new ProductInfo(product));
        }

        async void toTelegram_Clicked(System.Object sender, System.EventArgs e)
        {
            await Launcher.OpenAsync("https://t.me/cayyfff");
        }

        async void toVk_Clicked(System.Object sender, System.EventArgs e)
        {
            await Launcher.OpenAsync("https://vk.com/lil_mylo");
        }

        async void ToSearch_Clicked(System.Object sender, System.EventArgs e)
        {
            await Navigation.PushModalAsync(new SearchPage());
        }

        async void ToCart_Clicked(System.Object sender, System.EventArgs e)
        {
            await Navigation.PushModalAsync(new Cart());
        }

        async void ToProfile_Clicked(System.Object sender, System.EventArgs e)
        {
            await Navigation.PushModalAsync(new ProfilePage());
        }

        async void ToGuitars_Clicked(System.Object sender, System.EventArgs e)
        {
            await Navigation.PushModalAsync(new AllProducts(1));
        }

        async void ToKey_Clicked(System.Object sender, System.EventArgs e)
        {
            await Navigation.PushModalAsync(new AllProducts(3));
        }

        async void ToPuf_Clicked(System.Object sender, System.EventArgs e)
        {
            await Navigation.PushModalAsync(new AllProducts(4));
        }
    }
}


