using AutoMapper;
using EmployeeManagementTask.Api.Requests;
using EmployeeManagementTask.Api.Responses;
using EmployeeManagementTask.Application.Handlers.Commands.CreateEmployee;
using EmployeeManagementTask.Application.Handlers.Commands.Queries.GetEmployeeById;

namespace EmployeeManagementTask.Api.Mappings;

public class EmployeeMappingProfile : Profile
{
    public EmployeeMappingProfile()
    {
        CreateMap<CreateEmployeeRequest, CreateEmployeeCommand>();
        CreateMap<CreateEmployeeCommandResult, CreateEmployeeResponse>();

        //CreateMap<GetEmployeeByIdRequest, GetEmployeeByIdQuery>();
        CreateMap<GetEmployeeByIdQueryResult, GetEmployeeByIdResponse>();

    }
}
