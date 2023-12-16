using FluentAssertions;
using MediatrDemo.Application.Abstractions;
using MediatrDemo.Application.UseCases.GetPersonById;
using MediatrDemo.Domain.Entities;
using MediatrDemo.Domain.ValueObjects;
using NSubstitute;

namespace MediatrDemo.UnitTests;

public class GetPersonByIdQueryHandlerTests
{
    [Fact]
    public async Task Should_Handle_GetPersonByIdQuery_Return_Valid_Response()
    {
        // arrange
        var person = new Person
        {
            Id = Guid.NewGuid(),
            FirstName = "FirstName",
            LastName = "LastName",
            Email = new Email("first@last.com")
        };
        var repository = Substitute.For<IPersonRepository>();
        repository
            .GetPersonByIdAsync(person.Id, Arg.Any<CancellationToken>())
            .Returns(person);
        var query = new GetPersonByIdQuery(person.Id.ToString());
        var handler = new GetPersonByIdQueryHandler(repository);

        // act
        var queryResponse = await handler.Handle(query, CancellationToken.None);

        // assert
        queryResponse.Should().NotBeNull();
        queryResponse.Id.Should().Be(person.Id.ToString());
        queryResponse.FullName.Should().Be($"{person.FirstName} {person.LastName}");
        queryResponse.Email.Should().Be(person.Email.Value);
    }
}
