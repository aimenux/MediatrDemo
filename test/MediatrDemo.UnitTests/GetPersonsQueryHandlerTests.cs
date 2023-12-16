using FluentAssertions;
using MediatrDemo.Application.Abstractions;
using MediatrDemo.Application.UseCases.GetPersons;
using MediatrDemo.Domain.Entities;
using MediatrDemo.Domain.ValueObjects;
using NSubstitute;

namespace MediatrDemo.UnitTests;

public class GetPersonsQueryHandlerTests
{
    [Fact]
    public async Task Should_Handle_GetPersonsQuery_Return_Valid_Response()
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
            .GetPersonsAsync(Arg.Any<CancellationToken>())
            .Returns(new[] { person });
        var query = new GetPersonsQuery();
        var handler = new GetPersonsQueryHandler(repository);

        // act
        var queryResponse = await handler.Handle(query, CancellationToken.None);

        // assert
        queryResponse.Should().NotBeNullOrEmpty().And.HaveCount(1);
        queryResponse.Single().Id.Should().Be(person.Id.ToString());
        queryResponse.Single().FullName.Should().Be($"{person.FirstName} {person.LastName}");
        queryResponse.Single().Email.Should().Be(person.Email.Value);
    }
}
