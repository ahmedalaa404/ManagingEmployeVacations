using ManagingEmployeVacations_Dal.Entites;
using ManagingEmployeVacations_Dal.InterFaces;
using Microsoft.AspNetCore.Mvc;

namespace ManagingEmployeVacations_PLayer.Controllers
{
    public class DepartmetnController : Controller
    {
        private readonly IRepository<Department> RepoDepartment;

        public DepartmetnController(IRepository<Department> repoDepartment)
        {
            RepoDepartment = repoDepartment;
        }
        public IActionResult Index()
        {
            var Data = RepoDepartment.GetAll().ToList();
            return View();
        }
    }
}
