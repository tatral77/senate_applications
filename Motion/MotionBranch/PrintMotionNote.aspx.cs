using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MotionEntities;
using MotionBIZ;

namespace MotionBranch
{
    public partial class PrintMotionNote : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            MotionEnt motion = new MotionEnt();
            int MotionId = Convert.ToInt32(Request.QueryString["MotionId"]);
            motion = new MotionBiz().GetMotion(MotionId);
            printingdiv.InnerHtml = motion.NoteDescription.ToString();

        }
    }
}