using AutoMapper;
using Empl.Application.Interfaces;
using Empl.Common.Enums;
using Empl.Domain.Entities;
using MediatR;

namespace Empl.Application.Employees.Commands;

public class AddEmployeeCommand:IRequest
{
    public string Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public Genres Genre { get; set; }
    public string City { get; set; }
}

public class AddEmployeeCommandHandler : IRequestHandler<AddEmployeeCommand>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;
    public AddEmployeeCommandHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task Handle(AddEmployeeCommand request, CancellationToken cancellationToken)
    {
        var entity = _mapper.Map<Employee>(request);
        _context.Employees.Add(entity);
        await _context.SaveChangesAsync(cancellationToken);
    }
}
