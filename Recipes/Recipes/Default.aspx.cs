using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Recipes.Code;
namespace Recipes
{
    public partial class _Default : Page
    {
        
        protected void Page_Load(object sender, EventArgs e)
        {
            Functions.LogOut(Request.QueryString["l"]);
    
        }

        protected void loginBtn_Click(object sender, EventArgs e)
        {

            if (Functions.Authenticate(username.Text.Trim(), password.Text))
            {
                Response.Redirect("Home.aspx");
            }  
            else
            {
                Functions.Alert("Wrong credentials");
            }

        }

        protected void signUpBtn_Click(object sender, EventArgs e)
        {
            if(Functions.SignUp(username.Text.Trim(), password.Text))
            {
                Response.Redirect("Home.aspx");
            }
            else
            {
                Functions.Alert("Username already exist");
            }
        }
    }
}