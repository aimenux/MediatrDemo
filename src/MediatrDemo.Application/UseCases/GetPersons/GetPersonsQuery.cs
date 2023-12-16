using MediatR;

namespace MediatrDemo.Application.UseCases.GetPersons;

public record GetPersonsQuery : IRequest<GetPersonsQueryResponse>;
