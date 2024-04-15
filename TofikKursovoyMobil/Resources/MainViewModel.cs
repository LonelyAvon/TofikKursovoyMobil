using System;
using System.Collections.ObjectModel;
using TofikKursovoyModels.ClassesCombine;
using TofikKursovoyModels;
using System.ComponentModel;

namespace TofikKursovoyMobil.Resources
{
	public class MainViewModel : BindableObject
    {
        public ObservableCollection<DiscountCombiner> _products { get; set; }
        public static ObservableCollection<DiscountCombiner> _products_types { get; set; }

        public MainViewModel()
		{
            AddToProduct();
		}
        public void AddToProduct()
        {
            _products = new ObservableCollection<DiscountCombiner>();


            List<Discount> discounts = Helper.GetAllDiscounts();
            List<Product> products = Helper.GetAllProducts();
            List<Brand> brands = Helper.GetAllBrands();

            for (int i = 0; i < 4; i++)
            {
                var product = products.Where(pr => pr.Id == discounts[i].IdProduct).FirstOrDefault();
                var brandname = brands.Where(b => b.Id == product.Brandname).FirstOrDefault().Name;
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
                _products.Add(new DiscountCombiner
                {
                    ID = product.Id,
                    Name = brandname + " " + product.Name,
                    PhotoName = $"Images/{typeOfTechnic}/{product.Photoname}.png",
                    ShortDescription = product.ShortDescription,
                    Description = product.Description,
                    OldCost = product.Cost,
                    NewCost = discounts[i].DiscountCost,
                    Existance = existance,
                });
            }
        }
    }
}

