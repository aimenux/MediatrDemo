using MediatR;

using MediatrDemo.Application.Abstractions;
using MediatrDemo.Application.Exceptions;

namespace MediatrDemo.Application.UseCases.GetPersonById;

public class GetPersonByIdQueryHandler : IRequestHandler<GetPersonByIdQuery, GetPersonByIdQueryResponse>
{
    private readonly IPersonRepository _personRepository;

    public GetPersonByIdQueryHandler(IPersonRepository personRepository)
    {
        _personRepository = personRepository ?? throw new ArgumentNullException(nameof(personRepository));
    }

    public async Task<GetPersonByIdQueryResponse> Handle(GetPersonByIdQuery request, CancellationToken cancellationToken)
    {
        var personId = Guid.Parse(request.Id);
        var person = await _personRepository.GetPersonByIdAsync(personId, cancellationToken);
        if (person is null)
        {
            throw NotFoundException.PersonIsNotFound(request.Id);
        }

        return new GetPersonByIdQueryResponse
        {
            Id = person.Id.ToString(),
            FullName = $"{person.FirstName} {person.LastName}",
            Email = person.Email.Value
        };
    }
}
