using JacobRiosMyRecipes.Model.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JacobRiosMyRecipes.Model.Services
{
    public interface IRecipeSvc : IService
    {
        // Interface to create a new recipe
        void create(List<Recipe> list);

        // Interface to retrieve and create a list of recipes (maybe from database)
        List<Recipe> retrieveAllRecipes();

        // Interface to add a single recipe to a stored recipe list
        void add(Recipe recipe);

        // Interface to update/edit a stored recipe
        void update(Recipe recipe);

        // Interface to delete a recipe from a list
        void delete(String id);

        // Interface to delete multipe recipes from a list
        void deleteMultiple(string recipesToDelete);
    }
}
