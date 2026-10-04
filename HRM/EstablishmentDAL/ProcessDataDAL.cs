using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EstablishmentENT;

namespace EstablishmentDAL
{
    public class ProcessDataDAL
    {
        public void ProcessRetirement()
        {
            List<EmpRetirement> empRetirement = new EmploymentDAL().GetRetirements();
            int processed = 0;
            if(empRetirement!=null)
            {
                foreach(EmpRetirement er in empRetirement)
                {
                    if (er.RetirementDate < DateTime.Now)
                    {
                        new EmploymentDAL().UpdateRetirementInEmployment(er.SystemUserId, er.RetirementDate);
                        processed++;
                    }
                }
            }
            // one summary entry for the whole run instead of one per employee
            if (processed > 0)
                AuditLogger.Log("SYSTEM_PROCESS_RETIREMENT", "EMP_EMPLOYMENTS", null, null, null, "{\"employeesProcessed\":\"" + processed + "\"}");
        }

    }
   
}
