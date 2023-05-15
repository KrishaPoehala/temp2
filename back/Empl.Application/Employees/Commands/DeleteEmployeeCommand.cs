using AutoMapper;
using Empl.Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Empl.Application.Employees.Commands;

public class DeleteEmployeeCommand:IRequest
{
    public string Id { get; set; }
}

public class DeleteEmployeeCommandHandler : IRequestHandler<DeleteEmployeeCommand>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;
    public DeleteEmployeeCommandHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task Handle(DeleteEmployeeCommand request, CancellationToken cancellationToken)
    {
        var entity = await _context.Employees.FirstAsync(x => x.Id == request.Id,cancellationToken);
        _context.Employees.Remove(entity);
        await _context.SaveChangesAsync(cancellationToken);
    }
}
