using System.ComponentModel.DataAnnotations.Schema;

namespace ManagingEmployeVacations_Dal.Entites
{
    public class RequestVacation:BaseEntity
    {
        public int EmpoyeeId { get; set; }
        public Employee Empoyee { get; set; }



        public DateTime DateRequestVacation { get; set; }
        public DateTime StartDateVacations { get; set; }
        public DateTime EndDateVacations { get; set; }


        public VacationType VacationType { get; set; }
        public int  VacationTypeId { get; set; }



        public List<VacationDatePlan> VacationDatePlan { get; set; } = new List<VacationDatePlan>();




    }
}