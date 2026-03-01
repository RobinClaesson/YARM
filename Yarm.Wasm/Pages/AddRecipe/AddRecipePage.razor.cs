using Fluxor;
using Fluxor.Blazor.Web.Components;
using Microsoft.AspNetCore.Components;
using PSC.Blazor.Components.MarkdownEditor;
using Yarm.Wasm.Services;
using Yarm.Wasm.Store.Edit;

namespace Yarm.Wasm.Pages.AddRecipe;

public partial class AddRecipePage : FluxorComponent
{
    [Inject] private IState<EditRecipeState> EditRecipeState { get; set; } = null!;
    [Inject] private IDispatcher Dispatcher { get; set; } = null!;
    [Inject] private IRecipeSourcesService RecipeSourcesService { get; set; } = null!;

    private static readonly string[] HiddenMarkdownButtons =
        ["mde-tb-preview", "mde-tb-side-by-side", "mde-tb-code", "mde-tb-fullscreen"];

    private Task OnMarkdownValueChanged(string value)
    {
        Dispatcher.Dispatch(new EditRecipeContentUpdatedAction(value));
        return Task.CompletedTask;
    }
}