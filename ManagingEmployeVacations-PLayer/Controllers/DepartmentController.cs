﻿using AutoMapper;
using ManagingEmployeVacations_Bl.Repositorey;
using ManagingEmployeVacations_Dal.Entites;
using ManagingEmployeVacations_Dal.InterFaces;
using ManagingEmployeVacations_PLayer.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace ManagingEmployeVacations_PLayer.Controllers
{
    public class DepartmentController : Controller
    {
        private readonly IRepository<Department> _RepoDepartment;
        private readonly IMapper _Mapper;

        public DepartmentController(IRepository<Department> _RepoDepartment, IMapper map)
        {
            this._RepoDepartment = _RepoDepartment;
            _Mapper = map;
        }
        public IActionResult Index()
        {
            var Data = _RepoDepartment.GetAll().ToList();
            var DataVM = _Mapper.Map<IEnumerable<DepartmentVm>>(Data);
            return View(DataVM);
        }


        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(DepartmentVm model)
        {
            if (ModelState.IsValid)
            {
                var DepartmentCreate = _Mapper.Map<DepartmentVm, Department>(model);
                _RepoDepartment.Create(DepartmentCreate);
                return RedirectToAction(nameof(Index));
            }
            return View(model);

        }



        [HttpGet]
        public IActionResult Delete(int id, string NameView="Delete")
        {
   
                var Department = _RepoDepartment.GetById(id);
            var DepartmentVM=_Mapper.Map<DepartmentVm>(Department);

            return View(NameView, DepartmentVM);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(DepartmentVm Model)
        {

            if (ModelState.IsValid)
            {
                
                var Department = _Mapper.Map<Department>(Model);
                _RepoDepartment.DeleteEntity(Department);
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
        public IActionResult update(DepartmentVm model)
        {
            if (ModelState.IsValid)
            {
                var DepartmentCreate = _Mapper.Map<DepartmentVm, Department>(model);
                _RepoDepartment.UpdateEntity(DepartmentCreate);
                return RedirectToAction(nameof(Index));
            }
            return View(model);
        } 
        #endregion



    }
}
