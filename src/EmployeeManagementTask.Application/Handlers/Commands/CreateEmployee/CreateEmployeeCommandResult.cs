namespace EmployeeManagementTask.Application.Handlers.Commands.CreateEmployee;

public class CreateEmployeeCommandResult
{
    public int Id { get; set; }

    public string Department { get; set; } = null!;

    public string FullName { get; set; } = null!;

    public DateTime DateOfBirth { get; set; }

    public DateTime HireDate { get; set; }

    public decimal Salary { get; set; }
}
