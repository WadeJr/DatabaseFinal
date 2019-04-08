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
    public partial class Recipe : System.Web.UI.Page
    {
        public static string recipeName { get; set; }
        private string rid { get; set; }

        
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!Functions.admin)
            {
                deleteBtn.Enabled = false;
            }


            rid = Request.QueryString["rid"];
           

            DataTable dt = Functions.HttpRequest_To_DataTable("recipes/byrid/" + rid, "get");
           
            DataTable dataTable = Functions.HttpRequest_To_DataTable("ingredients/byrid/" + rid, "get");


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

        protected void addBtn_Click(object sender, EventArgs e)
        {
            string userFav = "favorites/add/" + Functions.username + "/" + rid;
            Functions.HttpRequest_To_DataTable(userFav, "post");
            Functions.Alert("Succesfully added to your favorites.");
        }

        protected void deleteBtn_Click(object sender, EventArgs e)
        {
            Functions.HttpRequest_To_DataTable("recipes/delete/" + rid, "delete");
            Response.Redirect("~/Home");
        }
    }
}