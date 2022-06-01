using ValueOf;

namespace ValueOfWithEf.ConsoleApp.Domain;

public class CustomerId : ValueOf<Guid, CustomerId>
{
    protected override void Validate()
    {
        if (Value == Guid.Empty)
        {
            throw new ArgumentException("Customer Id cannot be empty", nameof(CustomerId));
        }
    }
}