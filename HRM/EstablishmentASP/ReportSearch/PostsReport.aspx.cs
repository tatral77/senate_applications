using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using Microsoft.Reporting.WebForms;

namespace EstablishmentASP.ReportSearch
{
    public partial class PostsReport : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {



        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            try
            {
                if (Posts.SelectedIndex!=0)
                {
                    SqlConnection con = new SqlConnection();
                    con.ConnectionString = "Server=OFFICE; Database=STUSER3; User id=sa; Password=123";
                    con.Open();
                    SqlCommand cmd = new SqlCommand("Select * From POSTS where DESCRIPTION='" + Posts.SelectedItem.Text + "'", con);
                    SqlDataAdapter sda = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    sda.Fill(dt);
                    con.Close();
                    DataView dv = new DataView(dt);
                    ReportViewer1.LocalReport.DataSources.Clear();
                    ReportViewer1.LocalReport.DataSources.Add(new ReportDataSource("DataSetPosts", dv));
                }
                else if (PostsFromTxt.Text!=null && PostsToTxt.Text!=null)
                {
                    SqlConnection con = new SqlConnection();
                    con.ConnectionString = "Server=OFFICE; Database=STUSER3; User id=sa; Password=123";
                    con.Open();
                    SqlCommand cmd = new SqlCommand("Select * From POSTS where  SCALE_FROM between '"+PostsFromTxt.Text+"' and '"+PostsToTxt.Text+"'", con);
                    SqlDataAdapter sda = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    sda.Fill(dt);
                    con.Close();
                    DataView dv = new DataView(dt);
                    ReportViewer1.LocalReport.DataSources.Clear();
                    ReportViewer1.LocalReport.DataSources.Add(new ReportDataSource("DataSetPosts", dv));
                }
                else if (PostsTypeTxt.Text!=null)
                {
                    SqlConnection con = new SqlConnection();
                    con.ConnectionString = "Server=OFFICE; Database=STUSER3; User id=sa; Password=123";
                    con.Open();
                    SqlCommand cmd = new SqlCommand("Select * From POSTS where  POST_TYPES_ID='"+PostsTypeTxt.Text+"'", con);
                    SqlDataAdapter sda = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    sda.Fill(dt);
                    con.Close();
                    DataView dv = new DataView(dt);
                    ReportViewer1.LocalReport.DataSources.Clear();
                    ReportViewer1.LocalReport.DataSources.Add(new ReportDataSource("DataSetPosts", dv));
                }
                
            }
            catch (Exception)
            {

                throw;
            }
            
        }
    }
}