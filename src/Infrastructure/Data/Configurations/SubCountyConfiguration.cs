using Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data.Configurations;

public class SubCountyConfiguration : IEntityTypeConfiguration<SubCounty>
{
    public void Configure(EntityTypeBuilder<SubCounty> builder)
    {
        builder.ToTable("SubCounties");

        builder.HasKey(sc => sc.Id);

        builder.Property(sc => sc.SubCountyName)
            .IsRequired()
            .HasMaxLength(255);

        builder.HasOne(sc => sc.County)
            .WithMany(c => c.SubCounties)
            .HasForeignKey(sc => sc.CountyId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
