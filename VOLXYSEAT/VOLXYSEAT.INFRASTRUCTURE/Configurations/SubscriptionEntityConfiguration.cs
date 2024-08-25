using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VOLXYSEAT.DOMAIN.Models;
using VOLXYSEAT.INFRASTRUCTURE.Data;

namespace VOLXYSEAT.INFRASTRUCTURE.Configurations
{
    public class SubscriptionEntityConfiguration : IEntityTypeConfiguration<Subscription>
    {
        public void Configure(EntityTypeBuilder<Subscription> builder)
        {
            builder.ToTable("Subscription", DataContext.DEFAULT_SCHEMA);

            builder.Property(_ => _.Id)
                .ValueGeneratedOnAdd();

            builder.Property(s => s.TypeId)
                .HasConversion(
                    v => (int)v,
                    v => (SubscriptionEnum)v)
                .HasColumnName("TypeId")
                .IsRequired();

            builder.Property(s => s.StatusId)
                .HasConversion(
                    v => (int)v,
                    v => (SubscriptionStatus)v)
                .HasColumnName("StatusId")
                .IsRequired();

            builder.HasMany(s => s.Histories)
                   .WithOne()
                   .HasForeignKey("SubscriptionId")
                   .IsRequired();

            builder.Property(s => s.CreatedOn)
                .HasColumnType("datetime")
                .HasDefaultValue(new DateTime(2000, 1, 1))
                .IsRequired();

            builder.Property(s => s.UpdatedOn)
                .HasColumnType("datetime")
                .HasDefaultValue(new DateTime(2000, 1, 1))
                .IsRequired();
        }
    }
}
