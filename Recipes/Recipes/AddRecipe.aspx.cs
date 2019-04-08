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
    public partial class AddRecipe: System.Web.UI.Page
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
    

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Add");
        }

        protected void insertBtn_Click(object sender, EventArgs e)
        {
            Functions.HttpRequest_To_DataTable("recipes/add/" + recipe.Text.Trim(), "post");
            Response.Redirect("~/AddRecipe");
        }
    }
}