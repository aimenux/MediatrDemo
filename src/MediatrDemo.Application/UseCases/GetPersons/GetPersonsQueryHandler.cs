using MediatR;
using MediatrDemo.Application.Abstractions;

namespace MediatrDemo.Application.UseCases.GetPersons;

public class GetPersonsQueryHandler : IRequestHandler<GetPersonsQuery, GetPersonsQueryResponse>
{
    private readonly IPersonRepository _personRepository;

    public GetPersonsQueryHandler(IPersonRepository personRepository)
    {
        _personRepository = personRepository ?? throw new ArgumentNullException(nameof(personRepository));
    }

    public async Task<GetPersonsQueryResponse> Handle(GetPersonsQuery request, CancellationToken cancellationToken)
    {
        var persons = await _personRepository.GetPersonsAsync(cancellationToken);
        return new GetPersonsQueryResponse(persons
            .Select(x => new GetPersonQueryResponse
            {
                Id = x.Id.ToString(),
                FullName = $"{x.FirstName} {x.LastName}",
                Email = x.Email.Value
            }));
    }
}
