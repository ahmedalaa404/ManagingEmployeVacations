namespace ManagingEmployeVacations_Dal.Entites
{
    public class VacationDatePlan:BaseEntity
    {
        public int VacationRequestId { get; set; }


        public RequestVacation VacationRequest { get; set; }



    }
}