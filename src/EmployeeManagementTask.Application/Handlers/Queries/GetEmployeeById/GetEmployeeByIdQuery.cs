using MediatR;

namespace EmployeeManagementTask.Application.Handlers.Queries.GetEmployeeById;

public class GetEmployeeByIdQuery : IRequest<GetEmployeeByIdQueryResult>
{
    public int Id { get; set; }
}
