using Empl.Application.Employees.Commands;
using Empl.Application.Employees.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Empl.Controllers;


[ApiController]
[Route("api/[controller]")]
public class EmployeesController : ControllerBase
{
    private readonly IMediator _mediator;

    public EmployeesController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    [Route("getAll")]
    public async Task<IActionResult> GetAll()
    {
        var query = new GetAllEmployeesQuery();
        return Ok(await _mediator.Send(query));
    }

    [HttpPost]
    [Route("add")]
    public async Task<IActionResult> Add(AddEmployeeCommand command)
    {
        await _mediator.Send(command);
        return Ok();
    }

    [HttpPut]
    [Route("edit")]
    public async Task<IActionResult> Edit(EditEmployeeCommand command)
    {
        await _mediator.Send(command);
        return Ok();
    }

    [HttpDelete]
    [Route("delete/{id}")]
    public async Task<IActionResult> Delete(string id)
    {
        var command = new DeleteEmployeeCommand { Id = id };
        await _mediator.Send(command);
        return Ok();
    }

}
