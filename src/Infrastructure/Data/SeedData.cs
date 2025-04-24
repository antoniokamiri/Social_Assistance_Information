using Domain.Entities;
using Infrastructure.Common;
using Infrastructure.PermissionSet;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Reflection;
using System.Security.Claims;

namespace Infrastructure.Data;
public class SeedData
{
    private readonly AppDBContext _context;
    private readonly ILogger<SeedData> _logger;
    private readonly RoleManager<ApplicationRole> _roleManager;
    private readonly UserManager<User> _userManager;

    public SeedData(ILogger<SeedData> logger, AppDBContext context, RoleManager<ApplicationRole> roleManager, UserManager<User> userManager)
    {
        _logger = logger;
        _context = context;
        _userManager = userManager;
        _roleManager = roleManager;
    }

    public async Task InitialiseAsync()
    {
        try
        {
            if (_context.Database.IsRelational())
                await _context.Database.MigrateAsync();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An error occurred while initialising the database");
            throw;
        }
    }
    public async Task SeedAsync()
    {
        try
        {
            await SeedRolesAsync();
            await SeedUsersAsync();
            await SeedDataAsync();
            _context.ChangeTracker.Clear();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An error occurred while seeding the database");
            throw;
        }
    }
    private static IEnumerable<string> GetAllPermissions()
    {
        var allPermissions = new List<string>();
        var modules = typeof(Permissions).GetNestedTypes();

        foreach (var module in modules)
        {
            var moduleName = string.Empty;
            var moduleDescription = string.Empty;

            var fields = module.GetFields(BindingFlags.Public | BindingFlags.Static | BindingFlags.FlattenHierarchy);

            foreach (var fi in fields)
            {
                var propertyValue = fi.GetValue(null);

                if (propertyValue is not null)
                    allPermissions.Add((string)propertyValue);
            }
        }

        return allPermissions;
    }
    private async Task SeedRolesAsync()
    {
        var adminRoleName = RoleName.Admin;
        var userRoleName = RoleName.Basic;

        if (await _roleManager.RoleExistsAsync(adminRoleName)) return;

        _logger.LogInformation("Seeding roles...");
        var administratorRole = new ApplicationRole(adminRoleName)
        {
            Description = "Admin Group",
        };
        var userRole = new ApplicationRole(userRoleName)
        {
            Description = "Basic Group",
        };

        await _roleManager.CreateAsync(administratorRole);
        await _roleManager.CreateAsync(userRole);

        var permissions = GetAllPermissions();

        foreach (var permission in permissions)
        {
            var claim = new Claim(ApplicationClaimTypes.Permission, permission);
            await _roleManager.AddClaimAsync(administratorRole, claim);

            if (permission.StartsWith("Permissions.Discussions"))
            {
                await _roleManager.AddClaimAsync(userRole, claim);
            }
        }
    }
    private async Task SeedUsersAsync()
    {
        string USER_EMAIL = "admin@sais.com";
        string USER_EMAIL2 = "user@sais.com";

        if (await _userManager.Users.AnyAsync()) return;

        _logger.LogInformation("Seeding users...");
        var adminUser = new User
        {
            UserName = USER_EMAIL,
            AccountConfirmed = false,
            DisplayName = "Administrator",
            Email = USER_EMAIL,
            EmailConfirmed = true,
            TwoFactorEnabled = false
        };

        var demoUser = new User
        {
            UserName = USER_EMAIL2,
            AccountConfirmed = false,
            DisplayName = "DemoUser",
            Email = USER_EMAIL2,
            EmailConfirmed = true,
        };

        await _userManager.CreateAsync(adminUser, Constants.DEFAULT_PASSWORD);
        await _userManager.AddToRoleAsync(adminUser, RoleName.Admin);

        await _userManager.CreateAsync(demoUser, Constants.DEFAULT_PASSWORD);
        await _userManager.AddToRoleAsync(demoUser, RoleName.Basic);
    }
    public async Task SeedDataAsync()
    {
        if (!await _context.Sexes.AnyAsync())
        {
            _logger.LogInformation("Seeding genders...");

            var gender = new[]
            {
                new Sex
                {
                    Name = "Male"
                },
                new Sex
                {
                    Name = "Female"
                },
                new Sex
                {
                    Name = "Others"
                }
            };
            await _context.Sexes.AddRangeAsync(gender);
            await _context.SaveChangesAsync();
        }

        if (!await _context.AssistancePrograms.AnyAsync())
        {
            _logger.LogInformation("Seeding Applicant Programs...");

            var program = new[]
            {
                new AssistanceProgram
                {
                    ProgramName = "Orphans and vulnerable children"
                },
                new AssistanceProgram
                {
                    ProgramName = "Poor elderly persons"
                },
                new AssistanceProgram
                {
                    ProgramName = "Persons with disability"
                },
                new AssistanceProgram
                {
                    ProgramName = "Persons in extreme poverty"
                },
                new AssistanceProgram
                {
                    ProgramName = "Any other"
                }
            };
            await _context.AssistancePrograms.AddRangeAsync(program);
            await _context.SaveChangesAsync();
        }

        if (!await _context.MaritalStatuses.AnyAsync())
        {
            _logger.LogInformation("Seeding Marital Statuses...");

            var status = new[]
            {
                new MaritalStatus
                {
                    Status = "Single"
                },
                new MaritalStatus
                {
                    Status = "Married"
                },
                new MaritalStatus
                {
                    Status = "Widowed"
                },
                new MaritalStatus
                {
                    Status = "Divorced"
                },
            };
            await _context.MaritalStatuses.AddRangeAsync(status);
            await _context.SaveChangesAsync();
        }

        if (!await _context.Counties.AnyAsync())
        {
            _logger.LogInformation("Seeding counties...");

            var county = new[]
            {
                new County
                {
                    CountyName = "Nairobi"
                },
                new County
                {
                    CountyName = "Kiambu"
                }
            };
            await _context.Counties.AddRangeAsync(county);
            await _context.SaveChangesAsync();
        }

        if (!await _context.SubCounties.AnyAsync())
        {
            _logger.LogInformation("Seeding sub counties...");

            var subCounty = new[]
            {               
                new SubCounty
                {
                    SubCountyName = "Roysambu",
                    CountyId = 1
                },
                new SubCounty
                {
                    SubCountyName = "Thika",
                    CountyId = 2
                }
            };
            await _context.SubCounties.AddRangeAsync(subCounty);
            await _context.SaveChangesAsync();
        }

        if (!await _context.SubCounties.AnyAsync())
        {
            _logger.LogInformation("Seeding sub counties...");

            var subCounty = new[]
            {
                new SubCounty
                {
                    SubCountyName = "Roysambu",
                    CountyId = 1
                },
                new SubCounty
                {
                    SubCountyName = "Thika",
                    CountyId = 2
                }
            };
            await _context.SubCounties.AddRangeAsync(subCounty);
            await _context.SaveChangesAsync();
        }

        if (!await _context.Locations.AnyAsync())
        {
            _logger.LogInformation("Seeding locations...");

            var locations = new[]
            {
                new Location
                {
                    LocationName = "Roysambu Constituency",
                    SubCountyId = 1
                },
                new Location
                {
                    LocationName = "Town Constituency",
                    SubCountyId = 2
                }
            };
            await _context.Locations.AddRangeAsync(locations);
            await _context.SaveChangesAsync();
        }

        if (!await _context.SubLocations.AnyAsync())
        {
            _logger.LogInformation("Seeding sub locations...");

            var subLocations = new[]
            {
                new SubLocation
                {
                    SubLocationName = "Zimmerman",
                    LocationId = 1
                },
                new SubLocation
                {
                    SubLocationName = "Ntarangwi",
                    LocationId = 2
                }
            };
            await _context.SubLocations.AddRangeAsync(subLocations);
            await _context.SaveChangesAsync();
        }

        if (!await _context.Villages.AnyAsync())
        {
            _logger.LogInformation("Seeding sub Villages...");

            var villages = new[]
            {
                new Village
                {
                    VillageName = "Canopy",
                    SubLocationId = 1
                },
                new Village
                {
                    VillageName = "kiandutu",
                    SubLocationId = 2
                }
            };
            await _context.Villages.AddRangeAsync(villages);
            await _context.SaveChangesAsync();
        }

        if (!await _context.Applicants.AnyAsync())
        {
            _logger.LogInformation("Seeding sub Applicants...");
            var userId = _userManager.Users.First().Id;
            var applicant = new[]
            {
                new Applicant
                {
                    ApplicationDate = new DateTime(2025,04,24),
                    FirstName = "Antony",
                    MiddleName = "Maina",
                    LastName = "Mwangi",
                    Status = "NEW",
                    SexId = 1,
                    Age = 31,
                    MaritalStatusId = 2,
                    IDOrPassportNumber = "a25DHW",
                    CountyId = 1,
                    SubCountyId = 1,
                    LocationId = 1,
                    SubLocationId = 1,
                    VillageId = 1,
                    PostalAddress = "1587",
                    PhysicalAddress = "Nairobi",
                    TelephoneContact = "0722558877",
                },
                new Applicant
                {
                    ApplicationDate = new DateTime(2025,04,24),
                    FirstName = "Aprelle",
                    LastName = "Mwangi",
                    Status = "APPROVED",
                    SexId = 2,
                    Age = 20,
                    MaritalStatusId = 1,
                    IDOrPassportNumber = "e45458jdhs",
                    CountyId = 2,
                    SubCountyId = 2,
                    LocationId = 2,
                    SubLocationId = 2,
                    VillageId = 2,
                    PostalAddress = "1587",
                    PhysicalAddress = "Kiambu",
                    TelephoneContact = "0722558877",
                    UserId = userId
                },
                new Applicant
                {
                    ApplicationDate = new DateTime(2025,04,24),
                    FirstName = "Rachael",
                    LastName = "Maina",
                    Status = "REJECTED",
                    SexId = 2,
                    Age = 20,
                    MaritalStatusId = 1,
                    IDOrPassportNumber = "hsye678",
                    CountyId = 2,
                    SubCountyId = 2,
                    LocationId = 2,
                    SubLocationId = 2,
                    VillageId = 2,
                    PostalAddress = "1587",
                    PhysicalAddress = "Thika",
                    TelephoneContact = "0722558877",
                    UserId = userId
                }
            };
            await _context.Applicants.AddRangeAsync(applicant);
            await _context.SaveChangesAsync();
        }

        if (!await _context.ApplicantPrograms.AnyAsync())
        {
            _logger.LogInformation("Seeding sub Applicant Program...");

            var programes = new[]
            {
                new ApplicantProgram
                {
                    ApplicantId = 1,
                    AssistanceProgramId = 1
                },
                new ApplicantProgram
                {
                    ApplicantId = 2,
                    AssistanceProgramId = 2
                },
                new ApplicantProgram
                {
                    ApplicantId = 3,
                    AssistanceProgramId = 3
                }
            };
            await _context.ApplicantPrograms.AddRangeAsync(programes);
            await _context.SaveChangesAsync();
        }
    }
}
