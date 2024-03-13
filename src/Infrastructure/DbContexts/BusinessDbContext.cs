using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using Core.DotNet.Extensions.DbContext;
using Core.DotNet.Extensions.Utilities;
using Core.Secure.Business.Domain.AggregatesModel.EntityAggregate;
using Core.Secure.Business.Infrastructure.DbContexts.EntityTypeConfigurations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace Core.Secure.Business.Infrastructure.DbContexts;

public class BusinessDbContext : DbContext
{
    public DbSet<Cart> Carts { get; set; }
    public DbSet<LogSystem> LogSystems { get; set; }
    public DbSet<Order> Orders { get; set; }
    public DbSet<OrderRequest> OrderRequests { get; set; }
    public DbSet<Suborder> Suborders { get; set; }
    
    public BusinessDbContext(DbContextOptions<BusinessDbContext> options) : base(options)
    {
        Debug.WriteLine("BusinessDbContext::ctor ->" + GetHashCode());
    }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new CartEntityTypeConfiguration());
        modelBuilder.ApplyConfiguration(new LogSystemEntityTypeConfiguration());
        modelBuilder.ApplyConfiguration(new OrderEntityTypeConfiguration());
        modelBuilder.ApplyConfiguration(new OrderRequestEntityTypeConfiguration());
        modelBuilder.ApplyConfiguration(new SuborderEntityTypeConfiguration());
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