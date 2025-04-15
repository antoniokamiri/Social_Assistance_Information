using Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data.Configurations;

public class SubLocationConfiguration : IEntityTypeConfiguration<SubLocation>
{
    public void Configure(EntityTypeBuilder<SubLocation> builder)
    {
        builder.ToTable("SubLocations");

        builder.HasKey(sl => sl.Id)
               .HasName("PK_SubLocation");

        builder.Property(sl => sl.SubLocationName)
               .IsRequired()
               .HasMaxLength(255);

        builder.HasOne(sl => sl.Location)
               .WithMany(loc => loc.SubLocations)
               .HasForeignKey(sl => sl.LocationId)
               .HasConstraintName("FK_SubLocation_Location")
               .OnDelete(DeleteBehavior.Restrict);
    }
}
