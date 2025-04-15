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
    }
}
