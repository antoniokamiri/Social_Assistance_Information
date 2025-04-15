using Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data.Configurations;

public class LocationConfiguration : IEntityTypeConfiguration<Location>
{
    public void Configure(EntityTypeBuilder<Location> builder)
    {
        builder.ToTable("Locations");

        builder.HasKey(l => l.Id);

        builder.Property(l => l.LocationName)
            .IsRequired()
            .HasMaxLength(255);

        builder.HasOne(l => l.SubCounty)
            .WithMany(sc => sc.Locations)
            .HasForeignKey(l => l.SubCountyId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
