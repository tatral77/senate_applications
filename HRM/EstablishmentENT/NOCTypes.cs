using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EstablishmentENT
{
    public class NOCTypes
    {
        private int nocTypeId;

        public int NocTypeId
        {
            get { return nocTypeId; }
            set { nocTypeId = value; }
        }
        private string description;

        public string Description
        {
            get { return description; }
            set { description = value; }
        }
        private int isactive;

        public int Isactive
        {
            get { return isactive; }
            set { isactive = value; }
        }
    }
}
