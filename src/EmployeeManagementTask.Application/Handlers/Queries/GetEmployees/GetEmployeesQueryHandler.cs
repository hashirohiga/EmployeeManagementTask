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

        if (!string.IsNullOrWhiteSpace(query.SortBy))
        {
            var isAsc = string.Equals(query.SortDir, "asc", StringComparison.OrdinalIgnoreCase);

            dbQuery = query.SortBy.ToLower() switch
            {
                "id" => isAsc ? dbQuery.OrderBy(e => e.Id) : dbQuery.OrderByDescending(e => e.Id),
                "department" => isAsc ? dbQuery.OrderBy(e => e.Department) : dbQuery.OrderByDescending(e => e.Department),
                "fullname" => isAsc ? dbQuery.OrderBy(e => e.FullName) : dbQuery.OrderByDescending(e => e.FullName),
                "dateofbirth" => isAsc ? dbQuery.OrderBy(e => e.DateOfBirth) : dbQuery.OrderByDescending(e => e.DateOfBirth),
                "hiredate" => isAsc ? dbQuery.OrderBy(e => e.HireDate) : dbQuery.OrderByDescending(e => e.HireDate),
                "salary" => isAsc ? dbQuery.OrderBy(e => e.Salary) : dbQuery.OrderByDescending(e => e.Salary),
                _ => dbQuery
            };
        }

        var employees = await dbQuery.ToListAsync(cancellationToken);

        return _mapper.Map<GetEmployeesQueryResult>(employees);
    }
}
