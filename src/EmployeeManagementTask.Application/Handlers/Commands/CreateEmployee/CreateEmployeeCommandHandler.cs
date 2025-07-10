using AutoMapper;
using EmployeeManagementTask.Domain.Entites;
using EmployeeManagementTask.Infrastructure;
using MediatR;

namespace EmployeeManagementTask.Application.Handlers.Commands.CreateEmployee;

public class CreateEmployeeCommandHandler : IRequestHandler<CreateEmployeeCommand, CreateEmployeeCommandResult>
{
    private readonly IMapper _mapper;
    private readonly EmployeeManagementTaskDbContext _context;

    public CreateEmployeeCommandHandler(
        IMapper mapper, EmployeeManagementTaskDbContext context)
    {
        _mapper = mapper;
        _context = context;
    }
    public async Task<CreateEmployeeCommandResult> Handle(CreateEmployeeCommand command, CancellationToken cancellationToken)
    {
        var employee = _mapper.Map<Employee>(command);

        _context.Employees.Add(employee);

        await _context.SaveChangesAsync(cancellationToken);

        return _mapper.Map<CreateEmployeeCommandResult>(employee);
    }
}
