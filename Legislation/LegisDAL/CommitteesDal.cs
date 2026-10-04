using CommitteesEntities;
using LegisEntities;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LegisDAL
{
    public class CommitteesDal
    {
        #region Committees
        public List<Committees> GetCommitteesByParliamentaryTerm(int ParliamentaryTermId)
        {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[Committees_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "GET_TERM_COMMITTEES";
                cmd.Parameters.Add("@Parliamentary_Terms_Id", SqlDbType.Int).Value = ParliamentaryTermId;
                cmd.CommandType = CommandType.StoredProcedure;
                List<Committees> MyList = null;
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    MyList = new List<Committees>();
                    while (dr.Read())
                    {
                        Committees Temp = new Committees();
                        Temp.CommitteesId = Convert.ToInt32(dr["COMMITTEES_ID"]);
                        Temp.CommitteeName = Convert.ToString(dr["COMMITTEE_NAME"]);
                        if(dr["FORMATION_DATE"]!=DBNull.Value)
                        Temp.FormationDate = Convert.ToDateTime(dr["FORMATION_DATE"]);
                        Temp.CommitteeTypeId = Convert.ToInt32(dr["COMMITTEE_TYPES_ID"]);
                        Temp.CommitteeType = Convert.ToString(dr["COMMITTEE_TYPE"]);
                        Temp.ParliamentaryTermId= Convert.ToInt32(dr["PARLIAMENTARY_TERMS_ID"]);
                        Temp.ParliamentaryTerm = Convert.ToString(dr["PARLIAMENTARY_TERM"]);
                        Temp.IsActive = Convert.ToInt32(dr["IS_ACTIVE"]);
                        MyList.Add(Temp);
                    }
                }

                if (MyList != null) MyList.TrimExcess();
                return MyList;
            }
            finally
            {
                con.Close();

            }
        }
        public void UpdateCommittee(Committees Temp)
        {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[Committees_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "UPDATE_COMMITTEE";
                cmd.Parameters.Add("@Id", SqlDbType.Int).Value = Temp.CommitteesId;
                cmd.Parameters.Add("@Committee_Name", SqlDbType.VarChar).Value = Temp.CommitteeName;
                cmd.Parameters.Add("@Committee_Types_Id", SqlDbType.Int).Value = Temp.CommitteeTypeId;
                cmd.Parameters.Add("@Parliamentary_terms_Id", SqlDbType.Int).Value = Temp.ParliamentaryTermId;
                cmd.Parameters.Add("@Formation_Date", SqlDbType.Date).Value = Temp.FormationDate;
                cmd.Parameters.Add("@IsActive", SqlDbType.Int).Value = Temp.IsActive;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                con.Close();

            }
        }
        public void InsrtCommittee(Committees Temp)
        {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[Committees_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "INSERT_COMMITTEE";
                cmd.Parameters.Add("@Committee_Name", SqlDbType.VarChar).Value = Temp.CommitteeName;
                cmd.Parameters.Add("@Committee_Types_Id", SqlDbType.Int).Value = Temp.CommitteeTypeId;
                cmd.Parameters.Add("@Parliamentary_terms_Id", SqlDbType.Int).Value = Temp.ParliamentaryTermId;
                cmd.Parameters.Add("@Formation_Date", SqlDbType.Date).Value = Temp.FormationDate;
                cmd.Parameters.Add("@IsActive", SqlDbType.Int).Value = Temp.IsActive;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                con.Close();

            }
        }
        #endregion
        #region Parliamentary Period
        public ParliamentaryTerms GetActiveParliamentaryTerm()
        {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[Administrations_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "GET_PARLIAMENTARY_TERMS";
                cmd.CommandType = CommandType.StoredProcedure;
                //  List<ParliamentaryTerms> MyList = null;
                ParliamentaryTerms Temp = null;
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    dr.Read();
                    //MyList = new List<ParliamentaryTerms>();
                    //while (dr.Read())
                    //{
                    Temp = new ParliamentaryTerms();
                    Temp.ParliamentaryTermsId = Convert.ToInt32(dr["PARLIAMENTARY_TERMS_ID"]);
                    Temp.Description = Convert.ToString(dr["DESCRIPTION"]);
                    Temp.FromDate = Convert.ToDateTime(dr["From_Date"]);
                    Temp.ToDate = Convert.ToDateTime(dr["To_Date"]);
                    Temp.IsActive = Convert.ToInt32(dr["Is_Active"]);
                    // }
                }


                return Temp;
            }
            finally
            {
                con.Close();

            }
        }
        #endregion
        #region Committee_Types
        public List<CommitteeTypes> GetCommitteesTypes()
        {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[Committees_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "GET_ACTIVE_COMMITTEE_TYPES";
                cmd.CommandType = CommandType.StoredProcedure;
                List<CommitteeTypes> MyList = null;
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    MyList = new List<CommitteeTypes>();
                    while (dr.Read())
                    {
                        CommitteeTypes Temp = new CommitteeTypes();
                        Temp.CommitteeTypeId = Convert.ToInt32(dr["COMMITTEE_TYPES_ID"]);
                        Temp.CommitteeType = Convert.ToString(dr["DESCRIPTION"]);
                        Temp.IsActive = Convert.ToInt32(dr["IS_ACTIVE"]);
                        MyList.Add(Temp);
                    }
                }

                if (MyList != null) MyList.TrimExcess();
                return MyList;
            }
            finally
            {
                con.Close();

            }
        }
        #endregion
    }
}
