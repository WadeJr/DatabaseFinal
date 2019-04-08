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




    public partial class Home : Page
    {
        public bool isRecipe = true;

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

        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void searchBtn_Click(object sender, EventArgs e)
        {
            isRecipe = true;
   
            string json = TextBox1.Text.Trim();

        
            if (DropDownList1.SelectedIndex == 1)
            {

                DataTable dataTable = Functions.HttpRequest_To_DataTable("recipes/byingredient/" + json, "get");
              

                if (dataTable != null)
                {
                    GridView1.DataSource = dataTable;
                }
                else
                {
                    GridView1.DataSource = null;
                }

                GridView1.DataBind();

            }
            else
            {

                DataTable dataTable = Functions.HttpRequest_To_DataTable("recipes/byname/" + json, "get");


                if (dataTable != null)
                {
                    GridView1.DataSource = dataTable;
                }
                else
                {
                    GridView1.DataSource = null;
                }

                GridView1.DataBind();
            }
        }

        protected void recipesBtn_Click(object sender, EventArgs e)
        {
            isRecipe = true;
            DataTable dataTable = Functions.HttpRequest_To_DataTable("recipes", "get");

            if (dataTable != null)
            {
                GridView1.DataSource = dataTable;
            }
            else
            {
                GridView1.DataSource = null;
            }

            GridView1.DataBind();
        }

        protected void ingredientBtn_Click(object sender, EventArgs e)
        {
            isRecipe = false;
            DataTable dataTable = Functions.HttpRequest_To_DataTable("ingredients", "get");

            if (dataTable != null)
            {
                GridView1.DataSource = Functions.GetColumn("name", dataTable);
            }
            else
            {
                GridView1.DataSource = null;
            }

            GridView1.DataBind();
        }



        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow && isRecipe)
            {
                // Get the value in the hyperlink column.
                string HyperLinkValue = e.Row.Cells[0].Text;
    
                HyperLink myLink = new HyperLink();
                myLink.NavigateUrl ="~/Recipe?rid=" + HyperLinkValue;
                myLink.Text = HyperLinkValue;
                // then add the control to the cell.
                e.Row.Cells[0].Controls.Add(myLink);

            }
        }
    }
}