using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Web;

namespace JacobRiosMyRecipes.Model.Domain
{
    [Serializable]

    public class Recipe
    {
        private string recipeName;
        private string recipeIngredients;
        private byte[] recipeImage;
        private string recipeInstructions;
        private string recipeId;
        private int recipeSize;

        // Default Constructor
        public Recipe()
        {
        }

        // Constructor where all values are given
        public Recipe(string recipeName, string recipeIngredients, string recipeInstructions,
            string recipeId)
        {
            this.recipeName = recipeName;
            this.recipeIngredients = recipeIngredients;
            this.recipeInstructions = recipeInstructions;
            this.recipeId = recipeId;
        }

        // Constructor where only recipe name is given
        public Recipe(string recipeName)
        {

            this.recipeName = recipeName;

            // Following strings are set to remind user that more information is needed
            recipeIngredients = "Ingredients for delicious recipe!!";
            recipeInstructions = "Cooking instructions to your delicious recipe!!";
        }

        // Constructor where recipe name, ingredients, and instructions are given
        public Recipe(string recipeName, string recipeIngredients, string recipeInstructions)
        {
            this.recipeName = recipeName;
            this.recipeIngredients = recipeIngredients;
            this.recipeInstructions = recipeInstructions;
        }

        // Constructor where everything but recipeId is given
        public Recipe(string recipeName, string recipeIngredients, string recipeInstructions,
            int recipeSize, byte[] recipeImage)
        {
            this.recipeName = recipeName;
            this.recipeIngredients = recipeIngredients;
            this.recipeInstructions = recipeInstructions;
            this.recipeSize = recipeSize;
            this.recipeImage = recipeImage;
        }
        // Getters and Setters

        // Returns the recipe's Id value
        public string RecipeId
        {
            get { return recipeId; }
            set { this.recipeId = value; }
        }

        // Returns the recipe's name
        public string RecipeName
        {
            get { return recipeName; }
            set { this.recipeName = value; }
        }

        // Returns the recipe's instructions
        public string RecipeInstructions
        {
            get { return recipeInstructions; }
            set { this.recipeInstructions = value; }
        }

        // Returns the recipe's ingredients
        public string RecipeIngredients
        {
            get { return recipeIngredients; }
            set { this.recipeIngredients = value; }
        }

        // Returns the recipe's image size
        public int RecipeSize
        {
            get { return recipeSize; }
            set { this.recipeSize = value; }
        }

        // Returns the recipe's image
        public byte[] RecipeImage
        {
            get { return recipeImage; }
            set { this.recipeImage = value; }
        }

        // Validate recipe name is not null or empty
        // All other variables can be null
        public bool validate()
        {
            if (RecipeName == null || RecipeName.Equals(""))
            {
                return false;
            }

            return true;
        }

        // Overriden ToString method for debugging purposes
        public override string ToString()
        {
            StringBuilder strBfr = new StringBuilder();

            strBfr.Append("recipeName:");
            strBfr.Append(recipeName);
            strBfr.Append("\nrecipeIngredients:");
            strBfr.Append(recipeIngredients);
            strBfr.Append("\nrecipeInstructions:");
            strBfr.Append(recipeInstructions);
            strBfr.Append("\nrecipeId:");
            strBfr.Append(recipeId);
            strBfr.Append("\nrecipeImage:");
            strBfr.Append(recipeImage);

            return strBfr.ToString();
        }
    }
}