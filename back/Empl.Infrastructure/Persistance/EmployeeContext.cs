using Empl.Application.Interfaces;
using Empl.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Empl.Infrastructure.Persistance;

public class EmployeeContext:DbContext,IApplicationDbContext
{
    public DbSet<Employee> Employees { get; init; }
    public EmployeeContext(DbContextOptions<EmployeeContext> options):base(options)
    {
    }
}

