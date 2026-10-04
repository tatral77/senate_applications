using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MotionBIZ;
using MotionEntities;

namespace MotionBranch
{
    public partial class PrintMotion : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            MotionEnt motion = new MotionEnt();
            int MotionId = Convert.ToInt32(Request.QueryString["MotionId"]);
            motion = new MotionBiz().GetMotion(MotionId);
            NoticeDateLbl.Text = motion.NoticeDiaryDate.ToShortDateString();
            MotionDNoLbl.Text = motion.WeekName.ToString();
            SessionLbl.Text = motion.SessionDesc + " / " + motion.MotionsId;
            MotionTypeLbl1.Text = "(" + motion.MotionType.ToUpper() + " )";
          //  MotionTypeLbl2.Text = motion.MotionType.ToUpper();
            StatusLbl.Text =  motion.MotionStatus;
            string txt = Regex.Replace(Convert.ToString(motion.Description.ToString()), @"<[^>]+>|&nbsp;", "").Trim();
            char c = txt[1];
            UnicodeCategory cat = char.GetUnicodeCategory(c);
            if (cat == UnicodeCategory.OtherLetter)
            {
                MotionTextLblUr.Text = motion.Description.ToString();
                MotionTextLblUr.Visible = true;
            }
            else
            {
                MotionTextLblEng.Text = motion.Description.ToString();
                MotionTextLblEng.Visible = true;
            }
            string movers = "";
            //if (motion.Movers != null)
            //{
            //    foreach (MotionMoversEnt temp in motion.Movers)
            //    {
            //        movers += "SENATOR " + temp.MoverName.ToUpper() + "</br>";

            //    }
            //    MoversLbl.Text = movers;
            //}
            if (motion.Movers != null)
            {

                foreach (MotionMoversEnt temp in motion.Movers)
                {
                    if (motion.Movers.Count > 1)
                        movers += temp.MoverName.ToUpper() + "</br>";
                    else
                        movers += "SENATOR " + temp.MoverName.ToUpper() + "</br>";

                }
            }
            if (motion.Movers != null)
            {
                MoversLbl.Text = movers;
                if (motion.Movers.Count != 1)
                    MoversLbl.Text += "SENATORS";
            }
        }
    }
}