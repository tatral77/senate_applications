using Entities;
using MotionDAL;
using MotionEntities;
using QuestionDAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MotionBIZ
{
    public class ResolutionBiz
    {
        public List<ResolutionEnt> GetResolutions(int AssemblySession)
        {
            return new ResolutionDal().GetResolutions(AssemblySession);
        }
        public List<ResolutionSubmittersEnt> GetResolutionSubmitters(int ResolutionsId)
        {
            return new ResolutionDal().GetResolutionSubmitters(ResolutionsId);
        }
        public List<ResolutionTypeEnt> GetResolutionTypes()
        {
            return new AdministrationDAL().GetResolutionTypes();
        }
        public List<ResolutionStatusesEnt> GetResolutionStatuses()
        {
            return new AdministrationDAL().GetResolutionStatuses();
        }
        public List<ResolutionEnt> SearchResolutions(string query)
        {
            return new ResolutionDal().SearchResolutions(query);
        }
    }
}
