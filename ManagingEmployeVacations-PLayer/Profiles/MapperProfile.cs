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
        }

    }
}
