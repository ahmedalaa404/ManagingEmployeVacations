using ManagingEmployeVacations_Dal.Entites;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagingEmployeVacations_Dal.Context
{
    public class VacationContext:DbContext
    {



        public VacationContext(DbContextOptions<VacationContext> options):base(options)
        {
            
        }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<VacationType> VacationsType { get; set; }
        public DbSet<RequestVacation> RequestsVacation { get; set; }
        public DbSet<VacationDatePlan> VacationsDatePlan { get; set; }



    }
}
