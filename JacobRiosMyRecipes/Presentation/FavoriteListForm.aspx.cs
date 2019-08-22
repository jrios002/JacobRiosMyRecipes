using JacobRiosMyRecipes.Model.Business;
using JacobRiosMyRecipes.Model.Domain;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace JacobRiosMyRecipes.Presentation
{
    public partial class FavoriteListForm : System.Web.UI.Page
    {
        private List<Recipe> list = new List<Recipe>();
        private bool recipeDeleted = false;
        string userName = "";

        protected void Page_Load(object sender, EventArgs e)
        {
            userName = (string)(Session["userName"]);
            FavoriteRecipeMgr favMgr = new FavoriteRecipeMgr();

            // Try to retrieve recipes from favorite lists
            try
            {
                list = favMgr.retrieveRecipes(userName);

                // Display message that no recipes in favorite list if empty
                if(list.Count == 0)
                {
                    ImageConverter imgConverter = new ImageConverter();
                    byte[] bytes = (byte[])imgConverter.ConvertTo(Properties.Resources.MyRecipes, typeof(byte[]));
                    Recipe recipe = new Recipe("Empty", "", "", 0, bytes);
                    list.Add(recipe);
                    favMgr.storeRecipes(list, userName);

                    favMgr.deleteRecipe("1", userName);
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", 
                        "<script>alert('There are no recipes stored in Favorites List!');</script>");
                }
            }

            // Catch exception for debugging and display message that no recipes are in fav list
            catch(Exception ex)
            {
                Debug.Write(ex.StackTrace);
                Debug.WriteLine(ex.ToString());
                Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", "<script>alert('There are no recipes stored in Favorites List!');</script>");
            }

            // Try to retrieve recipeDeleted bool variable if available
            try
            {
                recipeDeleted = (bool)(Session["recipeDeleted"]);
            }
            catch (Exception ex)
            {
                Debug.Write(ex.StackTrace);
                Debug.WriteLine("Form loaded with no recipeDeleted variable available.");
            }

            // Display success message if recipe deleted and set session var back to false
            if (recipeDeleted)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", "<script>alert('Recipe successfully deleted from list!');</script>");
                Session["recipeDeleted"] = false;
            }
        }

        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            // Get location of item selected on the grid and assign bool var to true
            int clickedRecipe = Convert.ToInt32(e.CommandArgument.ToString());
            bool isOnFavorites = true;

            // Assign location variable to one less to get correct database location
            clickedRecipe--;

            // Add variables to session and transfer them to details form
            Session.Add("clickedRecipe", clickedRecipe);
            Session.Add("isOnFavorites", isOnFavorites);
            Server.Transfer("DetailsForm.aspx");
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("RecipeListForm.aspx");
        }

        protected void AddButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("AddRecipeForm.aspx");
        }

        protected void imgPreview_Click(object sender, ImageClickEventArgs e)
        {
            // Get location of item selected on the grid and assign bool var to true
            ImageButton button = sender as ImageButton;
            int clickedRecipe = Convert.ToInt32(button.CommandArgument.ToString());
            bool isOnFavorites = true;

            // Assign location variable to one less to get correct database location
            clickedRecipe--;

            // Add variables to session and transfer them to details form
            Session.Add("clickedRecipe", clickedRecipe);
            Session.Add("isOnFavorites", isOnFavorites);
            Server.Transfer("DetailsForm.aspx");
        }

        protected void LoginStatus2_LoggedOut(object sender, EventArgs e)
        {
            RecipeWS.RecipeWebService ws = new RecipeWS.RecipeWebService();
            ws.ReadUserInformation(User.Identity.Name.ToString(), DateTime.Now.ToString(), "Logged Out");
        }
    }
}