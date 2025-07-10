using AutoMapper;
using EmployeeManagementTask.Application.Handlers.Commands.CreateEmployee;
using EmployeeManagementTask.Application.Handlers.Commands.UpdateEmployee;
using EmployeeManagementTask.Application.Handlers.Queries.GetEmployeeById;
using EmployeeManagementTask.Application.Handlers.Queries.GetEmployees;
using EmployeeManagementTask.Domain.Entites;

namespace EmployeeManagementTask.Application.Mappings;

public class EmployeeMappingProfile : Profile
{
    public EmployeeMappingProfile()
    {
        CreateMap<CreateEmployeeCommand, Employee>();
        CreateMap<Employee, CreateEmployeeCommandResult>();

        CreateMap<Employee, GetEmployeeByIdQueryResult>();

        CreateMap<Employee, GetEmployeesQueryResult.EmployeeModel>();
        CreateMap<List<Employee>, GetEmployeesQueryResult>()
            .ForPath(dest => dest.Employees, opt => opt.MapFrom(src => src));

        CreateMap<Employee, UpdateEmployeeCommandResult>();

    }
}
