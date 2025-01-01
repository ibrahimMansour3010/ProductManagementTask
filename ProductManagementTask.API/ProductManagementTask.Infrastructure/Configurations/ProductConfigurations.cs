using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProductManagementTask.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductManagementTask.Infrastructure.Configurations
{
    public class ProductConfigurations : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            // Configuring the properties
            builder.Property(c => c.Price)
                   .IsRequired();      // Optional: Ensure the field is not nullable

            builder.Property(c => c.Name)
                   .HasMaxLength(100)
                   .IsRequired();

            builder.Property(c => c.Description)
                   .HasMaxLength(500);

            // Add a check constraint for Price to ensure it doesn't exceed 1
            builder.HasCheckConstraint("CK_Product_Price", "[Price] >= 1");
        }
    }
}
