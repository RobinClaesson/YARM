using Microsoft.JSInterop;
using Yarm.Common.Models;
using Yarm.Wasm.RecipeSources;

namespace Yarm.Wasm.Extensions;

public static class LocalStorageServiceExtensions
{
    private const string RecipeSourcesKey = "RecipeSourceInfos";

    extension(ILocalStorageService localStorageService)
    {
        public List<RecipeSourceInfo> GetRecipeSourceInfos() =>
            localStorageService.GetItem<List<RecipeSourceInfo>>(RecipeSourcesKey) ?? [];

        public void AddRecipeSourceInfo(RecipeSourceInfo recipeSourceInfo)
        {
            var currentSources = localStorageService.GetRecipeSourceInfos();
            currentSources.Add(recipeSourceInfo);
            localStorageService.SetItem(RecipeSourcesKey, currentSources);
        }
    }
}