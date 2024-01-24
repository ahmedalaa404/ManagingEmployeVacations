using ManagingEmployeVacations_Dal.Entites;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagingEmployeVacations_Dal.Context.Configuration
{
    public class RequestVacationConfiguration : IEntityTypeConfiguration<RequestVacation>
    {
        public void Configure(EntityTypeBuilder<RequestVacation> builder)
        {
            builder.HasOne<Employee>().WithMany(X => X.RequestVacations).HasForeignKey(x => x.EmpoyeeId);
            builder.HasOne<VacationType>().WithMany(X => X.RequestVacations).HasForeignKey(x => x.VacationTypeId);
            builder.HasMany<VacationDatePlan>().WithOne(X => X.VacationRequest).HasForeignKey(x => x.VacationRequestId);
        }
    }
}
