using AutoMapper;
using EmployeeManagementTask.Application.Handlers.Commands.CreateEmployee;
using EmployeeManagementTask.Application.Handlers.Commands.Queries.GetEmployeeById;
using EmployeeManagementTask.Domain.Entites;

namespace EmployeeManagementTask.Application.Mappings;

public class EmployeeMappingProfile : Profile
{
    public EmployeeMappingProfile()
    {
        CreateMap<CreateEmployeeCommand, Employee>();
        CreateMap<Employee, CreateEmployeeCommandResult>();

        CreateMap<Employee, GetEmployeeByIdQueryResult>();

    }
}
