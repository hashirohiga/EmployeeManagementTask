using MediatR;

namespace EmployeeManagementTask.Application.Handlers.Commands.DeleteEmployee;

public class DeleteEmployeeCommand : IRequest<DeleteEmployeeCommandResult>
{
    public int Id { get; set; }
}
