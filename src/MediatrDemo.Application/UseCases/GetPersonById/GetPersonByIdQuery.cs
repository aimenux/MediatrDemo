using MediatR;

namespace MediatrDemo.Application.UseCases.GetPersonById;

public record GetPersonByIdQuery(string Id) : IRequest<GetPersonByIdQueryResponse>;
