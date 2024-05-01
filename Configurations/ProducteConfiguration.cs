using E_Commerce.Core.Entites;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Repostry.Configurations
{
    public class ProducteConfiguration : IEntityTypeConfiguration<Producte>
    {

        public void Configure(EntityTypeBuilder<Producte> builder)
        {
            builder.HasOne(p => p.producteBrand)
                   .WithMany()
                   .HasForeignKey(p => p.BrandId);

            builder.HasOne(p => p.ProducteType)
                   .WithMany()
                   .HasForeignKey(p => p.TypeId);

            builder.Property(p => p.Price)
                   .HasColumnType("decimal(18,5)");
        }
    }
}
