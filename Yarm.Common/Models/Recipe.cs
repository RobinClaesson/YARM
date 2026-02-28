namespace Yarm.Common.Models;

public class Recipe
{
    public int Id { get; set; }
    public required string Title { get; set; }
    public int? EstimatedTimeInMinutes { get; set; }
    public List<string> Tags { get; set; } = [];
    public List<Ingredient> Ingredients { get; set; } = [];
    public List<RecipeStep> Steps { get; set; } = [];

    public RecipePreview ToPreview() => new()
    {
        RecipeId = Id,
        Title = Title,
        Tags = Tags.ToList()
    };
}