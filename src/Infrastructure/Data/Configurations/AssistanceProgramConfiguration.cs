using Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data.Configurations;

public class AssistanceProgramConfiguration : IEntityTypeConfiguration<AssistanceProgram>
{
    public void Configure(EntityTypeBuilder<AssistanceProgram> builder)
    {
        builder.ToTable("AssistancePrograms");

        builder.HasKey(p => p.Id);

        builder.Property(p => p.ProgramName)
            .IsRequired()
            .HasMaxLength(255);
    }
}
