using AutoMapper;
using ManagingEmployeVacations_Dal.Entites;
using ManagingEmployeVacations_PLayer.ViewModel;

namespace ManagingEmployeVacations_PLayer.Profiles
{
    public class MapperProfile:Profile
    {
        public MapperProfile()
        {
            CreateMap<Department, DepartmentVm>().ReverseMap();
            CreateMap<Employee, EmployeeVm>().ReverseMap(); 
            CreateMap<VacationType, VacationTypeVm>().ReverseMap();
            CreateMap<RequestVacation, RequestVacationVm>().ReverseMap();
            CreateMap<VacationDatePlan, VacationDatePlanVm>().ReverseMap();
        }

    }
}
