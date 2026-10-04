using Entities;
using ManBIZ;
using ManEntities;
using QuestionBIZ;
using ResolutionBIZ;
using ResolutionEntities;
using System;
using System.Collections.Generic;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.Services;
using System.Web.UI.WebControls;

namespace QuestionManagement
{
    public partial class ResolutionDetail : System.Web.UI.Page
    {
        [WebMethod]
        public static List<string> GetEmployeeName(string empName)
        {
            List<string> empResult = new List<string>();
            List<Member> mems = new QuestionBiz().GetMembersByName(empName);
            foreach (Member a in mems)
            {
                empResult.Add(a.MemberName);
            }
            return empResult;
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindCombos();
                BindFields();

            }
        }
        protected void BindCombos()
        {
            List<ResolutionTypesEnt> resolutiontypes = new ResolutionBiz().GetResolutionTypes();
            foreach (ResolutionTypesEnt row in resolutiontypes)
            {
                ListItem li = new ListItem();
                li.Text = row.Description.ToString();
                li.Value = row.ResTypesId.ToString();
                ResolutionTypeDDL.Items.Add(li);
            }
            List<ResolutionStatusesEnt> motionstatus = new ResolutionBiz().GetResolutionStatuses();
            foreach (ResolutionStatusesEnt row in motionstatus)
            {
                ListItem li = new ListItem();
                li.Text = row.Description.ToString();
                li.Value = row.ResolutionStatusesId.ToString();
                ResolutionStatusDDL.Items.Add(li);
            }
            //List<AssemblySessions> ASessions = new AdministrationBiz().GetAssemblySessions();
            //foreach (AssemblySessions row in ASessions)
            //{
            //    ListItem li = new ListItem();
            //    li.Text = row.SessionNumber.ToString();
            //    li.Value = row.AssemblySessionsId.ToString();
            //    SessionDDL.Items.Add(li);
            //}

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            int userid = 0;
            if (Request.Cookies["userInfo"] != null)
            {
                //HttpCookie userInfo = new HttpCookie("userInfo");
                HttpCookie userInfo = Request.Cookies["userInfo"];
                userid = Convert.ToInt32(userInfo["userid"]);
            }
            ResolutionEnt resolution = new ResolutionEnt();
            resolution.ResolutionsId = Convert.ToInt32(ResolutionIDTxt.Text);
            resolution.AssemblySessionsId = Convert.ToInt32(HidSessionNumber.Value);
            // resolution.AssemblySessionsId = Convert.ToInt32(SessionDDL.SelectedItem.Value);
            resolution.NoticeDiaryNo = Convert.ToInt32(NoticeDiaryNoTxt.Text);
            resolution.NoticeDiaryDate = Convert.ToDateTime(NoticeDiaryDateTxt.Text);
            string str = NoticeDiaryDateTxt.Text + " " + NoticeDiaryTimeTxt.Text;  // assumed date and time are textboxes
            DateTime dt = new DateTime();
            DateTime.TryParse(str, out (dt)); // returns datetime in dt if it is valid
            resolution.NoticeDiaryTime = dt;

            // resolution.NoticeDiaryTime = Convert.ToDateTime(NoticeDiaryTimeTxt.Text);
            resolution.ResolutionDiaryNo = Convert.ToInt32(ResolutionDiaryNoTxt.Text);
            resolution.ResolutionNumber = Convert.ToInt32(ResolutionNoTxt.Text);
            resolution.Description = Convert.ToString(ResolutionTxt.Value);
            resolution.ResTypesId = Convert.ToInt32(ResolutionTypeDDL.SelectedItem.Value);
            int PrevResolutionStatusId = Convert.ToInt32(HidResolutionStatusId.Value);
            int NewResolutionStatusId = Convert.ToInt32(ResolutionStatusDDL.SelectedItem.Value);
            resolution.ResolutionStatusId = NewResolutionStatusId;
            if (PrevResolutionStatusId != NewResolutionStatusId)
            {
                ResolutionStatusHistory resolutionStatusHistory = new ResolutionStatusHistory();
                resolutionStatusHistory.ResolutionId = resolution.ResolutionsId;
                resolutionStatusHistory.AssemblySessionId = resolution.AssemblySessionsId;
                resolutionStatusHistory.ResolutionStatusId = resolution.ResolutionStatusId;
                resolutionStatusHistory.InsertedBy = userid;
                new ResolutionBiz().InsertResolutionStatusHistory(resolutionStatusHistory);
            }
            if (!String.IsNullOrEmpty(HouseMovingDateTxt.Text))
                resolution.MovedDate = Convert.ToDateTime(HouseMovingDateTxt.Text);
            if (!String.IsNullOrEmpty(DiscussionDateTxt.Text))
                resolution.DiscussedDate = Convert.ToDateTime(DiscussionDateTxt.Text);
            if (!String.IsNullOrEmpty(PassingDateTxt.Text))
                resolution.PassedDate = Convert.ToDateTime(PassingDateTxt.Text);
            resolution.IsUrdu = UrduCB.Checked == true ? 1 : 0;
            resolution.EngSubject = OriginalTxt.Value;
            resolution.ClubedTo = ClubedToTxt.Text;
            resolution.ClubedResolutions = ClubedResolutionsTxt.Text;
            resolution.UpdatedBy = userid;
            new ResolutionBiz().UpdateResolution(resolution);
            SyncSubmittersAndMinistries(resolution.ResolutionsId);

            Response.Redirect("~/ResolutionDetail.aspx?ResolutionId=" + resolution.ResolutionsId);

        }

