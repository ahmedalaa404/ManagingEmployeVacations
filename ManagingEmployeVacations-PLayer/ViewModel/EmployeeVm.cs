using System.ComponentModel.DataAnnotations;

namespace ManagingEmployeVacations_PLayer.ViewModel
{
    public class EmployeeVm
    {

        public int Id{ get; set; }
        [Required(ErrorMessage = "Must Enter Number Balance Vacations")]

        public int VacationBalance { get; set; }
        [Required(ErrorMessage = "Must Enter Name Employee")]

        public string  Name { get; set; }
        [Required(ErrorMessage = "Must Choose Department")]

        public int DepartmentId { get; set; }
        public DepartmentVm? Department   { get; set; }
    }
}
