using AutoMapper;
using Empl.Application.Dtos;
using Empl.Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Empl.Application.Employees.Queries;

public class GetAllEmployeesQuery:IRequest<IEnumerable<EmployeeDto>>
{
}

public class GetAllEmployeesQueryHandler : IRequestHandler<GetAllEmployeesQuery, IEnumerable<EmployeeDto>>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;
    public GetAllEmployeesQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<IEnumerable<EmployeeDto>> Handle(GetAllEmployeesQuery request, CancellationToken cancellationToken)
    {
        var entities = await _context.Employees.ToListAsync(cancellationToken);
        return _mapper.Map<IEnumerable<EmployeeDto>>(entities.AsEnumerable()); 
    }
}
