using AutoMapper;
using Empl.Application.Dtos;
using Empl.Application.Employees.Commands;
using Empl.Domain.Entities;

namespace Empl.Application.Profilers;

public class EmployeeProfile:Profile
{
    public EmployeeProfile()
    {
        CreateMap<AddEmployeeCommand, Employee>();
        CreateMap<EditEmployeeCommand, Employee>();
        CreateMap<Employee, EmployeeDto>().ReverseMap();
    }
}
