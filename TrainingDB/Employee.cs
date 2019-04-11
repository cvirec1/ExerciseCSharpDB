using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrainingDB
{
    public class Employee
    {
        public int BussinessEntityID { get; set; }
        public string NationallIDNumber { get; set; }
        public string LoginID { get; set; }
        //public string OrganizationNode { get; set; }
        public int OrgnizationLevel { get; set; }
        public string JobTitle { get; set; }
        public DateTime BirthDate { get; set; }
        public char MaritalStatus { get; set; }
        public char Gender { get; set; }
        public DateTime HireDate { get; set; }
        public bool SalariedFlag { get; set; }
        public int VacationHours { get; set; }
        public int SickLeaveHours { get; set; }
        public bool CurrentFlag { get; set; }
        public Guid RowGuid { get; set; }
        public DateTime ModifiedDate { get; set; }
    }
}
