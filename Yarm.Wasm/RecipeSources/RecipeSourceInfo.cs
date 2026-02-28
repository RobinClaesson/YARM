using System.Text.Json.Serialization;

namespace Yarm.Wasm.RecipeSources;

public record RecipeSourceInfo
{
    public required string Name { get; init; }
    public string Description { get; init; } = string.Empty;
    public required string RecipeSourceType { get; init; }
    public Dictionary<string, string> Config { get; init; } = new();

    public static RecipeSourceInfo LocalStorage => new()
    {
        Name = "Local",
        Description = "Stores recipes in your browsers local storage. Not recomended for longtime storage.",
        RecipeSourceType = "LocalStorageRecipeSource",
    };
}