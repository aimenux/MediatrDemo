namespace MediatrDemo.Api.Presentation.Controllers.V1.GetPersons;

public sealed class GetPersonsApiResponse : List<GetPersonApiResponse>
{
    public GetPersonsApiResponse(IEnumerable<GetPersonApiResponse> responses) : base(responses)
    {
    }
}

public sealed record GetPersonApiResponse
{
    public string Id { get; init; }
    public string FullName { get; init; }
    public string Email { get; init; }
}
