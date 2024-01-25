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
    public class RepoVacationPlan : IVacationPlan
    {
        private readonly VacationContext context;

        public RepoVacationPlan(VacationContext Context)
        {
            context = Context;
        }

        public bool CheckExist(VacationDatePlan entity)
        {
            #region Check If Here Before Or Not 
            var Resulte = context.VacationsDatePlan
              .Where(x =>x.VacationRequest.EmployeeId == entity.VacationRequest.EmployeeId
              && x.VacationDate >= entity.VacationRequest.StartDateVacations
              && x.VacationDate <= entity.VacationRequest.EndDateVacations).FirstOrDefault();
            #endregion
            if (Resulte is not null)
                return false;

            else
            {
                return true;
            }
        }

        public int Create(VacationDatePlan entity)
        {

            context.VacationsDatePlan.Add(entity);
            return context.SaveChanges();
        }
    }
}
