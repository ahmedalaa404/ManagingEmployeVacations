namespace ManagingEmployeVacations_PLayer.ViewModel
{
    public class EmployeeVm
    {

        public int Id{ get; set; }

        public int VacationBalance { get; set; }

        public string  Name { get; set; }
        public int DepartmentId { get; set; }
        public DepartmentVm? Department   { get; set; }
    }
}
