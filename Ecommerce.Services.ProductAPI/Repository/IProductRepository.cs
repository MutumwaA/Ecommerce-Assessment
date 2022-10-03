﻿using Ecommerce.Services.ProductAPI.Models.Dtos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Ecommerce.Services.ProductAPI.Repository
{
    public interface IProductRepository
    {
        Task<IEnumerable<ProductDto>> GetProducts();
        Task<ProductDto> GetProductById(int productId);
        Task<ProductDto> CreateUpdateProduct(ProductDto productDto);
        Task<bool> DeleteProduct(int productId);
    }
}
