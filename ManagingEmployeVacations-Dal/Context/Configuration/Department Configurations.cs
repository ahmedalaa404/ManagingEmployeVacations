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
    public class Department_Configurations : IEntityTypeConfiguration<Department>
    {
        public void Configure(EntityTypeBuilder<Department> builder)
        {
            builder.HasMany<Employee>().WithOne(x => x.Department).HasForeignKey(x => x.DepartmentId);
        }
    }
}
