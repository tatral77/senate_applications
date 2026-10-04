using ResolutionBIZ;
using ResolutionEntities;
using System;
using System.Globalization;
using System.Text.RegularExpressions;

namespace QuestionManagement
{
    public partial class PrintResolution : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            ResolutionEnt Resolution = new ResolutionEnt();
            int ResolutionId = Convert.ToInt32(Request.QueryString["ResolutionId"]);
            Resolution = new ResolutionBiz().GetResolution(ResolutionId);
            NoticeDateLbl.Text = Resolution.NoticeDiaryDate.ToShortDateString();
            SessionLbl.Text = Resolution.SessionNumber.ToString() + " / " + Resolution.ResolutionsId;
            MotionDNoLbl.Text = Resolution.ResolutionDiaryNo.ToString();
            //ResolutionTypeLbl.Text = Resolution.ResType.ToUpper();
            //ResolutionTypeLbl2.Text = Resolution.ResType.ToUpper();
            StatusLbl.Text = Resolution.ResolutionStatus;
            string txt = Regex.Replace(Convert.ToString(Resolution.Description.ToString()), @"<[^>]+>|&nbsp;", "").Trim();
            char c = txt[1];
            UnicodeCategory cat = char.GetUnicodeCategory(c);
            if (cat == UnicodeCategory.OtherLetter)
            {
                MotionTextLblUr.Text = Resolution.Description.ToString();
                MotionTextLblUr.Visible = true;
            }
            else
            {
                MotionTextLblEng.Text = Resolution.Description.ToString();
                MotionTextLblEng.Visible = true;
            }

            //if (Regex.IsMatch(Resolution.Description.ToString(), "^[a-zA-Z]*"))
            //{

            //}
            //else
            //{

            //}
            string movers = "";
            if (Resolution.Submitters != null)
            {

                foreach (ResolutionSubmittersEnt temp in Resolution.Submitters)
                {
                    if (Resolution.Submitters.Count > 1)
                        movers += temp.MoverName.ToUpper() + "</br>";
                    else
                        movers += "SENATOR " + temp.MoverName.ToUpper() + "</br>";

                }
            }
            MoversLbl.Text = movers;
            if (Resolution.Submitters != null)
            {
                if (Resolution.Submitters.Count != 1)
                    MoversLbl.Text += "SENATORS";
            }
        }
    }
}
