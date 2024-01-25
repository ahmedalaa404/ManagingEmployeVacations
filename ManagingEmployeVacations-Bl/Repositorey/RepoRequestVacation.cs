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
    public class RepoRequestVacation:IGetAll<RequestVacation>
    {
        private readonly VacationContext _Context;

        public RepoRequestVacation(VacationContext Context)
        {
            _Context = Context;
        }





        public IEnumerable<RequestVacation> GetAll()
        {
            var AllRequest = _Context.RequestsVacation
              .Include(x => x.Employee)
              .Include(x => x.VacationType)
              .OrderBy(x => x.DateRequestVacation);
            return AllRequest;
        }




    }
}
