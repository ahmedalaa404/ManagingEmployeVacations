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





    }
}
