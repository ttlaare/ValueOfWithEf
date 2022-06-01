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
                id => id.Value,
                id => CustomerId.From(id));

        modelBuilder
            .Entity<Customer>()
            .Property(e => e.Email)
            .HasConversion(
                emailAddress => emailAddress.ToString(),
                emailAddress => EmailAddress.From(emailAddress));
    }
}