using EmployeeManagementTask.Domain.Entites;
using Microsoft.EntityFrameworkCore;

namespace EmployeeManagementTask.Infrastructure;

public class EmployeeManagementTaskDbContext : DbContext
{
    public EmployeeManagementTaskDbContext(DbContextOptions<EmployeeManagementTaskDbContext> options)
        : base(options)
    {
    }

    public DbSet<Employee> Employees { get; set; }
}
