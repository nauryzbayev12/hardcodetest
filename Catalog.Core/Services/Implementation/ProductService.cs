using AutoMapper;
using Catalog.Core.DTOs;
using Catalog.Core.Services.Interfaces;
using Catalog.Data;
using Catalog.Data.Entities;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.IO;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Catalog.Core.Services.Implementation
{
    public class ProductService : IProductService
    {
        private readonly DatabaseContext _db;
        private readonly IMapper _mapper;
        private readonly IUploadService _uploadService;
        public ProductService(DatabaseContext db, IMapper mapper, IUploadService uploadService)
        {

            _mapper = mapper;
            _db = db;
            _uploadService = uploadService;
        }
        public async Task<Product> Delete(int id)
        {
            var entity = await _db.Products.FindAsync(id);

            _db.Remove(entity);
            await _db.SaveChangesAsync();

            return entity;
        }
        public IQueryable<Product> GetAll()
        {
            return _db.Products.Include(s => s.ProductType).AsQueryable();
        }
        public async Task<Product> Insert(CreateProductDTO dTO)
        {
            var ev = _mapper.Map<Product>(dTO);

            var imageId = await _uploadService.SaveImageAsync(dTO.Photo);

            ev.UploadId = imageId;

            var productType = await _db.ProductTypes.FirstOrDefaultAsync(s => s.Id == dTO.ProductTypeId);

            if (productType.HaveSize == false) {

                ev.Size = null;
            }
            if (productType.HaveColor == false)
            {
                ev.Color= null;
            }
            if (productType.HaveWeight == false)
            {
                ev.Weight= null;
            }

            await _db.Products.AddAsync(ev);
            await _db.SaveChangesAsync();
            
            return ev;
        }
        public async Task<Product> Update(UpdateProductDTO dTO)
        {
            var entity = await _db.Products.Include(s => s.ProductType).FirstOrDefaultAsync(s => s.Id == dTO.Id);

            _mapper.Map(dTO, entity);

            if (entity.ProductType.HaveSize == false)
            {
                entity.Size = null;
            }
            if (entity.ProductType.HaveColor == false)
            {
                entity.Color = null;
            }
            if (entity.ProductType.HaveWeight == false)
            {
                entity.Weight = null;
            }

            _db.Products.Update(entity);
            await _db.SaveChangesAsync();
            
            return entity;
        }
        public async Task<Product> Find(int id)
        {
            return await _db.Products.Include(s => s.ProductType).FirstOrDefaultAsync(s => s.Id == id);
        }
    }
}
