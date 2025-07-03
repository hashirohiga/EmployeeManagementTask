using AutoMapper;
using Azure.Core;
using EmployeeManagementTask.Api.Requests;
using EmployeeManagementTask.Api.Responses;
using EmployeeManagementTask.Application.Handlers.Commands.CreateEmployee;
using EmployeeManagementTask.Application.Handlers.Commands.Queries.GetEmployeeById;
using EmployeeManagementTask.Domain.Entites;
using MediatR;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading;

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

}
