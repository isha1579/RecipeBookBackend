using Microsoft.AspNetCore.Mvc;
using RecipeBook;
using Services;
using System.Collections.Generic;

namespace DatasetAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class RecipesController : ControllerBase
    {
        private readonly RecipeServices _recipeService;

        public RecipesController(RecipeServices recipeService)
        {
            _recipeService = recipeService;
        }

        [HttpGet]
        public List<Recipe> GetRecipes()
        {
            return _recipeService.GetAllRecipes();
        }
        [HttpGet("{id}")]
        public ActionResult<Recipe> GetRecipe(int id)
        {
            var recipe = _recipeService.GetRecipeById(id);
            if (recipe == null)
            {
                return NotFound();
            }
            return recipe;
        }

        [HttpPost]
        public void AddRecipe(Recipe recipe)
        {
            _recipeService.AddRecipe(recipe);
        }
        [HttpPut("{id}")]
        public IActionResult UpdateRecipe(int id, Recipe recipe)
        {
            string result = _recipeService.UpdateRecipe(id, recipe);
            if (result == "Recipe updated successfully")
            {
                return Ok(new { message = "Recipe updated successfully" });
            }
            else if (result == "Recipe not found")
            {
                return NotFound(new { message = "Recipe not found" });
            }
            else
            {
                return BadRequest(new { message = "An error occurred while updating the recipe" });
            }
        }



        [HttpDelete("{id}")]
        public IActionResult DeleteRecipe(int id)
        {
            var result = _recipeService.DeleteRecipe(id);
            return Ok(result); 
        }

        [HttpGet("category/{category}")]
        public List<Recipe> GetRecipesByCategory(string category)
        {
            return _recipeService.GetRecipesByCategory(category);
        }

        [HttpGet("veg")]
        public List<Recipe> GetVegRecipes()
        {
            return _recipeService.GetVegRecipes();
        }
        [HttpGet("non-veg")]
        public List<Recipe> GetNonVegRecipes()
        {
            return _recipeService.GetNonVegRecipes();
        }
        [HttpGet("vegan")]
        public List<Recipe> GetVeganRecipes()
        {
            return _recipeService.GetVeganRecipes();
        }
    }
}
