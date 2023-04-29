using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingCart.Application.DTOs.Product
{
    public class ProductUpdateDto
    {
        public int Id { get; set; }
        public int DiscountId { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
    }
}
