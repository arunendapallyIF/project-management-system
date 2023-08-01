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
        public string ProductCategory { get; set; }
        public string Image { get; set; }
        public string SubCategory { get; set;}
    }

  
}