using System.ComponentModel.DataAnnotations;

namespace ManagingEmployeVacations_PLayer.ViewModel
{
    public class VacationTypeVm
    {
        public int? Id { get; set; }
        [Required(ErrorMessage = " Name Vacations ")]

        public string Name { get; set; }
        [Required(ErrorMessage = "BackgroundColor")]


        public string Background_Color { get; set; }

        [Required(ErrorMessage = "Number OF Days")]
        public int NumberDays { get; set; }

    }
}
