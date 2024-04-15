using System.Net.Http;
using System.Net.Http.Json;
using Newtonsoft.Json;
using TofikKursovoyModels.ClassesCombine;

namespace TofikKursovoyModels
{
	public interface Helper
	{
        public static string Uuid { get; set; }
        public static Client user { get; set; }

		public static HttpClient GetHttpClient()
		{
            var handler = new HttpClientHandler()
            {
                ServerCertificateCustomValidationCallback = HttpClientHandler.DangerousAcceptAnyServerCertificateValidator
            };
            HttpClient client =  new HttpClient(handler)
			{
				BaseAddress = new Uri(@"https://localhost:7204/"),
			};
            return client;
		}

        public static List<Product> GetCart()
        {
            using (HttpClient client = GetHttpClient())
            {
                var answer = client.GetStringAsync($"GetCart?uuid={Uuid}").Result;

                var productorders = JsonConvert.DeserializeObject<List<Product>>(answer);

                return productorders;
            }
        }
        public static void  RemoveProduct(int id)
        {
            using (HttpClient client = GetHttpClient())
            {
                var answer = client.DeleteAsync($"DeleteCartProduct?id={id}").Result;
            }
        }
        public static Client AddClient(Client _client)
        {
            using (HttpClient client = GetHttpClient())
            {
                JsonContent content = JsonContent.Create(_client);

                var answer = client.PostAsync("AddClient", content).Result;

                var resultJson = answer.Content.ReadAsStringAsync().Result;

                return JsonConvert.DeserializeObject<Client>(resultJson);
            }
        }
        public static void AddToCart(int idProduct)
        {
            CombineToCart cart = new CombineToCart()
            {
                IdProduct = idProduct,
                Uuid = Helper.Uuid
            };
            HttpContent content = JsonContent.Create(cart);
            using (HttpClient client = GetHttpClient())
            {
                var answer = client.PostAsync($"AddToCart",content).Result;
            };
        }
        public static bool RefreshClient(Client _client)
        {
            using (HttpClient client = GetHttpClient())
            {
                JsonContent content = JsonContent.Create(_client);

                var answer = client.PostAsync("RefreshClient", content).Result;

                var resultJson = answer.Content.ReadAsStringAsync().Result;

                return Convert.ToBoolean(resultJson);
            }
        }
        public static Client GetClient()
        {
            using (HttpClient client = GetHttpClient())
            {
                string response = client.GetStringAsync($"GetClient?uuid={Uuid}").Result;
                return JsonConvert.DeserializeObject<Client>(response);
            }
        }
        public static List<Discount> GetAllDiscounts()
        {
			using (HttpClient client = GetHttpClient())
			{
				string response =  client.GetStringAsync(@"GetDiscounts").Result;
				return JsonConvert.DeserializeObject<List<Discount>>(response);
			}
		}
        public static List<Typeoftechnic> GetAllTypes()
        {
            using (HttpClient client = GetHttpClient())
            {
                string response = client.GetStringAsync(@"GetTypes").Result;
                return JsonConvert.DeserializeObject<List<Typeoftechnic>>(response);
            }
        }
        public static List<Product> GetAllProducts()
        {
            using (HttpClient client = GetHttpClient())
            {
                string response = client.GetStringAsync("GetProducts").Result;
                return JsonConvert.DeserializeObject<List<Product>>(response);
            }
        }
        public static List<Brand> GetAllBrands()
        {
            using (HttpClient client = GetHttpClient())
            {
                string response =  client.GetStringAsync("GetBrands").Result;
                return JsonConvert.DeserializeObject<List<Brand>>(response);
            }
        }
    }
}

