using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Web;

namespace JacobRiosMyRecipes.Model.Domain
{
    [Serializable]

    public class RecipeLists
    {
        public List<Recipe> recipeList;
        public Image recipeImage;

        // Default Constructor
        public RecipeLists()
        {
        }

        // Constructor with only a list of recipes given
        public RecipeLists(List<Recipe> recipeList)
        {
            this.recipeList = recipeList;
            sortRecipeList(recipeList);

            foreach (Recipe r in recipeList)
            {
                recipeImage = assignImage(r.RecipeName);
            }
        }

        // Getters and Setters

        public List<Recipe> RecipeListValues
        {
            get { return recipeList; }
            set { this.recipeList = value; }
        }

        public Image ListImage
        {
            get { return recipeImage; }
            set { this.recipeImage = value; }
        }

        // Retrieve the name of a recipe at a certain location
        public String getRecipeNames(int location)
        {
            return recipeList[location].RecipeName;
        }

        // Get the total count of recipes in the recipe list
        public int getRecipeListCount()
        {
            return recipeList.Count;
        }

        // Sort the list of recipes names in alphabetical order
        public List<Recipe> sortRecipeList(List<Recipe> recipeList)
        {
            recipeList.Sort((x, y) => x.RecipeName.CompareTo(y.RecipeName));
            return recipeList;
        }

        // Method to assign image to recipe object
        public Image assignImage(string recipeName)
        {
            String nameLowerCase = "";

            // Change all string characters to lower case for switch
            nameLowerCase = recipeName.ToLower();

            switch (nameLowerCase)
            {
                default:
                    break;
            }

            return recipeImage;
        }
    }
}