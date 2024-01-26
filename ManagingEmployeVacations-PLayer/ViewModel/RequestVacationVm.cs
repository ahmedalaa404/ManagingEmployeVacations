using ManagingEmployeVacations_Dal.Entites;
using System.ComponentModel.DataAnnotations;

namespace ManagingEmployeVacations_PLayer.ViewModel
{
    public class RequestVacationVm
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Must Choose Employee")]

        public int EmployeeId { get; set; }
        public Employee? Employee { get; set; }




        public DateTime DateRequestVacation { get; set; }
        [Required(ErrorMessage = " Start Date Vacations")]

        public DateTime StartDateVacations { get; set; }
        [Required(ErrorMessage = " End Date Vacations")]

        public DateTime EndDateVacations { get; set; }


        public VacationType? VacationType { get; set; }
        [Required(ErrorMessage = "vacation Type")]

        public int VacationTypeId { get; set; }


        public bool Approved { get; set; }

        public DateTime? DateApproved { get; set; }
        [Required(ErrorMessage = " Comment Of Vacations Date Vacations")]

        public string Comment { get; set; }
        public List<VacationDatePlan> VacationDatePlan { get; set; } = new List<VacationDatePlan>();

    }
}
