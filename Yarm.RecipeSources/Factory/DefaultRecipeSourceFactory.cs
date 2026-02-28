namespace Yarm.RecipeSources.Factory;

public class DefaultRecipeSourceFactory(IEnumerable<IRecipeSource> recipeSources) : IRecipeSourceFactory
{
    public IRecipeSource Create(string recipeSourceType)
    {
        var source = recipeSources.FirstOrDefault(x => x.GetType().Name == recipeSourceType);
        return source ?? throw new ArgumentException($"Found no registered RecipeSource of type '{recipeSourceType}'",
            nameof(recipeSourceType));
    }

    public IRecipeSource Create(string recipeSourceType, IDictionary<string, string> config)
    {
        var source = Create(recipeSourceType);
        source.Configure(config);
        return source;
    }

    public IRecipeSource Create<TRecipeSource>() where TRecipeSource : IRecipeSource
    {
        var type = typeof(TRecipeSource);
        var source = recipeSources.FirstOrDefault(x => x.GetType() == type);

        return source ?? throw new ArgumentException($"Found no registered RecipeSource of type '{type}'",
            nameof(TRecipeSource));
    }

    public IRecipeSource Create<TRecipeSource>(IDictionary<string, string> config) where TRecipeSource : IRecipeSource
    {
        var source = Create<TRecipeSource>();
        source.Configure(config);
        return source;
    }
}