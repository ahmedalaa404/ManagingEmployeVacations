using AutoMapper;
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
        private readonly IGetAll<RequestVacation> RequestRepo;
        private readonly IVacationPlan repoVacationPlan;

        public RequestVacationController(IMapper map , IGetAll<RequestVacation> requestRepo , IVacationPlan RepoVacationPlan)
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


    }
}
