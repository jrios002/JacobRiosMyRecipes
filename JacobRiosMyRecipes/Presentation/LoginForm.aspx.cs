using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace JacobRiosMyRecipes.Presentation
{
    public partial class LoginForm : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Login1_LoggedIn(object sender, EventArgs e)
        {
            RecipeWS.RecipeWebService ws = new RecipeWS.RecipeWebService();
            string userName = Login1.UserName;
            if (userName == "")
            {
                userName = "Guest";
            }

            ws.ReadUserInformation(userName, DateTime.Now.ToString(), "Logged In");
        }
    }
}