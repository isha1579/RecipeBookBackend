using DatasetAPI;
using RecipeBook;

namespace Services
{
    public class RecipeServices
    {
        private readonly AppDbContext _dbContext;

        public RecipeServices(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public List<Recipe> GetAllRecipes()
        {
            return _dbContext.Recipes.ToList();
        }

        public Recipe GetRecipeById(int id)
        {
            return _dbContext.Recipes.Find(id);
        }

        public void AddRecipe(Recipe recipe)
        {
            _dbContext.Recipes.Add(recipe);
            _dbContext.SaveChanges();
        }

        public string UpdateRecipe(int id, Recipe recipe)
        {
            var existingRecipe = _dbContext.Recipes.Find(id);
            if (existingRecipe == null)
            {
                return "Recipe not found"; // Recipe not found
            }

            try
            {
                // Update properties of existing recipe
                existingRecipe.Category = recipe.Category;
                existingRecipe.Name = recipe.Name;
                existingRecipe.Ingredients = recipe.Ingredients;
                existingRecipe.Procedure = recipe.Procedure;

                _dbContext.SaveChanges();
                return "Recipe updated successfully"; // Return success message
            }
            catch (Exception)
            {
                // Log the exception or handle it appropriately
                return "An error occurred while updating the recipe"; // Return error message
            }
        }



        public string DeleteRecipe(int id)
        {
            var recipe = _dbContext.Recipes.Find(id);
            if (recipe != null)
            {
                _dbContext.Recipes.Remove(recipe);
                _dbContext.SaveChanges();
                return "Recipe deleted successfully";
            }
            else
            {
                return "Recipe not found";
            }
        }


        public List<Recipe> GetRecipesByCategory(string category)
        {
            return _dbContext.Recipes.Where(r => r.Category.ToLower() == category.ToLower()).ToList();
        }
        public List<Recipe> GetVegRecipes()
        {
            return _dbContext.Recipes.Where(r => r.Category.ToLower() == "veg").ToList();
        }
        public List<Recipe> GetNonVegRecipes()
        {
            return _dbContext.Recipes.Where(r => r.Category.ToLower() == "non-veg").ToList();
        }
        public List<Recipe> GetVeganRecipes()
        {
            return _dbContext.Recipes.Where(r => r.Category.ToLower() == "vegan").ToList();
        }
    }
}
