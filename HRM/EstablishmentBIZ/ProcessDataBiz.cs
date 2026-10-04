using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EstablishmentDAL;

namespace EstablishmentBIZ
{
    public class ProcessDataBiz
    {
        public void ProcessRetirement()
        {
            new ProcessDataDAL().ProcessRetirement();
        }
    }
}
