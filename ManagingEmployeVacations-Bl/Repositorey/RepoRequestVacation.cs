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
    public class RepoRequestVacation: IRequestRepo
    {
        private readonly VacationContext _Context;

        public RepoRequestVacation(VacationContext Context)
        {
            _Context = Context;
        }

        public void DeleteEntity(RequestVacation entity)
        {
            _Context.RequestsVacation.Remove(entity);
            _Context.SaveChanges(); 
        }

        public IEnumerable<RequestVacation> GetAll()
        {
            var AllRequest = _Context.RequestsVacation
              .Include(x => x.Employee)
              .Include(x => x.VacationType)
              .OrderBy(x => x.DateRequestVacation);
            return AllRequest;
        }

        public RequestVacation? GetById(int id)
        {
          return _Context.RequestsVacation.Include(x => x.Employee)
              .Include(x => x.VacationType).Where(x=>x.Id==id).FirstOrDefault();
        }

        public void UpdateEntity(RequestVacation entity)
        {
            _Context.RequestsVacation.Update(entity);
          var x=  _Context.SaveChanges();
        }
    }
}
