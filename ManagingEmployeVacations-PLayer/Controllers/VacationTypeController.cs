using AutoMapper;
using ManagingEmployeVacations_Bl.Repositorey;
using ManagingEmployeVacations_Dal.Entites;
using ManagingEmployeVacations_Dal.InterFaces;
using ManagingEmployeVacations_PLayer.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace ManagingEmployeVacations_PLayer.Controllers
{
    public class VacationTypeController : Controller
    {
        private readonly IRepository<VacationType> _RepoVacationType;
        private readonly IMapper _Mapper;

        public VacationTypeController(IRepository<VacationType> _repoVacationType, IMapper map)
        {
            _RepoVacationType = _repoVacationType;
            _Mapper = map;
        }
        public IActionResult Index()
        {
            var Data = _RepoVacationType.GetAll().ToList();
            var DataVM = _Mapper.Map<IEnumerable<VacationTypeVm>>(Data);
            return View(DataVM);
        }


        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(VacationTypeVm model)
        {
            if (ModelState.IsValid)
            {
                var VacationCreate = _Mapper.Map<VacationTypeVm, VacationType>(model);
                _RepoVacationType.Create(VacationCreate);
                return RedirectToAction(nameof(Index));
            }
            return View(model);

        }



        [HttpGet]
        public IActionResult Delete(int id, string NameView="Delete")
        {
   
                var VacationType = _RepoVacationType.GetById(id);
            var VacationTypeVm=_Mapper.Map<VacationTypeVm>(VacationType);

            return View(NameView, VacationTypeVm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(VacationTypeVm Model)
        {

            if (ModelState.IsValid)
            {
                
                var VacationType = _Mapper.Map<VacationType>(Model);
                _RepoVacationType.DeleteEntity(VacationType);
                return RedirectToAction(nameof(Index));
            }
            return View(Model);
        }

        #region Update
        [HttpGet]
        public IActionResult update(int id)
        {
            return Delete(id, "Update");
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult update(VacationTypeVm model)
        {
            if (ModelState.IsValid)
            {
                var VacationTypeCreate = _Mapper.Map<VacationTypeVm, VacationType>(model);
                _RepoVacationType.UpdateEntity(VacationTypeCreate);
                return RedirectToAction(nameof(Index));
            }
            return View(model);
        } 
        #endregion



    }
}
