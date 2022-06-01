using Bogus;
using Cocona;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ValueOfWithEf.ConsoleApp;
using ValueOfWithEf.ConsoleApp.Domain;

var builder = CoconaApp.CreateBuilder();

builder.Services.AddDbContext<CustomerContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));

var app = builder.Build();

await app.RunAsync(async (CustomerContext customerContext) =>
{
    await customerContext.Database.MigrateAsync();
    
    var customer = new Faker<Customer>()
        .RuleFor(c => c.Name, f => f.Name.FirstName())
        .RuleFor(c => c.Email, (f, c) => EmailAddress.From(f.Internet.Email(c.Name)))
        .Generate();

    await customerContext.AddAsync(customer);
    await customerContext.SaveChangesAsync();
    
    var customers = await customerContext.Customers.AsNoTracking().ToListAsync();

    foreach (var c in customers)
    {
        Console.WriteLine("-------------------------");
        Console.WriteLine(c.Id);
        Console.WriteLine(c.Name);
        Console.WriteLine(c.Email);
    }

    Console.ReadKey();
});