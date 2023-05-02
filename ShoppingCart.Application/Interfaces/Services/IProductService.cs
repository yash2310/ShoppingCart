using ShoppingCart.Application.DTOs.Product;
using ShoppingCart.Domain.Entities;

namespace ShoppingCart.Application.Interfaces.Services
{
    public interface IProductService
    {
        bool CreateProduct(ProductCreateDto createDto);
        IEnumerable<ProductReadDto> GetProducts();
        ProductReadDto GetProduct(int productId);
        ProductReadDto UpdateProduct(ProductUpdateDto updateDto);
    }
}
