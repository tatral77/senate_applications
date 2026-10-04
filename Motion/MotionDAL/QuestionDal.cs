using Entities;
using MotionEntities;
using QuestionDAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace MotionDAL
{
    public class QuestionDal
    {
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
		public List<Question> GetQuestions(int AssemblySessionsId)
		{
			SqlConnection con = new DalHelper().GetConnection();
			try
			{

				SqlCommand cmd = new SqlCommand("[dbo].[Question_CRUD]", con);
				cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "GET_QUESTIONS";
				cmd.Parameters.Add("@AssemblySessionId", SqlDbType.VarChar).Value = AssemblySessionsId;
				cmd.CommandType = CommandType.StoredProcedure;
				List<Question> MyList = null;
				SqlDataReader dr = cmd.ExecuteReader();
				if (dr.HasRows)
				{
					MyList = new List<Question>();
					while (dr.Read())
					{
						Question Temp = new Question();
						Temp.QuestionsId = Convert.ToInt32(dr["Questions_Id"]);
						Temp.ParliamentaryYear = Convert.ToString(dr["Parliamentary_Year"]);
						if (dr["Mover"] != DBNull.Value)
						{
							Temp.Mover = Convert.ToInt32(dr["Mover"]);
							Temp.MoverName = Convert.ToString(dr["F_Name"]);
						}
						Temp.ListId = Convert.ToInt32(dr["List_No"]);
						if (dr["Question_Date"] != DBNull.Value)
							Temp.QuestionDate = Convert.ToDateTime(dr["Question_Date"]);
						Temp.QuestionCategory = Convert.ToString(dr["Category"]);
						Temp.QuestionStatus = Convert.ToString(dr["Question_Status"]);
						if (dr["STATUS_DATE"] != DBNull.Value)
							Temp.QuestionStatusDate = Convert.ToDateTime(dr["STATUS_DATE"]);
						if (dr["REPLY_DATE"] != DBNull.Value)
							Temp.QuestionStatusDate = Convert.ToDateTime(dr["REPLY_DATE"]);

						if (dr["QUESTION_DIARY_DATE"] != DBNull.Value)
							Temp.QuestionDiaryDate = Convert.ToDateTime(dr["QUESTION_DIARY_DATE"]);
						if (dr["Question_Time"] != DBNull.Value)
							Temp.QuestionTime = Convert.ToString(dr["Question_Time"]);
						if (dr["Subject"] != DBNull.Value)
						{
							Temp.Subject = Convert.ToString(dr["Subject"]);
							//if(Temp.Subject.Length>42)
							//Temp.Subject = Temp.Subject.Substring(43);
						}
						Temp.QuestionText = Convert.ToString(dr["Question_Text"]);
						if (dr["Urdu_Text"] != DBNull.Value)
							Temp.UrduText = Convert.ToString(dr["Urdu_Text"]);
						if (dr["Question_File"] != DBNull.Value)
							Temp.QuestionFile = Convert.ToString(dr["Question_File"]);

						Temp.Ministry = Convert.ToString(dr["Ministry"]);
						Temp.MinistryGroup = Convert.ToString(dr["Ministry_Group"]);
						Temp.DivisionId = Convert.ToInt32(dr["Division"]);
						Temp.Division = Convert.ToString(dr["DIVISION_NAME"]);
						// Temp.DepartmentsId = Convert.ToInt32(dr["Departments_Id"]);
						// Temp.Department = Convert.ToString(dr["Deptt_Name"]);
						//Temp.NoticeDiaryNo = Convert.ToInt32(dr["Notice_Diary_No"]);
						//Temp.NoticeDiaryDate = Convert.ToDateTime(dr["Notice_Diary_Date"]);
						if (dr["Notice_Diary_No"] != DBNull.Value)
							Temp.NoticeDiaryNo = Convert.ToInt32(dr["Notice_Diary_No"]);
						Temp.NoticeDiaryTime = Convert.ToDateTime(dr["Notice_Diary_Time"]);
						Temp.NoticeDiaryDate = Convert.ToDateTime(dr["Notice_Diary_Date"]);
						//Temp.AdmittedNumber = Convert.ToString(dr["Admitted_Number"]);
						if (dr["Question_Diary_No"] != DBNull.Value)
							Temp.QuestionDiaryNo = Convert.ToInt32(dr["Question_Diary_No"]);
						//Temp.QuestionDiaryDate = Convert.ToDateTime(dr["Question_Diary_Date"]);

						// Temp.QuestionDiaryTime = Convert.ToDateTime(dr["Question_Diary_Time"]);
						Temp.SessionNumberId = Convert.ToInt32(dr["Session_Number"]);
						Temp.SessionNumber = Convert.ToString(dr["Session_Name"]);
						Temp.IsCarryFwd = Convert.ToInt32(dr["Is_Carry_Fwd"]);
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

		public List<Question> SearchQuestion(string query)
		{
			SqlConnection con = new DalHelper().GetConnection();
			try
			{
				SqlCommand cmd = new SqlCommand(query, con);
				List<Question> emp = null;
				using (con)
				{
					SqlDataReader dr = cmd.ExecuteReader();
					if (dr.HasRows)
					{
						emp = new List<Question>();
						while (dr.Read())
						{
							Question Temp = new Question();
							Temp.QuestionsId = Convert.ToInt32(dr["Questions_Id"]);
							Temp.ParliamentaryYear = Convert.ToString(dr["Parliamentary_Year"]);
							Temp.ListId = Convert.ToInt32(dr["List_No"]);
							if (dr["Mover"] != DBNull.Value)
							{
								Temp.Mover = Convert.ToInt32(dr["Mover"]);
								Temp.MoverName = Convert.ToString(dr["F_Name"]);
							}
							if (dr["Question_Date"] != DBNull.Value)
								Temp.QuestionDate = Convert.ToDateTime(dr["Question_Date"]);
							Temp.QuestionCategory = Convert.ToString(dr["Category"]);
							Temp.QuestionStatus = Convert.ToString(dr["Question_Status"]);
							if (dr["Status_Date"] != DBNull.Value)
								Temp.QuestionStatusDate = Convert.ToDateTime(dr["Status_Date"]);
							if (dr["Reply_Date"] != DBNull.Value)
								Temp.QuestionStatusDate = Convert.ToDateTime(dr["Reply_Date"]);
							if (dr["QUESTION_DIARY_DATE"] != DBNull.Value)
								Temp.QuestionDiaryDate = Convert.ToDateTime(dr["QUESTION_DIARY_DATE"]);
							if (dr["Question_Time"] != DBNull.Value)
								Temp.QuestionTime = Convert.ToString(dr["Question_Time"]);
							if (dr["Subject"] != DBNull.Value)
							{
								Temp.Subject = Convert.ToString(dr["Subject"]);
								//if(Temp.Subject.Length>42)
								//Temp.Subject = Temp.Subject.Substring(43);
							}
							Temp.QuestionText = Regex.Replace(Convert.ToString(dr["Question_Text"]), @"<[^>]+>|&nbsp;", "").Trim();
							if (!string.IsNullOrEmpty(Temp.UrduText))
								Temp.UrduText = Convert.ToString(dr["Urdu_Text"]);
							Temp.Ministry = Convert.ToString(dr["Ministry"]);
							if (dr["Ministry_Group"] != DBNull.Value)
								Temp.MinistryGroup = Convert.ToString(dr["Ministry_Group"]);
							Temp.DivisionId = Convert.ToInt32(dr["Division"]);
							Temp.Division = Convert.ToString(dr["Division_Name"]);
							// Temp.DivisionId=
							// Temp.DepartmentsId = Convert.ToInt32(dr["Departments_Id"]);
							// Temp.Department = Convert.ToString(dr["Deptt_Name"]);
							if (dr["Notice_Diary_No"] != DBNull.Value)
								Temp.NoticeDiaryNo = Convert.ToInt32(dr["Notice_Diary_No"]);
							//Temp.NoticeDiaryDate = Convert.ToDateTime(dr["Notice_Diary_Date"]);
							Temp.NoticeDiaryTime = Convert.ToDateTime(dr["Notice_Diary_Time"]);
							if (dr["Notice_Diary_Date"] != DBNull.Value)
								Temp.NoticeDiaryDate = Convert.ToDateTime(dr["Notice_Diary_Date"]);
							//Temp.AdmittedNumber = Convert.ToString(dr["Admitted_Number"]);
							if (dr["Question_Diary_No"] != DBNull.Value)
								Temp.QuestionDiaryNo = Convert.ToInt32(dr["Question_Diary_No"]);
							//Temp.QuestionDiaryDate = Convert.ToDateTime(dr["Question_Diary_Date"]);
							// Temp.QuestionDiaryTime = Convert.ToDateTime(dr["Question_Diary_Time"]);
							Temp.SessionNumberId = Convert.ToInt32(dr["Session_Number"]);
							Temp.SessionNumber = Convert.ToString(dr["Session_Name"]);
							Temp.IsCarryFwd = Convert.ToInt32(dr["Is_Carry_Fwd"]);
							if (dr["Session_Sittings_Id"] != DBNull.Value)
								Temp.SessionSittingsId = Convert.ToInt32(dr["Session_Sittings_Id"]);
							emp.Add(Temp);

						}
					}

					if (emp != null) emp.TrimExcess();
					return emp;
				}
			}
			finally
			{
				con.Close();
			}
		}
		public List<Groups> GetSessionGroups(int AssemplySessionsId, int CategoryId)
		{
			SqlConnection con = new DalHelper().GetConnection();
			try
			{
				SqlCommand cmd = new SqlCommand("[dbo].[Question_CRUD]", con);
				if (CategoryId == 1 || CategoryId == 3)
					cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "GET_SESSION_GROUPS";
				else if (CategoryId == 2)
					cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "GET_UNSTARRED_GROUPS";
				else
					cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "";


				cmd.Parameters.Add("@AssemblySessionId", SqlDbType.Int).Value = AssemplySessionsId;
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
		public Groups GetGroupById(int GroupId)
		{
			SqlConnection con = new DalHelper().GetConnection();
			try
			{
				SqlCommand cmd = new SqlCommand("[dbo].[Question_CRUD]", con);
				cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "GET_GROUP";
				cmd.Parameters.Add("@GroupsId", SqlDbType.Int).Value = GroupId;
				cmd.CommandType = CommandType.StoredProcedure;
				Groups Temp = null;
				SqlDataReader dr = cmd.ExecuteReader();
				if (dr.HasRows)
				{
					dr.Read();
					Temp = new Groups();
					Temp.GroupsId = Convert.ToInt32(dr["Groups_Id"]);
					Temp.Description = Convert.ToString(dr["Group_Name"]);
					Temp.IsActive = Convert.ToInt32(dr["Is_Active"]);
					Temp.AssembliesSessionId = Convert.ToInt32(dr["Assembly_Sessions_Id"]);
					//Temp.AssembliesSession = Convert.ToString(dr["Session_Number"]);
					Temp.CorrespondingGroup = Convert.ToInt32(dr["Corresponding_Group"]);
					Temp.GroupSequence = Convert.ToInt32(dr["Group_Sequence"]);
					Temp.UnstarDesc = Convert.ToString(dr["Unstar_Desc"]);


				}

				return Temp;
			}
			finally
			{
				con.Close();

			}
		}
		public Question GetQuestionById(int QuestionId)
		{
			SqlConnection con = new DalHelper().GetConnection();
			try
			{
				SqlCommand cmd = new SqlCommand("[dbo].[Question_CRUD]", con);
				cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "GET_QUESTION_BY_ID";
				cmd.Parameters.Add("@QuestionsId", SqlDbType.VarChar).Value = QuestionId;
				cmd.CommandType = CommandType.StoredProcedure;
				Question Temp = new Question();
				SqlDataReader dr = cmd.ExecuteReader();
				if (dr.HasRows)
				{
					dr.Read();
					Temp.QuestionsId = Convert.ToInt32(dr["Questions_Id"]);
					Temp.ParliamentaryYear = Convert.ToString(dr["Parliamentary_Year"]);
					Temp.QuestionStatus = Convert.ToString(dr["Question_Statusdesc"]);
					Temp.ListId = Convert.ToInt32(dr["LIST_NO"]);
					Temp.SupNo = Convert.ToString(dr["SUP_NO"]);
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
					Temp.QuestionStatusId = Convert.ToInt32(dr["Question_Status"]);

					if (dr["Question_Date"] != DBNull.Value)
						Temp.QuestionDate = Convert.ToDateTime(dr["Question_Date"]);
					if (dr["Question_Time"] != DBNull.Value)
						Temp.QuestionTime = Convert.ToString(dr["Question_Time"]);
					//if (dr["Subject"] != DBNull.Value)
					//{
					//    Temp.Subject = Convert.ToString(dr["Subject"]);
					//    //if(Temp.Subject.Length>42)
					//    //Temp.Subject = Temp.Subject.Substring(43);
					//}
					Temp.QuestionText = Convert.ToString(dr["Question_Text"]);
					if (dr["Urdu_Text"] != DBNull.Value)
						Temp.UrduText = Convert.ToString(dr["Urdu_Text"]);
					//Temp.Ministry = Convert.ToString(dr["Ministry"]);
					if (dr["MINISTRY_GROUP"] != DBNull.Value)
					{
						Temp.MinistryGroupId = Convert.ToInt32(dr["MINISTRY_GROUP"]);
						Temp.MinistryGroup = Convert.ToString(dr["GROUPDESC"]);
						Temp.UnstarDesc = Convert.ToString(dr["UNSTAR_DESC"]);
						Temp.GroupSequence = Convert.ToInt32(dr["GROUP_SEQUENCE"]);
					}

					Temp.DivisionId = Convert.ToInt32(dr["Division"]);
					Temp.Division = Convert.ToString(dr["Division_Name"]);
					Temp.Priority = Convert.ToInt32(dr["Priority"]);
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
					if (dr["Question_Diary_Date"] != DBNull.Value)
						Temp.QuestionDiaryDate = Convert.ToDateTime(dr["Question_Diary_Date"]);

					// Temp.QuestionDiaryTime = Convert.ToDateTime(dr["Question_Diary_Time"]);
					Temp.SessionNumberId = Convert.ToInt32(dr["Session_Number"]);
					Temp.SessionNumber = Convert.ToString(dr["SessionNumber"]);
					if (dr["Session_Sittings_Id"] != DBNull.Value)
						Temp.SessionSittingsId = Convert.ToInt32(dr["Session_Sittings_Id"]);
					if (dr["Reply"] != DBNull.Value)
						Temp.Reply = Convert.ToString(dr["Reply"]);
					if (dr["Reply_Date"] != DBNull.Value)
						Temp.ReplyDate = Convert.ToDateTime(dr["Reply_Date"]);
					Temp.IsActive = Convert.ToInt32(dr["IS_ACTIVE"]);

				}
				return Temp;
			}
			finally
			{
				con.Close();

			}
		}

		
	}
}
