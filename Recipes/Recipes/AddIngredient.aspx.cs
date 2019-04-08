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
    public partial class AddIngredient : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Functions.loggedIn)
            {
                Response.Redirect("Default.aspx");
            }

            DataTable dataTable = Functions.HttpRequest_To_DataTable("ingredients", "get");
            GridView1.DataSource = dataTable;
            GridView1.DataBind();
        }

        protected void addIngredientBtn_Click(object sender, EventArgs e)
        {
            Functions.HttpRequest_To_DataTable("ingredients/" + ingredient.Text.Trim(), "post");
            Response.Redirect("~/AddIngredient");
        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Add");
        }
    }
}