using AutoMapper;
using ManagingEmployeVacations_Bl.Repositorey;
using ManagingEmployeVacations_Dal.Entites;
using ManagingEmployeVacations_Dal.InterFaces;
using ManagingEmployeVacations_PLayer.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace ManagingEmployeVacations_PLayer.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IRepository<Employee> _RepoEmployee;
        private readonly IMapper _Mapper;
        private readonly IRepository<Department> _RepoDepartment;

        public EmployeeController(IRepository<Employee> _RepoEmployee, IMapper map, IRepository<Department> _repoDepartment)
        {
            this._RepoEmployee = _RepoEmployee;
            _Mapper = map;
            _RepoDepartment = _repoDepartment;
        }
        public IActionResult Index()
        {
            var Data = _RepoEmployee.GetAll().ToList();
            var DataVM = _Mapper.Map<IEnumerable<EmployeeVm>>(Data);
            return View(DataVM);
        }


        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.Department = _RepoDepartment.GetAll();

            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(EmployeeVm model)
        {
            if (ModelState.IsValid)
            {
                var EmployeeCreate = _Mapper.Map<EmployeeVm, Employee>(model);
                _RepoEmployee.Create(EmployeeCreate);
                return RedirectToAction(nameof(Index));
            }
            ViewBag.Department = _RepoDepartment.GetAll();

            return View(model);

        }



        [HttpGet]
        public IActionResult Delete(int id, string NameView="Delete")
        {
   
                var Employee = _RepoEmployee.GetById(id);
            var EmployeeVM=_Mapper.Map<EmployeeVm>(Employee);
            ViewBag.Department = _RepoDepartment.GetAll();

            return View(NameView, EmployeeVM);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(EmployeeVm Model)
        {

            if (ModelState.IsValid)
            {
                
                var Employee = _Mapper.Map<Employee>(Model);
                _RepoEmployee.DeleteEntity(Employee);
                return RedirectToAction(nameof(Index));
            }
            ViewBag.Department = _RepoDepartment.GetAll();

            return View(Model);
        }

        #region Update
        [HttpGet]
        public IActionResult update(int id)
        {
            ViewBag.Department = _RepoDepartment.GetAll();

            return Delete(id, "Update");
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult update(EmployeeVm model)
        {
            if (ModelState.IsValid)
            {
                var EmployeeCreate = _Mapper.Map<EmployeeVm, Employee>(model);
                _RepoEmployee.UpdateEntity(EmployeeCreate);
                return RedirectToAction(nameof(Index));
            }
            ViewBag.Department = _RepoDepartment.GetAll();

            return View(model);
        } 
        #endregion



    }
}
