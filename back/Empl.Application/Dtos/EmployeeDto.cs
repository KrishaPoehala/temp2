using Empl.Common.Enums;

namespace Empl.Application.Dtos;

public class EmployeeDto
{
    public string Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public Genres Genre { get; set; }
    public string City { get; set; }
}
