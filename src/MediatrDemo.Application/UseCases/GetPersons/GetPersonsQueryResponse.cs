namespace MediatrDemo.Application.UseCases.GetPersons;

public class GetPersonsQueryResponse : List<GetPersonQueryResponse>
{
    public GetPersonsQueryResponse(IEnumerable<GetPersonQueryResponse> responses) : base(responses)
    {
    }
}

public class GetPersonQueryResponse
{
    public string Id { get; init; }
    public string FullName { get; init; }
    public string Email { get; init; }
}
