namespace Yarm.Common.Models;

public class Recipe
{
    public required string Title { get; set; }
    public int? EstimatedTimeInMinutes { get; set; }
    public List<Ingredient> Ingredients { get; set; } = [];
    public List<RecipeStep> Steps { get; set; } = [];
}