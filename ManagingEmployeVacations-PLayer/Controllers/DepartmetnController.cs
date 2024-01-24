using AutoMapper;
using ManagingEmployeVacations_Dal.Entites;
using ManagingEmployeVacations_Dal.InterFaces;
using ManagingEmployeVacations_PLayer.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace ManagingEmployeVacations_PLayer.Controllers
{
    public class DepartmetnController : Controller
    {
        private readonly IRepository<Department> RepoDepartment;
        private readonly IMapper Map;

        public DepartmetnController(IRepository<Department> repoDepartment,IMapper map)
        {
            RepoDepartment = repoDepartment;
            Map = map;
        }
        public IActionResult Index()
        {
            var Data = RepoDepartment.GetAll().ToList();
            var DataVM= Map.Map<IEnumerable<DepartmentVm>>(Data);
            return View(DataVM);
        }
    }
}
