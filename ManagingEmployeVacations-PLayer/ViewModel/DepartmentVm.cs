using ManagingEmployeVacations_Dal.Entites;

namespace ManagingEmployeVacations_PLayer.ViewModel
{
    public class DepartmentVm
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public string Description { get; set; }
        public List<Employee> Employees { get; set; } = new List<Employee>();





    }
}
