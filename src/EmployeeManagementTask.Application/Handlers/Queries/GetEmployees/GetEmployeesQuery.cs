using MediatR;

namespace EmployeeManagementTask.Application.Handlers.Queries.GetEmployees;

public class GetEmployeesQuery : IRequest<GetEmployeesQueryResult>
{
    public string? Department { get; set; }
    public string? FullName { get; set; }
    public DateTime? DateOfBirth { get; set; }
    public DateTime? HireDate { get; set; }
}
