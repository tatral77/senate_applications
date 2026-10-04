using LegisDAL;
using LegisEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LegisBIZ
{
    public class MiscBiz
    {
        #region MEMBER
        //public List<MemberStatuses> GetMemberStatuses()
        //{
        //    return new AdministrationDAL().GetMemberStatuses();
        //}
        public List<Member> GetMembersByStatus(int StatusId)
        {
            return new MiscDal().GetMembersByStatus(StatusId);
        }
        public List<Member> GetMembersByName(string MemberName)
        {
            return new MiscDal().GetMemberByName(MemberName);
        }
        public List<Member> GetMemberMinisterByName(string MemberName)
        {
            return new MiscDal().GetMemberMinisterByName(MemberName);
        }
        public List<Member> GetAllMemberByName(string MemberName)
        {
            return new MiscDal().GetAllMemberByName(MemberName);
        }
        public List<Divisions> GetCurrentDivisionsByName(string DivisionName)
        {
            return new MiscDal().GetCurrentDivisionsByName(DivisionName);
        }
        #endregion MEMBER
    }
}
