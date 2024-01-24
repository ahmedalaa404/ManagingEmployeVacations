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
    public class Repositorey<t> : IRepository<t> where t : BaseEntity
    {
        private readonly VacationContext _Context;

        public Repositorey(VacationContext context)
        {
            _Context = context;
        }

        public void DeleteEntity(t entity)
        {
            _Context.Set<t>().Remove(entity);
            _Context.SaveChanges();
        }

        public IEnumerable<t?> GetAll()
        {
            var AllData = _Context.Set<t>().ToList();

            if (AllData is null)
                return null;

            return AllData;
        }

        public t? GetById(int id)
        {
            return _Context.Set<t>().FirstOrDefault(x => x.Id == id);
        }

        public void UpdateEntity(t entity)
        {
            _Context.Set<t>().Update(entity);
            _Context.SaveChanges();
        }
    }
}
