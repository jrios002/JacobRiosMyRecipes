using JacobRiosMyRecipes.Model.Domain;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Web;
using System.Web.UI;

namespace JacobRiosMyRecipes.Model.Services
{
    public class RecipeSQLSvcImpl : IRecipeSvc
    {
        private SqlConnection dbConnection;
        private int numberAdded = 0;
        private string SQLname = "";
        private string SQLingredient = "";
        private string SQLinstruct = "";
        private string SQLimage = "";
        private string SQLsize = "";

        public void create(List<Recipe> list)
        {
            // Connect to SQLite database or create the file if it doesn't exists
            dbConnection = new SqlConnection(
                ConfigurationManager.ConnectionStrings["RecipeDatabaseConnectionString1"].
                ConnectionString);
            dbConnection.Open();

            // Create a sqlite command to test if there is anything stored in the table
            string testDatabase = "SELECT COUNT(*) FROM RecipeTable";
            SqlCommand command = new SqlCommand(testDatabase, dbConnection);

            // Try catch method to create a table if none exists in the database
            try
            {
                string count = command.ExecuteScalar().ToString();

                if (count != null && count == "0")
                {
                    foreach (Recipe r in list)
                    {
                        SQLname = "@name" + numberAdded.ToString();
                        SQLingredient = "@ingredients" + numberAdded.ToString();
                        SQLinstruct = "@instructions" + numberAdded.ToString();
                        SQLimage = "@image" + numberAdded.ToString();
                        SQLsize = "@size" + numberAdded.ToString();

                        command.CommandText = "INSERT INTO RecipeTable " +
                        "(Name, Ingredients, Instructions, RecipeImg, Size) VALUES " + "(" +
                        SQLname + ", " + SQLingredient + ", " + SQLinstruct + ", " + SQLimage +
                        ", " + SQLsize + ")";
                        command.Parameters.AddWithValue(SQLname, r.RecipeName);
                        command.Parameters.AddWithValue(SQLingredient, r.RecipeIngredients);
                        command.Parameters.AddWithValue(SQLinstruct, r.RecipeInstructions);
                        command.Parameters.AddWithValue(SQLimage, r.RecipeImage);
                        command.Parameters.AddWithValue(SQLsize, r.RecipeSize);
                        try
                        {
                            command.ExecuteNonQuery();
                            numberAdded++;
                        }
                        catch (Exception e)
                        {
                            Debug.WriteLine(e.Message);
                        }
                    }
                }
            }

            // Catch sqlite exception to create a table if none exists
            catch (SqlException e1)
            {
                Debug.WriteLine(e1.ToString());
                Debug.Write(e1.StackTrace);

                command.CommandText = "CREATE TABLE [RecipeTable]([Id] INT NOT NULL " +
                    "IDENTITY(1, 1) PRIMARY KEY,[Name] TEXT NULL,[Ingredients] TEXT NULL," +
                    "[Instructions] TEXT NULL,[RecipeImg] VARBINARY(MAX) NULL, [Size] INT NULL)";
                command.ExecuteNonQuery();
                foreach (Recipe r in list)
                {
                    SQLname = "@name" + numberAdded.ToString();
                    SQLingredient = "@ingredients" + numberAdded.ToString();
                    SQLinstruct = "@instructions" + numberAdded.ToString();
                    SQLimage = "@image" + numberAdded.ToString();
                    SQLsize = "@size" + numberAdded.ToString();

                    command.CommandText = "INSERT INTO RecipeTable " +
                    "(Name, Ingredients, Instructions, RecipeImg, Size) VALUES " + "(" +
                    SQLname + ", " + SQLingredient + ", " + SQLinstruct + ", " + SQLimage +
                    ", " + SQLsize + ")";
                    command.Parameters.AddWithValue(SQLname, r.RecipeName);
                    command.Parameters.AddWithValue(SQLingredient, r.RecipeIngredients);
                    command.Parameters.AddWithValue(SQLinstruct, r.RecipeInstructions);
                    command.Parameters.AddWithValue(SQLimage, r.RecipeImage);
                    command.Parameters.AddWithValue(SQLsize, r.RecipeSize);
                    try
                    {
                        command.ExecuteNonQuery();
                        numberAdded++;
                    }
                    catch (Exception e)
                    {
                        string error = e.ToString();
                        Debug.WriteLine(e.Message);
                    }
                }
            }

            // Catch if no sqlite table could be created in the database for debugging purposes
            catch (Exception e1)
            {
                Debug.WriteLine(e1.ToString());
                Debug.Write(e1.StackTrace);
            }

            dbConnection.Close();
        }

