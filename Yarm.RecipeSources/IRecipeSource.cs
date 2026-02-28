using Yarm.Common.Models;

namespace Yarm.RecipeSources;

public interface IRecipeSource
{
    public void Configure(IDictionary<string, string> config);
    
    public Task<IEnumerable<RecipePreview>> GetRecipePreviewsAsync();
    public Task<Recipe?> GetRecipeAsync(int recipeId);
    public Task<int> SaveRecipeAsync(Recipe recipe);
}