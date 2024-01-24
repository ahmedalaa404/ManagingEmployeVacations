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
    internal class VacationTypeConfigurations : IEntityTypeConfiguration<VacationType>
    {
        public void Configure(EntityTypeBuilder<VacationType> builder)
        {
            builder.HasMany<RequestVacation>().WithOne(X => X.VacationType).HasForeignKey(x => x.VacationTypeId);
        }
    }
}
