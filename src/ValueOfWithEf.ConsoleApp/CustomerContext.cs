using Microsoft.EntityFrameworkCore;
using ValueOfWithEf.ConsoleApp.Domain;

namespace ValueOfWithEf.ConsoleApp;

public class CustomerContext : DbContext
{
    public CustomerContext(DbContextOptions options) : base(options)
    {
    }

    public DbSet<Customer> Customers => Set<Customer>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .Entity<Customer>()
            .Property(e => e.Id)
            .HasConversion(
                convertToProviderExpression: id => id.Value,
                convertFromProviderExpression: id => CustomerId.From(id));

        modelBuilder
            .Entity<Customer>()
            .Property(e => e.Email)
            .HasConversion(
                convertToProviderExpression: emailAddress => emailAddress.ToString(),
                convertFromProviderExpression: emailAddress => EmailAddress.From(emailAddress));
    }
}