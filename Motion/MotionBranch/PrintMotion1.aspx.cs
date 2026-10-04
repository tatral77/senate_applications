using MotionBIZ;
using MotionEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MotionBranch
{
    public partial class PrintMotion1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            MotionEnt motion = new MotionEnt();
            int MotionId = Convert.ToInt32(Request.QueryString["MotionId"]);
            motion = new MotionBiz().GetMotion(MotionId);
            MotionFileNoLbl.Text = "C.A.N. No. " + motion.MotionDiaryNo +" for " + motion.WeekName + " (Session-" + motion.SessionDesc + ")/"  + motion.NoticeDiaryDate.Year +"-M/" + motion.MotionsId.ToString(); ;
            MotionTextLbl.Text = motion.Description.ToString();
           // string movers = "";
            //foreach(MotionMoversEnt temp in motion.Movers)
            //{
            //    movers += "SENATOR" + temp.MoverName.ToUpper() + "</br>";

            //}
            //MoversLbl.Text = movers;
        }
    }
}