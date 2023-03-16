using Catalog.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catalog.Data.Configurations.Entities
{
    public class ProductTypeConfiguration : IEntityTypeConfiguration<ProductType>
    {
        public void Configure(EntityTypeBuilder<ProductType> builder)
        {
            builder.HasData(
                new ProductType
                {
                    Id = 1,
                    HaveSize = true,
                    HaveColor = true,
                    HaveWeight = true,
                },
                new ProductType
                {
                    Id = 2,
                    HaveSize = false,
                    HaveColor = false,
                    HaveWeight = false,
                },
                new ProductType
                {
                    Id = 3,
                    HaveSize = true,
                    HaveColor = true,
                    HaveWeight = true

                }
            );
        }

    }
}
