using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EstablishmentENT
{
    public class EducationLevel
    {
        int educationLevelId;

        public int EducationLevelId
        {
            get { return educationLevelId; }
            set { educationLevelId = value; }
        }
        string education_Level;

        public string Education_Level
        {
            get { return education_Level; }
            set { education_Level = value; }
        }
        int is_Active;

        public int Is_Active
        {
            get { return is_Active; }
            set { is_Active = value; }
        }
    }
}