        public List<Recipe> retrieveAllRecipes()
        {
            List<Recipe> list = new List<Recipe>();

            // Connect to database and create sqlite command to read from database
            dbConnection = new SqlConnection(
                ConfigurationManager.ConnectionStrings["RecipeDatabaseConnectionString1"].
                ConnectionString);
            dbConnection.Open();
            SqlCommand command = dbConnection.CreateCommand();
            command.CommandText = @"SELECT * FROM RecipeTable";
            command.CommandType = CommandType.Text;

            // Try to read all the recipes stored in sqlite database
            try
            {
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    Recipe recipe = new Recipe();
                    recipe.RecipeId = reader["Id"].ToString();
                    recipe.RecipeName = reader["Name"].ToString();
                    recipe.RecipeIngredients = reader["Ingredients"].ToString();
                    recipe.RecipeInstructions = reader["Instructions"].ToString();
                    recipe.RecipeImage = (byte[])reader["RecipeImg"];
                    recipe.RecipeSize = (int)reader["Size"];
                    
                    list.Add(recipe);
                }
            }

            // Catch sqlite exception if no recipes are stored and display message
            catch (SqlException e2)
            {
                Debug.WriteLine(e2.ToString());
                Debug.Write(e2.StackTrace);
            }

            // Catch any other exception for debugging purposes
            catch (Exception e2)
            {
                Debug.WriteLine(e2.ToString());
                Debug.Write(e2.StackTrace);
            }

            dbConnection.Close();
            return list;
        }

        public void add(Recipe recipe)
        {
            List<Recipe> list = new List<Recipe>();
            RecipeLists sortedList = new RecipeLists();

            // Retrieve all recipes in database if any and add new recipe to list
            list = retrieveAllRecipes();
            list.Add(recipe);

            // Sort all the recipes including newly added recipe in alphabetical order
            list = sortedList.sortRecipeList(list);

            // Try to drop the old table and create recipe list database
            try
            {
                dropTable();
                create(list);
                var page = HttpContext.Current.CurrentHandler as Page;
                ScriptManager.RegisterStartupScript(page, 
                    page.GetType(), "Scripts", 
                    "<script>alert('Recipe Successfully Added to Recipe List!!!');</script>", 
                    false);
            }

            // Catch sqlite exception to see if database error occurs
            catch (SqlException e3)
            {
                Debug.WriteLine("Unable to add recipe!", e3.ToString());
                Debug.Write(e3.StackTrace);
            }

            // Catch any other exception for debugging
            catch (Exception e3)
            {
                Debug.WriteLine(e3.ToString());
                Debug.Write(e3.StackTrace);
            }
        }

        // Method to update the information of a single recipe stored in database
        public void update(Recipe recipe)
        {
            // Connect to database and create commands to delete a recipe from database
            dbConnection = new SqlConnection(
                ConfigurationManager.ConnectionStrings["RecipeDatabaseConnectionString1"].
                ConnectionString);
            dbConnection.Open();
            string updateRow = "UPDATE RecipeTable SET Name = '" +
                recipe.RecipeName + "', Ingredients = '" + recipe.RecipeIngredients +
                "', Instructions = '" + recipe.RecipeInstructions + "' WHERE Id = " +
                recipe.RecipeId + ";";
            SqlCommand command = new SqlCommand(updateRow, dbConnection);

            // Try to update the single recipe of the database
            try
            {
                command.ExecuteNonQuery();
            }
            catch (SqlException e5)
            {
                Debug.WriteLine("Unable to update database!", e5.ToString());
                Debug.Write(e5.StackTrace);
            }
            catch (Exception e5)
            {
                Debug.WriteLine(e5.ToString());
                Debug.Write(e5.StackTrace);
            }

            dbConnection.Close();
        }

