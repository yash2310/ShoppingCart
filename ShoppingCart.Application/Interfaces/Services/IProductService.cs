using ShoppingCart.Application.DTOs.Product;

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
