using Catalog.Core.DTOs;
using Catalog.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catalog.Core.Services.Interfaces
{
    public interface IProductTypeService
    {
        Task<ProductType> Delete(int id);
        IQueryable<ProductType> GetAll();
        Task<ProductType> Insert(CreateProductTypeDTO dTO);
        Task<ProductType> Update(UpdateProductTypeDTO dTO);
        Task<ProductType> Find(int id);
      
    }
}
