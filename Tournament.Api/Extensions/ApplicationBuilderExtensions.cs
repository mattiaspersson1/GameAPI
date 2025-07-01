using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Tournament.Data.Data;

namespace Tournament.Api.Extensions
{
    public static class ApplicationBuilderExtensions
    {
        public static void SeedData(this IApplicationBuilder app)
        {
            using var scope = app.ApplicationServices.CreateScope();
            var context = scope.ServiceProvider.GetRequiredService<TournamentDbContext>();
            TournamentDataSeeder.Initialize(context);
        }
    }
}