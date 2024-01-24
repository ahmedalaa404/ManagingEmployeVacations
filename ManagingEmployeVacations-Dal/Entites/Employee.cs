using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagingEmployeVacations_Dal.Entites
{
    public class Employee:BaseEntity 
    {
        public string Name { get; set; }

        public int VacationBalance { get; set; }

        public int DepartmentId { get; set; }

        
        public Department Department { get; set; }
        public List<RequestVacation> RequestVacations { get; set; }


    }
}
