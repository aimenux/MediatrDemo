using MediatrDemo.Application.Abstractions;
using MediatrDemo.Domain.Entities;
using MediatrDemo.Infrastructure.Persistence.Contexts;

using Microsoft.EntityFrameworkCore;

namespace MediatrDemo.Infrastructure.Persistence.Repositories;

public class PersonRepository : IPersonRepository
{
    private readonly PersonDbContext _context;

    public PersonRepository(PersonDbContext context)
    {
        _context = context ?? throw new ArgumentNullException(nameof(context));
    }

    public async Task<ICollection<Person>> GetPersonsAsync(CancellationToken cancellationToken)
    {
        var persons = await _context.Set<Person>().ToListAsync(cancellationToken);
        return persons;
    }

    public async Task<Person> GetPersonByIdAsync(Guid personId, CancellationToken cancellationToken)
    {
        var person = await _context.Set<Person>().FirstOrDefaultAsync(x => x.Id == personId, cancellationToken);
        return person;
    }
}
