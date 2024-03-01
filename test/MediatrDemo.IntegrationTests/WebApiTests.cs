using System.Net;
using FluentAssertions;
using Xunit.Abstractions;

namespace MediatrDemo.IntegrationTests;

public class WebApiTests
{
    private readonly ITestOutputHelper _testOutputHelper;

    public WebApiTests(ITestOutputHelper testOutputHelper)
    {
        _testOutputHelper = testOutputHelper;
    }

    [Fact]
    public async Task Should_Get_Persons_Returns_Ok()
    {
        // arrange
        var fixture = new IntegrationWebApplicationFactory(_testOutputHelper);
        var client = fixture.CreateClient();

        // act
        var response = await client.GetAsync("api/v1/persons");
        var responseBody = await response.Content.ReadAsStringAsync();

        // assert
        response.StatusCode.Should().Be(HttpStatusCode.OK);
        responseBody.Should().NotBeNullOrWhiteSpace();
    }

    [Fact]
    public async Task Should_Get_Person_By_Id_Returns_Ok()
    {
        // arrange
        var fixture = new IntegrationWebApplicationFactory(_testOutputHelper);
        var client = fixture.CreateClient();
        var personId = fixture.Persons.First().Id;

        // act
        var response = await client.GetAsync($"api/v1/persons/{personId}");
        var responseBody = await response.Content.ReadAsStringAsync();

        // assert
        response.StatusCode.Should().Be(HttpStatusCode.OK);
        responseBody.Should().NotBeNullOrWhiteSpace();
    }

    [Theory]
    [InlineData("abc")]
    [InlineData("123")]
    public async Task Should_Get_Person_By_Id_Returns_BadRequest(string personId)
    {
        // arrange
        var fixture = new IntegrationWebApplicationFactory(_testOutputHelper);
        var client = fixture.CreateClient();

        // act
        var response = await client.GetAsync($"api/v1/persons/{personId}");
        var responseBody = await response.Content.ReadAsStringAsync();

        // assert
        response.StatusCode.Should().Be(HttpStatusCode.BadRequest);
        responseBody.Should().NotBeNullOrWhiteSpace();
    }
}
