using Empl.Common.Enums;

namespace Empl.Domain.Entities;

public class Employee
{
    public string Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public Genres Genre { get; set; }
    public string City { get; set; }
}
