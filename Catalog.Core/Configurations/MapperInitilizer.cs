using AutoMapper;
using Catalog.Core.DTOs;
using Catalog.Data.Entities;

namespace Catalog.Core.Configurations
{
    public class MapperInitilizer : Profile
    {
        public MapperInitilizer()
        {
         
            CreateMap<Product, ProductDTO>().ReverseMap();
            CreateMap<Product, CreateProductDTO>().ReverseMap();
            CreateMap<Product, UpdateProductDTO>().ReverseMap();

            CreateMap<ProductType, ProductTypeDTO>().ReverseMap();
            CreateMap<ProductType, CreateProductTypeDTO>().ReverseMap();
            CreateMap<ProductType, UpdateProductTypeDTO>().ReverseMap();

            CreateMap<ApplicationUser, UserDTO>().ReverseMap();
        }
    }
}
