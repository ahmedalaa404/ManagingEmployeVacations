﻿using System.ComponentModel.DataAnnotations.Schema;

namespace ManagingEmployeVacations_Dal.Entites
{
    public class RequestVacation:BaseEntity
    {
        public int EmployeeId { get; set; }
        public Employee? Employee { get; set; }



        public DateTime DateRequestVacation { get; set; }
        public DateTime StartDateVacations { get; set; }
        public DateTime EndDateVacations { get; set; }


        public VacationType? VacationType { get; set; }
        public int  VacationTypeId { get; set; }


        public bool Approved { get; set; }

        public DateTime? DateApproved { get; set; }



        public string Comment { get; set; }
        public List<VacationDatePlan> VacationDatePlan { get; set; } = new List<VacationDatePlan>();




    }
}