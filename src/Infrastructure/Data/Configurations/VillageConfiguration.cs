using Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data.Configurations;

public class VillageConfiguration : IEntityTypeConfiguration<Village>
{
    public void Configure(EntityTypeBuilder<Village> builder)
    {
        builder.ToTable("Villages");

        builder.HasKey(v => v.Id);

        builder.Property(v => v.VillageName)
            .IsRequired()
            .HasMaxLength(255);

        builder.HasOne(v => v.SubLocation)
            .WithMany(sl => sl.Villages)
            .HasForeignKey(v => v.SubLocationId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