        // Serialises the selected items for the searchable multi-select: [{"id":1,"name":"x"}]
        private static string ToJson<T>(List<T> list, Func<T, int> id, Func<T, string> name)
        {
            List<object> items = new List<object>();
            if (list != null)
                foreach (T item in list)
                    items.Add(new { id = id(item), name = name(item) });
            return new JavaScriptSerializer().Serialize(items);
        }

        // Reads the ids the user picked, in the order shown. Returns null when the field is empty (nothing to sync).
        private static List<int> ReadIds(string json)
        {
            if (string.IsNullOrEmpty(json)) return null;
            List<int> ids = new List<int>();
            foreach (Dictionary<string, object> item in new JavaScriptSerializer().Deserialize<List<Dictionary<string, object>>>(json))
            {
                int id = Convert.ToInt32(item["id"]);
                if (!ids.Contains(id)) ids.Add(id);
            }
            return ids;
        }

        // Adds newly picked submitters/ministries, removes the ones taken off, and saves the submitters' order.
        private void SyncSubmittersAndMinistries(int resolutionId)
        {
            ResolutionBiz biz = new ResolutionBiz();
            ResolutionEnt current = biz.GetResolution(resolutionId);

            List<int> movers = ReadIds(HidMoversJson.Value);
            if (movers != null)
            {
                Dictionary<int, ResolutionSubmittersEnt> existing = new Dictionary<int, ResolutionSubmittersEnt>();
                if (current.Submitters != null)
                    foreach (ResolutionSubmittersEnt m in current.Submitters) existing[m.SystemUsersId] = m;
                foreach (int id in existing.Keys)
                    if (!movers.Contains(id)) biz.DeleteResolutionMover(resolutionId, id);
                for (int i = 0; i < movers.Count; i++)
                {
                    int position = i + 1;   // 1 = printed first
                    ResolutionSubmittersEnt row;
                    if (!existing.TryGetValue(movers[i], out row))
                        biz.InsertResolutionSubmitters(new ResolutionSubmittersEnt { ResolutionsId = resolutionId, SystemUsersId = movers[i], SortOrder = position });
                    else if (row.SortOrder != position)
                    {
                        row.SortOrder = position;
                        biz.UpdateResolutionSubmitters(row);
                    }
                }
            }

            List<int> ministries = ReadIds(HidMinistriesJson.Value);
            if (ministries != null)
            {
                HashSet<int> existing = new HashSet<int>();
                if (current.ResolutionMinistries != null)
                    foreach (ResolutionMinistries m in current.ResolutionMinistries) existing.Add(m.MinistryId);
                foreach (int id in existing)
                    if (!ministries.Contains(id)) biz.DeleteResolutionMinistry(resolutionId, id);
                foreach (int id in ministries)
                    if (!existing.Contains(id))
                        biz.InsertResolutionMinistries(new ResolutionMinistries { ResolutionId = resolutionId, MinistryId = id });
            }
        }

