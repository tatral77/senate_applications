using LegisEntities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LegisDAL
{
    public class NoticeDal
    {
		#region BILLS
		public List<Bills> GetNoticeBills()
		{
			SqlConnection con = new DalHelper().GetConnection();
			try
			{

				SqlCommand cmd = new SqlCommand("[dbo].[NOTICE_CRUD]", con);
				cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "GET_NOTICE_BILLS";
				//cmd.Parameters.Add("@AssemblySessionId", SqlDbType.Int).Value = SessionId;
				cmd.CommandType = CommandType.StoredProcedure;
				List<Bills> MyList = null;
				SqlDataReader dr = cmd.ExecuteReader();
				if (dr.HasRows)
				{
					MyList = new List<Bills>();
					while (dr.Read())
					{
						Bills Temp = new Bills();
						Temp.BillsId = Convert.ToInt32(dr["BILLS_ID"]);
						Temp.HouseTypes = new LegisEntities.HouseTypes();
						Temp.HouseTypesId = Convert.ToInt32(dr["HOUSE_TYPES_ID"]);
						Temp.HouseTypes.Description = Convert.ToString(dr["HOUSE_TYPE"]);
						Temp.BillCategories = new BillCategories();
						Temp.BillCategoriesId = Convert.ToInt32(dr["BILL_CATEGORIES_ID"]);
						Temp.HouseTypes.Description = Convert.ToString(dr["BILL_CATEGORY"]);
						if (dr["NOTICE_DIARY_DATE"] != DBNull.Value)
							Temp.NoticeDiaryDate = Convert.ToDateTime(dr["NOTICE_DIARY_DATE"]);
						if (dr["BILL_TITLE"] != DBNull.Value)
							Temp.BillTitle = Convert.ToString(dr["BILL_TITLE"]);
						if (dr["SUBJECT"] != DBNull.Value)
							Temp.Subject = Convert.ToString(dr["SUBJECT"]);
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
        #region BILL_CATEGORIES
        public List<BillCategories> GetBillCategories()
        {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {

                SqlCommand cmd = new SqlCommand("[dbo].[LEGISLATION_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "GET_BILL_CATEGORIES";
                cmd.CommandType = CommandType.StoredProcedure;

                SqlDataReader dr = cmd.ExecuteReader();
                List<BillCategories> BillCategories = null;

                if (dr.HasRows)
                {
                    BillCategories = new List<BillCategories>();
                    while (dr.Read())
                    {
                        BillCategories Temp = new BillCategories();
                        Temp.BillCategoriesId = Convert.ToInt32(dr["BILL_CATEGORIES_ID"]);

                        Temp.IsActive = Convert.ToInt32(dr["IS_ACTIVE"]);
                        Temp.Description = Convert.ToString(dr["DESCRIPTION"]);


                        BillCategories.Add(Temp);
                    }
                }
                return BillCategories;
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
        public List<BillCategories> GetAllBillCategories()
        {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {

                SqlCommand cmd = new SqlCommand("[dbo].[LEGISLATION_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "GET_ALL_BILL_CATEGORIES";
                cmd.CommandType = CommandType.StoredProcedure;

                SqlDataReader dr = cmd.ExecuteReader();
                List<BillCategories> BillCategories = null;

                if (dr.HasRows)
                {
                    BillCategories = new List<BillCategories>();
                    while (dr.Read())
                    {
                        BillCategories Temp = new BillCategories();
                        Temp.BillCategoriesId = Convert.ToInt32(dr["BILL_CATEGORIES_ID"]);

                        Temp.IsActive = Convert.ToInt32(dr["IS_ACTIVE"]);
                        Temp.Description = Convert.ToString(dr["DESCRIPTION"]);


                        BillCategories.Add(Temp);
                    }
                }
                return BillCategories;
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
        public void UpdateBillCategory(BillCategories billCategory)
        {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {

                SqlCommand cmd = new SqlCommand("[dbo].[LEGISLATION_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "UPDATE_BILL_CATEGORY";
                cmd.Parameters.Add("@BillCategoriesId", SqlDbType.Int).Value = billCategory.BillCategoriesId;
                cmd.Parameters.Add("@Description", SqlDbType.VarChar).Value = billCategory.Description;
                cmd.Parameters.Add("@IsActive", SqlDbType.Int).Value = billCategory.IsActive;
                cmd.CommandType = CommandType.StoredProcedure;

                SqlDataReader dr = cmd.ExecuteReader();

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
        public void InsertBillCategory(BillCategories billCategory)
        {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {

                SqlCommand cmd = new SqlCommand("[dbo].[LEGISLATION_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "INSERT_BILL_CATEGORY";

                cmd.Parameters.Add("@Description", SqlDbType.VarChar).Value = billCategory.Description;
                cmd.Parameters.Add("@IsActive", SqlDbType.Int).Value = billCategory.IsActive;
                cmd.CommandType = CommandType.StoredProcedure;

                SqlDataReader dr = cmd.ExecuteReader();

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
        #endregion BILL_CATEGORIES
        #region BILL_TYPES
        public List<BillTypes> GetBillTypes()
        {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {

                SqlCommand cmd = new SqlCommand("[dbo].[LEGISLATION_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "GET_BILL_TYPES";
                cmd.CommandType = CommandType.StoredProcedure;

                SqlDataReader dr = cmd.ExecuteReader();
                List<BillTypes> BillTypes = null;

                if (dr.HasRows)
                {

                    BillTypes = new List<BillTypes>();
                    while (dr.Read())
                    {
                        BillTypes Temp = new BillTypes();
                        Temp.BillTypesId = Convert.ToInt32(dr["BILL_TYPES_ID"]);

                        Temp.IsActive = Convert.ToInt32(dr["IS_ACTIVE"]);
                        Temp.Description = Convert.ToString(dr["DESCRIPTION"]);


                        BillTypes.Add(Temp);
                    }
                }
                return BillTypes;
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
        #endregion BILL_TYPES
        #region BILLS
        public Bills GetBill(int BillsId)
        {
            SqlConnection con = new DalHelper().GetConnection();
            using (con)
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("[dbo].[NOTICE_CRUD]", con);
                    cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "GET_BILL";
                    cmd.Parameters.Add("@BillsId", SqlDbType.VarChar).Value = BillsId;
                    cmd.CommandType = CommandType.StoredProcedure;
                    Bills Temp = new Bills();
                    SqlDataReader dr = cmd.ExecuteReader();
                    if (dr.HasRows)
                    {

                        dr.Read();
                        Temp = BindNoticeFields(dr);
                    }
                    return Temp;
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

        }


        public List<Bills> GetBills(int parliamentaryYearsId)
        {
            SqlConnection con = new DalHelper().GetConnection();
            using (con)
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("[dbo].[NOTICE_CRUD]", con);
                    cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "GET_NOTICE_BILLS";
                    cmd.Parameters.Add("@ParliamentaryYearsId", SqlDbType.VarChar).Value = parliamentaryYearsId;
                    cmd.CommandType = CommandType.StoredProcedure;
                    SqlDataReader dr = cmd.ExecuteReader();
                    List<Bills> Bills = null;
                    if (dr.HasRows)
                    {
                        Bills = new List<Bills>();
                        while (dr.Read())
                        {
                            Bills Temp = BindNoticeFields(dr);
                            Bills.Add(Temp);
                        }

                    }
                    return Bills;
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
        }
        public List<Bills> GetBillsByStatus(int StatusId)
        {
            SqlConnection con = new DalHelper().GetConnection();
            using (con)
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("[dbo].[LEGISLATION_CRUD]", con);
                    cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "GET_BILLS_BY_STATUS";
                    cmd.Parameters.Add("@BillStatusId", SqlDbType.Int).Value = StatusId;
                    cmd.CommandType = CommandType.StoredProcedure;
                    SqlDataReader dr = cmd.ExecuteReader();
                    List<Bills> Bills = null;
                    if (dr.HasRows)
                    {
                        Bills = new List<Bills>();
                        while (dr.Read())
                        {
                            Bills Temp = BindFields(dr);
                            Bills.Add(Temp);
                        }

                    }
                    return Bills;
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
        }

        public List<Bills> GetBillsByHouse(int ParliamentaryYearsId, int HouseTypesId)
        {
            SqlConnection con = new DalHelper().GetConnection();
            using (con)
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("[dbo].[LEGISLATION_CRUD]", con);
                    cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "GET_BILLS_BY_HOUSE";
                    cmd.Parameters.Add("@ParliamentaryYearsId", SqlDbType.VarChar).Value = ParliamentaryYearsId;
                    cmd.Parameters.Add("@HouseTypesId", SqlDbType.VarChar).Value = HouseTypesId;
                    cmd.CommandType = CommandType.StoredProcedure;
                    SqlDataReader dr = cmd.ExecuteReader();
                    List<Bills> Bills = null;
                    if (dr.HasRows)
                    {
                        Bills = new List<Bills>();
                        while (dr.Read())
                        {
                            Bills Temp = BindFields(dr);
                            Bills.Add(Temp);
                        }

                    }
                    return Bills;
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
        }

        public List<Bills> SearchBills(string query)
        {

            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                List<Bills> bills = null;
                SqlCommand cmd = new SqlCommand(query, con);
                SqlDataReader dr = cmd.ExecuteReader();
                using (con)
                {
                    if (dr.HasRows)
                    {
                        bills = new List<Bills>();
                        while (dr.Read())
                        {
                            Bills Temp = BindFields(dr);
                            bills.Add(Temp);
                        }
                    }

                }
                return bills;
            }
            finally
            {
                con.Close();
            }

        }

        #region Senate Bills
        public void InsertBill(Bills bill)
        {
            SqlConnection con = new DalHelper().GetConnection();
            int BillId = new DalHelper().GetPk("BILLS", "BILLS_ID");

            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[NOTICE_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "INSERT_BILL";
                cmd.Parameters.Add("@BillsId", SqlDbType.Int).Value = BillId;
                cmd.Parameters.Add("@BillTypeId", SqlDbType.Int).Value = bill.BillTypeId;
                cmd.Parameters.Add("@BillStatusId", SqlDbType.Int).Value = bill.BillStatusId;
                cmd.Parameters.Add("@StatusDate", SqlDbType.DateTime).Value = bill.StatusDate;
                cmd.Parameters.Add("@BillCategoriesId", SqlDbType.Int).Value = bill.BillCategoryId;
                cmd.Parameters.Add("@BillStagesId", SqlDbType.Int).Value = bill.BillStagesId;
                cmd.Parameters.Add("@HouseTypesId", SqlDbType.Int).Value = bill.HouseTypesId;
                cmd.Parameters.Add("@Subject", SqlDbType.VarChar).Value = bill.Subject;
                cmd.Parameters.Add("@BillTitle", SqlDbType.VarChar).Value = bill.BillTitle;
                cmd.Parameters.Add("@ParliamentaryYearsId", SqlDbType.Int).Value = bill.ParliamentaryYearId;
                //cmd.Parameters.Add("@BillDate", SqlDbType.DateTime).Value = bill.BillDate;
                // cmd.Parameters.Add("@BillTime", SqlDbType.DateTime).Value = bill.BillTime;
                cmd.Parameters.Add("@AssemblySessionsId", SqlDbType.Int).Value = bill.AssemblySessionsId;
                //cmd.Parameters.Add("@NoticeDiaryNo", SqlDbType.VarChar).Value = bill.NoticeDiaryNo;
                cmd.Parameters.Add("@NoticeDiaryDate", SqlDbType.DateTime).Value = bill.NoticeDiaryDate;
                // cmd.Parameters.Add("@NoticeDiaryTime", SqlDbType.DateTime).Value = bill.NoticeDiaryTime;
                //cmd.Parameters.Add("@LegislationDiaryNo", SqlDbType.VarChar).Value = bill.LegislationDiaryNo;
                cmd.Parameters.Add("@LegislationDiaryDate", SqlDbType.DateTime).Value = DateTime.Now;
                //cmd.Parameters.Add("@LegislationDiaryTime", SqlDbType.DateTime).Value = bill.LegislationDiaryTime;
                //cmd.Parameters.Add("@ParticipatedMembers", SqlDbType.Int).Value = bill.ParticipatedMembers;
                // cmd.Parameters.Add("@BillIdentifier", SqlDbType.VarChar).Value = bill.BillIdentifier;
                cmd.Parameters.Add("@FileNumber", SqlDbType.VarChar).Value = bill.FileNumber;
                //cmd.Parameters.Add("@BillGazettedDate", SqlDbType.DateTime).Value = bill.BillGazettedDate;
                cmd.Parameters.Add("@BillYear", SqlDbType.Int).Value = bill.BillYear;
                cmd.Parameters.Add("@BillFile", SqlDbType.Int).Value = bill.BillFile;
                cmd.Parameters.Add("@NoticeFile", SqlDbType.Int).Value = bill.NoticeFile;
                // cmd.Parameters.Add("@BillGazettedDate", SqlDbType.DateTime).Value = bill.BillGazettedDate;
                cmd.Parameters.Add("@IsActive", SqlDbType.Int).Value = bill.IsActive;
                cmd.Parameters.Add("@MembersCSV", SqlDbType.VarChar).Value = bill.MembersCSV;
                cmd.Parameters.Add("@MinistersCSV", SqlDbType.VarChar).Value = bill.MinistersCSV;
                cmd.Parameters.Add("@DivisionsSCV", SqlDbType.VarChar).Value = bill.DivisionsCSV;
                cmd.Parameters.Add("@InsertedBy", SqlDbType.Int).Value = bill.InsertedBy;
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader dr = cmd.ExecuteReader();
                InsertBillMovers(bill.BillMovers, BillId);
                InsertBillMinisters(bill.BillMinisters, BillId);
                InsertBillDivisions(bill.Divisions, BillId);
                //return BillId;
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

        public void UpdateBill(Bills bill)
        {
            SqlConnection con = new DalHelper().GetConnection();

            try
            {

                SqlCommand cmd = new SqlCommand("[dbo].[NOTICE_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "UPDATE_BILL";
                cmd.Parameters.Add("@BillsId", SqlDbType.Int).Value = bill.BillsId;
                cmd.Parameters.Add("@BillTypeId", SqlDbType.Int).Value = bill.BillTypeId;
                cmd.Parameters.Add("@BillStatusId", SqlDbType.Int).Value = bill.BillStatusId;
                cmd.Parameters.Add("@StatusDate", SqlDbType.DateTime).Value = bill.StatusDate;
                cmd.Parameters.Add("@BillCategoriesId", SqlDbType.Int).Value = bill.BillCategoryId;
                //cmd.Parameters.Add("@BillStagesId", SqlDbType.Int).Value = bill.BillStagesId;
                cmd.Parameters.Add("@HouseTypesId", SqlDbType.Int).Value = bill.HouseTypesId;
                cmd.Parameters.Add("@Subject", SqlDbType.VarChar).Value = bill.Subject;
                cmd.Parameters.Add("@BillTitle", SqlDbType.VarChar).Value = bill.BillTitle;
                cmd.Parameters.Add("@ParliamentaryYearsId", SqlDbType.Int).Value = bill.ParliamentaryYearId;
                //cmd.Parameters.Add("@BillDate", SqlDbType.DateTime).Value = bill.BillDate;
                // cmd.Parameters.Add("@BillTime", SqlDbType.DateTime).Value = bill.BillTime;
                cmd.Parameters.Add("@AssemblySessionsId", SqlDbType.Int).Value = bill.AssemblySessionsId;
                //cmd.Parameters.Add("@NoticeDiaryNo", SqlDbType.VarChar).Value = bill.NoticeDiaryNo;
                cmd.Parameters.Add("@NoticeDiaryDate", SqlDbType.DateTime).Value = bill.NoticeDiaryDate;
                // cmd.Parameters.Add("@NoticeDiaryTime", SqlDbType.DateTime).Value = bill.NoticeDiaryTime;
                //cmd.Parameters.Add("@LegislationDiaryNo", SqlDbType.VarChar).Value = bill.LegislationDiaryNo;
                //cmd.Parameters.Add("@LegislationDiaryDate", SqlDbType.DateTime).Value = bill.LegislationDiaryDate;
                //cmd.Parameters.Add("@LegislationDiaryTime", SqlDbType.DateTime).Value = bill.LegislationDiaryTime;
                //cmd.Parameters.Add("@ParticipatedMembers", SqlDbType.Int).Value = bill.ParticipatedMembers;
                // cmd.Parameters.Add("@BillIdentifier", SqlDbType.VarChar).Value = bill.BillIdentifier;
                cmd.Parameters.Add("@FileNumber", SqlDbType.VarChar).Value = bill.FileNumber;
                //cmd.Parameters.Add("@BillGazettedDate", SqlDbType.DateTime).Value = bill.BillGazettedDate;
                cmd.Parameters.Add("@BillYear", SqlDbType.Int).Value = bill.BillYear;
                // cmd.Parameters.Add("@BillGazettedDate", SqlDbType.DateTime).Value = bill.BillGazettedDate;
                cmd.Parameters.Add("@IsActive", SqlDbType.Int).Value = bill.IsActive;
                cmd.Parameters.Add("@MembersCSV", SqlDbType.VarChar).Value = bill.MembersCSV;
                cmd.Parameters.Add("@MinistersCSV", SqlDbType.VarChar).Value = bill.MinistersCSV;
                cmd.Parameters.Add("@DivisionsSCV", SqlDbType.VarChar).Value = bill.DivisionsCSV;
                cmd.Parameters.Add("@Remarks", SqlDbType.VarChar).Value = bill.Remarks;
                cmd.Parameters.Add("@UpdatedBy", SqlDbType.Int).Value = bill.UpdatedBy;
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader dr = cmd.ExecuteReader();
                InsertBillMovers(bill.BillMovers, bill.BillsId);
                InsertBillMinisters(bill.BillMinisters, bill.BillsId);
                InsertBillDivisions(bill.Divisions, bill.BillsId);
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
        public void UpdateNABill(Bills bill)
        {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[LEGISLATION_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "UPDATE_NA_BILL";
                cmd.Parameters.Add("@BillsId", SqlDbType.Int).Value = bill.BillsId;
                cmd.Parameters.Add("@BillTypeId", SqlDbType.Int).Value = bill.BillTypeId;
                cmd.Parameters.Add("@BillStatusId", SqlDbType.Int).Value = bill.BillStatusId;
                cmd.Parameters.Add("@StatusDate", SqlDbType.DateTime).Value = bill.StatusDate;
                cmd.Parameters.Add("@BillCategoriesId", SqlDbType.Int).Value = bill.BillCategoryId;
                //cmd.Parameters.Add("@BillStagesId", SqlDbType.Int).Value = bill.BillStagesId;
                cmd.Parameters.Add("@HouseTypesId", SqlDbType.Int).Value = bill.HouseTypesId;
                cmd.Parameters.Add("@Subject", SqlDbType.VarChar).Value = bill.Subject;
                cmd.Parameters.Add("@BillTitle", SqlDbType.VarChar).Value = bill.BillTitle;
                cmd.Parameters.Add("@ParliamentaryYearsId", SqlDbType.Int).Value = bill.ParliamentaryYearId;
                //cmd.Parameters.Add("@BillDate", SqlDbType.DateTime).Value = bill.BillDate;
                // cmd.Parameters.Add("@BillTime", SqlDbType.DateTime).Value = bill.BillTime;
                cmd.Parameters.Add("@AssemblySessionsId", SqlDbType.Int).Value = bill.AssemblySessionsId;
                //cmd.Parameters.Add("@NoticeDiaryNo", SqlDbType.VarChar).Value = bill.NoticeDiaryNo;
                if (bill.NoticeDiaryDate > Convert.ToDateTime("01/01/1900"))
                    cmd.Parameters.Add("@NoticeDiaryDate", SqlDbType.DateTime).Value = bill.NoticeDiaryDate;
                else
                    cmd.Parameters.Add("@NoticeDiaryDate", SqlDbType.DateTime).Value = DBNull.Value;

                cmd.Parameters.Add("@PassedByNADate", SqlDbType.DateTime).Value = bill.PassedByNADate;
                cmd.Parameters.Add("@ReceivedFromNADate", SqlDbType.DateTime).Value = bill.ReceivedFromNADate;
                cmd.Parameters.Add("@BillCirculationDate", SqlDbType.DateTime).Value = bill.BillCircDate;
                if (bill.NoticeCircDate > Convert.ToDateTime("01/01/1900"))
                    cmd.Parameters.Add("@NoticeCircDate", SqlDbType.DateTime).Value = bill.NoticeCircDate;
                else
                    cmd.Parameters.Add("@NoticeCircDate", SqlDbType.DateTime).Value = DBNull.Value;

                // cmd.Parameters.Add("@NoticeDiaryTime", SqlDbType.DateTime).Value = bill.NoticeDiaryTime;
                //cmd.Parameters.Add("@LegislationDiaryNo", SqlDbType.VarChar).Value = bill.LegislationDiaryNo;
                //cmd.Parameters.Add("@LegislationDiaryDate", SqlDbType.DateTime).Value = bill.LegislationDiaryDate;
                //cmd.Parameters.Add("@LegislationDiaryTime", SqlDbType.DateTime).Value = bill.LegislationDiaryTime;
                //cmd.Parameters.Add("@ParticipatedMembers", SqlDbType.Int).Value = bill.ParticipatedMembers;
                // cmd.Parameters.Add("@BillIdentifier", SqlDbType.VarChar).Value = bill.BillIdentifier;
                cmd.Parameters.Add("@FileNumber", SqlDbType.VarChar).Value = bill.FileNumber;
                //cmd.Parameters.Add("@BillGazettedDate", SqlDbType.DateTime).Value = bill.BillGazettedDate;
                cmd.Parameters.Add("@BillYear", SqlDbType.Int).Value = bill.BillYear;
                // cmd.Parameters.Add("@BillGazettedDate", SqlDbType.DateTime).Value = bill.BillGazettedDate;
                cmd.Parameters.Add("@IsActive", SqlDbType.Int).Value = bill.IsActive;
                cmd.Parameters.Add("@MembersCSV", SqlDbType.VarChar).Value = bill.MembersCSV;
                cmd.Parameters.Add("@MinistersCSV", SqlDbType.VarChar).Value = bill.MinistersCSV;
                cmd.Parameters.Add("@DivisionsSCV", SqlDbType.VarChar).Value = bill.DivisionsCSV;
                cmd.Parameters.Add("@Remarks", SqlDbType.VarChar).Value = bill.Remarks;
                cmd.Parameters.Add("@UpdatedBy", SqlDbType.Int).Value = bill.UpdatedBy;
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader dr = cmd.ExecuteReader();
                InsertBillMovers(bill.BillMovers, bill.BillsId);
                InsertBillMinisters(bill.BillMinisters, bill.BillsId);
                InsertBillDivisions(bill.Divisions, bill.BillsId);
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

        public void UpdateCommitteeDetails(Bills bill)
        {
            SqlConnection con = new DalHelper().GetConnection();

            try
            {

                SqlCommand cmd = new SqlCommand("[dbo].[LEGISLATION_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "UPDATE_COMMITTEE_DETAILS";
                cmd.Parameters.Add("@BillsId", SqlDbType.Int).Value = bill.BillsId;
                if (bill.IntroducedInHouseOn > Convert.ToDateTime("01/01/1900"))
                    cmd.Parameters.Add("@BillIntroduceDate", SqlDbType.DateTime).Value = bill.IntroducedInHouseOn;
                else
                    cmd.Parameters.Add("@BillIntroduceDate", SqlDbType.DateTime).Value = DBNull.Value;
                if (bill.CommitteeRefDate > Convert.ToDateTime("01/01/1900"))
                    cmd.Parameters.Add("@CommitteeRefferdDate", SqlDbType.DateTime).Value = bill.CommitteeRefDate;
                else
                    cmd.Parameters.Add("@CommitteeRefferdDate", SqlDbType.DateTime).Value = DBNull.Value;

                if (bill.CommitteeReportDate > Convert.ToDateTime("01/01/1900"))
                    cmd.Parameters.Add("@CommitteeReportDate", SqlDbType.DateTime).Value = bill.CommitteeReportDate;
                else
                    cmd.Parameters.Add("@CommitteeReportDate", SqlDbType.DateTime).Value = DBNull.Value;
                cmd.Parameters.Add("@CommitteesId", SqlDbType.Int).Value = bill.CommitteeId;
                cmd.Parameters.Add("@CommitteeDaysLimit", SqlDbType.Int).Value = bill.CommitteeTimeLimit;
                //cmd.Parameters.Add("@CommitteeRefferdDate", SqlDbType.DateTime).Value = bill.StatusDate;
                cmd.Parameters.Add("@CommitteeRecommendationId", SqlDbType.Int).Value = bill.CommitteeRecommendationId;
                cmd.Parameters.Add("@AssemblySessionsId", SqlDbType.Int).Value = bill.AssemblySessionsId;
                cmd.Parameters.Add("@IsSentToCommittee", SqlDbType.Int).Value = bill.IsSentToCommittee;

                cmd.Parameters.Add("@Remarks", SqlDbType.VarChar).Value = bill.CommitteeRemarks;
                cmd.Parameters.Add("@UpdatedBy", SqlDbType.Int).Value = bill.UpdatedBy;
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader dr = cmd.ExecuteReader();
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
        public void UpdateNADetails(Bills bill)
        {
            SqlConnection con = new DalHelper().GetConnection();

            try
            {

                SqlCommand cmd = new SqlCommand("[dbo].[LEGISLATION_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "UPDATE_NA_DETAILS";
                cmd.Parameters.Add("@BillsId", SqlDbType.Int).Value = bill.BillsId;
                if (bill.BillPassageDate > Convert.ToDateTime("01/01/1900"))
                    cmd.Parameters.Add("@BillPassageDate", SqlDbType.DateTime).Value = bill.BillPassageDate;
                if (bill.SentToNaDate > Convert.ToDateTime("01/01/1900"))
                    cmd.Parameters.Add("@SentToNADate", SqlDbType.DateTime).Value = bill.SentToNaDate;
                if (bill.ReceivedFromNADate > Convert.ToDateTime("01/01/1900"))
                    cmd.Parameters.Add("@ReceivedFromNADate", SqlDbType.DateTime).Value = bill.ReceivedFromNADate;
                if (bill.PassedByNADate > Convert.ToDateTime("01/01/1900"))
                    cmd.Parameters.Add("@PassedByNADate", SqlDbType.DateTime).Value = bill.PassedByNADate;
                cmd.Parameters.Add("@Remarks", SqlDbType.VarChar).Value = bill.NARemarks;
                cmd.Parameters.Add("@UpdatedBy", SqlDbType.Int).Value = bill.UpdatedBy;
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader dr = cmd.ExecuteReader();
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

        public void UpdateNABillNADetails(Bills bill)
        {
            SqlConnection con = new DalHelper().GetConnection();

            try
            {

                SqlCommand cmd = new SqlCommand("[dbo].[LEGISLATION_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "UPDATE_NA_BILL_NA_DETAILS";
                cmd.Parameters.Add("@BillsId", SqlDbType.Int).Value = bill.BillsId;
                if (bill.BillPassageDate > Convert.ToDateTime("01/01/1900"))
                    cmd.Parameters.Add("@BillPassageDate", SqlDbType.DateTime).Value = bill.BillPassageDate;
                if (bill.SentToNaDate > Convert.ToDateTime("01/01/1900"))
                    cmd.Parameters.Add("@SentToNADate", SqlDbType.DateTime).Value = bill.SentToNaDate;
                if (bill.PresidentAssentDate > Convert.ToDateTime("01/01/1900"))
                    cmd.Parameters.Add("@PresidentAssentDate", SqlDbType.DateTime).Value = bill.PresidentAssentDate;
                if (bill.ActGazettePubDate > Convert.ToDateTime("01/01/1900"))
                    cmd.Parameters.Add("@ActGazettePubDate", SqlDbType.DateTime).Value = bill.ActGazettePubDate;
                //cmd.Parameters.Add("@Remarks", SqlDbType.VarChar).Value = bill.NARemarks;
                cmd.Parameters.Add("@UpdatedBy", SqlDbType.Int).Value = bill.UpdatedBy;
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader dr = cmd.ExecuteReader();
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
        public void UpdateBillMemberDetails(Bills bill)
        {
            SqlConnection con = new DalHelper().GetConnection();

            try
            {

                SqlCommand cmd = new SqlCommand("[dbo].[LEGISLATION_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "UPDATE_BILL_MEMBER_DETAILS";
                cmd.Parameters.Add("@BillsId", SqlDbType.Int).Value = bill.BillsId;
                cmd.Parameters.Add("@MemberWithdrawStatusId", SqlDbType.Int).Value = bill.MemberWithdrawStatusId;
                if (bill.MemberWithdrawStatusDate > Convert.ToDateTime("01/01/1900"))
                    cmd.Parameters.Add("@MemberWithdrawStatusDate", SqlDbType.DateTime).Value = bill.MemberWithdrawStatusDate;
                if (bill.HouseForConsiderationDate > Convert.ToDateTime("01/01/1900"))
                    cmd.Parameters.Add("@HouseForConsiderationDate", SqlDbType.DateTime).Value = bill.HouseForConsiderationDate;
                cmd.Parameters.Add("@ConsiderationSessionId", SqlDbType.Int).Value = bill.ConsiderationSessionId;
                cmd.Parameters.Add("@MemberRemarks", SqlDbType.VarChar).Value = bill.MemberRemarks;
                cmd.Parameters.Add("@UpdatedBy", SqlDbType.Int).Value = bill.UpdatedBy;
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader dr = cmd.ExecuteReader();
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
        #region Senate Bills
        public void InsertNABill(Bills bill)
        {
            SqlConnection con = new DalHelper().GetConnection();
            int BillId = new DalHelper().GetPk("BILLS", "BILLS_ID");

            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[LEGISLATION_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "INSERT_NA_BILL";
                cmd.Parameters.Add("@BillsId", SqlDbType.Int).Value = BillId;
                cmd.Parameters.Add("@BillTypeId", SqlDbType.Int).Value = bill.BillTypeId;
                cmd.Parameters.Add("@BillStatusId", SqlDbType.Int).Value = bill.BillStatusId;
                cmd.Parameters.Add("@StatusDate", SqlDbType.DateTime).Value = bill.StatusDate;
                cmd.Parameters.Add("@BillCategoriesId", SqlDbType.Int).Value = bill.BillCategoryId;
                cmd.Parameters.Add("@BillStagesId", SqlDbType.Int).Value = bill.BillStagesId;
                cmd.Parameters.Add("@HouseTypesId", SqlDbType.Int).Value = bill.HouseTypesId;
                cmd.Parameters.Add("@Subject", SqlDbType.VarChar).Value = bill.Subject;
                cmd.Parameters.Add("@BillTitle", SqlDbType.VarChar).Value = bill.BillTitle;
                cmd.Parameters.Add("@ParliamentaryYearsId", SqlDbType.Int).Value = bill.ParliamentaryYearId;
                //cmd.Parameters.Add("@BillDate", SqlDbType.DateTime).Value = bill.BillDate;
                // cmd.Parameters.Add("@BillTime", SqlDbType.DateTime).Value = bill.BillTime;
                cmd.Parameters.Add("@AssemblySessionsId", SqlDbType.Int).Value = bill.AssemblySessionsId;
                //cmd.Parameters.Add("@NoticeDiaryNo", SqlDbType.VarChar).Value = bill.NoticeDiaryNo;
                cmd.Parameters.Add("@PassedByNADate", SqlDbType.DateTime).Value = bill.PassedByNADate;
                cmd.Parameters.Add("@ReceivedFromNADate", SqlDbType.DateTime).Value = bill.ReceivedFromNADate;
                // cmd.Parameters.Add("@NoticeDiaryTime", SqlDbType.DateTime).Value = bill.NoticeDiaryTime;
                //cmd.Parameters.Add("@LegislationDiaryNo", SqlDbType.VarChar).Value = bill.LegislationDiaryNo;
                // cmd.Parameters.Add("@LegislationDiaryDate", SqlDbType.DateTime).Value = DateTime.Now;
                //cmd.Parameters.Add("@LegislationDiaryTime", SqlDbType.DateTime).Value = bill.LegislationDiaryTime;
                //cmd.Parameters.Add("@ParticipatedMembers", SqlDbType.Int).Value = bill.ParticipatedMembers;
                // cmd.Parameters.Add("@BillIdentifier", SqlDbType.VarChar).Value = bill.BillIdentifier;
                cmd.Parameters.Add("@FileNumber", SqlDbType.VarChar).Value = bill.FileNumber;
                //cmd.Parameters.Add("@BillGazettedDate", SqlDbType.DateTime).Value = bill.BillGazettedDate;
                cmd.Parameters.Add("@BillYear", SqlDbType.Int).Value = bill.BillYear;
                // cmd.Parameters.Add("@BillFile", SqlDbType.Int).Value = bill.BillFile;
                // cmd.Parameters.Add("@NoticeFile", SqlDbType.Int).Value = bill.NoticeFile;
                // cmd.Parameters.Add("@BillGazettedDate", SqlDbType.DateTime).Value = bill.BillGazettedDate;
                cmd.Parameters.Add("@IsActive", SqlDbType.Int).Value = bill.IsActive;
                cmd.Parameters.Add("@MembersCSV", SqlDbType.VarChar).Value = bill.MembersCSV;
                cmd.Parameters.Add("@MinistersCSV", SqlDbType.VarChar).Value = bill.MinistersCSV;
                cmd.Parameters.Add("@DivisionsSCV", SqlDbType.VarChar).Value = bill.DivisionsCSV;
                cmd.Parameters.Add("@InsertedBy", SqlDbType.Int).Value = bill.InsertedBy;
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader dr = cmd.ExecuteReader();
                InsertBillMovers(bill.BillMovers, BillId);
                InsertBillMinisters(bill.BillMinisters, BillId);
                InsertBillDivisions(bill.Divisions, BillId);
                //return BillId;
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

        //public void UpdateNABill(Bills bill)
        //{
        //    SqlConnection con = new DalHelper().GetConnection();

        //    try
        //    {
        //        SqlCommand cmd = new SqlCommand("[dbo].[LEGISLATION_CRUD]", con);
        //        cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "UPDATE_BILL";
        //        cmd.Parameters.Add("@BillsId", SqlDbType.Int).Value = bill.BillsId;
        //        cmd.Parameters.Add("@BillTypeId", SqlDbType.Int).Value = bill.BillTypeId;
        //        cmd.Parameters.Add("@BillStatusId", SqlDbType.Int).Value = bill.BillStatusId;
        //        cmd.Parameters.Add("@StatusDate", SqlDbType.DateTime).Value = bill.StatusDate;
        //        cmd.Parameters.Add("@BillCategoriesId", SqlDbType.Int).Value = bill.BillCategoryId;
        //        cmd.Parameters.Add("@BillStagesId", SqlDbType.Int).Value = bill.BillStagesId;
        //        cmd.Parameters.Add("@HouseTypesId", SqlDbType.Int).Value = bill.HouseTypesId;
        //        cmd.Parameters.Add("@Subject", SqlDbType.VarChar).Value = bill.Subject;
        //        cmd.Parameters.Add("@BillTitle", SqlDbType.VarChar).Value = bill.BillTitle;
        //        cmd.Parameters.Add("@ParliamentaryYearId", SqlDbType.Int).Value = bill.ParliamentaryYearId;
        //        //cmd.Parameters.Add("@BillDate", SqlDbType.DateTime).Value = bill.BillDate;
        //        // cmd.Parameters.Add("@BillTime", SqlDbType.DateTime).Value = bill.BillTime;
        //        cmd.Parameters.Add("@AssemblySessionsId", SqlDbType.Int).Value = bill.AssemblySessionsId;
        //        //cmd.Parameters.Add("@NoticeDiaryNo", SqlDbType.VarChar).Value = bill.NoticeDiaryNo;
        //        cmd.Parameters.Add("@NoticeDiaryDate", SqlDbType.DateTime).Value = bill.NoticeDiaryDate;
        //        // cmd.Parameters.Add("@NoticeDiaryTime", SqlDbType.DateTime).Value = bill.NoticeDiaryTime;
        //        //cmd.Parameters.Add("@LegislationDiaryNo", SqlDbType.VarChar).Value = bill.LegislationDiaryNo;
        //        //cmd.Parameters.Add("@LegislationDiaryDate", SqlDbType.DateTime).Value = bill.LegislationDiaryDate;
        //        //cmd.Parameters.Add("@LegislationDiaryTime", SqlDbType.DateTime).Value = bill.LegislationDiaryTime;
        //        //cmd.Parameters.Add("@ParticipatedMembers", SqlDbType.Int).Value = bill.ParticipatedMembers;
        //        // cmd.Parameters.Add("@BillIdentifier", SqlDbType.VarChar).Value = bill.BillIdentifier;
        //        cmd.Parameters.Add("@FileNumber", SqlDbType.VarChar).Value = bill.FileNumber;
        //        //cmd.Parameters.Add("@BillGazettedDate", SqlDbType.DateTime).Value = bill.BillGazettedDate;
        //        cmd.Parameters.Add("@BillYear", SqlDbType.Int).Value = bill.BillYear;
        //        // cmd.Parameters.Add("@BillGazettedDate", SqlDbType.DateTime).Value = bill.BillGazettedDate;
        //        cmd.Parameters.Add("@IsActive", SqlDbType.Int).Value = bill.IsActive;
        //        cmd.Parameters.Add("@MembersCSV", SqlDbType.VarChar).Value = bill.MembersCSV;
        //        cmd.Parameters.Add("@MinistersCSV", SqlDbType.VarChar).Value = bill.MinistersCSV;
        //        cmd.Parameters.Add("@DivisionsSCV", SqlDbType.VarChar).Value = bill.DivisionsCSV;
        //        cmd.Parameters.Add("@Remarks", SqlDbType.VarChar).Value = bill.Remarks;
        //        cmd.Parameters.Add("@UpdatedBy", SqlDbType.Int).Value = bill.UpdatedBy;
        //        cmd.CommandType = CommandType.StoredProcedure;
        //        SqlDataReader dr = cmd.ExecuteReader();
        //        InsertBillMovers(bill.BillMovers, bill.BillsId);
        //        InsertBillMinisters(bill.BillMinisters, bill.BillsId);
        //        InsertBillDivisions(bill.Divisions, bill.BillsId);
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


        public void UpdateNACommitteeDetails(Bills bill)
        {
            SqlConnection con = new DalHelper().GetConnection();

            try
            {

                SqlCommand cmd = new SqlCommand("[dbo].[LEGISLATION_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "UPDATE_COMMITTEE_DETAILS";
                cmd.Parameters.Add("@BillsId", SqlDbType.Int).Value = bill.BillsId;
                if (bill.IntroducedInHouseOn > Convert.ToDateTime("01/01/1900"))
                {
                    cmd.Parameters.Add("@BillIntroduceDate", SqlDbType.DateTime).Value = bill.IntroducedInHouseOn;
                    cmd.Parameters.Add("@CommitteeRefferdDate", SqlDbType.DateTime).Value = bill.IntroducedInHouseOn; //As Both Dates are same
                }
                if (bill.CommitteeReportDate > Convert.ToDateTime("01/01/1900"))
                    cmd.Parameters.Add("@CommitteeReportDate", SqlDbType.DateTime).Value = bill.CommitteeReportDate;
                cmd.Parameters.Add("@CommitteesId", SqlDbType.Int).Value = bill.CommitteeId;
                cmd.Parameters.Add("@CommitteeDaysLimit", SqlDbType.Int).Value = bill.CommitteeTimeLimit;
                //cmd.Parameters.Add("@CommitteeRefferdDate", SqlDbType.DateTime).Value = bill.StatusDate;
                cmd.Parameters.Add("@CommitteeRecommendationId", SqlDbType.Int).Value = bill.CommitteeRecommendationId;
                cmd.Parameters.Add("@AssemblySessionsId", SqlDbType.Int).Value = bill.AssemblySessionsId;
                cmd.Parameters.Add("@IsSentToCommittee", SqlDbType.Int).Value = bill.IsSentToCommittee;

                cmd.Parameters.Add("@Remarks", SqlDbType.VarChar).Value = bill.CommitteeRemarks;
                cmd.Parameters.Add("@UpdatedBy", SqlDbType.Int).Value = bill.UpdatedBy;
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader dr = cmd.ExecuteReader();
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
        public void UpdateNABillMemberDetails(Bills bill)
        {
            SqlConnection con = new DalHelper().GetConnection();

            try
            {

                SqlCommand cmd = new SqlCommand("[dbo].[LEGISLATION_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "UPDATE_BILL_MEMBER_DETAILS";
                cmd.Parameters.Add("@BillsId", SqlDbType.Int).Value = bill.BillsId;
                cmd.Parameters.Add("@MemberWithdrawStatusId", SqlDbType.Int).Value = bill.MemberWithdrawStatusId;
                if (bill.MemberWithdrawStatusDate > Convert.ToDateTime("01/01/1900"))
                    cmd.Parameters.Add("@MemberWithdrawStatusDate", SqlDbType.DateTime).Value = bill.MemberWithdrawStatusDate;
                if (bill.HouseForConsiderationDate > Convert.ToDateTime("01/01/1900"))
                    cmd.Parameters.Add("@HouseForConsiderationDate", SqlDbType.DateTime).Value = bill.HouseForConsiderationDate;
                cmd.Parameters.Add("@ConsiderationSessionId", SqlDbType.Int).Value = bill.ConsiderationSessionId;
                cmd.Parameters.Add("@MemberRemarks", SqlDbType.VarChar).Value = bill.MemberRemarks;
                cmd.Parameters.Add("@UpdatedBy", SqlDbType.Int).Value = bill.UpdatedBy;
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader dr = cmd.ExecuteReader();
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

        protected void DeleteBillMovers(int BillId)
        {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[LEGISLATION_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "DELETE_BILL_MOVERS";
                cmd.Parameters.Add("@BillsId", SqlDbType.Int).Value = BillId;
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader dr = cmd.ExecuteReader();
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
        protected List<BillMovers> GetBillMovers(int BillId)
        {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[LEGISLATION_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "GET_BILL_MOVERS";
                cmd.Parameters.Add("@BillsId", SqlDbType.Int).Value = BillId;
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader dr = cmd.ExecuteReader();
                List<BillMovers> billMovers = null;

                if (dr.HasRows)
                {
                    billMovers = new List<BillMovers>();
                    while (dr.Read())
                    {
                        BillMovers Temp = new BillMovers();
                        Temp.SystemUsersId = Convert.ToInt32(dr["SYSTEM_USERS_ID"]);
                        Temp.Mover = Convert.ToString(dr["F_NAME"]);
                        billMovers.Add(Temp);
                    }
                }
                return billMovers;
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

        protected List<BillDivisions> GetBillDivisions(int BillId)
        {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[LEGISLATION_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "GET_BILL_DIVISIONS";
                cmd.Parameters.Add("@BillsId", SqlDbType.Int).Value = BillId;
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader dr = cmd.ExecuteReader();
                List<BillDivisions> BillDivisions = null;

                if (dr.HasRows)
                {
                    BillDivisions = new List<BillDivisions>();
                    while (dr.Read())
                    {
                        BillDivisions Temp = new BillDivisions();
                        Temp.BillDivisionsId = Convert.ToInt32(dr["BILL_DIVISIONS_ID"]);
                        Temp.BillsId = Convert.ToInt32(dr["BILLS_ID"]);
                        Temp.DivisionsId = Convert.ToInt32(dr["DIVISION_ID"]);
                        Temp.Division = Convert.ToString(dr["DIVISION"]);
                        BillDivisions.Add(Temp);
                    }
                }
                return BillDivisions;
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
        protected void InsertBillMovers(List<BillMovers> billMovers, int BillId)
        {
            SqlConnection con = new DalHelper().GetConnection();
            string query = "";
            try
            {
                using (con)
                {
                    if (billMovers != null)
                    {
                        if (billMovers.Count > 0)
                        {
                            DeleteBillMovers(BillId);
                            foreach (BillMovers billmovers in billMovers)
                            {
                                query += "INSERT INTO BILL_MOVERS (BILLS_ID,SYSTEM_USERS_ID) VALUES(" + BillId + "," + billmovers.SystemUsersId + ");";

                            }
                            SqlCommand cmd = new SqlCommand(query, con);
                            SqlDataReader dr = cmd.ExecuteReader();
                        }
                    }
                }

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

        protected void DeleteBillDivisions(int BillId)
        {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[LEGISLATION_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "DELETE_BILL_DIVISIONS";
                cmd.Parameters.Add("@BillsId", SqlDbType.Int).Value = BillId;
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader dr = cmd.ExecuteReader();
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

        protected void InsertBillDivisions(List<Divisions> divisions, int BillId)
        {
            SqlConnection con = new DalHelper().GetConnection();
            string query = "";
            try
            {
                using (con)
                {
                    if (divisions != null)
                    {
                        if (divisions.Count > 0)
                        {
                            DeleteBillDivisions(BillId);
                            foreach (Divisions billdivisions in divisions)
                            {
                                query += "INSERT INTO BILL_DIVISIONS (BILLS_ID,DIVISION_ID) VALUES(" + BillId + "," + billdivisions.DivisionsId + ");";

                            }
                            SqlCommand cmd = new SqlCommand(query, con);
                            SqlDataReader dr = cmd.ExecuteReader();
                        }
                    }

                }
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
        #region Bill Ministers
        public List<BillMinisters> GetBillMinisters(int BillId)
        {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[LEGISLATION_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "GET_BILL_MINISTERS";
                cmd.Parameters.Add("@BillsId", SqlDbType.Int).Value = BillId;
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader dr = cmd.ExecuteReader();
                List<BillMinisters> billMovers = null;

                if (dr.HasRows)
                {
                    billMovers = new List<BillMinisters>();
                    while (dr.Read())
                    {
                        BillMinisters Temp = new BillMinisters();
                        Temp.BillMinistersId = Convert.ToInt32(dr["BILL_MINISTER_ID"]);
                        Temp.BillsId = Convert.ToInt32(dr["BILL_ID"]);
                        Temp.MinisterId = Convert.ToInt32(dr["MINISTERS_ID"]);
                        Temp.MinisterName = Convert.ToString(dr["MINISTER_NAME"]);
                        billMovers.Add(Temp);
                    }
                }
                return billMovers;
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
        public void InsertBillMinisters(List<BillMinisters> billMovers, int BillId)
        {
            SqlConnection con = new DalHelper().GetConnection();
            string query = "";
            try
            {
                using (con)
                {
                    if (billMovers != null)
                    {
                        if (billMovers.Count > 0)
                        {
                            DeleteBillMinisters(BillId);
                            foreach (BillMinisters billmovers in billMovers)
                            {
                                query += "INSERT INTO BILL_MINISTERS (BILL_ID,MINISTERS_ID) VALUES(" + BillId + "," + billmovers.MinisterId + ");";

                            }
                            SqlCommand cmd = new SqlCommand(query, con);
                            SqlDataReader dr = cmd.ExecuteReader();
                        }
                    }

                }
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
        protected void DeleteBillMinisters(int BillId)
        {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[LEGISLATION_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "DELETE_BILL_MINISTERS";
                cmd.Parameters.Add("@BillsId", SqlDbType.Int).Value = BillId;
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader dr = cmd.ExecuteReader();
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
        //public void UpdateBill(Bills bill)
        //{
        //    SqlConnection con = new DalHelper().GetConnection();
        //    try
        //    {
        //        SqlCommand cmd = new SqlCommand("[dbo].[LEGISLATION_CRUD]", con);
        //        cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "UPDATE_BILL";

        //        cmd.Parameters.Add("@BillsId", SqlDbType.Int).Value = bill.BillsId;
        //        cmd.Parameters.Add("@BillTypeId", SqlDbType.Int).Value = bill.BillTypeId;
        //        cmd.Parameters.Add("@BillStatusId", SqlDbType.Int).Value = 2; //Under Process
        //        cmd.Parameters.Add("@BillCategoriesId", SqlDbType.VarChar).Value = bill.BillCategoriesId;
        //        cmd.Parameters.Add("@BillStagesId", SqlDbType.VarChar).Value = bill.BillStagesId;
        //        cmd.Parameters.Add("@HouseTypesId", SqlDbType.VarChar).Value = bill.HouseTypesId;
        //        cmd.Parameters.Add("@ParliamentaryYear", SqlDbType.Int).Value = bill.ParliamentaryYear;
        //        cmd.Parameters.Add("@BillDate", SqlDbType.DateTime).Value = bill.BillDate;
        //        cmd.Parameters.Add("@BillTime", SqlDbType.DateTime).Value = bill.BillTime;
        //        cmd.Parameters.Add("@SessionNumber", SqlDbType.Int).Value = bill.AssemblySessionsId;
        //        cmd.Parameters.Add("@NoticeDiaryNo", SqlDbType.VarChar).Value = bill.NoticeDiaryNo;
        //        cmd.Parameters.Add("@NoticeDiaryDate", SqlDbType.DateTime).Value = bill.NoticeDiaryDate;
        //        cmd.Parameters.Add("@NoticeDiaryTime", SqlDbType.DateTime).Value = bill.NoticeDiaryTime;
        //        cmd.Parameters.Add("@LegislationDiaryNo", SqlDbType.VarChar).Value = bill.LegislationDiaryNo;
        //        cmd.Parameters.Add("@LegislationDiaryDate", SqlDbType.DateTime).Value = bill.LegislationDiaryDate;
        //        cmd.Parameters.Add("@LegislationDiaryTime", SqlDbType.DateTime).Value = bill.LegislationDiaryTime;
        //        cmd.Parameters.Add("@ParticipatedMembers", SqlDbType.Int).Value = bill.ParticipatedMembers;
        //        cmd.Parameters.Add("@BillIdentifier", SqlDbType.VarChar).Value = bill.BillIdentifier;
        //        cmd.Parameters.Add("@FileNumber", SqlDbType.Int).Value = bill.FileNumber;
        //        cmd.Parameters.Add("@BillGazettedDate", SqlDbType.DateTime).Value = bill.BillGazettedDate;
        //        cmd.Parameters.Add("@BillYear", SqlDbType.Int).Value = bill.BillYear;
        //        cmd.Parameters.Add("@BillGazettedDate", SqlDbType.DateTime).Value = bill.BillGazettedDate;
        //        cmd.Parameters.Add("@IsActive", SqlDbType.Int).Value = 1;
        //        cmd.CommandType = CommandType.StoredProcedure;
        //        SqlDataReader dr = cmd.ExecuteReader();

        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}
        public void DeleteBill(int BillId)
        {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[LEGISLATION_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "DELETE_BILL";

                cmd.Parameters.Add("@BillsId", SqlDbType.Int).Value = BillId;

                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader dr = cmd.ExecuteReader();
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
        protected Bills BindNoticeFields(SqlDataReader dr)
        {
            Bills Temp = new Bills();
            Temp.BillsId = Convert.ToInt32(dr["BILLS_ID"]);
            if (dr["BILL_STATUS_ID"] != DBNull.Value)
            {
                Temp.BillStatusId = Convert.ToInt32(dr["BILL_STATUS_ID"]);
            }
            if (dr["Bill_TYPE_ID"] != DBNull.Value)
            {
                Temp.BillTypeId = Convert.ToInt32(dr["Bill_TYPE_ID"]);
                Temp.BillTypes = new BillTypes();
                Temp.BillTypes.BillTypesId = Convert.ToInt32(dr["BILL_TYPE_ID"]);
                Temp.BillTypes.Description = Convert.ToString(dr["BILL_TYPE"]);
            }
            //if (dr["BILL_STAGES_ID"] != DBNull.Value)
            //{
            //    Temp.BillStagesId = Convert.ToInt32(dr["BILL_STAGES_ID"]);
            //    Temp.BillStages = new BillStages();
            //    Temp.BillStages.BillStagesId = Convert.ToInt32(dr["BILL_STAGES_ID"]);
            //    Temp.BillStages.Description = Convert.ToString(dr["BILL_STAGE"]);
            //}
            if (dr["ASSEMBLY_SESSIONS_ID"] != DBNull.Value)
            {
                Temp.AssemblySessionsId = Convert.ToInt32(dr["ASSEMBLY_SESSIONS_ID"]);
                Temp.AssemblySessions = new AssemblySessions();
                Temp.AssemblySessions.AssemblySessionsId = Convert.ToInt32(dr["ASSEMBLY_SESSIONS_ID"]);
                Temp.AssemblySessions.SessionNumber = Convert.ToInt32(dr["SESSION_NUMBER_DESC"]);
            }
            if (dr["HOUSE_TYPES_ID"] != DBNull.Value)
            {
                Temp.HouseTypesId = Convert.ToInt32(dr["HOUSE_TYPES_ID"]);
                Temp.HouseTypes = new HouseTypes();
                Temp.HouseTypes.HouseTypesId = Convert.ToInt32(dr["HOUSE_TYPES_ID"]);
                Temp.HouseTypes.Description = Convert.ToString(dr["HOUSE_TYPE"]);
            }

            if (dr["BILL_CATEGORIES_ID"] != DBNull.Value)
            {
                Temp.BillCategoriesId = Convert.ToInt32(dr["BILL_CATEGORIES_ID"]);
                Temp.BillCategories = new BillCategories();
                Temp.BillCategories.BillCategoriesId = Convert.ToInt32(dr["BILL_CATEGORIES_ID"]);
                Temp.BillCategories.Description = Convert.ToString(dr["BILL_CATEGORY"]);
            }
            //if (dr["PARLIAMENTARY_YEAR_ID"] != DBNull.Value)
            //{
            //    Temp.ParliamentaryYearId = Convert.ToInt32(dr["PARLIAMENTARY_YEAR_ID"]);
            //    Temp.ParliamentaryYears = new ParliamentaryYears();
            //    Temp.ParliamentaryYears.ParliamentaryYearsId = Convert.ToInt32(dr["PARLIAMENTARY_YEAR_ID"]);
            //    Temp.ParliamentaryYears.ParliamentaryYear = Convert.ToString(dr["PARLIAMENTARY_YEAR"]);
            //}

            if (dr["STATUS_DATE"] != DBNull.Value)
                Temp.StatusDate = Convert.ToDateTime(dr["STATUS_DATE"]);
            if (dr["BILL_TITLE"] != DBNull.Value)
                Temp.BillTitle = Convert.ToString(dr["BILL_TITLE"]);
            //if (dr["SESSION_SITTINGS_ID"] != DBNull.Value)
            //    Temp.SessionSittingsId = Convert.ToInt32(dr["SESSION_SITTINGS_ID"]);
            //if (dr["LEGISLATION_DIARY_NO"] != DBNull.Value)
            //    Temp.LegislationDiaryNo = Convert.ToString(dr["LEGISLATION_DIARY_NO"]);
            //if (dr["LEGISLATION_DIARY_DATE"] != DBNull.Value)
            //    Temp.LegislationDiaryDate = Convert.ToDateTime(dr["LEGISLATION_DIARY_DATE"]);
            //if (dr["SNT_ENTRY_DATE"] != DBNull.Value)
            //    Temp.SntEntryDate = Convert.ToDateTime(dr["SNT_ENTRY_DATE"]);
            //if (dr["IS_ACT"] != DBNull.Value)
            //    Temp.IsAct = Convert.ToInt32(dr["IS_ACT"]);
            //if (dr["SECOND_READING_DATE"] != DBNull.Value)
            //    Temp.SecondReadindDate = Convert.ToDateTime(dr["SECOND_READING_DATE"]);
            //if (dr["OTHER_HOUSE_RECEIPT_DATE"] != DBNull.Value)
            //    Temp.OtherHouseReceiptDate = Convert.ToDateTime(dr["OTHER_HOUSE_RECEIPT_DATE"]);
            //if (dr["OTHER_HOUSE_RETURN_DATE"] != DBNull.Value)
            //    Temp.OtherHouseReturnDate = Convert.ToDateTime(dr["OTHER_HOUSE_RETURN_DATE"]);
            //if (dr["CII_REPORT_DATE"] != DBNull.Value)
            //    Temp.CllReportDate = Convert.ToDateTime(dr["CII_REPORT_DATE"]);
            //if (dr["LEAVE_GRANTED_BY"] != DBNull.Value)
            //    Temp.LeaveGrantedBy = Convert.ToString(dr["LEAVE_GRANTED_BY"]);
            //if (dr["IS_SENT_TO_TRANSLATION"] != DBNull.Value)
            //    Temp.IsSentToTranslation = Convert.ToInt32(dr["IS_SENT_TO_TRANSLATION"]);

            //if (dr["REVIEWED_BY"] != DBNull.Value)
            //    Temp.ReviewedBy = Convert.ToString(dr["REVIEWED_BY"]);
            //if (dr["LEGISLATION_DIARY_TIME"] != DBNull.Value)
            //    Temp.LegislationDiaryTime = Convert.ToDateTime(dr["LEGISLATION_DIARY_TIME"]);
            //if (dr["F_BILL_PRES_DATE"] != DBNull.Value)
            //    Temp.FBillPresDate = Convert.ToDateTime(dr["F_BILL_PRES_DATE"]);
            //if (dr["SNT_ENTRY_TIME"] != DBNull.Value)
            //    Temp.SntEntryTime = Convert.ToDateTime(dr["SNT_ENTRY_TIME"]);

            //if (dr["IS_WITH_NA"] != DBNull.Value)
            //    Temp.IsWithNa = Convert.ToInt32(dr["IS_WITH_NA"]);
            //if (dr["THIRD_READING_DATE"] != DBNull.Value)
            //    Temp.ThirdReadingDate = Convert.ToDateTime(dr["THIRD_READING_DATE"]);

            //if (dr["BILL_CIRC_DATE"] != DBNull.Value)
            //    Temp.BillCircDate = Convert.ToDateTime(dr["BILL_CIRC_DATE"]);
            //if (dr["ACT_GAZETTE_PUB_DATE"] != DBNull.Value)
            //    Temp.ActGazettePubDate = Convert.ToDateTime(dr["ACT_GAZETTE_PUB_DATE"]);
            //if (dr["BILL_YEAR"] != DBNull.Value)
            //    Temp.BillYear = Convert.ToInt32(dr["BILL_YEAR"]);
            //if (dr["DESIGNATION"] != DBNull.Value)
            //    Temp.Designation = Convert.ToString(dr["DESIGNATION"]);
            if (dr["URDU_TEXT"] != DBNull.Value)
                Temp.UrduText = Convert.ToString(dr["URDU_TEXT"]);
            //if (dr["REMARKS"] != DBNull.Value)
            //    Temp.Remarks = Convert.ToString(dr["REMARKS"]);
            //if (dr["GOVT_BILL_DATE"] != DBNull.Value)
            //    Temp.GovtBillDate = Convert.ToDateTime(dr["GOVT_BILL_DATE"]);
            //if (dr["DISCUSS_DAYS"] != DBNull.Value)
            //    Temp.DiscussDays = Convert.ToInt32(dr["DISCUSS_DAYS"]);
            //if (dr["SNT_REFERENCE"] != DBNull.Value)
            //    Temp.SntReference = Convert.ToString(dr["SNT_REFERENCE"]);
            //if (dr["AND_WHEREAS"] != DBNull.Value)
            //    Temp.AndWhereas = Convert.ToString(dr["AND_WHEREAS"]);
            //if (dr["IS_ENTERED_BY_MEMBER"] != DBNull.Value)
            //    Temp.IsEnteredByMember = Convert.ToInt32(dr["IS_ENTERED_BY_MEMBER"]);
            //if (dr["MINISTER_NOTICE_DATE"] != DBNull.Value)
            //    Temp.MinisterNoticeDate = Convert.ToDateTime(dr["MINISTER_NOTICE_DATE"]);
            //if (dr["PUBLIC_OPINION"] != DBNull.Value)
            //    Temp.PublicOpinion = Convert.ToString(dr["PUBLIC_OPINION"]);
            //if (dr["PRESIDENT_ASSENT_DATE"] != DBNull.Value)
            //    Temp.PresidentAssentDate = Convert.ToDateTime(dr["PRESIDENT_ASSENT_DATE"]);
            //if (dr["LEAVE_GRANTE_DATE"] != DBNull.Value)
            //    Temp.LeaveGranteDate = Convert.ToDateTime(dr["LEAVE_GRANTE_DATE"]);
            //if (dr["AMENDED_CONTENT"] != DBNull.Value)
            //    Temp.AmendedContent = Convert.ToString(dr["AMENDED_CONTENT"]);
            //if (dr["CURRENT_ROLE"] != DBNull.Value)
            //    Temp.CurrentRole = Convert.ToString(dr["CURRENT_ROLE"]);
            //if (dr["IS_ACTIVE"] != DBNull.Value)
            //    Temp.IsActive = Convert.ToInt32(dr["IS_ACTIVE"]);
            //if (dr["MOTION_DATE"] != DBNull.Value)
            //    Temp.MotionDate = Convert.ToDateTime(dr["MOTION_DATE"]);
            //if (dr["PARTICIPATED_MEMBERS"] != DBNull.Value)
            //    Temp.ParticipatedMembers = Convert.ToInt32(dr["PARTICIPATED_MEMBERS"]);
            //if (dr["SNT_RECOMMENDATION"] != DBNull.Value)
            //    Temp.SntRecommendation = Convert.ToString(dr["SNT_RECOMMENDATION"]);
            //if (dr["BILL_GAZETTED_DATE"] != DBNull.Value)
            //    Temp.BillGazettedDate = Convert.ToDateTime(dr["BILL_GAZETTED_DATE"]);
            //if (dr["NOW_THEREFORE"] != DBNull.Value)
            //    Temp.NowTherefore = Convert.ToString(dr["NOW_THEREFORE"]);
            //if (dr["MED_CMT_REF_DATE"] != DBNull.Value)
            //    Temp.MedCmtRefDate = Convert.ToDateTime(dr["MED_CMT_REF_DATE"]);
            //if (dr["NOTICE_CIRC_DATE"] != DBNull.Value)
            //    Temp.NoticeCircDate = Convert.ToDateTime(dr["NOTICE_CIRC_DATE"]);
            //if (dr["CII_OPINION"] != DBNull.Value)
            //    Temp.CiiOpinion = Convert.ToString(dr["CII_OPINION"]);
            //if (dr["FINANCE_BILL_REFERENCE"] != DBNull.Value)
            //    Temp.FinanceBillReference = Convert.ToString(dr["FINANCE_BILL_REFERENCE"]);
            //if (dr["IS_WITH_MED_COMMITTEE"] != DBNull.Value)
            //    Temp.IswithSatndingCommitee = Convert.ToInt32(dr["IS_WITH_MED_COMMITTEE"]);
            //if (dr["MEM_BILL_SUBJECT"] != DBNull.Value)
            //    Temp.MemBillSubject = Convert.ToString(dr["MEM_BILL_SUBJECT"]);
            if (dr["NOTICE_DIARY_DATE"] != DBNull.Value)
                Temp.NoticeDiaryDate = Convert.ToDateTime(dr["NOTICE_DIARY_DATE"]);
            //if (dr["BILL_PASSAGE_DATE"] != DBNull.Value)
            //    Temp.BillPassageDate = Convert.ToDateTime(dr["BILL_PASSAGE_DATE"]);
            //if (dr["GOVT_P_MEMBERS"] != DBNull.Value)
            //    Temp.GovtPMembers = Convert.ToInt32(dr["GOVT_P_MEMBERS"]);
            //if (dr["BILL_IDENTIFIER"] != DBNull.Value)
            //    Temp.BillIdentifier = Convert.ToString(dr["BILL_IDENTIFIER"]);
            //if (dr["SEND_TO_NA_DATE"] != DBNull.Value)
            //    Temp.SentToNaDate = Convert.ToDateTime(dr["SEND_TO_NA_DATE"]);
            //if (dr["RECEIVED_FROM_NA_DATE"] != DBNull.Value)
            //    Temp.ReceivedFromNADate = Convert.ToDateTime(dr["RECEIVED_FROM_NA_DATE"]);

            //if (dr["PASSED_BY_NA_DATE"] != DBNull.Value)
            //    Temp.PassedByNADate = Convert.ToDateTime(dr["PASSED_BY_NA_DATE"]);

            //if (dr["NA_REMARKS"] != DBNull.Value)
            //    Temp.NARemarks = Convert.ToString(dr["NA_REMARKS"]);
            //if (dr["WITHDRAWAL_DATE"] != DBNull.Value)
            //    Temp.WithdrawalDate = Convert.ToDateTime(dr["WITHDRAWAL_DATE"]);
            //if (dr["MED_CMT_PRES_DATE"] != DBNull.Value)
            //    Temp.MedCmtPresDate = Convert.ToDateTime(dr["MED_CMT_PRES_DATE"]);
            //if (dr["LAW_DIV_SENT_DATE"] != DBNull.Value)
            //    Temp.LawDivSentDate = Convert.ToDateTime(dr["LAW_DIV_SENT_DATE"]);
            //if (dr["PUBLIC_OPINION_CIRC_DATE"] != DBNull.Value)
            //    Temp.PublicOpinionCircDate = Convert.ToDateTime(dr["PUBLIC_OPINION_CIRC_DATE"]);
            //if (dr["IS_SENT_TO_SENATE"] != DBNull.Value)
            //    Temp.IsSentToSenate = Convert.ToInt32(dr["IS_SENT_TO_SENATE"]);
            if (dr["SUBJECT"] != DBNull.Value)
                Temp.Subject = Convert.ToString(dr["SUBJECT"]);
            //if (dr["MEM_BILL_CONTENT"] != DBNull.Value)
            //    Temp.MemBillContent = Convert.ToString(dr["MEM_BILL_CONTENT"]);
            //if (dr["PRIORITY"] != DBNull.Value)
            //    Temp.Priority = Convert.ToInt32(dr["PRIORITY"]);
            //if (dr["NOTICE_DIARY_NO"] != DBNull.Value)
            //    Temp.NoticeDiaryNo = Convert.ToInt32(dr["NOTICE_DIARY_NO"]);
            //if (dr["BILL_ASSENT_DATE"] != DBNull.Value)
            //    Temp.BillAssentDate = Convert.ToDateTime(dr["BILL_ASSENT_DATE"]);
            //if (dr["OPP_P_MEMBERS"] != DBNull.Value)
            //    Temp.OppPMembers = Convert.ToInt32(dr["OPP_P_MEMBERS"]);
            //if (dr["FILE_NUMBER"] != DBNull.Value)
            //    Temp.FileNumber = Convert.ToString(dr["FILE_NUMBER"]);
            //if (dr["IS_WITH_PRESIDENT"] != DBNull.Value)
            //    Temp.IsWithPresident = Convert.ToInt32(dr["IS_WITH_PRESIDENT"]);
            //if (dr["FIRST_READING_DATE"] != DBNull.Value)
            //    Temp.FirstReadingDate = Convert.ToDateTime(dr["FIRST_READING_DATE"]);
            //if (dr["AGREED_BILL_CONS_DATE"] != DBNull.Value)
            //    Temp.AgreedBillConsDate = Convert.ToDateTime(dr["AGREED_BILL_CONS_DATE"]);
            //if (dr["LAW_DIV_REC_DATE"] != DBNull.Value)
            //    Temp.LawDivRecDate = Convert.ToDateTime(dr["LAW_DIV_REC_DATE"]);
            //if (dr["PUBLIC_OPINION_DATE"] != DBNull.Value)
            //    Temp.PublicOpinionDate = Convert.ToDateTime(dr["PUBLIC_OPINION_DATE"]);
            //if (dr["IS_SENT_TO_COMMITTEE"] != DBNull.Value)
            //    Temp.IsSentToCommittee = Convert.ToInt32(dr["IS_SENT_TO_COMMITTEE"]);
            //if (dr["REJECT_AMEND_DATE"] != DBNull.Value)
            //    Temp.RejectAmendDate = Convert.ToDateTime(dr["REJECT_AMEND_DATE"]);
            //if (dr["NOTICE_DIARY_TIME"] != DBNull.Value)
            //    Temp.NoticeDiaryTime = Convert.ToDateTime(dr["NOTICE_DIARY_TIME"]);
            //if (dr["IS_WITH_STANDING_COMMITTEE"] != DBNull.Value)
            //    Temp.IswithSatndingCommitee = Convert.ToInt32(dr["IS_WITH_STANDING_COMMITTEE"]);
            //if (dr["SNT_REC_DATE"] != DBNull.Value)
            //    Temp.SntRecDate = Convert.ToDateTime(dr["SNT_REC_DATE"]);
            //if (dr["PASSED_AS_REPT_BY_SC"] != DBNull.Value)
            //    Temp.PassedAsReptBySc = Convert.ToString(dr["PASSED_AS_REPT_BY_SC"]);
            //if (dr["SEND_TO_PRESIDENT_DATE"] != DBNull.Value)
            //    Temp.SendToPresidentDate = Convert.ToDateTime(dr["SEND_TO_PRESIDENT_DATE"]);
            //if (dr["AGREED_BILL_PASS_DATE"] != DBNull.Value)
            //    Temp.AgreedBillPassDate = Convert.ToDateTime(dr["AGREED_BILL_PASS_DATE"]);
            //if (dr["OTHER_HOUSE_INTIMATE_DATE"] != DBNull.Value)
            //    Temp.OtherHouseIntimateDate = Convert.ToDateTime(dr["OTHER_HOUSE_INTIMATE_DATE"]);
            //if (dr["CII_REFER_DATE"] != DBNull.Value)
            //    Temp.CiiOpinion = Convert.ToString(dr["CII_REFER_DATE"]);
            //if (dr["IS_LEAVE_GRANTE"] != DBNull.Value)
            //    Temp.IsLeaveGranted = Convert.ToInt32(dr["IS_LEAVE_GRANTE"]);
            //if (dr["LETTER"] != DBNull.Value)
            //    Temp.Letter = Convert.ToString(dr["LETTER"]);
            //if (dr["BILL_DATE"] != DBNull.Value)
            //    Temp.BillDate = Convert.ToDateTime(dr["BILL_DATE"]);
            //if (dr["LEGISLATION_DIARY_NO"] != DBNull.Value)
            //    Temp.LegislationDiaryNo = Convert.ToString(dr["LEGISLATION_DIARY_NO"]);
            //if (dr["SNT_REC_TIME"] != DBNull.Value)
            //    Temp.SntRecTime = Convert.ToDateTime(dr["SNT_REC_TIME"]);
            //if (dr["PASSED_WO_ST_CMT"] != DBNull.Value)
            //    Temp.PassedWoStCmt = Convert.ToString(dr["PASSED_WO_ST_CMT"]);
            //if (dr["NOTING"] != DBNull.Value)
            //    Temp.Noting = Convert.ToString(dr["NOTING"]);
            //if (dr["BILL_TIME"] != DBNull.Value)
            //    Temp.BillTime = Convert.ToDateTime(dr["BILL_TIME"]);
            if (dr["BILL_FILE"] != DBNull.Value)
                Temp.BillFile = Convert.ToString(dr["BILL_FILE"]);
            //if (dr["NOTICE_FILE"] != DBNull.Value)
            //    Temp.NoticeFile = Convert.ToString(dr["NOTICE_FILE"]);
            //if (dr["BILL_INTRODUCE_DATE"] != DBNull.Value)
            //    Temp.IntroducedInHouseOn = Convert.ToDateTime(dr["BILL_INTRODUCE_DATE"]);
            //if (dr["COMMITTEE_ID"] != DBNull.Value)
            //    Temp.CommitteeId = Convert.ToInt32(dr["COMMITTEE_ID"]);
            //if (dr["COMMITTEE_DAYS_LIMIT"] != DBNull.Value)
            //    Temp.CommitteeTimeLimit = Convert.ToInt32(dr["COMMITTEE_DAYS_LIMIT"]);
            //if (dr["COMMITTEE_RECOMMENDATION_ID"] != DBNull.Value)
            //    Temp.CommitteeRecommendationId = Convert.ToInt32(dr["COMMITTEE_RECOMMENDATION_ID"]);
            //if (dr["COMMITTEE_NAME"] != DBNull.Value)
            //    Temp.CommitteeName = Convert.ToString(dr["COMMITTEE_NAME"]);
            //if (dr["COMMITTEE_REF_DATE"] != DBNull.Value)
            //    Temp.CommitteeRefDate = Convert.ToDateTime(dr["COMMITTEE_REF_DATE"]);
            //if (dr["COMMITTEE_REMARKS"] != DBNull.Value)
            //    Temp.CommitteeRemarks = Convert.ToString(dr["COMMITTEE_REMARKS"]);
            //if (dr["COMMITTEE_REPORT_FILE"] != DBNull.Value)
            //    Temp.CommitteeReportFile = Convert.ToString(dr["COMMITTEE_REPORT_FILE"]);
            //if (dr["COMMITTEE_REPORT_DATE"] != DBNull.Value)
            //    Temp.CommitteeReportDate = Convert.ToDateTime(dr["COMMITTEE_REPORT_DATE"]);
            if (dr["MEMBERS"] != DBNull.Value)
                Temp.MembersCSV = Convert.ToString(dr["MEMBERS"]);
            if (dr["MINISTERS"] != DBNull.Value)
                Temp.MinistersCSV = Convert.ToString(dr["MINISTERS"]);
            if (dr["DIVISIONS"] != DBNull.Value)
                Temp.DivisionsCSV = Convert.ToString(dr["DIVISIONS"]);

            //if (dr["MEMBER_WITHDRAWAL_STATUS_ID"] != DBNull.Value)
            //    Temp.MemberWithdrawStatusId = Convert.ToInt32(dr["MEMBER_WITHDRAWAL_STATUS_ID"]);
            //if (dr["CONSIDERATION_SESSION_ID"] != DBNull.Value)
            //    Temp.ConsiderationSessionId = Convert.ToInt32(dr["CONSIDERATION_SESSION_ID"]);

            //if (dr["MEMBER_WITHDRAWAL_STATUS_DATE"] != DBNull.Value)
            //    Temp.MemberWithdrawStatusDate = Convert.ToDateTime(dr["MEMBER_WITHDRAWAL_STATUS_DATE"]);
            //if (dr["HOUSE_FOR_CONSIDERATION_DATE"] != DBNull.Value)
            //    Temp.HouseForConsiderationDate = Convert.ToDateTime(dr["HOUSE_FOR_CONSIDERATION_DATE"]);
            //if (dr["MEMBER_REMARKS"] != DBNull.Value)
            //    Temp.MemberRemarks = Convert.ToString(dr["MEMBER_REMARKS"]);


            //if (dr["UPDATED_BY"] != DBNull.Value)
            //    Temp.UpdatedBy = Convert.ToInt32(dr["UPDATED_BY"]);
            if (dr["UPDATED_ON"] != DBNull.Value)
                Temp.UpdatedOn = Convert.ToDateTime(dr["UPDATED_ON"]);
            if (dr["INSERTED_BY"] != DBNull.Value)
                Temp.InsertedBy = Convert.ToInt32(dr["INSERTED_BY"]);
            if (dr["INSERTED_ON"] != DBNull.Value)
                Temp.InsertedOn = Convert.ToDateTime(dr["INSERTED_ON"]);
            if (dr["DELETED_BY"] != DBNull.Value)
                Temp.DeletedBy = Convert.ToInt32(dr["DELETED_BY"]);
            if (dr["DELETED_ON"] != DBNull.Value)
                Temp.DeletedOn = Convert.ToDateTime(dr["DELETED_ON"]);
            if (dr["RECOVERED_BY"] != DBNull.Value)
                Temp.RecoveredBy = Convert.ToInt32(dr["RECOVERED_BY"]);
            if (dr["RECOVERED_ON"] != DBNull.Value)
                Temp.RecoveredOn = Convert.ToDateTime(dr["RECOVERED_ON"]);
            if (dr["MEMBERS"] != DBNull.Value)
            {
                Temp.MembersCSV = Convert.ToString(dr["MEMBERS"]);
                Temp.MoverNames = GetBillMoverNamesCsv(Temp.MembersCSV.Trim(','));
            }
            Temp.BillMovers = new List<BillMovers>();
            Temp.BillMovers = GetBillMoverNames(Temp.MembersCSV.Trim(','));
            //Temp.MoverNames = GetBillMoverNames(Temp.BillMovers);
            Temp.BillMinisters = new List<BillMinisters>();
            Temp.BillMinisters = GetBillMinisters(Temp.BillsId);
            Temp.MinisterNames = GetBillMinisterNames(Temp.BillMinisters);
            Temp.BillDivisions = new List<BillDivisions>();
            Temp.BillDivisions = GetBillDivisions(Temp.BillsId);
            Temp.DivisionNames = GetBillDivisionNames(Temp.BillDivisions);
            return Temp;
        }
        public string GetBillMoverNamesCsv(string MoverIds)
        {
            //List<int> Ids= MoverIds
            //        .Split(',')
            //        .Select(int.Parse)
            //        .ToList();
            string Names = "";
            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                string query = "SELECT SYSTEM_USERS_ID,F_NAME from SYSTEM_USERS WHERE SYSTEM_USERS_ID IN(" + MoverIds + ")";
                SqlCommand cmd = new SqlCommand(query, con);
                using (con)
                {
                    SqlDataReader dr = cmd.ExecuteReader();

                    if (dr.HasRows)
                    {
                        while (dr.Read())
                        {
                            Names = Names + "," + Convert.ToString(dr["F_NAME"]);
                        }
                    }
                    return Names;
                }
            }
            finally
            {
                con.Close();

            }
        }
        public List<BillMovers> GetBillMoverNames(string MoverIds)
        {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                string query = "SELECT SYSTEM_USERS_ID,F_NAME from SYSTEM_USERS WHERE SYSTEM_USERS_ID IN(" + MoverIds + ")";
                SqlCommand cmd = new SqlCommand(query, con);
                List<BillMovers> movers = null; ;
                using (con)
                {
                    SqlDataReader dr = cmd.ExecuteReader();

                    if (dr.HasRows)
                    {
                        movers = new List<BillMovers>();
                        while (dr.Read())
                        {
                            BillMovers temp = new BillMovers();
                            temp.SystemUsersId = Convert.ToInt32(dr["SYSTEM_USERS_ID"]);
                            temp.Mover = Convert.ToString(dr["F_NAME"]);
                            movers.Add(temp);
                        }
                    }
                    return movers;
                }
            }
            finally
            {
                con.Close();

            }
        }
        protected Bills BindFields(SqlDataReader dr)
        {
            Bills Temp = new Bills();
            Temp.BillsId = Convert.ToInt32(dr["BILLS_ID"]);
            if (dr["BILL_STATUS_ID"] != DBNull.Value)
            {
                Temp.BillStatusId = Convert.ToInt32(dr["BILL_STATUS_ID"]);
                Temp.BillStatuses = new BillStatuses();
                Temp.BillStatuses.BillStatusesId = Convert.ToInt32(dr["BILL_STATUS_ID"]);
                Temp.BillStatuses.Description = Convert.ToString(dr["BILL_STATUS"]);
            }
            if (dr["Bill_TYPE_ID"] != DBNull.Value)
            {
                Temp.BillTypeId = Convert.ToInt32(dr["Bill_TYPE_ID"]);
                Temp.BillTypes = new BillTypes();
                Temp.BillTypes.BillTypesId = Convert.ToInt32(dr["BILL_TYPE_ID"]);
                Temp.BillTypes.Description = Convert.ToString(dr["BILL_TYPE"]);
            }
            if (dr["BILL_STAGES_ID"] != DBNull.Value)
            {
                Temp.BillStagesId = Convert.ToInt32(dr["BILL_STAGES_ID"]);
                Temp.BillStages = new BillStages();
                Temp.BillStages.BillStagesId = Convert.ToInt32(dr["BILL_STAGES_ID"]);
                Temp.BillStages.Description = Convert.ToString(dr["BILL_STAGE"]);
            }
            if (dr["ASSEMBLY_SESSIONS_ID"] != DBNull.Value)
            {
                Temp.AssemblySessionsId = Convert.ToInt32(dr["ASSEMBLY_SESSIONS_ID"]);
                Temp.AssemblySessions = new AssemblySessions();
                Temp.AssemblySessions.AssemblySessionsId = Convert.ToInt32(dr["ASSEMBLY_SESSIONS_ID"]);
                Temp.AssemblySessions.SessionNumber = Convert.ToInt32(dr["SESSION_NUMBER_DESC"]);
            }
            if (dr["HOUSE_TYPES_ID"] != DBNull.Value)
            {
                Temp.HouseTypesId = Convert.ToInt32(dr["HOUSE_TYPES_ID"]);
                Temp.HouseTypes = new HouseTypes();
                Temp.HouseTypes.HouseTypesId = Convert.ToInt32(dr["HOUSE_TYPES_ID"]);
                Temp.HouseTypes.Description = Convert.ToString(dr["HOUSE_TYPE"]);
            }

            if (dr["BILL_CATEGORIES_ID"] != DBNull.Value)
            {
                Temp.BillCategoriesId = Convert.ToInt32(dr["BILL_CATEGORIES_ID"]);
                Temp.BillCategories = new BillCategories();
                Temp.BillCategories.BillCategoriesId = Convert.ToInt32(dr["BILL_CATEGORIES_ID"]);
                Temp.BillCategories.Description = Convert.ToString(dr["BILL_CATEGORY"]);
            }
            if (dr["PARLIAMENTARY_YEAR_ID"] != DBNull.Value)
            {
                Temp.ParliamentaryYearId = Convert.ToInt32(dr["PARLIAMENTARY_YEAR_ID"]);
                Temp.ParliamentaryYears = new ParliamentaryYears();
                Temp.ParliamentaryYears.ParliamentaryYearsId = Convert.ToInt32(dr["PARLIAMENTARY_YEAR_ID"]);
                Temp.ParliamentaryYears.ParliamentaryYear = Convert.ToString(dr["PARLIAMENTARY_YEAR"]);
            }

            if (dr["STATUS_DATE"] != DBNull.Value)
                Temp.StatusDate = Convert.ToDateTime(dr["STATUS_DATE"]);
            if (dr["BILL_TITLE"] != DBNull.Value)
                Temp.BillTitle = Convert.ToString(dr["BILL_TITLE"]);
            if (dr["SESSION_SITTINGS_ID"] != DBNull.Value)
                Temp.SessionSittingsId = Convert.ToInt32(dr["SESSION_SITTINGS_ID"]);
            if (dr["LEGISLATION_DIARY_NO"] != DBNull.Value)
                Temp.LegislationDiaryNo = Convert.ToString(dr["LEGISLATION_DIARY_NO"]);
            if (dr["LEGISLATION_DIARY_DATE"] != DBNull.Value)
                Temp.LegislationDiaryDate = Convert.ToDateTime(dr["LEGISLATION_DIARY_DATE"]);
            if (dr["SNT_ENTRY_DATE"] != DBNull.Value)
                Temp.SntEntryDate = Convert.ToDateTime(dr["SNT_ENTRY_DATE"]);
            if (dr["IS_ACT"] != DBNull.Value)
                Temp.IsAct = Convert.ToInt32(dr["IS_ACT"]);
            if (dr["SECOND_READING_DATE"] != DBNull.Value)
                Temp.SecondReadindDate = Convert.ToDateTime(dr["SECOND_READING_DATE"]);
            if (dr["OTHER_HOUSE_RECEIPT_DATE"] != DBNull.Value)
                Temp.OtherHouseReceiptDate = Convert.ToDateTime(dr["OTHER_HOUSE_RECEIPT_DATE"]);
            if (dr["OTHER_HOUSE_RETURN_DATE"] != DBNull.Value)
                Temp.OtherHouseReturnDate = Convert.ToDateTime(dr["OTHER_HOUSE_RETURN_DATE"]);
            if (dr["CII_REPORT_DATE"] != DBNull.Value)
                Temp.CllReportDate = Convert.ToDateTime(dr["CII_REPORT_DATE"]);
            if (dr["LEAVE_GRANTED_BY"] != DBNull.Value)
                Temp.LeaveGrantedBy = Convert.ToString(dr["LEAVE_GRANTED_BY"]);
            if (dr["IS_SENT_TO_TRANSLATION"] != DBNull.Value)
                Temp.IsSentToTranslation = Convert.ToInt32(dr["IS_SENT_TO_TRANSLATION"]);

            if (dr["REVIEWED_BY"] != DBNull.Value)
                Temp.ReviewedBy = Convert.ToString(dr["REVIEWED_BY"]);
            if (dr["LEGISLATION_DIARY_TIME"] != DBNull.Value)
                Temp.LegislationDiaryTime = Convert.ToDateTime(dr["LEGISLATION_DIARY_TIME"]);
            if (dr["F_BILL_PRES_DATE"] != DBNull.Value)
                Temp.FBillPresDate = Convert.ToDateTime(dr["F_BILL_PRES_DATE"]);
            if (dr["SNT_ENTRY_TIME"] != DBNull.Value)
                Temp.SntEntryTime = Convert.ToDateTime(dr["SNT_ENTRY_TIME"]);

            if (dr["IS_WITH_NA"] != DBNull.Value)
                Temp.IsWithNa = Convert.ToInt32(dr["IS_WITH_NA"]);
            if (dr["THIRD_READING_DATE"] != DBNull.Value)
                Temp.ThirdReadingDate = Convert.ToDateTime(dr["THIRD_READING_DATE"]);

            if (dr["BILL_CIRC_DATE"] != DBNull.Value)
                Temp.BillCircDate = Convert.ToDateTime(dr["BILL_CIRC_DATE"]);
            if (dr["ACT_GAZETTE_PUB_DATE"] != DBNull.Value)
                Temp.ActGazettePubDate = Convert.ToDateTime(dr["ACT_GAZETTE_PUB_DATE"]);
            if (dr["BILL_YEAR"] != DBNull.Value)
                Temp.BillYear = Convert.ToInt32(dr["BILL_YEAR"]);
            if (dr["DESIGNATION"] != DBNull.Value)
                Temp.Designation = Convert.ToString(dr["DESIGNATION"]);
            if (dr["URDU_TEXT"] != DBNull.Value)
                Temp.UrduText = Convert.ToString(dr["URDU_TEXT"]);
            if (dr["REMARKS"] != DBNull.Value)
                Temp.Remarks = Convert.ToString(dr["REMARKS"]);
            if (dr["GOVT_BILL_DATE"] != DBNull.Value)
                Temp.GovtBillDate = Convert.ToDateTime(dr["GOVT_BILL_DATE"]);
            if (dr["DISCUSS_DAYS"] != DBNull.Value)
                Temp.DiscussDays = Convert.ToInt32(dr["DISCUSS_DAYS"]);
            if (dr["SNT_REFERENCE"] != DBNull.Value)
                Temp.SntReference = Convert.ToString(dr["SNT_REFERENCE"]);
            if (dr["AND_WHEREAS"] != DBNull.Value)
                Temp.AndWhereas = Convert.ToString(dr["AND_WHEREAS"]);
            if (dr["IS_ENTERED_BY_MEMBER"] != DBNull.Value)
                Temp.IsEnteredByMember = Convert.ToInt32(dr["IS_ENTERED_BY_MEMBER"]);
            if (dr["MINISTER_NOTICE_DATE"] != DBNull.Value)
                Temp.MinisterNoticeDate = Convert.ToDateTime(dr["MINISTER_NOTICE_DATE"]);
            if (dr["PUBLIC_OPINION"] != DBNull.Value)
                Temp.PublicOpinion = Convert.ToString(dr["PUBLIC_OPINION"]);
            if (dr["PRESIDENT_ASSENT_DATE"] != DBNull.Value)
                Temp.PresidentAssentDate = Convert.ToDateTime(dr["PRESIDENT_ASSENT_DATE"]);
            if (dr["LEAVE_GRANTE_DATE"] != DBNull.Value)
                Temp.LeaveGranteDate = Convert.ToDateTime(dr["LEAVE_GRANTE_DATE"]);
            if (dr["AMENDED_CONTENT"] != DBNull.Value)
                Temp.AmendedContent = Convert.ToString(dr["AMENDED_CONTENT"]);
            if (dr["CURRENT_ROLE"] != DBNull.Value)
                Temp.CurrentRole = Convert.ToString(dr["CURRENT_ROLE"]);
            if (dr["IS_ACTIVE"] != DBNull.Value)
                Temp.IsActive = Convert.ToInt32(dr["IS_ACTIVE"]);
            if (dr["MOTION_DATE"] != DBNull.Value)
                Temp.MotionDate = Convert.ToDateTime(dr["MOTION_DATE"]);
            if (dr["PARTICIPATED_MEMBERS"] != DBNull.Value)
                Temp.ParticipatedMembers = Convert.ToInt32(dr["PARTICIPATED_MEMBERS"]);
            if (dr["SNT_RECOMMENDATION"] != DBNull.Value)
                Temp.SntRecommendation = Convert.ToString(dr["SNT_RECOMMENDATION"]);
            if (dr["BILL_GAZETTED_DATE"] != DBNull.Value)
                Temp.BillGazettedDate = Convert.ToDateTime(dr["BILL_GAZETTED_DATE"]);
            if (dr["NOW_THEREFORE"] != DBNull.Value)
                Temp.NowTherefore = Convert.ToString(dr["NOW_THEREFORE"]);
            if (dr["MED_CMT_REF_DATE"] != DBNull.Value)
                Temp.MedCmtRefDate = Convert.ToDateTime(dr["MED_CMT_REF_DATE"]);
            if (dr["NOTICE_CIRC_DATE"] != DBNull.Value)
                Temp.NoticeCircDate = Convert.ToDateTime(dr["NOTICE_CIRC_DATE"]);
            if (dr["CII_OPINION"] != DBNull.Value)
                Temp.CiiOpinion = Convert.ToString(dr["CII_OPINION"]);
            if (dr["FINANCE_BILL_REFERENCE"] != DBNull.Value)
                Temp.FinanceBillReference = Convert.ToString(dr["FINANCE_BILL_REFERENCE"]);
            if (dr["IS_WITH_MED_COMMITTEE"] != DBNull.Value)
                Temp.IswithSatndingCommitee = Convert.ToInt32(dr["IS_WITH_MED_COMMITTEE"]);
            if (dr["MEM_BILL_SUBJECT"] != DBNull.Value)
                Temp.MemBillSubject = Convert.ToString(dr["MEM_BILL_SUBJECT"]);
            if (dr["NOTICE_DIARY_DATE"] != DBNull.Value)
                Temp.NoticeDiaryDate = Convert.ToDateTime(dr["NOTICE_DIARY_DATE"]);
            if (dr["BILL_PASSAGE_DATE"] != DBNull.Value)
                Temp.BillPassageDate = Convert.ToDateTime(dr["BILL_PASSAGE_DATE"]);
            if (dr["GOVT_P_MEMBERS"] != DBNull.Value)
                Temp.GovtPMembers = Convert.ToInt32(dr["GOVT_P_MEMBERS"]);
            if (dr["BILL_IDENTIFIER"] != DBNull.Value)
                Temp.BillIdentifier = Convert.ToString(dr["BILL_IDENTIFIER"]);
            if (dr["SEND_TO_NA_DATE"] != DBNull.Value)
                Temp.SentToNaDate = Convert.ToDateTime(dr["SEND_TO_NA_DATE"]);
            if (dr["RECEIVED_FROM_NA_DATE"] != DBNull.Value)
                Temp.ReceivedFromNADate = Convert.ToDateTime(dr["RECEIVED_FROM_NA_DATE"]);

            if (dr["PASSED_BY_NA_DATE"] != DBNull.Value)
                Temp.PassedByNADate = Convert.ToDateTime(dr["PASSED_BY_NA_DATE"]);

            if (dr["NA_REMARKS"] != DBNull.Value)
                Temp.NARemarks = Convert.ToString(dr["NA_REMARKS"]);
            if (dr["WITHDRAWAL_DATE"] != DBNull.Value)
                Temp.WithdrawalDate = Convert.ToDateTime(dr["WITHDRAWAL_DATE"]);
            if (dr["MED_CMT_PRES_DATE"] != DBNull.Value)
                Temp.MedCmtPresDate = Convert.ToDateTime(dr["MED_CMT_PRES_DATE"]);
            if (dr["LAW_DIV_SENT_DATE"] != DBNull.Value)
                Temp.LawDivSentDate = Convert.ToDateTime(dr["LAW_DIV_SENT_DATE"]);
            if (dr["PUBLIC_OPINION_CIRC_DATE"] != DBNull.Value)
                Temp.PublicOpinionCircDate = Convert.ToDateTime(dr["PUBLIC_OPINION_CIRC_DATE"]);
            if (dr["IS_SENT_TO_SENATE"] != DBNull.Value)
                Temp.IsSentToSenate = Convert.ToInt32(dr["IS_SENT_TO_SENATE"]);
            if (dr["SUBJECT"] != DBNull.Value)
                Temp.Subject = Convert.ToString(dr["SUBJECT"]);
            if (dr["MEM_BILL_CONTENT"] != DBNull.Value)
                Temp.MemBillContent = Convert.ToString(dr["MEM_BILL_CONTENT"]);
            if (dr["PRIORITY"] != DBNull.Value)
                Temp.Priority = Convert.ToInt32(dr["PRIORITY"]);
            if (dr["NOTICE_DIARY_NO"] != DBNull.Value)
                Temp.NoticeDiaryNo = Convert.ToInt32(dr["NOTICE_DIARY_NO"]);
            if (dr["BILL_ASSENT_DATE"] != DBNull.Value)
                Temp.BillAssentDate = Convert.ToDateTime(dr["BILL_ASSENT_DATE"]);
            if (dr["OPP_P_MEMBERS"] != DBNull.Value)
                Temp.OppPMembers = Convert.ToInt32(dr["OPP_P_MEMBERS"]);
            if (dr["FILE_NUMBER"] != DBNull.Value)
                Temp.FileNumber = Convert.ToString(dr["FILE_NUMBER"]);
            if (dr["IS_WITH_PRESIDENT"] != DBNull.Value)
                Temp.IsWithPresident = Convert.ToInt32(dr["IS_WITH_PRESIDENT"]);
            if (dr["FIRST_READING_DATE"] != DBNull.Value)
                Temp.FirstReadingDate = Convert.ToDateTime(dr["FIRST_READING_DATE"]);
            if (dr["AGREED_BILL_CONS_DATE"] != DBNull.Value)
                Temp.AgreedBillConsDate = Convert.ToDateTime(dr["AGREED_BILL_CONS_DATE"]);
            if (dr["LAW_DIV_REC_DATE"] != DBNull.Value)
                Temp.LawDivRecDate = Convert.ToDateTime(dr["LAW_DIV_REC_DATE"]);
            if (dr["PUBLIC_OPINION_DATE"] != DBNull.Value)
                Temp.PublicOpinionDate = Convert.ToDateTime(dr["PUBLIC_OPINION_DATE"]);
            if (dr["IS_SENT_TO_COMMITTEE"] != DBNull.Value)
                Temp.IsSentToCommittee = Convert.ToInt32(dr["IS_SENT_TO_COMMITTEE"]);
            if (dr["REJECT_AMEND_DATE"] != DBNull.Value)
                Temp.RejectAmendDate = Convert.ToDateTime(dr["REJECT_AMEND_DATE"]);
            if (dr["NOTICE_DIARY_TIME"] != DBNull.Value)
                Temp.NoticeDiaryTime = Convert.ToDateTime(dr["NOTICE_DIARY_TIME"]);
            if (dr["IS_WITH_STANDING_COMMITTEE"] != DBNull.Value)
                Temp.IswithSatndingCommitee = Convert.ToInt32(dr["IS_WITH_STANDING_COMMITTEE"]);
            if (dr["SNT_REC_DATE"] != DBNull.Value)
                Temp.SntRecDate = Convert.ToDateTime(dr["SNT_REC_DATE"]);
            if (dr["PASSED_AS_REPT_BY_SC"] != DBNull.Value)
                Temp.PassedAsReptBySc = Convert.ToString(dr["PASSED_AS_REPT_BY_SC"]);
            if (dr["SEND_TO_PRESIDENT_DATE"] != DBNull.Value)
                Temp.SendToPresidentDate = Convert.ToDateTime(dr["SEND_TO_PRESIDENT_DATE"]);
            if (dr["AGREED_BILL_PASS_DATE"] != DBNull.Value)
                Temp.AgreedBillPassDate = Convert.ToDateTime(dr["AGREED_BILL_PASS_DATE"]);
            if (dr["OTHER_HOUSE_INTIMATE_DATE"] != DBNull.Value)
                Temp.OtherHouseIntimateDate = Convert.ToDateTime(dr["OTHER_HOUSE_INTIMATE_DATE"]);
            if (dr["CII_REFER_DATE"] != DBNull.Value)
                Temp.CiiOpinion = Convert.ToString(dr["CII_REFER_DATE"]);
            if (dr["IS_LEAVE_GRANTE"] != DBNull.Value)
                Temp.IsLeaveGranted = Convert.ToInt32(dr["IS_LEAVE_GRANTE"]);
            if (dr["LETTER"] != DBNull.Value)
                Temp.Letter = Convert.ToString(dr["LETTER"]);
            if (dr["BILL_DATE"] != DBNull.Value)
                Temp.BillDate = Convert.ToDateTime(dr["BILL_DATE"]);
            if (dr["LEGISLATION_DIARY_NO"] != DBNull.Value)
                Temp.LegislationDiaryNo = Convert.ToString(dr["LEGISLATION_DIARY_NO"]);
            if (dr["SNT_REC_TIME"] != DBNull.Value)
                Temp.SntRecTime = Convert.ToDateTime(dr["SNT_REC_TIME"]);
            if (dr["PASSED_WO_ST_CMT"] != DBNull.Value)
                Temp.PassedWoStCmt = Convert.ToString(dr["PASSED_WO_ST_CMT"]);
            if (dr["NOTING"] != DBNull.Value)
                Temp.Noting = Convert.ToString(dr["NOTING"]);
            if (dr["BILL_TIME"] != DBNull.Value)
                Temp.BillTime = Convert.ToDateTime(dr["BILL_TIME"]);
            if (dr["BILL_FILE"] != DBNull.Value)
                Temp.BillFile = Convert.ToString(dr["BILL_FILE"]);
            if (dr["NOTICE_FILE"] != DBNull.Value)
                Temp.NoticeFile = Convert.ToString(dr["NOTICE_FILE"]);
            if (dr["BILL_INTRODUCE_DATE"] != DBNull.Value)
                Temp.IntroducedInHouseOn = Convert.ToDateTime(dr["BILL_INTRODUCE_DATE"]);
            if (dr["COMMITTEE_ID"] != DBNull.Value)
                Temp.CommitteeId = Convert.ToInt32(dr["COMMITTEE_ID"]);
            if (dr["COMMITTEE_DAYS_LIMIT"] != DBNull.Value)
                Temp.CommitteeTimeLimit = Convert.ToInt32(dr["COMMITTEE_DAYS_LIMIT"]);
            if (dr["COMMITTEE_RECOMMENDATION_ID"] != DBNull.Value)
                Temp.CommitteeRecommendationId = Convert.ToInt32(dr["COMMITTEE_RECOMMENDATION_ID"]);
            if (dr["COMMITTEE_NAME"] != DBNull.Value)
                Temp.CommitteeName = Convert.ToString(dr["COMMITTEE_NAME"]);
            if (dr["COMMITTEE_REF_DATE"] != DBNull.Value)
                Temp.CommitteeRefDate = Convert.ToDateTime(dr["COMMITTEE_REF_DATE"]);
            if (dr["COMMITTEE_REMARKS"] != DBNull.Value)
                Temp.CommitteeRemarks = Convert.ToString(dr["COMMITTEE_REMARKS"]);
            if (dr["COMMITTEE_REPORT_FILE"] != DBNull.Value)
                Temp.CommitteeReportFile = Convert.ToString(dr["COMMITTEE_REPORT_FILE"]);
            if (dr["COMMITTEE_REPORT_DATE"] != DBNull.Value)
                Temp.CommitteeReportDate = Convert.ToDateTime(dr["COMMITTEE_REPORT_DATE"]);
            if (dr["MEMBERS"] != DBNull.Value)
                Temp.MembersCSV = Convert.ToString(dr["MEMBERS"]);
            if (dr["MINISTERS"] != DBNull.Value)
                Temp.MinistersCSV = Convert.ToString(dr["MINISTERS"]);
            if (dr["DIVISIONS"] != DBNull.Value)
                Temp.DivisionsCSV = Convert.ToString(dr["DIVISIONS"]);

            if (dr["MEMBER_WITHDRAWAL_STATUS_ID"] != DBNull.Value)
                Temp.MemberWithdrawStatusId = Convert.ToInt32(dr["MEMBER_WITHDRAWAL_STATUS_ID"]);
            if (dr["CONSIDERATION_SESSION_ID"] != DBNull.Value)
                Temp.ConsiderationSessionId = Convert.ToInt32(dr["CONSIDERATION_SESSION_ID"]);

            if (dr["MEMBER_WITHDRAWAL_STATUS_DATE"] != DBNull.Value)
                Temp.MemberWithdrawStatusDate = Convert.ToDateTime(dr["MEMBER_WITHDRAWAL_STATUS_DATE"]);
            if (dr["HOUSE_FOR_CONSIDERATION_DATE"] != DBNull.Value)
                Temp.HouseForConsiderationDate = Convert.ToDateTime(dr["HOUSE_FOR_CONSIDERATION_DATE"]);
            if (dr["MEMBER_REMARKS"] != DBNull.Value)
                Temp.MemberRemarks = Convert.ToString(dr["MEMBER_REMARKS"]);


            if (dr["UPDATED_BY"] != DBNull.Value)
                Temp.UpdatedBy = Convert.ToInt32(dr["UPDATED_BY"]);
            if (dr["UPDATED_ON"] != DBNull.Value)
                Temp.UpdatedOn = Convert.ToDateTime(dr["UPDATED_ON"]);
            if (dr["INSERTED_BY"] != DBNull.Value)
                Temp.InsertedBy = Convert.ToInt32(dr["INSERTED_BY"]);
            if (dr["INSERTED_ON"] != DBNull.Value)
                Temp.InsertedOn = Convert.ToDateTime(dr["INSERTED_ON"]);
            if (dr["DELETED_BY"] != DBNull.Value)
                Temp.DeletedBy = Convert.ToInt32(dr["DELETED_BY"]);
            if (dr["DELETED_ON"] != DBNull.Value)
                Temp.DeletedOn = Convert.ToDateTime(dr["DELETED_ON"]);
            if (dr["RECOVERED_BY"] != DBNull.Value)
                Temp.RecoveredBy = Convert.ToInt32(dr["RECOVERED_BY"]);
            if (dr["RECOVERED_ON"] != DBNull.Value)
                Temp.RecoveredOn = Convert.ToDateTime(dr["RECOVERED_ON"]);
            Temp.BillMovers = new List<BillMovers>();
            Temp.BillMovers = GetBillMovers(Temp.BillsId);
            Temp.MoverNames = GetBillMoverNames(Temp.BillMovers);
            Temp.BillMinisters = new List<BillMinisters>();
            Temp.BillMinisters = GetBillMinisters(Temp.BillsId);
            Temp.MinisterNames = GetBillMinisterNames(Temp.BillMinisters);
            Temp.BillDivisions = new List<BillDivisions>();
            Temp.BillDivisions = GetBillDivisions(Temp.BillsId);
            Temp.DivisionNames = GetBillDivisionNames(Temp.BillDivisions);
            return Temp;
        }
        #endregion BILLS
        protected string GetBillMoverNames(List<BillMovers> billMovers)
        {
            string movers = "";
            if (billMovers != null)
            {
                foreach (BillMovers mover in billMovers)
                {
                    movers += mover.Mover + ", ";
                }

            }
            return movers;
        }
        protected string GetBillMinisterNames(List<BillMinisters> billMinisters)
        {
            string movers = "";
            if (billMinisters != null)
            {
                foreach (BillMinisters mover in billMinisters)
                {
                    movers += mover.MinisterName + ", ";
                }

            }
            return movers;
        }
        protected string GetBillDivisionNames(List<BillDivisions> billDivisions)
        {
            string movers = "";
            if (billDivisions != null)
            {
                foreach (BillDivisions mover in billDivisions)
                {
                    movers += mover.Division + ", ";
                }

            }
            return movers;
        }

        #region Misc
        #region Member
        //public List<MemberStatuses> GetMemberStatuses()
        //{
        //    SqlConnection con = new DalHelper().GetConnection();
        //    try
        //    {
        //        SqlCommand cmd = new SqlCommand("[dbo].[Administrations_CRUD]", con);
        //        cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "GET_MEMBER_STATUSES";
        //        cmd.CommandType = CommandType.StoredProcedure;
        //        List<MemberStatuses> MyList = null;
        //        SqlDataReader dr = cmd.ExecuteReader();
        //        if (dr.HasRows)
        //        {
        //            MyList = new List<MemberStatuses>();
        //            while (dr.Read())
        //            {
        //                MemberStatuses Temp = new MemberStatuses();

        //                Temp.MemberStatusId = Convert.ToInt32(dr["Member_Statuses_Id"]);
        //                Temp.MemberStatus = Convert.ToString(dr["Description"]);
        //                Temp.IsActive = Convert.ToInt32(dr["Is_Active"]);
        //                MyList.Add(Temp);
        //            }
        //        }

        //        if (MyList != null) MyList.TrimExcess();
        //        return MyList;
        //    }
        //    finally
        //    {
        //        con.Close();

        //    }
        //}

        public List<Member> GetMemberByName(string MemberName)
        {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[Question_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "GET_ALL_MEMBERS_BY_NAME";
                cmd.Parameters.Add("@MemberName", SqlDbType.VarChar).Value = MemberName;
                cmd.CommandType = CommandType.StoredProcedure;
                List<Member> MyList = null;
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    MyList = new List<Member>();
                    while (dr.Read())
                    {
                        Member Temp = new Member();

                        Temp.MemberId = Convert.ToInt32(dr["SYSTEM_USERS_ID"]);
                        Temp.MemberName = Convert.ToString(dr["Senator_Name"]);
                        Temp.IsActive = Convert.ToInt32(dr["MEMBER_STATUS"]);
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

        public List<Member> GetMemberMinisterByName(string MemberName)
        {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[Question_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "GET_MEMBERS_MINISTER_BY_NAME";
                cmd.Parameters.Add("@MemberName", SqlDbType.VarChar).Value = MemberName;
                cmd.CommandType = CommandType.StoredProcedure;
                List<Member> MyList = null;
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    MyList = new List<Member>();
                    while (dr.Read())
                    {
                        Member Temp = new Member();

                        Temp.MemberId = Convert.ToInt32(dr["SYSTEM_USERS_ID"]);
                        Temp.MemberName = Convert.ToString(dr["Senator_Name"]);
                        Temp.IsActive = Convert.ToInt32(dr["MEMBER_STATUS"]);
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



        public List<Member> GetAllMemberByName(string MemberName)
        {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[Question_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "GET_ALL_MEMBERS_BY_NAME";
                cmd.Parameters.Add("@MemberName", SqlDbType.VarChar).Value = MemberName;
                cmd.CommandType = CommandType.StoredProcedure;
                List<Member> MyList = null;
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    MyList = new List<Member>();
                    while (dr.Read())
                    {
                        Member Temp = new Member();

                        Temp.MemberId = Convert.ToInt32(dr["SYSTEM_USERS_ID"]);
                        Temp.MemberName = Convert.ToString(dr["Senator_Name"]);
                        Temp.IsActive = Convert.ToInt32(dr["MEMBER_STATUS"]);
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
        public List<Member> GetMembersByStatus(int StatusId)
        {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[Question_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "GET_MEMBERS_BY_STATUS";
                cmd.Parameters.Add("@MemberStatusId", SqlDbType.Int).Value = StatusId;
                cmd.CommandType = CommandType.StoredProcedure;
                List<Member> MyList = null;
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    MyList = new List<Member>();
                    while (dr.Read())
                    {
                        Member Temp = new Member();
                        string membername = "";
                        if (dr["F_Name"] != DBNull.Value)
                            membername = Convert.ToString(dr["F_Name"]);
                        if (dr["M_Name"] != DBNull.Value)
                            membername += " " + Convert.ToString(dr["M_Name"]);
                        if (dr["L_Name"] != DBNull.Value)
                            membername += " " + Convert.ToString(dr["L_Name"]);
                        Temp.MemberId = Convert.ToInt32(dr["SYSTEM_USERS_ID"]);
                        Temp.MemberName = membername;
                        Temp.IsActive = Convert.ToInt32(dr["MEMBER_STATUS"]);
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
        #endregion Member
        public List<Divisions> GetCurrentDivisionsByName(string DivisionName)
        {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[Question_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "GET_CURRENT_DIVISION_BY_NAME";
                cmd.Parameters.Add("@Division", SqlDbType.VarChar).Value = DivisionName;
                cmd.CommandType = CommandType.StoredProcedure;
                List<Divisions> MyList = null;
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    MyList = new List<Divisions>();
                    while (dr.Read())
                    {
                        Divisions Temp = new Divisions();

                        Temp.DivisionsId = Convert.ToInt32(dr["Divisions_Id"]);
                        Temp.Description = Convert.ToString(dr["Description"]);
                        //Temp.IsActive = Convert.ToInt32(dr["Is_Active"]);
                        //Temp.MinistriesId = Convert.ToInt32(dr["Ministries_Id"]);
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
        public string GetPassword()
        {
            return "X#Bv7_4qT!Ma";
        }
        public List<Ministers> GetMinistersByName(string MinisterName)
        {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[LEGISLATION_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "GET_MINISTERS_BY_NAME";
                cmd.Parameters.Add("@MinisterName", SqlDbType.VarChar).Value = MinisterName;
                cmd.CommandType = CommandType.StoredProcedure;
                List<Ministers> MyList = null;
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    MyList = new List<Ministers>();
                    while (dr.Read())
                    {
                        Ministers Temp = new Ministers();
                        Temp.MinisterId = Convert.ToInt32(dr["MINISTER_ID"]);
                        Temp.MinisterName = Convert.ToString(dr["MINISTER_NAME"]);
                        //Temp.PoliticalPartyId = Convert.ToInt32(dr["POLITICAL_PARTY_ID"]);
                        //Temp.PoliticalParty = Convert.ToString(dr["PARTY_NAME"]);
                        //Temp.GenderId = Convert.ToInt32(dr["GENDERS_ID"]);
                        //Temp.Gender = Convert.ToString(dr["GENDER"]);
                        //Temp.PoliticalPartyId = Convert.ToInt32(dr["POLITICAL_PARTY_ID"]);
                        //Temp.IsActive = Convert.ToInt32(dr["IS_ACTIVE"]);
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
        public void InsertBillFile(string file, int BillId)
        {
            SqlConnection con = new DalHelper().GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[NOTICE_CRUD]", con);
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "INSERT_BILL_FILE";
                cmd.Parameters.Add("@BillsId", SqlDbType.Int).Value = BillId;
                cmd.Parameters.Add("@BillFile", SqlDbType.VarChar).Value = file;
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
    }
}
