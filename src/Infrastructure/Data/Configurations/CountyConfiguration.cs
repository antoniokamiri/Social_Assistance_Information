using Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data.Configurations;

public class CountyConfiguration : IEntityTypeConfiguration<County>
{
    public void Configure(EntityTypeBuilder<County> builder)
    {
        builder.ToTable("Counties");

        builder.HasKey(c => c.Id);

        builder.Property(c => c.CountyName)
            .IsRequired()
            .HasMaxLength(255);
    }
}
