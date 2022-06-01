namespace ValueOfWithEf.ConsoleApp.Domain;

public class Customer
{
    public CustomerId Id { get; init; } = CustomerId.From(Guid.NewGuid());

    public EmailAddress Email { get; init; } = default!;

    public string Name { get; init; } = string.Empty;
}