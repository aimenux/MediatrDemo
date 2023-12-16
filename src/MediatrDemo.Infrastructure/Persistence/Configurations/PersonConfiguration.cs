using MediatrDemo.Domain.Entities;
using MediatrDemo.Domain.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MediatrDemo.Infrastructure.Persistence.Configurations;

public class PersonConfiguration : IEntityTypeConfiguration<Person>
{
    public void Configure(EntityTypeBuilder<Person> builder)
    {
        builder
            .Property(x => x.Email)
            .HasConversion(email => email.Value, emailValue => new Email(emailValue));

        builder
            .Property(x => x.FirstName)
            .HasMaxLength(100);

        builder
            .Property(x => x.LastName)
            .HasMaxLength(100);

        builder
            .HasData(GetPersons());
    }

    private static Person[] GetPersons()
    {
        return new[]
        {
            new Person
            {
                Id = Guid.NewGuid(),
                FirstName = "Walter",
                LastName = "White",
                Email = new Email("Walter@White.com")
            }
        };
    }
}
