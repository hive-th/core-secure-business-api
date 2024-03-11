using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using Core.DotNet.Extensions.DbContext;
using Core.DotNet.Extensions.Utilities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace Core.Secure.Business.Infrastructure.DbContexts;

public class BusinessDbContext : DbContext
{
    //public DbSet<AttributeOption> AttributeOptions { get; set; }
    
    public BusinessDbContext(DbContextOptions<BusinessDbContext> options) : base(options)
    {
        Debug.WriteLine("AuthenticationDbContext::ctor ->" + GetHashCode());
    }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        //modelBuilder.ApplyConfiguration(new AttributeEntityTypeConfiguration());
        modelBuilder.ApplyGlobalFiltersSoftDeleted();
        modelBuilder.UseSnakeCaseNames();
    }
}

[ExcludeFromCodeCoverage]
public class BusinessContextDesignFactory : IDesignTimeDbContextFactory<BusinessDbContext>
{
    public BusinessDbContext CreateDbContext(string[] args)
    {
        var connectionString = ConfigurationExtension
            .CreateConfigurationBuilder("API")
            .AddJsonFile($"appsettings.Development.json", true, true)
            .AddEnvironmentVariables()
            .Build()["POSTGRES_CONNECTIONSTRING"];

        var dbContextOptions = new DbContextOptionsBuilder<BusinessDbContext>()
            .UseNpgsql(connectionString)
            .Options;

        return new BusinessDbContext(dbContextOptions);
    }
}