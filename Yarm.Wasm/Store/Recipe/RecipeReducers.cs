using Fluxor;

namespace Yarm.Wasm.Store.Recipe;

public static class RecipeReducers
{
    [ReducerMethod]
    public static RecipeState OnRecipeSourcesLoadedAction(RecipeState state, RecipeSourcesLoadedAction action) =>
        state with
        {
            Sources = state.Sources.Concat(action.RecipeSourceInfos).ToList()
        };

    [ReducerMethod]
    public static RecipeState OnRecipePreviewsLoadedAction(RecipeState state, RecipePreviewsLoadedAction action) =>
        state with
        {
            Recipes = state.Recipes.Concat(action.RecipePreviews).ToList()
        };
}