using Microsoft.EntityFrameworkCore;

namespace Discount.Grpc.Data
{
    public static class Extension
    {

        public static IApplicationBuilder UseMigration(this IApplicationBuilder app) 
        {
            using var scope = app.ApplicationServices.CreateScope();
            using var dBcontext = scope.ServiceProvider.GetRequiredService<DiscountContext>();
            dBcontext.Database.MigrateAsync();
            return app;
        }
    }
}
