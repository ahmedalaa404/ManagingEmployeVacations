namespace ManagingEmployeVacations_Dal.Entites
{
    public class VacationType:BaseEntity
    {

        public string Name { get; set; }


        public int NumberDays { get; set; }



        public List<RequestVacation> RequestVacations { get; set; } = new List<RequestVacation>();
    }
}