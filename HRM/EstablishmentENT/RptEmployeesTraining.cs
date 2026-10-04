using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EstablishmentENT
{
    public class RptEmployeesTraining
    {
        public int SystemUsersId { get; set; }
        public int EmpId { get; set; }
        public string EmployeeName { get; set; }
        public string Post { get; set; }
        public string BPS { get; set; }
        public DateTime DateOfBirth { get; set; }
        public int Age { get; set; }
        public int AgeMonths { get; set; }
        public DateTime  GovtJoiningDate { get; set; }
        public int ServiceYears { get; set; }
        public int ServiceMonths { get; set; }
        public int ProbationStatus { get; set; }
        public DateTime DateOfPromotion { get; set; }
        public int PromotionYears { get; set; }
        public int PromotionMonths { get; set; }
        public int ServiceInGradeYears { get; set; }
        public int ServiceInGradeMonth { get; set; }
        public string TrainingsAttended { get; set; }
        public string TrainingInstitute { get; set; }
        public string TrainingField { get; set; }
        public string TrainingStation { get; set; }
        public DateTime FromDate { get; set; }
        public DateTime ToDate { get; set; }
        public string Remarks { get; set; }
    }
}
