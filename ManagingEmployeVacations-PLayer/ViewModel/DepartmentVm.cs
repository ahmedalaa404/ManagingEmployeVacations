using ManagingEmployeVacations_Dal.Entites;
using System.ComponentModel.DataAnnotations;

namespace ManagingEmployeVacations_PLayer.ViewModel
{
    public class DepartmentVm
    {
        public int? Id { get; set; }
        [Required(ErrorMessage ="Must Enter Name Department")]

        public string Name { get; set; }
        [Required(ErrorMessage = "Must Enter Deescriptin Department")]


        public string Description { get; set; }






    }
}
