using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Recipes.Code;

namespace Recipes
{
    public partial class Favorites : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
            if (!Functions.loggedIn)
            {
                Response.Redirect("Default.aspx");
            }
            QueryCheck();

            DataTable dataTable = Functions.HttpRequest_To_DataTable("favorites/byuser/" + Functions.username, "get");
            GridView1.DataSource = dataTable;
            GridView1.DataBind();
        }

  
        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                // Get the value in the hyperlink column.
                string HyperLinkValue = e.Row.Cells[0].Text;
                string HyperLinkValue2 = e.Row.Cells[1].Text;

                HyperLink myLink = new HyperLink();
                HyperLink delLink = new HyperLink();

                myLink.NavigateUrl = "~/Recipe?rid=" + HyperLinkValue;
                myLink.Text = HyperLinkValue;
                // then add the control to the cell.
                e.Row.Cells[0].Controls.Add(myLink);


                delLink.NavigateUrl = "~/Favorites?rid=" + HyperLinkValue;
                delLink.Text = HyperLinkValue2;

                e.Row.Cells[1].Controls.Add(delLink);
            }
        }

        public void QueryCheck()
        {
            string rid = Request.QueryString["rid"];
            if(rid != null || rid != "")
            {
                string del = "favorites/delete/" + Functions.username + "/" + rid;
                Functions.HttpRequest_To_DataTable(del, "delete");
            }
        }
    }
}