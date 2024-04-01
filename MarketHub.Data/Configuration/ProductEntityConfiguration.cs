using MarketHub.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketHub.Data.Configuration
{
    public class ProductEntityConfiguration: IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder) 
        {
            builder.ToTable("Product");

            builder.Property(p => p.Name)
               .IsRequired()
               .HasMaxLength(100)
               .IsUnicode(false);

            builder.Property(p => p.Description)
               .IsRequired()
               .HasMaxLength(100)
               .IsUnicode(false);

            builder.Property(p => p.Price)
                .IsRequired();

            builder.Property(p => p.Quantity)
                .IsRequired();

            builder.Property(p => p.CategoryId)
                .IsRequired();
            builder.HasOne<Category>()
                .WithMany()
                .HasForeignKey(p => p.CategoryId)
                .HasConstraintName("FK_Category_Product");

            builder.Property(p => p.VendorId)
                .IsRequired();
            builder.HasOne<Vendor>()
                .WithMany()
                .HasForeignKey(p => p.VendorId)
                .HasConstraintName("FK_Vendor_Product");
        }
    }
}
