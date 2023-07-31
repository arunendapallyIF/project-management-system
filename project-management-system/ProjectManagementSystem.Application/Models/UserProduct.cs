using ProjectManagementSystem.Domain;

namespace ProjectManagementSystem.Application
{
    public class UserProduct
    {
        public string ProductId { get; set; }
        public string Name { get; set; }
        public int Quantity { get; set; }
        public double Price { get; set; }
        public string Description { get; set; }
        public Category ProductCategory { get; set; }
        public Byte[] Image { get; set; }
        public string SubCategory { get; set;}
    }

  
}