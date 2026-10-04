using Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuestionDAL
{
    public class QuestionDal
    {

        #region  QUESTION_CATEGORY
        
        public List<QuestionCategories> GetQuestionCategories()
        {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[Question_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "GET_QUESTION_CATOGORIES";
                cmd.CommandType = CommandType.StoredProcedure;
                List<QuestionCategories> MyList = null;
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    MyList = new List<QuestionCategories>();
                    while (dr.Read())
                    {
                        QuestionCategories Temp = new QuestionCategories();

                        Temp.QuestionCategoriesId = Convert.ToInt32(dr["QUESTION_CATEGORIES_ID"]);
                        Temp.Description = Convert.ToString(dr["Description"]);
                        Temp.IsActive = Convert.ToInt32(dr["Is_Active"]);
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
        public void UpdateQuestionCategory(QuestionCategories Temp)
        {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[Question_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "UPDATE_QUESTION_CATOGORY";
                cmd.Parameters.Add("@QuestionCategoriesId", SqlDbType.Int).Value = Temp.QuestionCategoriesId;
                cmd.Parameters.Add("@Description", SqlDbType.VarChar).Value = Temp.Description;
                cmd.Parameters.Add("@IsActive", SqlDbType.Int).Value =Temp.IsActive;
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
        public void InsertQuestionCategory(QuestionCategories Temp)
        {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[Question_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "INSERT_QUESTION_CATOGORY";
                cmd.Parameters.Add("@Description", SqlDbType.VarChar).Value = Temp.Description;
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
        #endregion QUESTION_CATEGORY

        //------------------------------------END----------------------------------------//

        //------------------------------------END-------------------------------------//

        #region  GroupDivisions

        public List<GroupDivisions> GetGroupDivisions( int AssemblySessionId)
        {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[Question_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "GET_GROUPS_DIVISIONS";
                cmd.Parameters.Add("@AssemblySessionsId", SqlDbType.Int).Value = AssemblySessionId;
                cmd.CommandType = CommandType.StoredProcedure;
                List<GroupDivisions> MyList = null;
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    MyList = new List<GroupDivisions>();
                    while (dr.Read())
                    {
                        GroupDivisions Temp = new GroupDivisions();

                        Temp.GroupDivisionsId = Convert.ToInt32(dr["Group_Divisions_Id"]);
                        Temp.GroupSequence= Convert.ToInt32(dr["GROUP_SEQUENCE"]);
                        Temp.Group = Convert.ToString(dr["GROUPDESC"]);
                        Temp.GroupsId = Convert.ToInt32(dr["Groups_Id"]);
                        Temp.DivisionsId= Convert.ToInt32(dr["Divisions_Id"]);
                        Temp.Division = Convert.ToString(dr["Division"]);
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
        //public void UpdateGroupDivision(GroupDivisions Temp)
        //{
        //    SqlConnection con = new DalHelper().GetConnection();
        //    try
        //    {
        //        SqlCommand cmd = new SqlCommand("[dbo].[Question_CRUD]", con);
        //        cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "UPDATE_GROUP_DIVISION";
        //        cmd.Parameters.Add("@GroupsId", SqlDbType.Int).Value = Temp.GroupsId;
        //        cmd.Parameters.Add("@DivisionsId", SqlDbType.Int).Value = Temp.DivisionsId;
        //        cmd.CommandType = CommandType.StoredProcedure;
        //        cmd.ExecuteNonQuery();
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //    finally
        //    {
        //        con.Close();

        //    }
        //}
        public void InsertGroupDivisions(GroupDivisions Temp)
        {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[Question_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "INSERT_GROUP_DIVISION";
                cmd.Parameters.Add("@GroupsId", SqlDbType.VarChar).Value = Temp.GroupsId;
                cmd.Parameters.Add("@DivisionId", SqlDbType.VarChar).Value = Temp.DivisionsId;
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

        public void DeleteGroupDivisions(int GroupsId,int DivisionId)
        {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[Question_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "DELETE_GROUP_DIVISION";
                cmd.Parameters.Add("@GroupsId", SqlDbType.Int).Value = GroupsId;
                cmd.Parameters.Add("@DivisionsId", SqlDbType.Int).Value = DivisionId;
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

        #endregion Divisions

        //------------------------------------END-------------------------------------//

        #region  Groups

        public List<Groups> GetSessionGroups(int AssemplySessionsId)
        {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[Question_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "GET_SESSION_GROUPS";
                cmd.Parameters.Add("@AssebliesSessionId", SqlDbType.Int).Value = AssemplySessionsId;
                cmd.CommandType = CommandType.StoredProcedure;
                List<Groups> MyList = null;
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    MyList = new List<Groups>();
                    while (dr.Read())
                    {
                        Groups Temp = new Groups();

                        Temp.GroupsId = Convert.ToInt32(dr["Groups_Id"]);
                        Temp.Description = Convert.ToString(dr["Description"]);
                        Temp.IsActive = Convert.ToInt32(dr["Is_Active"]);
                        Temp.AssembliesSessionId = Convert.ToInt32(dr["Assembly_Sessions_Id"]);
                        //Temp.AssembliesSession = Convert.ToString(dr["Session_Number"]);
                        Temp.CorrespondingGroup = Convert.ToInt32(dr["Corresponding_Group"]);
                        Temp.GroupSequence = Convert.ToInt32(dr["Group_Sequence"]);
                        Temp.UnstarDesc = Convert.ToString(dr["Unstar_Desc"]);

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
        public List<Groups> GetSessionCorrespondingGroup(int AssemplySessionsId,int CorrespondingGroupId)
        {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[Question_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "GET_SESSION_CORRESPONDING_GROUPS";
                cmd.Parameters.Add("@AssebliesSessionId", SqlDbType.Int).Value = AssemplySessionsId;
                cmd.Parameters.Add("@CorrespondingGroupId", SqlDbType.Int).Value = CorrespondingGroupId;
                cmd.CommandType = CommandType.StoredProcedure;
                List<Groups> MyList = null;
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    MyList = new List<Groups>();
                    while (dr.Read())
                    {
                        Groups Temp = new Groups();

                        Temp.GroupsId = Convert.ToInt32(dr["Groups_Id"]);
                        Temp.Description = Convert.ToString(dr["Description"]);
                        Temp.IsActive = Convert.ToInt32(dr["Is_Active"]);
                        Temp.AssembliesSessionId = Convert.ToInt32(dr["Assembly_Sessions_Id"]);
                        //Temp.AssembliesSession = Convert.ToString(dr["Session_Number"]);
                        Temp.CorrespondingGroup = Convert.ToInt32(dr["Corresponding_Group"]);
                        Temp.GroupSequence = Convert.ToInt32(dr["Group_Sequence"]);
                        Temp.UnstarDesc = Convert.ToString(dr["Unstar_Desc"]);

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

        public void UpdateGroups(Groups Temp)
        {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[Question_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "UPDATE_GROUPS";
                cmd.Parameters.Add("@Descriptation", SqlDbType.VarChar).Value = Temp.Description;
                cmd.Parameters.Add("@IsActive", SqlDbType.Int).Value = Temp.IsActive;
                cmd.Parameters.Add("@AssemblySessionsId", SqlDbType.Int).Value = Temp.AssembliesSessionId;
                cmd.Parameters.Add("@CorrespondingGroup", SqlDbType.Int).Value = Temp.CorrespondingGroup;
                cmd.Parameters.Add("@GroupSequence", SqlDbType.Int).Value = Temp.GroupSequence;
                cmd.Parameters.Add("@UnstarDesc", SqlDbType.VarChar).Value = Temp.UnstarDesc;
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
        public void InsertGroups(Groups Temp)
        {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[Question_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "INSERT_GROUPS";
                cmd.Parameters.Add("@Descriptation", SqlDbType.VarChar).Value = Temp.Description;
                cmd.Parameters.Add("@IsActive", SqlDbType.Int).Value = Temp.IsActive;
                cmd.Parameters.Add("@AssemblySessionsId", SqlDbType.Int).Value = Temp.AssembliesSessionId;
                cmd.Parameters.Add("@CorrespondingGroup", SqlDbType.Int).Value = Temp.CorrespondingGroup;
                cmd.Parameters.Add("@GroupSequence", SqlDbType.Int).Value = Temp.GroupSequence;
                cmd.Parameters.Add("@UnstarDesc", SqlDbType.VarChar).Value = Temp.UnstarDesc;
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

        #endregion Groups

        //------------------------------------END-------------------------------------//

        #region  ParliamentaryPeriods

        public List<ParliamentaryPeriods> GetParliamentaryPeriods()
        {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[Question_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "GET_PARLIAMENTARY_PERIODS";
                cmd.CommandType = CommandType.StoredProcedure;
                List<ParliamentaryPeriods> MyList = null;
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    MyList = new List<ParliamentaryPeriods>();
                    while (dr.Read())
                    {
                        ParliamentaryPeriods Temp = new ParliamentaryPeriods();
                        Temp.ParliamentaryPeriodsId = Convert.ToInt32(dr["Parliamentary_Periods_Id"]);
                        Temp.Description = Convert.ToString(dr["Description"]);
                        Temp.FromDate = Convert.ToDateTime(dr["From_Date"]);
                        Temp.ToDate = Convert.ToDateTime(dr["To_Date"]);
                        Temp.IsActive = Convert.ToInt32(dr["Is_Active"]);
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
        public void UpdateParliamentaryPeriods(ParliamentaryPeriods Temp)
        {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[Question_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "UPDATE_PARLIAMENTARY_PERIOD";
                cmd.Parameters.Add("@Descriptation", SqlDbType.VarChar).Value = Temp.Description;
                cmd.Parameters.Add("@FromDate", SqlDbType.Date).Value = Temp.FromDate;
                cmd.Parameters.Add("@ToDate", SqlDbType.Date).Value = Temp.ToDate;
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
        public void InsertParliamentaryPeriods(ParliamentaryPeriods Temp)
        {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[Question_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "INSERT_PARLIAMENTARY_PERIODS";
                cmd.Parameters.Add("@Descriptation", SqlDbType.VarChar).Value = Temp.Description;
                cmd.Parameters.Add("@FromDate", SqlDbType.Date).Value = Temp.FromDate;
                cmd.Parameters.Add("@ToDate", SqlDbType.Date).Value = Temp.ToDate;
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

        #endregion ParliamentaryPeriods

        //------------------------------------END-------------------------------------//

        #region Assemblies
        public List<Assemblies> GetAssemblies()
        {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[Question_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "GET_ASSEMBLIES";
                cmd.CommandType = CommandType.StoredProcedure;
                List<Assemblies> MyList = null;
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    MyList = new List<Assemblies>();
                    while (dr.Read())
                    {
                        Assemblies Temp = new Assemblies();
                        Temp.AssembliesId = Convert.ToInt32(dr["Assemblies_Id"]);
                        Temp.Term = Convert.ToInt32(dr["Term"]);
                        Temp.FromDate = Convert.ToDateTime(dr["From_Date"]);
                        Temp.ToDate = Convert.ToDateTime(dr["To_Date"]);
                        Temp.NoOfSeats = Convert.ToInt32(dr["No_Of_Seats"]);
                        Temp.ElectionYear = Convert.ToInt32(dr["Election_Year"]);
                        Temp.IsActive = Convert.ToInt32(dr["Is_Active"]);
                        Temp.MaxStarredAllowed = Convert.ToInt32(dr["Max_Starred_Allowed"]);
                        Temp.MaxUnStarredAllowed = Convert.ToInt32(dr["Max_Un_Starred_Allowed"]);
                        Temp.MaxSNoticeAllowed = Convert.ToInt32(dr["Max_S_Notice_Allowed"]);
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
        public void UpdateAssemblies(Assemblies Temp)
        {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[Question_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "UPDATE_ASSEMBLY";
                cmd.Parameters.Add("@Term", SqlDbType.VarChar).Value = Temp.Term;
                cmd.Parameters.Add("@FromDate", SqlDbType.Date).Value = Temp.FromDate;
                cmd.Parameters.Add("@ToDate", SqlDbType.Date).Value = Temp.ToDate;
                cmd.Parameters.Add("@NoOfSeats", SqlDbType.Date).Value = Temp.NoOfSeats;
                cmd.Parameters.Add("@ElectionYear", SqlDbType.Date).Value = Temp.ElectionYear;
                cmd.Parameters.Add("@MaxStarredAllowed", SqlDbType.Int).Value = Temp.MaxStarredAllowed;
                cmd.Parameters.Add("@MaxUnStarredAllowed", SqlDbType.Int).Value = Temp.MaxUnStarredAllowed;
                cmd.Parameters.Add("@MaxSNoticeAllowed", SqlDbType.Int).Value = Temp.MaxSNoticeAllowed;
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
        public void InsertAssemblies(Assemblies Temp)
        {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[Question_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "INSERT_ASSEMBLY";
                cmd.Parameters.Add("@Term", SqlDbType.VarChar).Value = Temp.Term;
                cmd.Parameters.Add("@FromDate", SqlDbType.Date).Value = Temp.FromDate;
                cmd.Parameters.Add("@ToDate", SqlDbType.Date).Value = Temp.ToDate;
                cmd.Parameters.Add("@NoOfSeats", SqlDbType.Date).Value = Temp.NoOfSeats;
                cmd.Parameters.Add("@ElectionYear", SqlDbType.Date).Value = Temp.ElectionYear;
                cmd.Parameters.Add("@MaxStarredAllowed", SqlDbType.Int).Value = Temp.MaxStarredAllowed;
                cmd.Parameters.Add("@MaxUnStarredAllowed", SqlDbType.Int).Value = Temp.MaxUnStarredAllowed;
                cmd.Parameters.Add("@MaxSNoticeAllowed", SqlDbType.Int).Value = Temp.MaxSNoticeAllowed;
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

        #endregion Assemblies

        //------------------------------------END-------------------------------------//

        #region SittingTypes

        public List<SittingTypes> GetSittingTypes()
        {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[Question_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "GET_SITTING_TYPES";
                cmd.CommandType = CommandType.StoredProcedure;
                List<SittingTypes> MyList = null;
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    MyList = new List<SittingTypes>();
                    while (dr.Read())
                    {
                        SittingTypes Temp = new SittingTypes();
                        Temp.SittingTypesId = Convert.ToInt32(dr["Sitting_Types_Id"]);
                        Temp.Description = Convert.ToString(dr["Descriptation"]);
                        Temp.IsActive = Convert.ToInt32(dr["Is_Active"]);
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
        public void UpdateSittingTypes(SittingTypes Temp)
        {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[Question_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "UPDATE_SITTING_TYPE";
                cmd.Parameters.Add("@Descriptation", SqlDbType.VarChar).Value = Temp.Description;
                cmd.Parameters.Add("@IsActive", SqlDbType.Date).Value = Temp.IsActive;
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
        public void InsertSittingTypes(SittingTypes Temp)
        {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[Question_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "INSERT_SITTING_TYPE";
                cmd.Parameters.Add("@Descriptation", SqlDbType.VarChar).Value = Temp.Description;
                cmd.Parameters.Add("@IsActive", SqlDbType.Date).Value = Temp.IsActive;
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

        #endregion SittingTypes

        //------------------------------------END-------------------------------------//

        #region SessionSittings

        public List<SessionSittings> GetSessionSitting()
        {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[Question_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "GET_SESSION_SITTINGS";
                cmd.CommandType = CommandType.StoredProcedure;
                List<SessionSittings> MyList = null;
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    MyList = new List<SessionSittings>();
                    while (dr.Read())
                    {
                        SessionSittings Temp = new SessionSittings();
                        Temp.SessionSittingsId = Convert.ToInt32(dr["Session_Sittings_Id"]);
                        Temp.AssembliesSessionId = Convert.ToInt32(dr["Assembly_Sessions_Id"]);
                        Temp.AssemblySession = Convert.ToString(dr["Session_Number"]);
                        Temp.Sessiondate = Convert.ToDateTime(dr["Session_Date"]);
                        Temp.IsMorningSitting = Convert.ToInt32(dr["Is_Morning_Sittings"]);
                        Temp.StartTime = Convert.ToDateTime(dr["Start_Time"]);
                        Temp.EndTime = Convert.ToDateTime(dr["End_Time"]);
                        Temp.TotalTimeConsumed = Convert.ToDouble(dr["Total_Time_Consumed"]);
                        Temp.Remarks = Convert.ToString(dr["Session_Date"]);
                        Temp.SittingGernal = Convert.ToString(dr["Sitting_Gernal"]);
                        Temp.EvenStartTime = Convert.ToDateTime(dr["Even_Start_Time"]);
                        Temp.EvenEndTime = Convert.ToDateTime(dr["Even_End_Time"]);
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
        public void UpdateSessionSittings(SessionSittings Temp)
        {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[Question_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "UPDATE_SESSION_SITTING";
                cmd.Parameters.Add("@Session_Sittings_Id", SqlDbType.VarChar).Value = Temp.SessionSittingsId;
                cmd.Parameters.Add("@Assembly_Sessions_Id", SqlDbType.VarChar).Value = Temp.AssembliesSessionId;
                cmd.Parameters.Add("@Is_Morning_Sittings", SqlDbType.VarChar).Value = Temp.IsMorningSitting;
                cmd.Parameters.Add("@Session_Date", SqlDbType.Date).Value = Temp.Sessiondate;
                cmd.Parameters.Add("@Is_Morning_Sittings", SqlDbType.VarChar).Value = Temp.IsMorningSitting;
                cmd.Parameters.Add("@Start_Time", SqlDbType.DateTime).Value = Temp.StartTime;
                cmd.Parameters.Add("@End_Time", SqlDbType.Date).Value = Temp.EndTime;
                cmd.Parameters.Add("@Total_Time_Consumed", SqlDbType.VarChar).Value = Temp.TotalTimeConsumed;
                cmd.Parameters.Add("@Session_Date", SqlDbType.DateTime).Value = Temp.Sessiondate;
                cmd.Parameters.Add("@Sitting_Gernal", SqlDbType.VarChar).Value = Temp.SittingGernal;
                cmd.Parameters.Add("@Even_Start_Time", SqlDbType.Date).Value = Temp.EvenStartTime;
                cmd.Parameters.Add("@Even_End_Time", SqlDbType.Date).Value = Temp.EvenEndTime;
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
        public void InsertSessionSittings(SessionSittings Temp)
        {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[Question_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "INSERT_SESSION_SITTING";
                cmd.Parameters.Add("@Assembly_Sessions_Id", SqlDbType.VarChar).Value = Temp.AssembliesSessionId;
                cmd.Parameters.Add("@Is_Morning_Sittings", SqlDbType.VarChar).Value = Temp.IsMorningSitting;
                cmd.Parameters.Add("@Session_Date", SqlDbType.Date).Value = Temp.Sessiondate;
                cmd.Parameters.Add("@Is_Morning_Sittings", SqlDbType.VarChar).Value = Temp.IsMorningSitting;
                cmd.Parameters.Add("@Start_Time", SqlDbType.DateTime).Value = Temp.StartTime;
                cmd.Parameters.Add("@End_Time", SqlDbType.Date).Value = Temp.EndTime;
                cmd.Parameters.Add("@Total_Time_Consumed", SqlDbType.VarChar).Value = Temp.TotalTimeConsumed;
                cmd.Parameters.Add("@Session_Date", SqlDbType.DateTime).Value = Temp.Sessiondate;
                cmd.Parameters.Add("@Sitting_Gernal", SqlDbType.VarChar).Value = Temp.SittingGernal;
                cmd.Parameters.Add("@Even_Start_Time", SqlDbType.Date).Value = Temp.EvenStartTime;
                cmd.Parameters.Add("@Even_End_Time", SqlDbType.Date).Value = Temp.EvenEndTime;
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

        #endregion SessionSitting

        //------------------------------------END-------------------------------------//

        #region AssemblySessions

        public List<AssemblySessions> GetAssemblySessions()
        {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[Question_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "GET_ASSEMBLY_SESSIONS";
                cmd.CommandType = CommandType.StoredProcedure;
                List<AssemblySessions> MyList = null;
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    MyList = new List<AssemblySessions>();
                    while (dr.Read())
                    {
                        AssemblySessions Temp = new AssemblySessions();
                        Temp.AssemblySessionsId = Convert.ToInt32(dr["Assembly_Sessions_Id"]);
                       // Temp.CalledBy = Convert.ToInt32(dr["Called_By"]);
                        Temp.IsJointSession = Convert.ToInt32(dr["Is_Joint_Session"]);
                        Temp.SessionNumber = Convert.ToInt32(dr["Session_Number"]);
                        //Temp.StartDate = Convert.ToDateTime(dr["Start_Date"]);
                        //Temp.EndDate = Convert.ToDateTime(dr["End_Date"]);
                        //Temp.SittingTypeId = Convert.ToInt32(dr["Sitting_Type_Id"]);
                        Temp.IsActive = Convert.ToInt32(dr["Is_Active"]);
                        Temp.AssembliesId = Convert.ToInt32(dr["Assemblies_Id"]);
                        //Temp.SummonedBy = Convert.ToInt32(dr["Summoned_By"]);
                        //Temp.ProroguedBy = Convert.ToInt32(dr["Prorogued_By"]);
                        //Temp.LegislationDiaryNo = Convert.ToInt32(dr["Legislation_Diary_No"]);
                        //Temp.LegislationDiaryDate = Convert.ToDateTime(dr["Legislation_Diary_Date"]);
                        //Temp.SessStatusesId = Convert.ToInt32(dr["Sess_Statuses_Id"]);
                        //Temp.IsQuorumAdjourned = Convert.ToInt32(dr["IS_QUORUM_ADJOURNED"]);
                       // Temp.ParliamentaryYearsId = Convert.ToInt32(dr["Parliamentary_Years_Id"]);
                       // Temp.LegislationDiaryTime = Convert.ToDateTime(dr["Legislation_Diary_Time"]);
                        //Temp.NoticeDiaryNo = Convert.ToInt32(dr["Notice_Diary_No"]);
                        //Temp.NoticeDiaryDate = Convert.ToDateTime(dr["Notice_Diary_Date"]);
                        //Temp.NoticeDiaryTime = Convert.ToDateTime(dr["Notice_Diary_Time"]);
                        //Temp.FileNo = Convert.ToString(dr["File_No"]);
                        //Temp.RequisitionDate = Convert.ToDateTime(dr["Requisition_Date"]);
                        //Temp.RequisitionTime = Convert.ToDateTime(dr["Requisition_Time"]);
                        //Temp.TotalWorkingDays = Convert.ToInt32(dr["Total_Working_Days"]);
                        //Temp.ActualSittingDays = Convert.ToInt32(dr["Actual_Sitting_Days"]);
                        //Temp.SummonNoticeDate = Convert.ToDateTime(dr["Summon_Notice_Date"]);
                        //Temp.SummonNoticeTime = Convert.ToDateTime(dr["Summon_Notice_Time"]);
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
        public int GetCurrentAssemblySessions()
        {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[Question_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "GET_CURRENT_SESSION";
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader dr = cmd.ExecuteReader();
                int AssemblySessionsId=0;
                if (dr.HasRows)
                {
                    dr.Read();
                    AssemblySessionsId = Convert.ToInt32(dr["ASSEMBLY_SESSIONS_ID"]);

                }
                return AssemblySessionsId;
            }
            finally
            {
                con.Close();

            }
        }
        public void UpdateAssemblySessions(AssemblySessions Temp)
        {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[Question_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "UPDATE_ASSEMBLY_SESSION";
                cmd.Parameters.Add("@Assembly_Sessions_Id", SqlDbType.Int).Value = Temp.AssemblySessionsId;
                cmd.Parameters.Add("@Called_By", SqlDbType.Int).Value = Temp.CalledBy;
                cmd.Parameters.Add("@Is_Joint_Session", SqlDbType.Int).Value = Temp.IsJointSession;
                cmd.Parameters.Add("@Session_Number", SqlDbType.Int).Value = Temp.SessionNumber;
                cmd.Parameters.Add("@Start_Date", SqlDbType.Date).Value = Temp.StartDate;
                cmd.Parameters.Add("@End_Date", SqlDbType.Date).Value = Temp.EndDate ;
                cmd.Parameters.Add("@Sitting_Type_Id", SqlDbType.Int).Value = Temp.SittingTypeId;
                cmd.Parameters.Add("@Is_Active", SqlDbType.Int).Value = Temp.IsActive;
                cmd.Parameters.Add("@Assemblies_Id", SqlDbType.Int).Value = Temp.AssembliesId;
                cmd.Parameters.Add("@Summoned_By", SqlDbType.Int).Value = Temp.SummonedBy;
                cmd.Parameters.Add("@Prorogued_By", SqlDbType.Int).Value = Temp.ProroguedBy;
                cmd.Parameters.Add("@Legislation_Diary_No", SqlDbType.Int).Value = Temp.LegislationDiaryNo;
                cmd.Parameters.Add("@Legislation_Diary_Date", SqlDbType.Date).Value = Temp.LegislationDiaryDate;
                cmd.Parameters.Add("@Sess_Statuses_Id", SqlDbType.Int).Value = Temp.SessStatusesId;
                cmd.Parameters.Add("@Is_Quorum_Adjourned", SqlDbType.Int).Value = Temp.IsQuorumAdjourned;
                cmd.Parameters.Add("@Parliamentary_Years_Id", SqlDbType.Int).Value = Temp.ParliamentaryYearsId;
                cmd.Parameters.Add("@Legislation_Diary_Time", SqlDbType.Date).Value = Temp.LegislationDiaryTime;
                cmd.Parameters.Add("@Notice_Diary_No", SqlDbType.Int).Value = Temp.NoticeDiaryNo;
                cmd.Parameters.Add("@Notice_Diary_Date", SqlDbType.Date).Value = Temp.NoticeDiaryDate;
                cmd.Parameters.Add("@Notice_Diary_Time", SqlDbType.Date).Value = Temp.NoticeDiaryTime;
                cmd.Parameters.Add("@File_No", SqlDbType.VarChar).Value = Temp.FileNo;
                cmd.Parameters.Add("@Requisition_Date", SqlDbType.Date).Value = Temp.RequisitionDate;
                cmd.Parameters.Add("@Requisition_Time", SqlDbType.Date).Value = Temp.RequisitionTime;
                cmd.Parameters.Add("@Total_Working_Days", SqlDbType.Int).Value = Temp.TotalWorkingDays;
                cmd.Parameters.Add("@Actual_Sitting_Days", SqlDbType.Int).Value = Temp.ActualSittingDays;
                cmd.Parameters.Add("@Summon_Notice_Date", SqlDbType.Date).Value = Temp.SummonNoticeDate;
                cmd.Parameters.Add("@Summon_Notice_Time", SqlDbType.Date).Value = Temp.SummonNoticeTime;
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
        public void InsertAssemblySessions(AssemblySessions Temp)
        {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[Question_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "INSERT_ASSEMBLY_SESSION";
                cmd.Parameters.Add("@Assembly_Sessions_Id", SqlDbType.Int).Value = Temp.AssemblySessionsId;
                cmd.Parameters.Add("@Called_By", SqlDbType.Int).Value = Temp.CalledBy;
                cmd.Parameters.Add("@Is_Joint_Session", SqlDbType.Int).Value = Temp.IsJointSession;
                cmd.Parameters.Add("@Session_Number", SqlDbType.Int).Value = Temp.SessionNumber;
                cmd.Parameters.Add("@Start_Date", SqlDbType.Date).Value = Temp.StartDate;
                cmd.Parameters.Add("@End_Date", SqlDbType.Date).Value = Temp.EndDate;
                cmd.Parameters.Add("@Sitting_Type_Id", SqlDbType.Int).Value = Temp.SittingTypeId;
                cmd.Parameters.Add("@Is_Active", SqlDbType.Int).Value = Temp.IsActive;
                cmd.Parameters.Add("@Assemblies_Id", SqlDbType.Int).Value = Temp.AssembliesId;
                cmd.Parameters.Add("@Summoned_By", SqlDbType.Int).Value = Temp.SummonedBy;
                cmd.Parameters.Add("@Prorogued_By", SqlDbType.Int).Value = Temp.ProroguedBy;
                cmd.Parameters.Add("@Legislation_Diary_No", SqlDbType.Int).Value = Temp.LegislationDiaryNo;
                cmd.Parameters.Add("@Legislation_Diary_Date", SqlDbType.Date).Value = Temp.LegislationDiaryDate;
                cmd.Parameters.Add("@Sess_Statuses_Id", SqlDbType.Int).Value = Temp.SessStatusesId;
                cmd.Parameters.Add("@Is_Quorum_Adjourned", SqlDbType.Int).Value = Temp.IsQuorumAdjourned;
                cmd.Parameters.Add("@Parliamentary_Years_Id", SqlDbType.Int).Value = Temp.ParliamentaryYearsId;
                cmd.Parameters.Add("@Legislation_Diary_Time", SqlDbType.Date).Value = Temp.LegislationDiaryTime;
                cmd.Parameters.Add("@Notice_Diary_No", SqlDbType.Int).Value = Temp.NoticeDiaryNo;
                cmd.Parameters.Add("@Notice_Diary_Date", SqlDbType.Date).Value = Temp.NoticeDiaryDate;
                cmd.Parameters.Add("@Notice_Diary_Time", SqlDbType.Date).Value = Temp.NoticeDiaryTime;
                cmd.Parameters.Add("@File_No", SqlDbType.VarChar).Value = Temp.FileNo;
                cmd.Parameters.Add("@Requisition_Date", SqlDbType.Date).Value = Temp.RequisitionDate;
                cmd.Parameters.Add("@Requisition_Time", SqlDbType.Date).Value = Temp.RequisitionTime;
                cmd.Parameters.Add("@Total_Working_Days", SqlDbType.Int).Value = Temp.TotalWorkingDays;
                cmd.Parameters.Add("@Actual_Sitting_Days", SqlDbType.Int).Value = Temp.ActualSittingDays;
                cmd.Parameters.Add("@Summon_Notice_Date", SqlDbType.Date).Value = Temp.SummonNoticeDate;
                cmd.Parameters.Add("@Summon_Notice_Time", SqlDbType.Date).Value = Temp.SummonNoticeTime;
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

        #endregion AssemblySessions
        //------------------------------------END-------------------------------------//

        #region Questions
        public Questions GetQuestionById(int QuestionId)
        {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[Question_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "GET_QUESTION_BY_ID";
                cmd.Parameters.Add("@QuestionsId", SqlDbType.VarChar).Value = QuestionId;
                cmd.CommandType = CommandType.StoredProcedure;
                Questions Temp = new Questions();
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    dr.Read();
                    Temp.QuestionsId = Convert.ToInt32(dr["Questions_Id"]);
                    Temp.ParliamentaryYear = Convert.ToString(dr["Parliamentary_Year"]);
                    if (dr["Mover"] != DBNull.Value)
                    {
                        Temp.Mover = Convert.ToInt32(dr["Mover"]);
                        Temp.MoverName = Convert.ToString(dr["F_Name"]);
                    }
                    if (dr["QUESTION_CATEGORY"] != DBNull.Value)
                    {
                        Temp.QuestionCategoriesId = Convert.ToInt32(dr["QUESTION_CATEGORY"]);
                        Temp.QuestionCategory = Convert.ToString(dr["Category"]);
                    }
                    Temp.QuestionStatus = Convert.ToString(dr["Question_Status"]);

                    if (dr["Question_Date"] != DBNull.Value)
                        Temp.QuestionDate = Convert.ToDateTime(dr["Question_Date"]);
                    if (dr["Question_Time"] != DBNull.Value)
                        Temp.QuestionTime = Convert.ToDateTime(dr["Question_Time"]);
                    if (dr["Subject"] != DBNull.Value)
                    {
                        Temp.Subject = Convert.ToString(dr["Subject"]);
                        //if(Temp.Subject.Length>42)
                        //Temp.Subject = Temp.Subject.Substring(43);
                    }
                    Temp.QuestionText = Convert.ToString(dr["Question_Text"]);
                    Temp.Ministry = Convert.ToString(dr["Ministry"]);
                    Temp.MinistryGroup = Convert.ToString(dr["CORRESPONDING_GROUP"]);
                    Temp.Division = Convert.ToString(dr["Division"]);
                    // Temp.DepartmentsId = Convert.ToInt32(dr["Departments_Id"]);
                    // Temp.Department = Convert.ToString(dr["Deptt_Name"]);
                    if (dr["Notice_Diary_No"] != DBNull.Value)
                     Temp.NoticeDiaryNo = Convert.ToInt32(dr["Notice_Diary_No"]);
                    if (dr["Notice_Diary_Date"] != DBNull.Value)
                        Temp.NoticeDiaryDate = Convert.ToDateTime(dr["Notice_Diary_Date"]);
                    if (dr["Notice_Diary_Time"] != DBNull.Value)
                        Temp.NoticeDiaryTime = Convert.ToDateTime(dr["Notice_Diary_Time"]);
                    //Temp.AdmittedNumber = Convert.ToString(dr["Admitted_Number"]);
                    if (dr["Question_Diary_No"] != DBNull.Value)
                        Temp.QuestionDiaryNo = Convert.ToInt32(dr["Question_Diary_No"]);
                    //Temp.QuestionDiaryDate = Convert.ToDateTime(dr["Question_Diary_Date"]);

                    // Temp.QuestionDiaryTime = Convert.ToDateTime(dr["Question_Diary_Time"]);
                    Temp.SessionNumber = Convert.ToString(dr["SessionNumber"]);
                    if (dr["Session_Sittings_Id"] != DBNull.Value)
                        Temp.SessionSittingsId = Convert.ToInt32(dr["Session_Sittings_Id"]);
                   
                }
                return Temp;
            }
            finally
            {
                con.Close();

            }
        }

        public List<Questions> GetQuestions(int AssemblySessionsId)
        {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[Question_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "GET_QUESTIONS";
                cmd.Parameters.Add("@AssemblySessionsId", SqlDbType.VarChar).Value = AssemblySessionsId;
                cmd.CommandType = CommandType.StoredProcedure;
                List<Questions> MyList = null;
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    MyList = new List<Questions>();
                    while (dr.Read())
                    {
                        Questions Temp = new Questions();
                        Temp.QuestionsId = Convert.ToInt32(dr["Questions_Id"]);
                        Temp.ParliamentaryYear = Convert.ToString(dr["Parliamentary_Year"]);
                        if (dr["Mover"] != DBNull.Value)
                        {
                            Temp.Mover = Convert.ToInt32(dr["Mover"]);
                            Temp.MoverName = Convert.ToString(dr["F_Name"]);
                        }

                        Temp.QuestionCategory = Convert.ToString(dr["Category"]);
                        Temp.QuestionStatus= Convert.ToString(dr["Question_Status"]);

                        if (dr["Question_Date"] != DBNull.Value)
                            Temp.QuestionDate = Convert.ToDateTime(dr["Question_Date"]);
                        if (dr["Question_Time"] != DBNull.Value)
                            Temp.QuestionTime = Convert.ToDateTime(dr["Question_Time"]);
                        if (dr["Subject"] != DBNull.Value)
                        {
                            Temp.Subject = Convert.ToString(dr["Subject"]);
                            //if(Temp.Subject.Length>42)
                            //Temp.Subject = Temp.Subject.Substring(43);
                        }
                        Temp.QuestionText = Convert.ToString(dr["Question_Text"]);
                        Temp.Ministry = Convert.ToString(dr["Ministry"]);
                        Temp.MinistryGroup = Convert.ToString(dr["Ministry_Group"]);
                        Temp.Division = Convert.ToString(dr["Division"]);
                        // Temp.DepartmentsId = Convert.ToInt32(dr["Departments_Id"]);
                        // Temp.Department = Convert.ToString(dr["Deptt_Name"]);
                        //Temp.NoticeDiaryNo = Convert.ToInt32(dr["Notice_Diary_No"]);
                        //Temp.NoticeDiaryDate = Convert.ToDateTime(dr["Notice_Diary_Date"]);
                        //Temp.NoticeDiaryTime = Convert.ToDateTime(dr["Notice_Diary_Time"]);
                        //Temp.AdmittedNumber = Convert.ToString(dr["Admitted_Number"]);
                        if (dr["Question_Diary_No"] != DBNull.Value)
                            Temp.QuestionDiaryNo = Convert.ToInt32(dr["Question_Diary_No"]);
                        //Temp.QuestionDiaryDate = Convert.ToDateTime(dr["Question_Diary_Date"]);

                       // Temp.QuestionDiaryTime = Convert.ToDateTime(dr["Question_Diary_Time"]);
                        Temp.SessionNumber = Convert.ToString(dr["Session_Number"]);
                        if (dr["Session_Sittings_Id"] != DBNull.Value)
                            Temp.SessionSittingsId = Convert.ToInt32(dr["Session_Sittings_Id"]);
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
        public void UpdateQuestions(Questions Temp)
        {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[Question_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "UPDATE_QUESTIONS";
                cmd.Parameters.Add("@QuestionsId", SqlDbType.Int).Value = Temp.QuestionsId;
                cmd.Parameters.Add("@Parliamentary_Year", SqlDbType.VarChar).Value = Temp.ParliamentaryYear;
                cmd.Parameters.Add("@Mover", SqlDbType.Int).Value = Temp.Mover;
                cmd.Parameters.Add("@Question_Category", SqlDbType.VarChar).Value = Temp.QuestionCategory;
                cmd.Parameters.Add("@Question_Date", SqlDbType.Date).Value = Temp.QuestionDate;
                cmd.Parameters.Add("@Question_Time", SqlDbType.Date).Value = Temp.QuestionTime;
                cmd.Parameters.Add("@Subject", SqlDbType.VarChar).Value = Temp.Subject;
                cmd.Parameters.Add("@Question_Text", SqlDbType.Int).Value = Temp.QuestionText;
                cmd.Parameters.Add("@Ministry", SqlDbType.VarChar).Value = Temp.Ministry;
                cmd.Parameters.Add("@Ministry_Group", SqlDbType.VarChar).Value = Temp.MinistryGroup;
                cmd.Parameters.Add("@Division", SqlDbType.VarChar).Value = Temp.Division;
                cmd.Parameters.Add("@Departments_Id", SqlDbType.Int).Value = Temp.DepartmentsId;
                cmd.Parameters.Add("@Notice_Diary_No", SqlDbType.Int).Value = Temp.NoticeDiaryNo;
                cmd.Parameters.Add("@Notice_Diary_Date", SqlDbType.Date).Value = Temp.NoticeDiaryDate;
                cmd.Parameters.Add("@Notice_Diary_Time", SqlDbType.Date).Value = Temp.NoticeDiaryTime;
                cmd.Parameters.Add("@Admitted_Number", SqlDbType.Int).Value = Temp.AdmittedNumber;
                cmd.Parameters.Add("@Question_Diary_No", SqlDbType.Date).Value = Temp.QuestionDiaryNo;
                cmd.Parameters.Add("@Question_Diary_Time", SqlDbType.Date).Value = Temp.QuestionDiaryTime;
                cmd.Parameters.Add("@Session_Number", SqlDbType.Int).Value = Temp.SessionNumber;
                cmd.Parameters.Add("@Session_Sittings_Id", SqlDbType.Int).Value = Temp.SessionSittingsId;
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
        public void InsertQuestions(Questions Temp)
        {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[Question_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "INSERT_QUESTIONS";
               // cmd.Parameters.Add("@Parliamentary_Year", SqlDbType.VarChar).Value = Temp.ParliamentaryYear;
                cmd.Parameters.Add("@Mover", SqlDbType.Int).Value = Temp.Mover;
                cmd.Parameters.Add("@Question_Category", SqlDbType.VarChar).Value = Temp.QuestionCategory;
                cmd.Parameters.Add("@Question_Date", SqlDbType.Date).Value = Temp.QuestionDate;
                cmd.Parameters.Add("@Question_Time", SqlDbType.Date).Value = Temp.QuestionTime;
                cmd.Parameters.Add("@Subject", SqlDbType.VarChar).Value = Temp.Subject;
                cmd.Parameters.Add("@Question_Text", SqlDbType.Int).Value = Temp.QuestionText;
                cmd.Parameters.Add("@Ministry", SqlDbType.VarChar).Value = Temp.Ministry;
                cmd.Parameters.Add("@Ministry_Group", SqlDbType.VarChar).Value = Temp.MinistryGroup;
                cmd.Parameters.Add("@Division", SqlDbType.VarChar).Value = Temp.Division;
                //cmd.Parameters.Add("@Departments_Id", SqlDbType.Int).Value = Temp.DepartmentsId;
                cmd.Parameters.Add("@Notice_Diary_No", SqlDbType.Int).Value = Temp.NoticeDiaryNo;
                cmd.Parameters.Add("@Notice_Diary_Date", SqlDbType.Date).Value = Temp.NoticeDiaryDate;
                cmd.Parameters.Add("@Notice_Diary_Time", SqlDbType.Date).Value = Temp.NoticeDiaryTime;
                //cmd.Parameters.Add("@Admitted_Number", SqlDbType.Int).Value = Temp.AdmittedNumber;
                cmd.Parameters.Add("@Question_Diary_No", SqlDbType.Date).Value = Temp.QuestionDiaryNo;
                cmd.Parameters.Add("@Question_Diary_Time", SqlDbType.Date).Value = Temp.QuestionDiaryTime;
                cmd.Parameters.Add("@Session_Number", SqlDbType.Int).Value = Temp.SessionNumber;
                //cmd.Parameters.Add("@Session_Sittings_Id", SqlDbType.Int).Value = Temp.SessionSittingsId;
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

        #endregion Questions

        #region Utilities
        public AssemblySessions GetCurrentSession()
        {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[Question_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "GET_CURRENT_SESSION_DETAILS";
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader dr = cmd.ExecuteReader();
                AssemblySessions asseblysessions = new AssemblySessions();
                if (dr.HasRows)
                {
                    dr.Read();
                    asseblysessions.SessionNumber = Convert.ToInt32(dr["SESSION_NUMBER"]);
                    asseblysessions.AssembliesId = Convert.ToInt32(dr["ASSEMBLY_SESSIONS_ID"]);

                }
                return asseblysessions;
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
        public AssemblySessions GetPreviousSession()
        {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[Question_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "GET_PREVIOUS_SESSION";
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader dr = cmd.ExecuteReader();
                AssemblySessions asseblysessions = new AssemblySessions();
                if (dr.HasRows)
                {
                    dr.Read();
                    asseblysessions.SessionNumber = Convert.ToInt32(dr["SESSION_NUMBER"]);
                    asseblysessions.AssembliesId = Convert.ToInt32(dr["ASSEMBLY_SESSIONS_ID"]);

                }
                return asseblysessions;
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
        public void CopySessionGroups()
        {
            AssemblySessions PreviousSession = GetPreviousSession();
            AssemblySessions CurrentSession = GetCurrentSession();
            List<Groups> PreviousGroups = GetSessionGroups(PreviousSession.AssemblySessionsId);
            foreach(Groups obj in PreviousGroups)
            {
                obj.AssembliesSessionId = CurrentSession.AssemblySessionsId;
                InsertGroups(obj);
               // obj.
            }
            List<Groups> CurrentGroups= GetSessionGroups(CurrentSession.AssemblySessionsId);
            //CopyGroupDivisions(PreviousGroups, CurrentGroups);
            List<GroupDivisions> gds = GetGroupDivisions(PreviousSession.AssemblySessionsId);
            foreach(GroupDivisions gd in gds)
            {
              //  gd.
            }




        }
        public void CopyGroupDivisions(List<Groups> PreviousGroups,List<Groups> CurrentGroups)
        {

        }
        #endregion Utilities

    }
}
