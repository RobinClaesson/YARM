using Fluxor;
using Microsoft.JSInterop;
using Yarm.RecipeSources.Factory;
using Yarm.Wasm.Extensions;
using Yarm.Wasm.RecipeSources;

namespace Yarm.Wasm.Store.Recipe;

public class RecipeEffects(ILocalStorageService localStorageService, IRecipeSourceFactory recipeSourceFactory)
{
    [EffectMethod(typeof(StoreInitializedAction))]
    public Task OnStoreInitializedAction(IDispatcher dispatcher)
    {
        var sources = new List<RecipeSourceInfo> { RecipeSourceInfo.LocalStorage };
        sources.AddRange(localStorageService.GetRecipeSourceInfos());
        dispatcher.Dispatch(new RecipeSourcesLoadedAction(sources));

        return Task.CompletedTask;
    }

    [EffectMethod]
    public async Task OnRecipeSourcesLoadedAction(RecipeSourcesLoadedAction action, IDispatcher dispatcher)
    {
        var sources = action.RecipeSourceInfos
            .Select(rsi => recipeSourceFactory.Create(rsi.RecipeSourceType, rsi.Config));

        foreach (var source in sources)
        {
            var recipePreviews = await source.GetRecipePreviewsAsync();
            dispatcher.Dispatch(new RecipePreviewsLoadedAction(recipePreviews.ToList()));
        }
    }
    
}