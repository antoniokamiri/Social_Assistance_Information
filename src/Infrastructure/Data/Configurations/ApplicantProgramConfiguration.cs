using Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data.Configurations;

public class ApplicantProgramConfiguration : IEntityTypeConfiguration<ApplicantProgram>
{
    public void Configure(EntityTypeBuilder<ApplicantProgram> builder)
    {
        builder.ToTable("ApplicantPrograms");

        builder.HasKey(ap => new { ap.ApplicantId, ap.AssistanceProgramId });

        builder.HasOne(ap => ap.Applicant)
            .WithMany(a => a.ProgramsAppliedFor)
            .HasForeignKey(ap => ap.ApplicantId);

        builder.HasOne(ap => ap.AssistanceProgram)
            .WithMany(p => p.ApplicantPrograms)
            .HasForeignKey(ap => ap.AssistanceProgramId);
    }
}
