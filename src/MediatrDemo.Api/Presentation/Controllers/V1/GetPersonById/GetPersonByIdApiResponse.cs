namespace MediatrDemo.Api.Presentation.Controllers.V1.GetPersonById;

public sealed record GetPersonByIdApiResponse
{
    public string Id { get; init; }
    public string FullName { get; init; }
    public string Email { get; init; }
}
