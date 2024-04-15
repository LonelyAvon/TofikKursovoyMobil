using System.Text.RegularExpressions;
using TofikKursovoyModels;

namespace TofikKursovoyMobil.Pages;

public partial class ProfilePage : ContentPage
{
	public ProfilePage()
	{
		InitializeComponent();
	}

    async void UploadButton_Clicked(System.Object sender, System.EventArgs e)
    {
		if (string.IsNullOrEmpty(SurnameTextBox.Text))
		{
			await DisplayAlert("Error", "Заполните поле Фамилия","ok");
			return;
		}
        if (string.IsNullOrEmpty(NameTextBox.Text))
        {
            await DisplayAlert("Error", "Заполните поле Имя","ok");
            return;
        }
        if (string.IsNullOrEmpty(PatronymicTextBox.Text))
        {
            await DisplayAlert("Error", "Заполните поле Отчество","ok");
            return;
        }
        string pattern = @"^((8|\+7)[\- ]?)?(\(?\d{3}\)?[\- ]?)?[\d\- ]{7,10}$";
        if (!Regex.IsMatch(PhoneTextBox.Text, pattern))
        {
            await DisplayAlert("Error", "Заполните поле Номер телефона", "ok");
            return;
        }
        Helper.user.Surname = SurnameTextBox.Text;
        Helper.user.Name = NameTextBox.Text;
        Helper.user.Patronymic = PatronymicTextBox.Text;
        Helper.user.Phone = PhoneTextBox.Text;
        if (Helper.RefreshClient(Helper.user))
        {
            await DisplayAlert("Acces", "Данные обновлены", "ok");
        }
    }
    protected override void OnAppearing()
    {
        base.OnAppearing();
        SurnameTextBox.Text = Helper.user.Surname;
        NameTextBox.Text = Helper.user.Name;
        PatronymicTextBox.Text = Helper.user.Patronymic;
        PhoneTextBox.Text = Helper.user.Phone;

    }

    async void ToCart_Clicked(System.Object sender, System.EventArgs e)
    {
        await Navigation.PushModalAsync(new CartPage());
    }

    void ToSearch_Clicked(System.Object sender, System.EventArgs e)
    {
    }

    async void ToHome_Clicked(System.Object sender, System.EventArgs e)
    {
        await Navigation.PushModalAsync(new MainPage());
    }
}
