using Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data.Configurations;

public class SexConfiguration : IEntityTypeConfiguration<Sex>
{
    public void Configure(EntityTypeBuilder<Sex> builder)
    {
        builder.ToTable("SexLookup");

        builder.HasKey(s => s.Id);

        builder.Property(s => s.Name)
            .IsRequired()
            .HasMaxLength(50);
    }
}
