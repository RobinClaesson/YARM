using Fluxor;
using Yarm.Common.Models;
using Yarm.Wasm.RecipeSources;

namespace Yarm.Wasm.Store.Recipe;

[FeatureState]
public record RecipeState
{
    public List<RecipeSourceInfo> Sources { get; init; } = [];
    public List<RecipePreview> Recipes { get; init; } = [];
}

