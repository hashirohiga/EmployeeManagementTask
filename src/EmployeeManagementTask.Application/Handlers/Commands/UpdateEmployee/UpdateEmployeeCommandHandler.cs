using AutoMapper;
using EmployeeManagementTask.Infrastructure;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace EmployeeManagementTask.Application.Handlers.Commands.UpdateEmployee;

public class UpdateEmployeeCommandHandler : IRequestHandler<UpdateEmployeeCommand, UpdateEmployeeCommandResult>
{
    private readonly IMapper _mapper;
    private readonly EmployeeManagementTaskDbContext _context;

    public UpdateEmployeeCommandHandler(
        IMapper mapper, EmployeeManagementTaskDbContext context)
    {
        _mapper = mapper;
        _context = context;
    }

    public async Task<UpdateEmployeeCommandResult> Handle(UpdateEmployeeCommand command, CancellationToken cancellationToken)
    {
        var employee = await _context.Employees.FirstOrDefaultAsync(e => e.Id == command.Id, cancellationToken);

        if (employee is null)
        {
            throw new Exception("Сотрудник с таким идентификатором не найден");
        }

        employee.FullName = command.FullName;
        employee.Department = command.Department;
        employee.DateOfBirth = command.DateOfBirth;
        employee.HireDate = command.HireDate;
        employee.Salary = command.Salary;

        await _context.SaveChangesAsync(cancellationToken);

        return _mapper.Map<UpdateEmployeeCommandResult>(employee);
    }
}
