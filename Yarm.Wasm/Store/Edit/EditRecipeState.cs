using Fluxor;

namespace Yarm.Wasm.Store.Edit;

[FeatureState]
public record EditRecipeState
{
    public string Content { get; init; } = """
                                           # Recipe Title
                                           ## Ingredients
                                           - Water 2 dl

                                           ## Steps
                                           ### Step title
                                           Do some stuff

                                           ### Another step
                                           Do some other stuff
                                           """;
}
