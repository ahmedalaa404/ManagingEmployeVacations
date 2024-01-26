using AutoMapper;
using ManagingEmployeVacations_Bl.Repositorey;
using ManagingEmployeVacations_Dal.Entites;
using ManagingEmployeVacations_Dal.InterFaces;
using ManagingEmployeVacations_PLayer.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ManagingEmployeVacations_PLayer.Controllers
{
    public class RequestVacationController : Controller
    {
        private readonly IMapper Map;
        private readonly IRepository<RequestVacation> RequestRepo;
        private readonly IVacationPlan repoVacationPlan;

        public RequestVacationController(IMapper map , IRepository<RequestVacation> requestRepo , IVacationPlan RepoVacationPlan)
        {
            Map = map;
            RequestRepo = requestRepo;
            repoVacationPlan = RepoVacationPlan;
        }

        public IActionResult Index()
        {
            var Data= RequestRepo.GetAll();
            var DataVm = Map.Map<IEnumerable<RequestVacationVm>>(Data);
            return View(DataVm);
        }

        [HttpGet]
        public IActionResult Create() 
        {
            return View();
        }

        public IActionResult Create(VacationDatePlanVm model, int[] DayOfWeekCheckbox)
        {
         
            var PlanWithoutVm = Map.Map<VacationDatePlan>(model);

            if (ModelState.IsValid)
            {
                 var Resulte =repoVacationPlan.CheckExist(PlanWithoutVm);
                if(Resulte is false )
                {
                    ViewBag.ExistBefore = true;
                    return View(model);
                }
      
        

                //if()

                for (DateTime date = PlanWithoutVm.VacationRequest.StartDateVacations;
                    date <= PlanWithoutVm.VacationRequest.EndDateVacations; date = date.AddDays(1))
                {
                    if (Array.IndexOf(DayOfWeekCheckbox, (int)date.DayOfWeek) != -1)
                    {
                        //PlanWithoutVm.VacationRequest.Id = 0;
                        PlanWithoutVm.Id = 0;
                        PlanWithoutVm.VacationDate = date;
                        PlanWithoutVm.VacationRequest.DateRequestVacation = DateTime.Now;
                        repoVacationPlan.Create(PlanWithoutVm);
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(model);
        }


        [HttpGet]
        public IActionResult Update(int? id,string ViewName="Update")
        {
          var RequestVacation=  RequestRepo.GetById(id.Value);
            var RVacationVm = Map.Map<RequestVacationVm>(RequestVacation);
            return View(ViewName, RVacationVm);

        }


        [HttpPost]
        public IActionResult Update(RequestVacationVm ModelVm)
        {
            if(ModelState.IsValid)
            {
                if (ModelVm.Approved == true)
                    ModelVm.DateApproved = DateTime.Now;
                else
                    ModelVm.DateApproved = null;

                var Model = Map.Map<RequestVacation>(ModelVm);
                RequestRepo.UpdateEntity(Model);
                    return RedirectToAction(nameof(Index));
                
            }
            return View(ModelVm);
        }



        [HttpGet]
        public IActionResult Delete(int? id)
        {
            return Update(id,"Delete");

        }


        [HttpPost]
        public IActionResult Delete(RequestVacationVm ModelVm)
        {
            if (ModelState.IsValid)
            {
                var Model = Map.Map<RequestVacation>(ModelVm);
                RequestRepo.DeleteEntity(Model);
                return RedirectToAction(nameof(Index));
            }
            return View(ModelVm);
        }






    }
}