        // Method to delete single recipe from database
        public void delete(String id)
        {
            // Connect to database and create commands to delete a recipe from database
            dbConnection = new SqlConnection(
                ConfigurationManager.ConnectionStrings["RecipeDatabaseConnectionString1"].
                ConnectionString);
            dbConnection.Open();
            string deleteRow = "DELETE FROM RecipeTable WHERE Id=" + id.ToString() + ";";
            SqlCommand command = new SqlCommand(deleteRow, dbConnection);

            // Try to delete the recipe from the sqlite database and update database to not
            // include delted recipe
            try
            {
                command.ExecuteNonQuery();
                List<Recipe> list = new List<Recipe>();
                list = retrieveAllRecipes();
                dropTable();
                create(list);
                var page = HttpContext.Current.CurrentHandler as Page;
                ScriptManager.RegisterStartupScript(page, page.GetType(), "Scripts", 
                    "<script>alert('Recipe Successfully Deleted " +
                    "from Recipe List!!!');</script>", false);
            }

            // Catch sqlite exception and display message that recipe was not deleted
            catch (SqlException e4)
            {
                Debug.WriteLine("Recipe not deleted from database", e4.ToString());
                Debug.Write(e4.StackTrace);
            }

            // Catch any other exception and display message that recipe was not deleted
            catch (Exception e4)
            {
                Debug.WriteLine("Recipe not deleted from database", e4.ToString());
                Debug.Write(e4.StackTrace);
            }

            dbConnection.Close();
        }

        // Method to delete a single recipe from database
        public void dropTable()
        {
            // Conntect to database and create commands to delete a table from database
            dbConnection = new SqlConnection(
                ConfigurationManager.ConnectionStrings["RecipeDatabaseConnectionString1"].
                ConnectionString);
            dbConnection.Open();
            string deleteTable = "DROP TABLE IF EXISTS RecipeTable";
            SqlCommand command = new SqlCommand(deleteTable, dbConnection);

            // Try catch command to drop table from sqlite database
            try
            {
                command.ExecuteNonQuery();
            }
            catch (SqlException e5)
            {
                Debug.WriteLine("No Table found, creating new recipe database!", e5.ToString());
                Debug.Write(e5.StackTrace);
            }
            catch (Exception e5)
            {
                Debug.WriteLine("Table unable to be dropped", e5.ToString());
                Debug.Write(e5.StackTrace);
            }

            dbConnection.Close();
        }

        // Method to delete multipe recipes from database
        public void deleteMultiple(string recipesToDelete)
        {
            // Assign count of commas in variable to zero and trim last comma off string
            int count = 0;
            recipesToDelete = recipesToDelete.TrimEnd(',');

            // Count commas to determine what method to use to delete recipe(s) from database
            foreach (char c in recipesToDelete)
            {
                if (c == ',')
                {
                    count++;
                }
            }

            // If count is zero, use delete method to delete single recipe
            if (count == 0)
            {
                delete(recipesToDelete);
            }

            // Method to delete multipe recipes from database
            else
            {
                // Connect to database and create commands to delete a recipes from database
                dbConnection = new SqlConnection(
                ConfigurationManager.ConnectionStrings["RecipeDatabaseConnectionString1"].
                ConnectionString);
                dbConnection.Open();
                string deleteRows = "DELETE FROM RecipeTable WHERE Id in (" +
                    recipesToDelete + ");";
                SqlCommand command = new SqlCommand(deleteRows, dbConnection);

                // Try to delete the recipe from the sqlite database and update database to not
                // include delted recipe
                try
                {
                    command.ExecuteNonQuery();
                    List<Recipe> list = new List<Recipe>();
                    list = retrieveAllRecipes();
                    dropTable();
                    create(list);
                }

                // Catch sqlite exception and display message that recipe was not deleted
                catch (SqlException e6)
                {
                    Debug.WriteLine("Recipes not deleted from database", e6.ToString());
                    Debug.Write(e6.StackTrace);
                }

                // Catch any other exception and display message that recipe was not deleted
                catch (Exception e6)
                {
                    Debug.WriteLine("Recipes not deleted from database", e6.ToString());
                    Debug.Write(e6.StackTrace);
                }

                dbConnection.Close();
            }
        }
    }
}