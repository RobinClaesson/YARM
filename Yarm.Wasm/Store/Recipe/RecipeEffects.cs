using Fluxor;
using Yarm.Wasm.RecipeSources;
using Yarm.Wasm.Services;

namespace Yarm.Wasm.Store.Recipe;

public class RecipeEffects(IRecipeSourcesService recipeSourcesService)
{
    [EffectMethod(typeof(StoreInitializedAction))]
    public Task OnStoreInitializedAction(IDispatcher dispatcher)
    {
        var sources = new List<RecipeSourceInfo> { RecipeSourceInfo.LocalStorage };
        sources.AddRange(recipeSourcesService.GetRecipeSourceInfos());
        dispatcher.Dispatch(new RecipeSourcesLoadedAction(sources));

        return Task.CompletedTask;
    }

    [EffectMethod]
    public async Task OnRecipeSourcesLoadedAction(RecipeSourcesLoadedAction action, IDispatcher dispatcher)
    {
        foreach (var source in recipeSourcesService.GetAllRecipeSources())
        {
            var recipePreviews = await source.GetRecipePreviewsAsync();
            dispatcher.Dispatch(new RecipePreviewsLoadedAction(recipePreviews.ToList()));
        }
    }
}