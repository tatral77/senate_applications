using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Translation
{
    public partial class Test : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            imgdiv.InnerHtml = "<object data='\\images\\test.pdf' type=\"application/pdf\" style=\"width:50%\" height=\"700\">\r\n alt:<a href='\\images\\test.pdf'>View File</a>\r\n  </object>";
        }
    }
}