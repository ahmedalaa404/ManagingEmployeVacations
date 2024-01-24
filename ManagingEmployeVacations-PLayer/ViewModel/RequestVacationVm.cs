using ManagingEmployeVacations_Dal.Entites;

namespace ManagingEmployeVacations_PLayer.ViewModel
{
    public class RequestVacationVm
    {

        public int EmpoyeeId { get; set; }
        public Employee Empoyee { get; set; }



        public DateTime DateRequestVacation { get; set; }
        public DateTime StartDateVacations { get; set; }
        public DateTime EndDateVacations { get; set; }


        public VacationType VacationType { get; set; }
        public int VacationTypeId { get; set; }


        public bool Approved { get; set; }

        public DateTime DateApproved { get; set; }



        public string Comment { get; set; }

    }
}
