using RedisTraining.Application.Interfaces;
using RedisTraining.Application.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace RedisTraining.Infrastructure.Services
{
    public class ProductService : IProductService
    {
        private readonly ICacheService _cache;
        private readonly List<Product> _products =
        [
            new Product
            {
                Id = 1,
                Name = "Laptop",
                Price = 999.99m
            },
            new Product
            {
                Id = 2,
                Name = "Keyboard",
                Price = 49.99m
            }
        ];

        public ProductService(ICacheService cache)
        {
            _cache = cache;
        }

        public async Task<Product?> GetProductAsync(int id)
        {
            //get from cache
            var cacheKey = $"product:{id}";

            var cachedProduct = await _cache.GetAsync<Product>(cacheKey);

            if (cachedProduct != null)
            {
                return cachedProduct;
            }

            var product = _products
                .FirstOrDefault(x => x.Id == id);

            if (product != null)
            {
                await _cache.SetAsync(
                    cacheKey,
                    product,
                    TimeSpan.FromMinutes(5));
            }

            return product;
        }

        public Task SetProductAsync(Product product)
        {
            if (product == null)
            {
                throw new ArgumentNullException(nameof(product));
            }

            _products.Add(product);

            return Task.CompletedTask;
        }
    }
}
