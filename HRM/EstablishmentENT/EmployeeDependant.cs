using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EstablishmentENT
{
    public class EmployeeDependant
    {
        public int EmpDependantId { get; set; }
        public int SystemUersId { get; set; }
        public string DependantName { get; set; }
        public int RelationshipId { get; set; }
        public string RelationshipName { get; set; }
        public string Gender { get; set; }
        public DateTime DOB { get; set; }
        public int AgeYears { get; set; }
        public int AgeMonths { get; set; }
        public int MaritalStatusId { get; set; }
        public string MaritalStatus { get; set; }
        public int IsDependant { get; set; }

    }
}
