using TofikKursovoyModels;
namespace TofikKursovoyMobil;

public partial class App : Application
{
	public App()
	{
		InitializeComponent();
		if (!Preferences.ContainsKey("uuid"))
		{
			string uuid = Guid.NewGuid().ToString();
			Preferences.Set("uuid", uuid);
            Helper.Uuid = uuid;
			Helper.user = Helper.AddClient(new Client
			{
				Id = uuid,
			});
		}
		Helper.Uuid = Preferences.Get("uuid", "1");
		Helper.user = Helper.GetClient();
		MainPage = new NavigationPage(new MainPage());
	}
}

