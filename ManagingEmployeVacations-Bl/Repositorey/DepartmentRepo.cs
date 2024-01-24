using ManagingEmployeVacations_Dal.Context;
using ManagingEmployeVacations_Dal.Entites;
using ManagingEmployeVacations_Dal.InterFaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagingEmployeVacations_Bl.Repositorey
{
    public class DepartmentRepo: IRepository<Department>
    {
        private readonly VacationContext _Context;

        public DepartmentRepo(VacationContext context)
        {
            _Context = context;
        }

        public void DeleteEntity(Department entity)
        {
            _Context.Departments.Remove(entity);
            _Context.SaveChanges();
        }

        public IEnumerable<Department?> GetAll()
        {
            var AllData = _Context.Departments.ToList();

            if (AllData is  null)
                return null;

            return AllData;
        }

        public Department? GetById(int id)
        {
            return _Context.Departments.FirstOrDefault(x=>x.Id==id);
        }

        public void UpdateEntity(Department entity)
        {
            _Context.Departments.Update(entity);
            _Context.SaveChanges();
        }
    }
}