        public string GetDate(DateTime date)
        {
            return (Convert.ToString(date) == "01/01/0001 00:00:00") ? string.Empty : date.ToString();

        }
        protected void MoveResolutionBtn_Click(object sender, EventArgs e)
        {
            ResolutionEnt resolution = new ResolutionEnt();
            resolution.ResolutionsId = Convert.ToInt32(ResolutionIDTxt.Text);
            resolution.AssemblySessionsId = Convert.ToInt32(MoveAssemblySessionDDL.SelectedItem.Value);
            resolution.NoticeDiaryNo = Convert.ToInt32(MoveNoticeDiaryTxt.Text);
            resolution.NoticeDiaryDate = Convert.ToDateTime(MoveNoticeDateTxt.Text);
            // DateTime noticedate = Convert.ToDateTime(NoticeDiaryDateTxt.Text);
            //String datetime = MoveNoticeDateTxt.Text + " " + MoveNoticeDiaryTimeTxt.Text;
            string str = MoveNoticeDateTxt.Text + " " + MoveNoticeDiaryTimeTxt.Text;  // assumed date and time are textboxes
            DateTime dt = new DateTime();
            DateTime.TryParse(str, out (dt)); // returns datetime in dt if it is valid
            resolution.NoticeDiaryTime = dt;
            //resolution.NoticeDiaryTime= Convert.ToDateTime(MoveNoticeDiaryTimeTxt.Text);
            resolution.ResolutionDiaryNo = Convert.ToInt32(MoveResDiaryNoTxt.Text);
            resolution.ResolutionNumber = Convert.ToInt32(ResolutionNoTxt.Text);
            resolution.Description = Convert.ToString(ResolutionTxt.Value);
            resolution.ResTypesId = Convert.ToInt32(ResolutionTypeDDL.SelectedItem.Value);
            resolution.ResolutionStatusId = Convert.ToInt32(ResolutionStatusDDL.SelectedItem.Value);

            if (!String.IsNullOrEmpty(HouseMovingDateTxt.Text))
                resolution.MovedDate = Convert.ToDateTime(HouseMovingDateTxt.Text);
            if (!String.IsNullOrEmpty(DiscussionDateTxt.Text))
                resolution.DiscussedDate = Convert.ToDateTime(DiscussionDateTxt.Text);
            if (!String.IsNullOrEmpty(PassingDateTxt.Text))
                resolution.PassedDate = Convert.ToDateTime(PassingDateTxt.Text);
            new ResolutionBiz().MoveResolution(resolution);
            Response.Redirect("~/ResolutionDetail.aspx?ResolutionId=" + resolution.ResolutionsId);

        }
        protected void PrintBtn_Click(object sender, EventArgs e)
        {
            // int id=InsertQuestion();
            // Response.Redirect("~/PrintQuestion.aspx?questionsId=" + id);

        }

