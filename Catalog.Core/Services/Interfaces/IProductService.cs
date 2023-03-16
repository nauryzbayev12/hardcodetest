using Catalog.Core.DTOs;
using Catalog.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catalog.Core.Services.Interfaces
{
    public interface IProductService
    {
        Task<Product> Delete(int id);
        IQueryable<Product> GetAll();
        Task<Product> Insert(CreateProductDTO dTO);
        Task<Product> Update(UpdateProductDTO dTO);
        Task<Product> Find(int id);
    }
}
