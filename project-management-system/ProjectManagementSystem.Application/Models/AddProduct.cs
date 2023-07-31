using ProjectManagementSystem.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManagementSystem.Application.Models
{
    internal class AddProduct
    {
        public string Name { get; set; }
        public int Quantity { get; set; }
        public double Price { get; set; }
        public string Description { get; set; }
        public string ProductCategory { get; set; }
        public Byte[] Image { get; set; }
        public string SubCategory { get; set; }
    }
}
