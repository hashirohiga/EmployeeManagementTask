using AutoMapper;
using Azure.Core;
using EmployeeManagementTask.Infrastructure;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace EmployeeManagementTask.Application.Handlers.Queries.GetEmployees;

public class GetEmployeesQueryHandler : IRequestHandler<GetEmployeesQuery, GetEmployeesQueryResult>
{
    private readonly IMapper _mapper;
    private readonly EmployeeManagementTaskDbContext _context;

    public GetEmployeesQueryHandler(
        IMapper mapper, EmployeeManagementTaskDbContext context)
    {
        _mapper = mapper;
        _context = context;
    }

    public async Task<GetEmployeesQueryResult> Handle(GetEmployeesQuery query, CancellationToken cancellationToken)
    {
        var dbQuery = _context.Employees.AsQueryable();

        if (!string.IsNullOrWhiteSpace(query.Department))
        {
            dbQuery = dbQuery.Where(e => e.Department.Contains(query.Department));
        }

        if (!string.IsNullOrWhiteSpace(query.FullName))
        {
            dbQuery = dbQuery.Where(e => e.FullName.Contains(query.FullName));
        }

        if (query.HireDate.HasValue)
        {
            var hireDate = query.HireDate.Value.Date;
            dbQuery = dbQuery.Where(e => e.HireDate >= hireDate && e.HireDate < hireDate.AddDays(1));
        }

        if (query.DateOfBirth.HasValue)
        {
            var birthDate = query.DateOfBirth.Value.Date;
            dbQuery = dbQuery.Where(e => e.DateOfBirth >= birthDate && e.DateOfBirth < birthDate.AddDays(1));
        }

        var employees = await dbQuery.ToListAsync(cancellationToken);

        return _mapper.Map<GetEmployeesQueryResult>(employees);
    }
}