        protected void BindFields()
        {
            ResolutionEnt res = new ResolutionEnt();
            int ResolutionId = Convert.ToInt32(Request.QueryString["ResolutionId"]);
            res = new ResolutionBiz().GetResolution(ResolutionId);
            if (res != null)
            {
                if (res.ResolutionsId != 0)
                {
                    ResolutionIDTxt.Text = Convert.ToString(res.ResolutionsId);
                    HidSessionNumber.Value = Convert.ToString(res.AssemblySessionsId);
                    SessionTxt.Text = Convert.ToString(res.SessionNumber);
                    // SessionDDL.SelectedValue = Convert.ToString(res.SessionNumber);
                    NoticeDiaryNoTxt.Text = Convert.ToString(res.NoticeDiaryNo);
                    MoveNoticeDiaryTxt.Text = Convert.ToString(res.NoticeDiaryNo);
                    NoticeDiaryDateTxt.Text = res.NoticeDiaryDate.ToShortDateString();
                    NoticeDiaryTimeTxt.Text = res.NoticeDiaryTime.ToShortTimeString();
                    MoveNoticeDiaryTimeTxt.Text = res.NoticeDiaryTime.ToShortTimeString();
                    MoveNoticeDateTxt.Text = res.NoticeDiaryDate.ToShortDateString();
                    ResolutionDiaryNoTxt.Text = res.ResolutionDiaryNo.ToString();
                    MoveResDiaryNoTxt.Text = res.ResolutionDiaryNo.ToString();
                    ResolutionNoTxt.Text = res.ResolutionNumber.ToString();
                    ResolutionTypeDDL.SelectedValue = res.ResTypesId.ToString();
                    ResolutionStatusDDL.SelectedValue = res.ResolutionStatusId.ToString();
                    HidResolutionStatusId.Value = res.ResolutionStatusId.ToString();
                    HouseMovingDateTxt.Text = (res.MovedDate < Convert.ToDateTime("01/01/1900")) ? "" : res.MovedDate.ToShortDateString();
                    DiscussionDateTxt.Text = (res.DiscussedDate < Convert.ToDateTime("01/01/1900")) ? "" : res.DiscussedDate.ToShortDateString();
                    PassingDateTxt.Text = (res.PassedDate < Convert.ToDateTime("01/01/1900")) ? "" : res.PassedDate.ToShortDateString();
                    ResolutionTxt.Value = res.Description.ToString();
                    HyperLink1.NavigateUrl = res.ResolutionFile;
                    ClubedToTxt.Text = res.ClubedTo;
                    ClubedResolutionsTxt.Text = res.ClubedResolutions;
                    UrduText.Value = res.UrduText;
                    if (String.IsNullOrEmpty(res.EngSubject))
                        OriginalTxt.Value = "No Text";
                    else
                        OriginalTxt.Value = res.EngSubject;
                    if (res.IsDeleted == 1)
                    {
                        DeleteDiv.Visible = false;
                        RecoverDiv.Visible = true;
                    }
                    else
                    {
                        DeleteDiv.Visible = true;
                        RecoverDiv.Visible = false;
                    }
                    if (res.IsUrdu == 1)
                        UrduCB.Checked = true;
                    string UpdatedLabelText = "";
                    if (res.UpdatedBy != 0)
                    {
                        UpdatedLabelText = GetUserName(res.UpdatedBy);
                        if (res.UpdatedOn != null && res.UpdatedOn > Convert.ToDateTime("1/1/1900"))
                        {
                            string updatedon = res.UpdatedOn.ToString();
                            UpdatedLabelText += " on " + updatedon;
                        }
                        UpdatedByLbl.Text = UpdatedLabelText;

                    }
                    string InsertLabelText = "";
                    if (res.InsertedBy != 0)
                    {
                        InsertLabelText = GetUserName(res.InsertedBy);
                        if (res.InsertedOn != null && res.InsertedOn > Convert.ToDateTime("1/1/1900"))
                        {
                            string insertedon = res.InsertedOn.ToString();
                            InsertLabelText += " on " + insertedon;
                        }
                        InsertedByLbl.Text = InsertLabelText;

                    }



                    string TranslationLabelText = "";
                    if (res.SentForTranslationBy != 0)
                    {
                        TranslationLabelText = GetUserName(res.SentForTranslationBy);
                        if (res.SentForTranslationOn != null && res.SentForTranslationOn > Convert.ToDateTime("1/1/1900"))
                        {
                            string translatedon = res.SentForTranslationOn.ToString();
                            TranslationLabelText += " on " + translatedon;
                        }
                        SentForTransByLbl.Text = TranslationLabelText;

                    }

                    string ApprovedByLbl = "";
                    if (res.TranslationApprovedBy != 0)
                    {
                        ApprovedByLbl = GetUserName(res.TranslationApprovedBy);
                        if (res.TranslationApprovedOn != null && res.TranslationApprovedOn > Convert.ToDateTime("1/1/1900"))
                        {
                            string approvedon = res.TranslationApprovedOn.ToString();
                            ApprovedByLbl += " on " + approvedon;
                        }
                        TransApprovedByLbl.Text = ApprovedByLbl;

                    }

                    string DeleteLabelTxt = "";
                    if (res.DeletedBy != 0)
                    {
                        DeleteLabelTxt = GetUserName(res.DeletedBy);
                        if (res.DeletedOn != null && res.DeletedOn > Convert.ToDateTime("1/1/1900"))
                        {
                            string deletedon = res.DeletedOn.ToString();
                            DeleteLabelTxt += " on " + deletedon;
                        }
                        DeletedByLbl.Text = DeleteLabelTxt;

                    }

                    string RecoveredLabelTxt = "";
                    if (res.RecoveredBy != 0)
                    {
                        RecoveredLabelTxt = GetUserName(res.RecoveredBy);
                        if (res.RecoveredOn != null && res.RecoveredOn > Convert.ToDateTime("1/1/1900"))
                        {
                            string recoverdon = res.RecoveredOn.ToString();
                            RecoveredLabelTxt += " on " + recoverdon;
                        }
                        RecoveredByLbl.Text = RecoveredLabelTxt;
                    }
                    BindMoveSessionDDL(res.AssemblySessionsId);
                    PrintHL.NavigateUrl = "~/PrintResolution.aspx?ResolutionId=" + ResolutionId;
                    PrintOriginal.NavigateUrl = "~/PrintOriginalResolution.aspx?ResolutionId=" + ResolutionId;
                    HidMoversJson.Value = ToJson(res.Submitters, m => m.SystemUsersId, m => m.MoverName);
                    HidMinistriesJson.Value = ToJson(res.ResolutionMinistries, m => m.MinistryId, m => m.MinistryName);
                    LVStatus.DataSource = res.ResolutionStatusHistories;
                    LVStatus.DataBind();
                }
            }
        }
        public string GetUserName(int UserId)
        {
            User user = new ManBiz().GetUser(UserId);
            if (user != null)
            {
                return user.FullName;
            }
            return "";
        }
        protected void TranslateBtn_Click(object sender, EventArgs e)
        {
            int userid = 0;
            if (Request.Cookies["userInfo"] != null)
            {
                //HttpCookie userInfo = new HttpCookie("userInfo");
                HttpCookie userInfo = Request.Cookies["userInfo"];
                userid = Convert.ToInt32(userInfo["userid"]);
            }
            int ResolutionId = Convert.ToInt32(Request.QueryString["ResolutionId"]);
            if (!string.IsNullOrEmpty(UrduText.Value))
            {

                new ResolutionBiz().SendForTranslation(ResolutionId, userid);
                UrduLbl.Visible = false;
                Response.Redirect("~/ResolutionDetail.aspx?ResolutionId=" + ResolutionId);
            }
            else
            {
                UrduLbl.Text = "No text found for translation";
                UrduLbl.Visible = true;
            }
        }
        public void BindMoveSessionDDL(int SessionNumberId)
        {
            List<AssemblySessions> AsSessions = new AdministrationBiz().GetAssemblySessions();
            foreach (AssemblySessions row in AsSessions)
            {
                ListItem li = new ListItem();
                li.Text = row.SessionNumber.ToString();
                li.Value = row.AssemblySessionsId.ToString();
                //if (Convert.ToInt32(li.Value) > SessionNumberId)
                //{
                MoveAssemblySessionDDL.Items.Add(li);
                //}

            }

        }

        protected void DeleteBtn_Click(object sender, EventArgs e)
        {
            int userid = 0;
            if (Request.Cookies["userInfo"] != null)
            {
                //HttpCookie userInfo = new HttpCookie("userInfo");
                HttpCookie userInfo = Request.Cookies["userInfo"];
                userid = Convert.ToInt32(userInfo["userid"]);
            }
            int ResolutionId = Convert.ToInt32(ResolutionIDTxt.Text);
            new ResolutionBiz().DeleteResolution(ResolutionId, userid);
            Response.Redirect("SearchResolution.aspx");
        }

        protected void Button2_Click(object sender, EventArgs e)
        {

        }

        protected void RecoverBtn_Click(object sender, EventArgs e)
        {
            int userid = 0;
            if (Request.Cookies["userInfo"] != null)
            {
                //HttpCookie userInfo = new HttpCookie("userInfo");
                HttpCookie userInfo = Request.Cookies["userInfo"];
                userid = Convert.ToInt32(userInfo["userid"]);
            }
            int ResolutionId = Convert.ToInt32(ResolutionIDTxt.Text);
            new ResolutionBiz().RecoverResolution(ResolutionId, userid);
            Response.Redirect("SearchResolution.aspx");
        }
    }
}