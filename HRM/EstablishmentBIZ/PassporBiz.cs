using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EstablishmentDAL;
using EstablishmentENT;

namespace EstablishmentBIZ
{
    public class PassporBiz

    {
        public List<PassportTypes> GetPassportTypes()
        {
            return new PassportDAL().GetPassportTypes();

        }
        public PassportTypes GetPassportType(int PassportTypeId)
        {
            return new PassportDAL().GetPassportType(PassportTypeId);
        }
    }
}
