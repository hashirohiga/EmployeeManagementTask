using AutoMapper;
using EmployeeManagementTask.Domain.Entites;
using EmployeeManagementTask.Infrastructure;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace EmployeeManagementTask.Application.Handlers.Queries.GetEmployeeById;

public class GetEmployeeByIdQueryHandler : IRequestHandler<GetEmployeeByIdQuery, GetEmployeeByIdQueryResult>
{
    private readonly IMapper _mapper;
    private readonly EmployeeManagementTaskDbContext _context;
    public GetEmployeeByIdQueryHandler(
        IMapper mapper, EmployeeManagementTaskDbContext context)
    {
        _mapper = mapper;
        _context = context;
    }

    public async Task<GetEmployeeByIdQueryResult> Handle(GetEmployeeByIdQuery query, CancellationToken cancellationToken)
    {
        var employee = await _context.Employees.FirstOrDefaultAsync(e => e.Id == query.Id, cancellationToken);

        if (employee is null)
        {
            throw new Exception("Сотрудник с таким идентификатором не найден");
        }

        return _mapper.Map<GetEmployeeByIdQueryResult>(employee);
    }
}
