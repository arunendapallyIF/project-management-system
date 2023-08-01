
namespace ProjectManagementSystem.Domain
{
    public class Product
    {
        public Product()
        {
            Code = Guid.NewGuid();
        }
        public Guid Code { get; set; }
        public string Name { get; set; }
        public int Quantity { get; set; }
        public double Price { get; set; }
        public string Description { get; set; }
        public Category ProductCategory { get; set; }
        public string Image { get; set; }
       public string  Subcategory { get; set; }
    }
}