using ManagingEmployeVacations_Dal.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagingEmployeVacations_Dal.InterFaces
{
    public interface IRepository<t> : IGetAll<t>,IGetById<t>, Delete<t>,Update<t> where t : BaseEntity
    {



    }
}
