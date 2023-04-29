using ShoppingCart.Application.DTOs.Product;
using ShoppingCart.Application.DTOs.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingCart.Application.Interfaces.Services
{
    public interface IProductService
    {
        bool CreateProduct(ProductCreateDto createDto);
        IEnumerable<ProductReadDto> GetProducts();
        ProductReadDto GetProduct(int userId);
        ProductReadDto UpdateProduct(ProductUpdateDto updateDto);
    }
}
