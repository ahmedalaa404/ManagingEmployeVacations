using ManagingEmployeVacations_Dal.Entites;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagingEmployeVacations_Dal.Context.Configuration
{
    internal class EmployeeConfiguration : IEntityTypeConfiguration<Employee>
    {
        public void Configure(EntityTypeBuilder<Employee> builder)
        {
            builder.HasOne(x => x.Department).WithMany(x=>x.Employees).HasForeignKey(x=>x.DepartmentId);
            builder.HasMany(x => x.RequestVacations).WithOne(x=>x.Empoyee).HasForeignKey(x=>x.EmpoyeeId);
        }
    }
}
