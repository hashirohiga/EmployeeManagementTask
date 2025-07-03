using MediatR;

namespace EmployeeManagementTask.Application.Handlers.Commands.Queries.GetEmployeeById;

public class GetEmployeeByIdQuery : IRequest<GetEmployeeByIdQueryResult>
{
    public int Id { get; set; }
}
