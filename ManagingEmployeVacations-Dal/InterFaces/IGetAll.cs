using ManagingEmployeVacations_Dal.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagingEmployeVacations_Dal.InterFaces
{
    public interface IGetAll<T> where T : BaseEntity
    {

        public IEnumerable<T?> GetAll();

    }
}
