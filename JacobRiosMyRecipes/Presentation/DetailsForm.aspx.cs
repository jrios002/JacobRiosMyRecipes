using JacobRiosMyRecipes.Model.Business;
using JacobRiosMyRecipes.Model.Domain;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace JacobRiosMyRecipes.Presentation
{
    public partial class DetailsForm : System.Web.UI.Page
    {
        // Private varibales to be used throughout details form
        private List<Recipe> list = new List<Recipe>();
        private Recipe recipeDisplayed = new Recipe();
        private Recipe updatedRecipe = new Recipe();
        private bool isOnFavorites;
        private string userName = "";

        protected void Page_Load(object sender, EventArgs e)
        {            
            if (!IsPostBack)
            {
                userName = (string)(Session["userName"]);
                EditModeLabel.Visible = false;

                // Assign session information to variables
                int clickedRecipe = (int)(Session["clickedRecipe"]);
                isOnFavorites = (bool)(Session["isOnFavorites"]);

                // Set text boxes to read only so they can't be modified unless they select update btn
                IngredientsBox.ReadOnly = true;
                InstructionsBox.ReadOnly = true;
                LabelBox.ReadOnly = true;
                SaveBtn.Visible = false;
                CancelBtn.Visible = false;

                // If else statements to display recipe from the correct database
                if (isOnFavorites)
                {
                    // Use favorite manager to display recipe from favorites list
                    FavoriteRecipeMgr favMgr = new FavoriteRecipeMgr();
                    list = favMgr.retrieveRecipes(userName);

                    // Hide Add to favorite button since user is currently viewing favorite recipe
                    AddToFavButton.Visible = false;

                    // Show Update button to allow users to modify their favorite recipes
                    UpdateBtn.Visible = true;

                    // Change the text of the delete button so user knows which database they're viewing
                    DeleteButton.Text = "Delete From Favorites";
                }
                else
                {
                    // Use recipe manager to display recipe from regular recipe list
                    RecipeMgr recipeMgr = new RecipeMgr();
                    list = recipeMgr.retrieveRecipes();

                    // Show favorite button since recipe can be added to favorites
                    AddToFavButton.Visible = true;

                    // Hide update button since users are not allowed to edit preloaded recipes
                    UpdateBtn.Visible = false;

                    // Change text of delete button
                    DeleteButton.Text = "Delete From Recipes";
                }

                // Retrieve desired recipe and display recipe information in text boxes
                recipeDisplayed = list[clickedRecipe];
                LabelBox.Text = list[clickedRecipe].RecipeName;
                IngredientsBox.Text = list[clickedRecipe].RecipeIngredients;
                InstructionsBox.Text = list[clickedRecipe].RecipeInstructions;
                string strBase64 = Convert.ToBase64String(list[clickedRecipe].RecipeImage);

                RecipeImage.ImageUrl = "data:Image/jpg;base64," + strBase64;
            }            
        }

        protected void BackButton_Click(object sender, EventArgs e)
        {
            isOnFavorites = (bool)(Session["isOnFavorites"]);

            // If else statement to return to previous list that was displayed
            if (isOnFavorites)
            {
                Response.Redirect("FavoriteListForm.aspx");
            }
            else
            {
                Response.Redirect("RecipeListForm.aspx");
            }
            
        }

        protected void AddToFavButton_Click(object sender, EventArgs e)
        {
            FavoriteRecipeMgr favMgr = new FavoriteRecipeMgr();
            RecipeMgr recipeMgr = new RecipeMgr();
            isOnFavorites = (bool)(Session["isOnFavorites"]);
            int clickedRecipe = (int)(Session["clickedRecipe"]);
            userName = (string)(Session["userName"]);

            list = recipeMgr.retrieveRecipes();
            recipeDisplayed = list[clickedRecipe];

            // Try to store recipe to favorite list and display success message
            try
            {
                favMgr.addRecipe(recipeDisplayed, userName);
                Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", "<script>alert('Recipe Successfully added to Favorite List!!!');</script>");
            }

            // Catch exception for debugging purposes and display error message
            catch(Exception ex)
            {
                Debug.Write(ex.StackTrace);
                Debug.WriteLine(ex.ToString());
                Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", "<script>alert('Error! Unable to save recipe to Favorite List!!!');</script>");
            }
        }

        protected void DeleteButton_Click(object sender, EventArgs e)
        {
            isOnFavorites = (bool)(Session["isOnFavorites"]);
            int clickedRecipe = (int)(Session["clickedRecipe"]);
            userName = (string)(Session["userName"]);

            // If else statement to delete recipe from correct database
            if (isOnFavorites)
            {
                FavoriteRecipeMgr favMgr = new FavoriteRecipeMgr();
                list = favMgr.retrieveRecipes(userName);

                recipeDisplayed = list[clickedRecipe];
                // Try to delete recipe from favorites and redirect to favorites form
                try
                {
                    favMgr.deleteRecipe(recipeDisplayed.RecipeId, userName);
                    bool recipeDeleted = true;
                    Session.Add("recipeDeleted", recipeDeleted);
                    Server.Transfer("FavoriteListForm.aspx");
                }

                // Catch exception for debugging and display error message
                catch(Exception ex)
                {
                    Debug.Write(ex.StackTrace);
                    Debug.WriteLine(ex.ToString());
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", "<script>alert('Error! Unable to delete recipe from Favorite List!!!');</script>");
                }
            }
            else
            {
                RecipeMgr recipeMgr = new RecipeMgr();
                list = recipeMgr.retrieveRecipes();
                recipeDisplayed = list[clickedRecipe];

                // Try to delete recipe from regular recipe list and redirect to recipe list form
                try
                {
                    recipeMgr.deleteRecipe(recipeDisplayed.RecipeId);
                    bool recipeDeleted = true;
                    Session.Add("recipeDeleted", recipeDeleted);
                    Server.Transfer("RecipeListForm.aspx");
                }

                // Catch exception for debugging and display error message
                catch (Exception ex)
                {
                    Debug.Write(ex.StackTrace);
                    Debug.WriteLine(ex.ToString());
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", "<script>alert('Error! Unable to delete recipe from Recipe List!!!');</script>");
                }
            }            
        }

        protected void UpdateBtn_Click(object sender, EventArgs e)
        {
            // Allow users to be able to edit recipe information
            IngredientsBox.ReadOnly = false;
            InstructionsBox.ReadOnly = false;
            LabelBox.ReadOnly = false;

            SaveBtn.Visible = true;
            CancelBtn.Visible = true;
            UpdateBtn.Visible = false;
            EditModeLabel.Visible = true;
        }

        protected void CancelBtn_Click(object sender, EventArgs e)
        {
            EditModeLabel.Visible = false;
            Response.Redirect("DetailsForm.aspx");
        }

        protected void SaveBtn_Click(object sender, EventArgs e)
        {
            // Update the recipe information in the user's favorite list
            FavoriteRecipeMgr favMgr = new FavoriteRecipeMgr();
            userName = (string)(Session["userName"]);

            // Assign recipe info to a different recipe to be updated if need be
            int clickedRecipe = (int)(Session["clickedRecipe"]);
            list = favMgr.retrieveRecipes(userName);
            recipeDisplayed = list[clickedRecipe];
            updatedRecipe = recipeDisplayed;            
            updatedRecipe.RecipeName = LabelBox.Text;
            updatedRecipe.RecipeIngredients = IngredientsBox.Text;
            updatedRecipe.RecipeInstructions = InstructionsBox.Text;
            favMgr.updateRecipe(updatedRecipe, userName);
            EditModeLabel.Visible = true;
            Response.Redirect("DetailsForm.aspx");
        }

        protected void LoginStatus2_LoggedOut(object sender, EventArgs e)
        {
            RecipeWS.RecipeWebService ws = new RecipeWS.RecipeWebService();
            ws.ReadUserInformation(User.Identity.Name.ToString(), DateTime.Now.ToString(), "Logged Out");
        }
    }
}