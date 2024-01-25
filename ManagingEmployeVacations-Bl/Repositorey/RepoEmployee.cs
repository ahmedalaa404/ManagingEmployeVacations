using ManagingEmployeVacations_Dal.Context;
using ManagingEmployeVacations_Dal.Entites;
using ManagingEmployeVacations_Dal.InterFaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagingEmployeVacations_Bl.Repositorey
{
    public class RepoEmployee: IRepository<Employee>
    {
        private readonly VacationContext _Context;

        public RepoEmployee(VacationContext context)
        {
            _Context = context;
        }

        public int Create(Employee entity)
        {
            _Context.Employees.Add(entity);
            return _Context.SaveChanges();
        }

        public void DeleteEntity(Employee entity)
        {
            _Context.Employees.Remove(entity);
            _Context.SaveChanges();
        }

        public IEnumerable<Employee> GetAll()
        {
            var AllData = _Context.Employees.Include(x=>x.Department).ToList();

            if (AllData is null)
                return null;

            return AllData;
        }

        public Employee? GetById(int id)
        {
            return _Context.Employees.FirstOrDefault(x => x.Id == id);
        }

        public void UpdateEntity(Employee entity)
        {
            _Context.Employees.Update(entity);
            _Context.SaveChanges();
        }
    }
}
