﻿using ManagingEmployeVacations_Dal.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagingEmployeVacations_Dal.InterFaces
{
    public interface IGetById<T> where T : BaseEntity
    {

        public T? GetById(int id);
    }
}
