using JacobRiosMyRecipes.Model.Business;
using JacobRiosMyRecipes.Model.Domain;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace JacobRiosMyRecipes.Presentation
{
    public partial class RecipeListForm : System.Web.UI.Page
    {
        private List<Recipe> list = new List<Recipe>();
        private bool recipeAdded = false;
        private bool recipeDeleted = false;

        protected void Page_Load(object sender, EventArgs e)
        {
            string userName = User.Identity.Name;
            if (userName == "")
            {
                userName = "Guest";
            }
            Session.Add("userName", userName);

            try
            {
                // Preload reg recipe list database to be displayed on grid view
                RecipeWS.RecipeWebService ws = new RecipeWS.RecipeWebService();
                RecipeWS.WSRecipe[] wsList = ws.GetWebServiceRecipes();
                int count = wsList.Length;

                for (int i = 0; i < count; i++)
                {
                    Recipe recipe = new Recipe();
                    recipe.RecipeName = wsList[i].RecipeName;
                    recipe.RecipeIngredients = wsList[i].RecipeIngredients;
                    recipe.RecipeInstructions = wsList[i].RecipeInstructions;
                    recipe.RecipeSize = wsList[i].RecipeSize;
                    recipe.RecipeImage = wsList[i].RecipeImage;
                    list.Add(recipe);
                }
            }
            catch
            {
                Debug.WriteLine("Unable to load data from Service1Client!");
                Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", "<script>alert('Error! Unable to retrieve recipe list from host!');</script>");
            }

            RecipeMgr recipeMgr = new RecipeMgr();
            RecipeLists loadData = new RecipeLists();

            // Create the recipe list database with preloaded recipes
            recipeMgr.storeRecipes(list);

            // Try to retrieve bool recipeAdded variable if available
            try
            {
                recipeAdded = (bool)(Session["recipeAdded"]);
            }
            catch (Exception ex)
            {
                Debug.Write(ex.StackTrace);
                Debug.WriteLine("Form loaded with no recipeAdded variable available.");
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

            // Display success message if recipe successfully added to list from AddRecipeForm
            // Change the session bool variables back to false
            if (recipeAdded)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", "<script>alert('Success! Recipe Added to List!');</script>");
                Session["recipeAdded"] = false;
            }
            else if (recipeDeleted)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", "<script>alert('Recipe successfully deleted from list!');</script>");
                Session["recipeDeleted"] = false;
            }
        }

        protected void AddRecipeButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("AddRecipeForm.aspx");
        }

        protected void SelectedItem(object sender, ListViewSelectEventArgs e)
        {

        }

        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {   
            // Get location of item selected on the grid and assign bool var to false
            int clickedRecipe = Convert.ToInt32(e.CommandArgument.ToString());
            bool isOnFavorites = false;

            // Assign location variable to one less to get correct database location
            clickedRecipe--;

            // Add variables to session and transfer them to details form
            Session.Add("clickedRecipe", clickedRecipe);
            Session.Add("isOnFavorites", isOnFavorites);
            Server.Transfer("DetailsForm.aspx");
        }

        protected void FavListButton_Click1(object sender, EventArgs e)
        {
            string userName = User.Identity.Name;
            if(userName == "")
            {
                userName = "Guest";
            }
            Session.Add("userName", userName);
            Server.Transfer("FavoriteListForm.aspx");
        }

        protected void imgPreview_Click(object sender, ImageClickEventArgs e)
        {
            // Get location of item selected on the grid and assign bool var to false
            ImageButton button = sender as ImageButton;
            int clickedRecipe = Convert.ToInt32(button.CommandArgument.ToString());
            bool isOnFavorites = false;

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