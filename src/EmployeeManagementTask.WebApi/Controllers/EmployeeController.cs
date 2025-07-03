using AutoMapper;
using EmployeeManagementTask.Api.Requests;
using EmployeeManagementTask.Api.Responses;
using EmployeeManagementTask.Application.Handlers.Commands.CreateEmployee;
using EmployeeManagementTask.Application.Handlers.Commands.DeleteEmployee;
using EmployeeManagementTask.Application.Handlers.Commands.UpdateEmployee;
using EmployeeManagementTask.Application.Handlers.Queries.GetEmployeeById;
using EmployeeManagementTask.Application.Handlers.Queries.GetEmployees;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeManagementTask.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class EmployeesController : ControllerBase
{
    private readonly IMapper _mapper;
    private readonly IMediator _mediator;

    public EmployeesController(IMediator mediator, IMapper mapper)
    {
        _mediator = mediator;
        _mapper = mapper;
    }

    [HttpPost]
    public async Task<IActionResult> CreateEmployeeAsync(CreateEmployeeRequest request, CancellationToken cancellationToken)
    {
        var command = _mapper.Map<CreateEmployeeCommand>(request);

        var result = await _mediator.Send(command, cancellationToken);

        return Ok(_mapper.Map<CreateEmployeeResponse>(result));
    }

    [HttpGet]
    public async Task<IActionResult> GetEmployeesAsync([FromQuery] GetEmployeesRequest request, CancellationToken cancellationToken)
    {
        var query = _mapper.Map<GetEmployeesQuery>(request);

        var result = await _mediator.Send(query, cancellationToken);

        return Ok(result.Employees);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetEmployeeByIdAsync([FromRoute] int id, CancellationToken cancellationToken)
    {
        var query = new GetEmployeeByIdQuery
        {
            Id = id
        };

        var result = await _mediator.Send(query, cancellationToken);

        return Ok(_mapper.Map<GetEmployeeByIdResponse>(result));
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateEmployeeAsync(
        [FromRoute] int id,
        [FromBody] UpdateEmployeeRequest request,
        CancellationToken cancellationToken)
    {
        var command = _mapper.Map<UpdateEmployeeCommand>(request);
        command.Id = id;

        var result = await _mediator.Send(command, cancellationToken);

        return Ok(_mapper.Map<UpdateEmployeeResponse>(result));
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteEmployeeAsync([FromRoute] int id, CancellationToken cancellationToken)
    {
        var command = new DeleteEmployeeCommand
        {
            Id = id
        };

        var result = await _mediator.Send(command, cancellationToken);

        return Ok();
    }
}
