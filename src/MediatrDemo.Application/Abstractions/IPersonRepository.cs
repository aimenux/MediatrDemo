using MediatrDemo.Domain.Entities;

namespace MediatrDemo.Application.Abstractions;

public interface IPersonRepository
{
    Task<ICollection<Person>> GetPersonsAsync(CancellationToken cancellationToken);
    Task<Person> GetPersonByIdAsync(Guid personId, CancellationToken cancellationToken);
}
