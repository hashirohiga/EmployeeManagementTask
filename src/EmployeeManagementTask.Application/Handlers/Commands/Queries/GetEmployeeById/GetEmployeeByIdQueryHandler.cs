using AutoMapper;
using EmployeeManagementTask.Infrastructure;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace EmployeeManagementTask.Application.Handlers.Commands.Queries.GetEmployeeById;

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
        var user = await _context.Employees.FirstOrDefaultAsync(u => u.Id == query.Id);

        return _mapper.Map<GetEmployeeByIdQueryResult>(user);
    }
}
