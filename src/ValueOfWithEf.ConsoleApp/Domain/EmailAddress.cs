using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;
using ValueOf;

namespace ValueOfWithEf.ConsoleApp.Domain;

public class EmailAddress : ValueOf<string, EmailAddress>
{
    private static readonly Regex EmailRegex =
        new("^[\\w!#$%&’*+/=?`{|}~^-]+(?:\\.[\\w!#$%&’*+/=?`{|}~^-]+)*@(?:[a-zA-Z0-9-]+\\.)+[a-zA-Z]{2,6}$",
            RegexOptions.Compiled | RegexOptions.IgnoreCase);

    protected override void Validate()
    {
        if (!EmailRegex.IsMatch(Value))
        {
            throw new ValidationException($"{Value} is not a valid email address");
        }
    }
}