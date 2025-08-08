using DotNetEnv;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace ShopMate.Persistence.Data;

public class ShopMateDbContextFactory : IDesignTimeDbContextFactory<ShopMateDbContext>
{
    public ShopMateDbContext CreateDbContext(string[] args)
    {
        try
        {
            Env.Load("../../../.env"); 
        }
        catch
        {
            // ignore
        }

        var connectionString = Environment.GetEnvironmentVariable("CONNECTION_STRING");

        var optionsBuilder = new DbContextOptionsBuilder<ShopMateDbContext>();
        optionsBuilder.UseNpgsql(connectionString);

        return new ShopMateDbContext(optionsBuilder.Options);
    }
}


