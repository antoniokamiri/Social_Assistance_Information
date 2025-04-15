using Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data.Configurations;
public class ApplicantConfiguration : IEntityTypeConfiguration<Applicant>
{
    public void Configure(EntityTypeBuilder<Applicant> builder)
    {
        builder.ToTable("Applicants");

        builder.HasKey(a => a.Id);

        builder.Property(a => a.FirstName).IsRequired().HasMaxLength(50);
        builder.Property(a => a.MiddleName).HasMaxLength(50);
        builder.Property(a => a.LastName).IsRequired().HasMaxLength(50);
        builder.Property(a => a.IDOrPassportNumber).IsRequired().HasMaxLength(20);
        builder.Property(a => a.PostalAddress).HasMaxLength(255);
        builder.Property(a => a.PhysicalAddress).HasMaxLength(255);
        builder.Property(a => a.TelephoneContact).HasMaxLength(20);

        builder.HasOne(a => a.Sex)
            .WithMany(s => s.Applicants)
            .HasForeignKey(a => a.SexId);

        builder.HasOne(a => a.MaritalStatus)
            .WithMany(m => m.Applicants)
            .HasForeignKey(a => a.MaritalStatusId);

        builder.HasOne(a => a.County)
            .WithMany(v => v.Applicants)
            .HasForeignKey(a => a.CountyId);

        builder.HasOne(a => a.SubCounty)
            .WithMany(v => v.Applicants)
            .HasForeignKey(a => a.SubCountyId);

        builder.HasOne(a => a.Location)
            .WithMany(v => v.Applicants)
            .HasForeignKey(a => a.LocationId);

        builder.HasOne(a => a.SubLocation)
            .WithMany(v => v.Applicants)
            .HasForeignKey(a => a.SubLocationId);

        builder.HasOne(a => a.Village)
            .WithMany(v => v.Applicants)
            .HasForeignKey(a => a.VillageId);

        builder.HasOne(a => a.User)
            .WithMany(v => v.Applicants)
            .HasForeignKey(a => a.UserId)
            .OnDelete(DeleteBehavior.NoAction);

        builder.HasMany(t => t.ProgramsAppliedFor).WithMany(x => x.Applicants).UsingEntity<ApplicantProgram>(x => x.HasOne(y => y.AssistanceProgram).WithMany().HasForeignKey(x => x.AssistanceProgramId).OnDelete(DeleteBehavior.NoAction),
        x => x.HasOne(y => y.Applicant).WithMany().HasForeignKey(x => x.ApplicantId).OnDelete(DeleteBehavior.NoAction));
    }
}
