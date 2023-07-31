using ProjectManagementSystem.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManagementSystem.Application.Utility
{
    public static class ConversionUtility
    {
        public static UserProduct ConvrtToUserProduct(this Product product)
        {
     
                var userProduct = new UserProduct()
                {
                    ProductId = product.Code.ToString(),
                    Name = product.Name,
                    Description = product.Description,
                    Image = product.Image,
                    ProductCategory = product.ProductCategory,
                    Price = product.Price,
                    Quantity = product.Quantity,
                    SubCategory = product.Subcategory
                };

            return userProduct;
        }

        public static Product  ConvrtToProduct(this UserProduct product)
        {

            var userProduct = new Product()
            {
                Code = new Guid(product.ProductId),
                Name = product.Name,
                Description = product.Description,
                Image = product.Image,
                ProductCategory = product.ProductCategory,
                Price = product.Price,
                Quantity = product.Quantity,
                Subcategory = product.SubCategory
            };

            return userProduct;
        }
    }
}
