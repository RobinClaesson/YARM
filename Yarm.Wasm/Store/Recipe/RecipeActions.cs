using Yarm.Common.Models;
using Yarm.Wasm.RecipeSources;

namespace Yarm.Wasm.Store.Recipe;

public record RecipeSourcesLoadedAction(List<RecipeSourceInfo> RecipeSourceInfos);
public record RecipePreviewsLoadedAction(List<RecipePreview> RecipePreviews);