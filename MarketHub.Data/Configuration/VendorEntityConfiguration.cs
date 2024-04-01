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
    public class VendorEntityConfiguration: IEntityTypeConfiguration<Vendor>
    {
        public void Configure(EntityTypeBuilder<Vendor> builder) 
        {
            builder.ToTable("Vendor");

            builder.Property(v => v.Name)
                .IsRequired()
                .HasMaxLength(100)
                .IsUnicode(false);

            // builder.Property(v => v.CNPJ)
            //     .IsRequired()
            //     .HasMaxLength(20)
            //     .IsUnicode(false);

            builder.Property(v => v.Email)
                .IsRequired()
                .HasMaxLength(100)
                .IsUnicode(false);

            builder.Property(v => v.Phone)
                .IsRequired()
                .HasMaxLength(20)
                .IsUnicode(false);
        }
    }
}
