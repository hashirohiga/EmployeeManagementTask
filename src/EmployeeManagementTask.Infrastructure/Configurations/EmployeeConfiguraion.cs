using EmployeeManagementTask.Domain.Entites;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.ComponentModel;

namespace EmployeeManagementTask.Infrastructure.Configurations;

public class EmployeeConfiguraion : IEntityTypeConfiguration<Employee>
{
    public void Configure(EntityTypeBuilder<Employee> builder)
    {
        builder.HasKey(e => e.Id);

        builder.Property(e => e.Department)
              .IsRequired();

        builder.Property(e => e.FullName)
              .IsRequired();

        builder.Property(e => e.Salary)
              .HasColumnType("decimal(18,2)");
    }
}
