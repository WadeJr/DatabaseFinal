using Recipes.Code;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Recipes
{
    public partial class MakeRecipe : System.Web.UI.Page
    {
        public static string recipeName { get; set; }
        private string rid { get; set; }
       
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!Functions.loggedIn)
            {
                Response.Redirect("Default.aspx");
            }

            QueryCheck();
            rid = Request.QueryString["rid"];


            DataTable dt = Functions.HttpRequest_To_DataTable("recipes/byrid/" + rid, "get");

            DataTable dataTable = Functions.HttpRequest_To_DataTable("ingredients", "get");


            if (dataTable != null && dt != null)
            {
                GridView1.DataSource = dataTable;
                recipeName = dt.Rows[0]["name"].ToString();

            }
            else
            {
                GridView1.DataSource = null;
            }

            GridView1.DataBind();
        }


        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow )
            {
                // Get the value in the hyperlink column.
                string HyperLinkValue = e.Row.Cells[0].Text;

                HyperLink myLink = new HyperLink();
                myLink.NavigateUrl = "~/MakeRecipe?rid=" + rid + "&iid=" + HyperLinkValue; 
                myLink.Text = HyperLinkValue;
                // then add the control to the cell.
                e.Row.Cells[0].Controls.Add(myLink);

            }
        }

        public void QueryCheck()
        {
            string iid = Request.QueryString["iid"];
            if (iid != null || iid != "")
            {
                Functions.HttpRequest_To_DataTable("recipe/add/ingredient/" + rid + "/" + iid + "/", "post");
            }
        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Add");
        }
    }
}