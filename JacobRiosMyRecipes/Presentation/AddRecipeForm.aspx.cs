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
    public partial class AddRecipeForm : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void SaveButton_Click(object sender, EventArgs e)
        {
            try
            {
                // Assign text values to recipe and try to save it to database
                Recipe recipeToAdd = new Recipe(NameBox.Text, IngredientsBox.Text,
                    InstructionsBox.Text);
                if (!ImageUpload.Equals(null))
                {
                    HttpPostedFile postedFile = ImageUpload.PostedFile;
                    string fileName = Path.GetFileName(postedFile.FileName);
                    string fileExtenstion = Path.GetExtension(fileName);
                    int fileSize = postedFile.ContentLength;

                    if(fileExtenstion.ToLower() == ".jpg" || fileExtenstion.ToLower() == ".bmp" ||
                        fileExtenstion.ToLower() == ".gif" || fileExtenstion.ToLower() == ".png")
                    {
                        Stream stream = postedFile.InputStream;
                        BinaryReader binReader = new BinaryReader(stream);
                        byte[] bytes = binReader.ReadBytes((int)stream.Length);
                        recipeToAdd.RecipeSize = fileSize;
                        recipeToAdd.RecipeImage = bytes;
                    }
                    else
                    {
                        throw new ApplicationException();
                    }

                }
                else
                {
                    ImageConverter imgConverter = new ImageConverter();
                    byte[] bytes = (byte[])imgConverter.ConvertTo(
                        Properties.Resources.MyRecipes, typeof(byte[]));
                    recipeToAdd.RecipeSize = 0;
                    recipeToAdd.RecipeImage = bytes;
                }

                RecipeMgr recipeMgr = new RecipeMgr();
                recipeMgr.addRecipe(recipeToAdd);

                bool recipeAdded = true;
                Session.Add("recipeAdded", recipeAdded);
                Server.Transfer("RecipeListForm.aspx");
            }
            catch(ApplicationException ex)
            {
                // Display what type of file can be used for recipe image
                Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", 
                    "<script>alert('Error! Only images .jpg, .png, .bmp, or " +
                    ".png can be uploaded!!');</script>");

                // For Debugging
                Debug.Write(ex.StackTrace);
                Debug.WriteLine(ex.ToString());
            }
            catch (Exception ex)
            {
                // Display alert message that recipe could not be added
                Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", 
                    "<script>alert('Error! Unable to add recipe to list!');</script>");

                // For Debugging
                Debug.Write(ex.StackTrace);
                Debug.WriteLine(ex.ToString());
            }            
        }

        protected void CancelButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("RecipeListForm.aspx");
        }

        protected void BackBtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("RecipeListForm.aspx");
        }

        protected void LoginStatus2_LoggedOut(object sender, EventArgs e)
        {
            RecipeWS.RecipeWebService ws = new RecipeWS.RecipeWebService();
            ws.ReadUserInformation(User.Identity.Name.ToString(), DateTime.Now.ToString(), "Logged Out");
        }
    }
}