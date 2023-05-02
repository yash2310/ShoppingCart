using AutoMapper;
using ShoppingCart.Application.DTOs.Product;
using ShoppingCart.Application.Interfaces.Repositories;
using ShoppingCart.Application.Interfaces.Services;
using ShoppingCart.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingCart.Application.Services
{
    public class ProductService : IProductService
    {
        private readonly IRepository<Product> repository;
        private readonly IMapper mapper;

        public ProductService(IRepository<Product> repository, IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }

        public IEnumerable<ProductReadDto> GetProducts()
        {
            return mapper.Map<IEnumerable<ProductReadDto>>(repository.GetAll());
        }

        public ProductReadDto GetProduct(int productId)
        {
            return mapper.Map<ProductReadDto>(repository.Get(p => p.Id == productId));
        }

        public bool CreateProduct(ProductCreateDto createDto)
        {
            var product = mapper.Map<Product>(createDto);
            repository.Add(product);
            repository.SaveChanges();

            return true;
        }

        public ProductReadDto UpdateProduct(ProductUpdateDto updateDto)
        {
            var product = repository.Get(p => p.Id == updateDto.Id);
            if (product != null)
            {
                mapper.Map(updateDto, product);
                repository.Update(product);
                repository.SaveChanges();

                return mapper.Map<ProductReadDto>(product);
            }

            return null;
        }
    }
}
