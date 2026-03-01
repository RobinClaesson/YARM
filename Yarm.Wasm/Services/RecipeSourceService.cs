using Microsoft.JSInterop;
using Yarm.RecipeSources;
using Yarm.RecipeSources.Factory;
using Yarm.Wasm.RecipeSources;

namespace Yarm.Wasm.Services;

public class RecipeSourceService(ILocalStorageService localStorageService, IRecipeSourceFactory recipeSourceFactory)
    : IRecipeSourcesService
{
    private const string RecipeSourcesKey = "RecipeSourceInfos";

    public List<RecipeSourceInfo> GetRecipeSourceInfos() =>
        localStorageService.GetItem<List<RecipeSourceInfo>>(RecipeSourcesKey) ?? [];

    public void AddRecipeSourceInfo(RecipeSourceInfo recipeSourceInfo)
    {
        var currentSources = GetRecipeSourceInfos();
        currentSources.Add(recipeSourceInfo);
        localStorageService.SetItem(RecipeSourcesKey, currentSources);
    }

    public List<IRecipeSource> GetAllRecipeSources() => GetRecipeSourceInfos()
        .Select(GetRecipeSource)
        .ToList();

    public IRecipeSource GetRecipeSource(RecipeSourceInfo recipeSourceInfo) =>
        recipeSourceFactory.Create(recipeSourceInfo.RecipeSourceType);
}