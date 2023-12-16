namespace MediatrDemo.Api.Presentation.Controllers.V1.GetPersons;

public class GetPersonsApiResponse : List<GetPersonApiResponse>
{
    public GetPersonsApiResponse(IEnumerable<GetPersonApiResponse> responses) : base(responses)
    {
    }
}

public class GetPersonApiResponse
{
    public string Id { get; init; }
    public string FullName { get; init; }
    public string Email { get; init; }
}
