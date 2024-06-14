namespace Record;

public record Person(string FirstName, string LastName, string[] PhoneNumbers);

public record Person2(string FirstName, string LastName)
{
    public string[] PhoneNumbers { get; init; }
}