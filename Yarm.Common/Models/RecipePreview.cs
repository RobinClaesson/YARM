namespace Yarm.Common.Models;

public class RecipePreview
{
    public required int RecipeId { get; set; }
    public required string Title { get; set; }
    public List<string> Tags { get; set; } = [];
}