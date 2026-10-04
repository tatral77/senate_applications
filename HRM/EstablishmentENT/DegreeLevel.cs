using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EstablishmentENT
{
    public class DegreeLevel
    {
        int degree_Level_Id;

        public int Degree_Level_Id
        {
            get { return degree_Level_Id; }
            set { degree_Level_Id = value; }
        }
        string degree_Level;

        public string Degree_Level
        {
            get { return degree_Level; }
            set { degree_Level = value; }
        }
        int is_Active;

        public int Is_Active
        {
            get { return is_Active; }
            set { is_Active = value; }
        }
    }
}
