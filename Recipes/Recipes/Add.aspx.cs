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
    public partial class Add : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
            if (!Functions.loggedIn)
            {
                Response.Redirect("Default.aspx");
            }

            DataTable dataTable = Functions.HttpRequest_To_DataTable("recipes", "get");
            GridView1.DataSource = dataTable;
            GridView1.DataBind();
        }

        protected void addRecipeBtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/AddRecipe");
        }

        protected void addIngredientBtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/AddIngredient");
        }

        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                // Get the value in the hyperlink column.
                string HyperLinkValue = e.Row.Cells[0].Text;

                HyperLink myLink = new HyperLink();
                myLink.NavigateUrl = "~/MakeRecipe?rid=" + HyperLinkValue;
                myLink.Text = HyperLinkValue;
                // then add the control to the cell.
                e.Row.Cells[0].Controls.Add(myLink);

            }
        }
    }
}