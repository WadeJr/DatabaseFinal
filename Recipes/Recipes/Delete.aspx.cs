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
    public partial class Delete : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Functions.loggedIn)
            {
                //Response.Redirect("Default.aspx");
            }
            QueryCheck();

            DataTable dataTable = Functions.HttpRequest_To_DataTable("recipes", "get");
            GridView1.DataSource = dataTable;
            GridView1.DataBind();
        }

        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                // Get the value in the hyperlink column.
                string HyperLinkValue = e.Row.Cells[0].Text;

                HyperLink myLink = new HyperLink();


                myLink.NavigateUrl = "~/Delete?id=" + HyperLinkValue;
                myLink.Text = HyperLinkValue;
                // then add the control to the cell.
                e.Row.Cells[0].Controls.Add(myLink);


            }
        }

        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (DropDownList1.SelectedIndex == 0)
            {
                DataTable dataTable = Functions.HttpRequest_To_DataTable("recipes", "get");
                GridView1.DataSource = dataTable;
                GridView1.DataBind();
            }
            else
            {
                DataTable dataTable = Functions.HttpRequest_To_DataTable("ingredients", "get");
                GridView1.DataSource = dataTable;
                GridView1.DataBind();
            }
        }

        public void QueryCheck()
        {
            string id = Request.QueryString["id"];
            if (id != null || id != "")
            {
                if (DropDownList1.SelectedIndex == 1)
                {
                    string del = "ingredients/"+ id;
                    Functions.HttpRequest_To_DataTable(del, "delete");
                }
                else
                {
                    string del = "recipes/delete/" + id;
                    Functions.HttpRequest_To_DataTable(del, "delete");
                }
            }
        }

     
    }
}