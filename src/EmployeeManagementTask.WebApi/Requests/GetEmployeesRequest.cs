namespace EmployeeManagementTask.Api.Requests
{
    public class GetEmployeesRequest
    {
        public string? Department { get; set; }

        public string? FullName { get; set; }

        public DateTime? DateOfBirth { get; set; }

        public DateTime? HireDate { get; set; }
    }
}
