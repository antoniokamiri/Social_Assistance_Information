using Domain.Entities;
using Domain.Interface;
using Domain.IRepository;
using Infrastructure.Data;
using Infrastructure.Data.Extensions;
using Infrastructure.Repository;
using Infrastructure.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using MudBlazor.Services;
using SAIS.Components;
using SAIS.Security;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

builder.Services.AddAuthorization();
builder.Services.AddCascadingAuthenticationState();
builder.Services.AddAuthentication().AddCookie(IdentityConstants.ApplicationScheme);

// Register Identity services
builder.Services.AddIdentityCore<User>()
    .AddRoles<ApplicationRole>()
    .AddEntityFrameworkStores<AppDBContext>()
    .AddSignInManager()
    .AddDefaultTokenProviders();

builder.Services.ConfigureApplicationCookie(opt =>
{
    opt.LoginPath = "/login";
    opt.AccessDeniedPath = "/accessdenied";
});

// Register DbContext with Identity
builder.Services.AddDbContext<AppDBContext>(opt =>
{
    opt.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

// Register Services
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<ICriteriaService, CriteriaService>();
builder.Services.AddScoped<IApplicationService, ApplicationService>();
builder.Services.AddScoped<SeedData>();
builder.Services.AddScoped(typeof(EncryptionHelper<>));
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped<IApplicantRepository, ApplicantRepository>();

builder.Services.AddMudServices();
builder.Services.AddHttpContextAccessor();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();

app.UseAuthentication();
app.UseAuthorization();

app.MapStaticAssets();
app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

await app.InitializeDatabaseAsync().ConfigureAwait(false);
app.Run();
