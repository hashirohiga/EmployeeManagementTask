using AutoMapper;
using EmployeeManagementTask.Api.Requests;
using EmployeeManagementTask.Api.Responses;
using EmployeeManagementTask.Application.Handlers.Commands.CreateEmployee;
using EmployeeManagementTask.Application.Handlers.Commands.UpdateEmployee;
using EmployeeManagementTask.Application.Handlers.Queries.GetEmployeeById;
using EmployeeManagementTask.Application.Handlers.Queries.GetEmployees;

namespace EmployeeManagementTask.Api.Mappings;

public class EmployeeMappingProfile : Profile
{
    public EmployeeMappingProfile()
    {
        CreateMap<CreateEmployeeRequest, CreateEmployeeCommand>();
        CreateMap<CreateEmployeeCommandResult, CreateEmployeeResponse>();

        CreateMap<GetEmployeeByIdQueryResult, GetEmployeeByIdResponse>();

        CreateMap<GetEmployeesRequest, GetEmployeesQuery>();

        CreateMap<UpdateEmployeeRequest, UpdateEmployeeCommand>();
        CreateMap<UpdateEmployeeCommandResult, UpdateEmployeeResponse>();
    }
}
