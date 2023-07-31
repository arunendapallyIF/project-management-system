using ProjectManagementSystem.Application.Utility;
using ProjectManagementSystem.Domain;
using ProjectManagementSystem.Repository;

namespace ProjectManagementSystem.Application
{
    public interface IProductService
    {
        Task<IEnumerable<UserProduct>> GetProducts();
        Task<UserProduct> GetProduct(string id);
        Task<bool> DeleteProduct(string id);
        Task<bool> UpdateProduct(string id, UserProduct userProduct);
        Task<string> AddProduct(UserProduct userProduct);
    }
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;
        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<IEnumerable<UserProduct>> GetProducts()
        {
            IList<UserProduct> userProducts = new List<UserProduct>();
            var productList = await _productRepository.GetProducts();
            productList.ForEach(theMoney => userProducts.Add(theMoney.ConvrtToUserProduct()));
            return userProducts.AsEnumerable();
        }

        public async Task<UserProduct> GetProduct(string id)
        {
            var product = await _productRepository.GetProduct(id);
            var userProduct = product.ConvrtToUserProduct();
            return userProduct;
        }

        public async Task<bool> DeleteProduct(string id)
        {
           return await _productRepository.DeleteProduct(id);
        }

        public async Task<bool> UpdateProduct(string id, UserProduct userProduct)
        {
            var product = userProduct.ConvrtToProduct();
            var result = await _productRepository.UpdateProduct(product);
            return result;
        }

        public async Task<string> AddProduct(UserProduct userProduct)
        {
            Product product = new Product();
            product.Name = userProduct.Name;
            product.Description = userProduct.Description;
            product.Image = userProduct.Image;
            product.ProductCategory = userProduct.ProductCategory;
            product.Price = userProduct.Price;
            product.Quantity = userProduct.Quantity;
            product.Subcategory = userProduct.SubCategory;

            return await _productRepository.AddProduct(product);
        }
    }
}