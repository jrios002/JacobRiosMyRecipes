using JacobRiosMyRecipes.Model.Domain;
using JacobRiosMyRecipes.Model.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JacobRiosMyRecipes.Model.Business
{
    public class FavoriteRecipeMgr : ManagerSuperType
    {
        public FavoriteRecipeMgr()
        {
            // Default constructor
        }

        // Method to store list of favorite recipes to sqlite database using favorite service
        public void storeRecipes(List<Recipe> list, string userName)
        {
            Factory factory = new Factory();
            IFavoriteSvc recipeSvc = (IFavoriteSvc)factory.getService("IFavoriteSvc");
            recipeSvc.create(list, userName);
        }

        // Method to retrieve all recipes stored is sqlite database using favorite service
        public List<Recipe> retrieveRecipes(string userName)
        {
            Factory factory = new Factory();
            IFavoriteSvc recipeSvc = (IFavoriteSvc)factory.getService("IFavoriteSvc");
            List<Recipe> list = recipeSvc.retrieveAllRecipes(userName);
            return list;
        }

        // Method to add a single recipe to sqlite database using favorite service
        public void addRecipe(Recipe recipe, string userName)
        {
            Factory factory = new Factory();
            IFavoriteSvc recipeSvc = (IFavoriteSvc)factory.getService("IFavoriteSvc");
            recipeSvc.add(recipe, userName);
        }

        // Method to delete a single recipe from sqlite database using favorite service
        public void deleteRecipe(string recipe, string userName)
        {
            Factory factory = new Factory();
            IFavoriteSvc recipeSvc = (IFavoriteSvc)factory.getService("IFavoriteSvc");
            recipeSvc.delete(recipe, userName);
        }

        // Method to update a single recipe in the sqlite database using favorite service
        public void updateRecipe(Recipe recipe, string userName)
        {
            Factory factory = new Factory();
            IFavoriteSvc recipeSvc = (IFavoriteSvc)factory.getService("IFavoriteSvc");
            recipeSvc.update(recipe, userName);
        }

        // Method to delete a multiple recipes from sqlite database using favorite service
        public void deleteMultiples(string recipes, string userName)
        {
            Factory factory = new Factory();
            IFavoriteSvc recipeSvc = (IFavoriteSvc)factory.getService("IFavoriteSvc");
            recipeSvc.deleteMultiple(recipes, userName);
        }
    }
}