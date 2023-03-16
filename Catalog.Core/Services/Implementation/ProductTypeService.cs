using AutoMapper;
using Catalog.Core.DTOs;
using Catalog.Core.Services.Interfaces;
using Catalog.Data.Entities;
using Catalog.Data;
using System.Linq;
using System.Threading.Tasks;

namespace Catalog.Core.Services.Implementation
{
    public class ProductTypeService : IProductTypeService
    {
        private readonly DatabaseContext _db;
        private readonly IMapper _mapper;

        public ProductTypeService(DatabaseContext db, IMapper mapper)
        {
            _mapper = mapper;
            _db = db;
        }
        public async Task<ProductType> Delete(int id)
        {
            var entity = await _db.ProductTypes.FindAsync(id);

            _db.ProductTypes.Remove(entity);
            await _db.SaveChangesAsync();

            return entity;
        }
        public IQueryable<ProductType> GetAll()
        {
            return _db.ProductTypes.AsQueryable();
        }
        public async Task<ProductType> Insert(CreateProductTypeDTO dTO)
        {
            var ev = _mapper.Map<ProductType>(dTO);
            
            await _db.ProductTypes.AddAsync(ev);
            await _db.SaveChangesAsync();
            
            return ev;
        }
        public async Task<ProductType> Update(UpdateProductTypeDTO dTO)
        {
            var entity = await _db.ProductTypes.FindAsync(dTO.Id);

            _mapper.Map(dTO,entity);

            _db.ProductTypes.Update(entity);
            await _db.SaveChangesAsync();
            
            return entity;
        }
        public async Task<ProductType> Find(int id)
        {
            return await _db.Set<ProductType>().FindAsync(id);
        }
    }
}
