using Domain.Entities;
using Domain.Entities.Common;
using Infrastructure.Data.Extensions;
using Microsoft.AspNetCore.DataProtection.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace Infrastructure.Data;
public class AppDBContext(DbContextOptions<AppDBContext> options) : IdentityDbContext<User>(options)
{
    public DbSet<Applicant> Applicants { get; set; }
    public DbSet<ApplicantProgram> ApplicantPrograms { get; set; }
    public DbSet<AssistanceProgram> AssistancePrograms { get; set; }
    public DbSet<County> Counties { get; set; }
    public DbSet<Sex> Sexes { get; set; }
    public DbSet<MaritalStatus> MaritalStatuses { get; set; }
    public DbSet<Location> Locations { get; set; }
    public DbSet<Village> Villages { get; set; }
    public DbSet<SubLocation> SubLocations { get; set; }
    public DbSet<SubCounty> SubCounties { get; set; }


    public DbSet<DataProtectionKey> DataProtectionKeys { get; set; }


    protected override void OnModelCreating(ModelBuilder builder)
    {

        base.OnModelCreating(builder);

        builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        builder.ApplyGlobalFilters<ISoftDelete>(s => s.DeletedDate == null);
    }
    protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
    {
        base.ConfigureConventions(configurationBuilder);
        configurationBuilder.Properties<string>().HaveMaxLength(450);
    }
}
