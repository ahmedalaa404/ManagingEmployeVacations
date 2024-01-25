using ManagingEmployeVacations_Dal.Entites;

namespace ManagingEmployeVacations_PLayer.ViewModel
{
    public class VacationDatePlanVm
    {
        public int Id { get; set; }
        public int VacationRequestId { get; set; }
        public DateTime? VacationDate { get; set; }

        public RequestVacation VacationRequest { get; set; }


    }
}
