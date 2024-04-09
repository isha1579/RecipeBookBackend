using System.ComponentModel.DataAnnotations;

namespace RecipeBook
{
    public class Recipe
    {
        [Key]
        public int Id { get; set; } 
        public required string Category { get; set; }
        public required string Name { get; set; }
        public required string Ingredients { get; set; }
        public required string Procedure { get; set; }
    }
}
