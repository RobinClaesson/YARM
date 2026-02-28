namespace Yarm.RecipeSources.Factory;

public interface IRecipeSourceFactory
{
    public IRecipeSource Create(string recipeSourceTypeName);
    public IRecipeSource Create(string recipeSourceTypeName, IDictionary<string, string> config);
    public IRecipeSource Create<TRecipeSource>() where TRecipeSource : IRecipeSource;
    public IRecipeSource Create<TRecipeSource>(IDictionary<string, string> config) where TRecipeSource : IRecipeSource;
}