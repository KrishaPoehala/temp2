using AutoMapper;
using Empl.Application.Interfaces;
using Empl.Common.Enums;
using Empl.Domain.Entities;
using MediatR;

namespace Empl.Application.Employees.Commands;

public class EditEmployeeCommand: IRequest
{
    public string Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public Genres Genre { get; set; }
    public string City { get; set; }
}

public class EditEmployeeCommandHandler : IRequestHandler<EditEmployeeCommand>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;
    public EditEmployeeCommandHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task Handle(EditEmployeeCommand request, CancellationToken cancellationToken)
    {
        var entity = _mapper.Map<Employee>(request);
        _context.Employees.Update(entity);
        await _context.SaveChangesAsync(cancellationToken);
    }
}
