using Microsoft.JSInterop;
using Yarm.Common.Models;
using Yarm.RecipeSources;

namespace Yarm.Wasm.RecipeSources;

public class LocalStorageRecipeSource(ILocalStorageService localStorageService) : IRecipeSource
{
    private const string RecipePreviewsKey = "RecipePreviews";
    private const string RecipeIncrementKey = "RecipeIncrement";

    public void Configure(IDictionary<string, string> config)
    {
    }

    public Task<IEnumerable<RecipePreview>> GetRecipePreviewsAsync() => Task.FromResult<IEnumerable<RecipePreview>>(
        localStorageService.GetItem<List<RecipePreview>>(RecipePreviewsKey) ?? []);

    public Task<Recipe?> GetRecipeAsync(int recipeId)
    {
        var key = GetRecipeKey(recipeId);
        var recipe = localStorageService.GetItem<Recipe>(key);
        return Task.FromResult(recipe);
    }

    public Task<int> SaveRecipeAsync(Recipe recipe)
    {
        if (recipe.Id == 0)
            recipe.Id = GetNextRecipeIdIncrement();

        var key = GetRecipeKey(recipe.Id);
        localStorageService.SetItem(key, recipe);

        return Task.FromResult(recipe.Id);
    }

    public int GetNextRecipeIdIncrement()
    {
        var increment = localStorageService.GetItem<int>(RecipeIncrementKey) + 1;
        localStorageService.SetItem(RecipeIncrementKey, increment);
        return increment;
    }

    private static string GetRecipeKey(int id) => $"Recipe:{id}";
}