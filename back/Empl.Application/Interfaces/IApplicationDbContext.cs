using Empl.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Empl.Application.Interfaces;

public interface IApplicationDbContext
{
    DbSet<Employee> Employees { get; }
    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}
