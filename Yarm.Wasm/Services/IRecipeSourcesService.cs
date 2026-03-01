using Yarm.RecipeSources;
using Yarm.Wasm.RecipeSources;

namespace Yarm.Wasm.Services;

public interface IRecipeSourcesService
{
    public List<RecipeSourceInfo> GetRecipeSourceInfos();
    public void AddRecipeSourceInfo(RecipeSourceInfo recipeSourceInfo);
    public List<IRecipeSource> GetAllRecipeSources();
    public IRecipeSource GetRecipeSource(RecipeSourceInfo recipeSourceInfo);
}