using AutoMapper;
using EmployeeManagementTask.Infrastructure;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace EmployeeManagementTask.Application.Handlers.Commands.DeleteEmployee;

public class DeleteEmployeeCommandHandler : IRequestHandler<DeleteEmployeeCommand, DeleteEmployeeCommandResult>
{
    private readonly EmployeeManagementTaskDbContext _context;

    public DeleteEmployeeCommandHandler(
        EmployeeManagementTaskDbContext context)
    {
        _context = context;
    }

    public async Task<DeleteEmployeeCommandResult> Handle(DeleteEmployeeCommand command, CancellationToken cancellationToken)
    {
        var employee = await _context.Employees.FirstOrDefaultAsync(e => e.Id == command.Id, cancellationToken);

        if (employee is null)
        {
            throw new Exception("Сотрудник с таким идентификатором не найден");
        }

        _context.Employees.Remove(employee);
        await _context.SaveChangesAsync(cancellationToken);

        return new DeleteEmployeeCommandResult();
    }
}
