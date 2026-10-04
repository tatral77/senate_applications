using CommitteesEntities;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LegisDAL;
using LegisEntities;

namespace LegisBIZ
{
    public class CommitteesBiz
    {
        #region Committees
        public List<Committees> GetCommitteesByParliamentaryTerm(int ParliamentaryTermId)
        {
            return new CommitteesDal().GetCommitteesByParliamentaryTerm(ParliamentaryTermId);
        }
        #endregion
        #region Parliamentary Period
        public ParliamentaryTerms GetActiveParliamentaryTerm()
        {
            return new CommitteesDal().GetActiveParliamentaryTerm();
        }
        public void UpdateCommittee(Committees Temp)
        {
            new CommitteesDal().UpdateCommittee(Temp);
        }
        public void InsrtCommittee(Committees Temp)
        {
            new CommitteesDal().InsrtCommittee(Temp);
        }
        #endregion
        #region Committee_Types
        public List<CommitteeTypes> GetCommitteesTypes()
        {
            return new CommitteesDal().GetCommitteesTypes();
        }
        #endregion
    }
}

