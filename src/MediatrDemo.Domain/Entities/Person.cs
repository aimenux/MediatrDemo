using MediatrDemo.Domain.ValueObjects;

namespace MediatrDemo.Domain.Entities;

public class Person
{
    public Guid Id { get; init; }
    public string FirstName { get; init; }
    public string LastName { get; init; }
    public Email Email { get; init; }
}
