using Yarm.Common.Models;

namespace Yarm.Common.Converting;

public interface IRecipeConverter<T>
{
    public T ConvertFromRecipe(Recipe recipe);
    public Recipe ConvertToRecipe(T convertedRecipe);
}