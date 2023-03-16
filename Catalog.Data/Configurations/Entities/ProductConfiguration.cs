using Catalog.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Catalog.Data.Configurations.Entities
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasData(
                new Product
                {
                    Id = 1,
                    Name = "Бумага",
                    ProductTypeId = 1 ,
                    Cost = 100 ,
                    Size= 100 ,
                    Color = "Red" ,
                    Weight= 1 
                },
                new Product
                {
                    Id = 2,
                    Name = "Мыло",
                    ProductTypeId = 1,
                    Cost = 200,
                    Size = 100,
                    Color = "Red",
                    Weight = 1
                },
                new Product
                {
                    Id = 3,
                    Name = "Зеркало",
                    ProductTypeId = 3,
                    Cost = 200,
                    Size = null,
                    Color = null,
                    Weight = null
                }
            );
        }
    }
}
