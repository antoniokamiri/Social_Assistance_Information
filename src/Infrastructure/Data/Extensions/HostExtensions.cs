using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.Data.Extensions;

/**
 * Initialize the database (e.g. apply migrations).
 * Seed sample data (only if in Development environment).
 */
public static class HostExtensions
{
    public static async Task InitializeDatabaseAsync(this IHost host)
    {
        using (var scope = host.Services.CreateScope())
        {
            var initializer = scope.ServiceProvider.GetRequiredService<SeedData>();
            await initializer.InitialiseAsync().ConfigureAwait(false);

            var env = host.Services.GetRequiredService<IHostEnvironment>();
            if (env.IsDevelopment())
            {
                await initializer.SeedAsync().ConfigureAwait(false);
            }
        }
    }
}