using ProjectManagementSystem.Domain;

namespace ProjectManagementSystem.Repository
{
    public interface IProductRepository
    {
        Task<List<Product>> GetProducts();
        Task<Product> GetProduct(string id);
        Task<bool> UpdateProduct(Product product);
        Task<bool> DeleteProduct(string id);
        Task<string> AddProduct(Product product);

    }
    public class ProductRepository : IProductRepository
    {
        private static List<Product> productsList = new List<Product>()
        {
            new Product()
            {
              Quantity=10,  Name="Shirt",Description="Shirt for men",Image=new byte[100],Price=1000.78,ProductCategory=Category.Appearal, Subcategory=nameof(AppearalSubCategory.Men)
            },
             new Product()
            {
               Quantity=9,  Name="Denim",Description="Denim for men",Image=new byte[100],Price=900,ProductCategory=Category.Appearal, Subcategory=nameof(AppearalSubCategory.Men)
            }, new Product()
            {
              Quantity=100,  Name="Top",Description="Top for women",Image=new byte[100],Price=600,ProductCategory=Category.Appearal, Subcategory=nameof(AppearalSubCategory.Women)
            }, new Product()
            {
               Quantity=150,  Name="Bottom",Description="Bottom for women",Image=new byte[100],Price=5000,ProductCategory=Category.Appearal, Subcategory=nameof(AppearalSubCategory.Women)
            }, new Product()
            {
               Quantity=5,  Name="T Shirt",Description="T shirt for men",Image=new byte[100],Price=8000,ProductCategory=Category.Appearal, Subcategory=nameof(AppearalSubCategory.Men)
            }, new Product()
            {
              Quantity=50,  Name="Hier",Description="Hier fridge",Image=new byte[100],Price=1000.78,ProductCategory=Category.Electronics, Subcategory=nameof(ElectronicsSubCategory.Refregirator)
            }, new Product()
            {
               Quantity=160, Name="Voltas",Description="Voltas AC",Image=new byte[100],Price=1000.78,ProductCategory=Category.Electronics, Subcategory=nameof(ElectronicsSubCategory.AC)},
            new Product()
            {
              Quantity=180,  Name="IPhone",Description="Iphone 14 model",Image=new byte[100],Price=1000.78,ProductCategory=Category.Electronics, Subcategory=nameof(ElectronicsSubCategory.Mobile)
            }, new Product()
            {
               Quantity=3, Name="Galaxy",Description="Samsung galaxy s23",Image=new byte[100],Price=1000.78,ProductCategory=Category.Electronics, Subcategory=nameof(ElectronicsSubCategory.Mobile)
            }, new Product()
            {
              Quantity=25,  Name="SportsShoe",Description="Sportws shoe for men",Image=new byte[100],Price=1000.78,ProductCategory=Category.FootWear, Subcategory=nameof(FootWearSubCategory.Men)
            }, new Product()
            {
               Quantity=45, Name="Sandles",Description="Sandles for women",Image=new byte[100],Price=1000.78,ProductCategory=Category.FootWear, Subcategory=nameof(FootWearSubCategory.Women)
            }, new Product()
            {
              Quantity=90,  Name="Shoe",Description="Shoe for kids",Image=new byte[100],Price=1000.78,ProductCategory=Category.FootWear, Subcategory=nameof(FootWearSubCategory.Kids)
            }
          };
        public async Task<List<Product>> GetProducts()
        {
            return productsList;
        }

        public async Task<Product> GetProduct(string id)
        {
            return productsList.Where(p => p.Code.ToString() == id).SingleOrDefault();
        }

        public async Task<bool> DeleteProduct(string id)
        {
            try
            {
                var deleteProduct = productsList.Where(e => e.Code.ToString() == id).SingleOrDefault();
                if(deleteProduct != null)
                return productsList.Remove(deleteProduct);
            }
            catch
            {
                return false;
            }
            return false;
        }

        public async Task<bool> UpdateProduct(Product product)
        {
            try
            {
                productsList.Where(e => e.Code == product.Code).ToList().ForEach(e =>
                {

                    e.Name = product.Name;
                    e.Description = product.Description;
                    e.Image = product.Image;
                    e.ProductCategory = product.ProductCategory;
                    e.Price = product.Price;
                    e.Quantity = product.Quantity;
                    e.Subcategory = product.Subcategory;
                });
            }
            catch
            {
                return false;
            }
            return true;

        }

        public async Task<string> AddProduct(Product product)
        {
            try
            {
                productsList.Add(product);
                return product.Code.ToString();
            }
            catch
            {
                throw;
            }
        }
    }
}