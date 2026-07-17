using RedisTraining.Application.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace RedisTraining.Application.Interfaces
{
    public interface IProductService
    {
        Task<Product?> GetProductAsync(int id);
        Task SetProductAsync(Product product);
    }
}
