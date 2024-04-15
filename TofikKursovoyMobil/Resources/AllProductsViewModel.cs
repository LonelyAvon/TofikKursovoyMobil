using System;
using System.Collections.ObjectModel;
using TofikKursovoyModels;
using TofikKursovoyModels.ClassesCombine;

namespace TofikKursovoyMobil.Resources
{
	public class AllProductsViewModel : BindableObject
    {
        public ObservableCollection<DiscountCombiner> _product { get; set; }

        public AllProductsViewModel(int IdType)
		{
            GetProductsTypes(IdType);
		}
        public void GetProductsTypes(int id_type)
        {
            _product = new ObservableCollection<DiscountCombiner>();
            List<Product> products = Helper.GetAllProducts();
            List<Brand> brands = Helper.GetAllBrands();

            var products1 = products.Where(x => x.Typeoftechnic == id_type).ToList();
            foreach (var product1 in products1)
            {
                var brandname = brands.Where(b => b.Id == Convert.ToInt32(product1.Brandname)).FirstOrDefault();
                string existance = "";
                switch (product1.Existance)
                {
                    case true:
                        existance = "В наличии";
                        break;
                    case false:
                        existance = "Нет в наличии";
                        break;
                }
                string typeOfTechnic = "";
                switch (product1.Typeoftechnic)
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
                _product.Add(new DiscountCombiner
                {
                    ID = product1.Id,
                    Name = brandname.Name + " " + product1.Name,
                    PhotoName = $"Images/{typeOfTechnic}/{product1.Photoname}.png",
                    ShortDescription = product1.ShortDescription,
                    Description = product1.Description,
                    NewCost = product1.Cost,
                    Existance = existance,
                });
            }
        }
    }
}

