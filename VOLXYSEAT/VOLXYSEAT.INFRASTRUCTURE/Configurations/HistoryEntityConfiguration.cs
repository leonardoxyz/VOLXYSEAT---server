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
    public class HistoryEntityConfiguration : IEntityTypeConfiguration<SubscriptionHistory>
    {
        public void Configure(EntityTypeBuilder<SubscriptionHistory> builder)
        {
            builder.ToTable("VolxyseatHistory", DataContext.DEFAULT_SCHEMA);

            builder.Property<Guid>("Id")
                .ValueGeneratedOnAdd();

            builder.Property(x => x.Comment)
                .IsRequired(false)
                .IsUnicode(false)
                .HasMaxLength(255);

            builder.Property(x => x.UpdatedBy)
                .IsRequired()
                .IsUnicode(false)
                .HasMaxLength(255);

            builder.Property(x => x.UpdatedOn)
                .IsRequired()
                .IsUnicode(false);
        }
    }
}
