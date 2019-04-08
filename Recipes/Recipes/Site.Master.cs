using System;
using System.IO;
using System.Web.UI;


namespace Recipes
{
    public partial class SiteMaster : MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string pageName = Path.GetFileNameWithoutExtension(Page.AppRelativeVirtualPath);
            if (pageName == "Default")
            {
                logOut.Visible = false;
            }
        }
    }
}