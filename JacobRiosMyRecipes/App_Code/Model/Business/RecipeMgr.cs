using JacobRiosMyRecipes.Model.Domain;
using JacobRiosMyRecipes.Model.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JacobRiosMyRecipes.Model.Business
{
    public class RecipeMgr : ManagerSuperType
    {
        public RecipeMgr()
        {
            // Default constructor
        }

        // Method to store list of recipes to .bin file using recipe service
        public void storeRecipes(List<Recipe> list)
        {
            Factory factory = new Factory();
            IRecipeSvc recipeSvc = (IRecipeSvc)factory.getService("IRecipeSvc");
            recipeSvc.create(list);
        }

        // Method to retrieve list of recipes in .bin file using recipe service
        public List<Recipe> retrieveRecipes()
        {
            Factory factory = new Factory();
            IRecipeSvc recipeSvc = (IRecipeSvc)factory.getService("IRecipeSvc");
            List<Recipe> list = recipeSvc.retrieveAllRecipes();
            return list;
        }

        // Method to add a single recipe to .bin file using recipe service
        public void addRecipe(Recipe recipe)
        {
            Factory factory = new Factory();
            IRecipeSvc recipeSvc = (IRecipeSvc)factory.getService("IRecipeSvc");
            recipeSvc.add(recipe);
        }

        // Method to delete a single recipe from .bin file using recipe service
        public void deleteRecipe(string recipe)
        {
            Factory factory = new Factory();
            IRecipeSvc recipeSvc = (IRecipeSvc)factory.getService("IRecipeSvc");
            recipeSvc.delete(recipe);
        }

        // Method to update a single recipe in the .bin file using recipe service
        public void updateRecipe(Recipe recipe)
        {
            Factory factory = new Factory();
            IRecipeSvc recipeSvc = (IRecipeSvc)factory.getService("IRecipeSvc");
            recipeSvc.update(recipe);
        }

        // Method to delete multiple recipes from .bin file using recipe service
        public void deleteMultiples(string recipes)
        {
            Factory factory = new Factory();
            IRecipeSvc recipeSvc = (IRecipeSvc)factory.getService("IRecipeSvc");
            recipeSvc.deleteMultiple(recipes);
        }
    }
}