using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagingEmployeVacations_Dal.Entites
{
    public class Department:BaseEntity  // C-Class -Convert to table 
    {
        public string Name { get; set; }

        public string Description { get; set; } 
        public List<Employee> Employees { get; set; }=new List<Employee>();


    }
}
