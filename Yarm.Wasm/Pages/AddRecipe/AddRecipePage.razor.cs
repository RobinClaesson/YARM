using Fluxor;
using Fluxor.Blazor.Web.Components;
using Microsoft.AspNetCore.Components;
using Yarm.Common.Models;
using Yarm.Wasm.Store.Edit;
using Yarm.Wasm.Store.Recipe;

namespace Yarm.Wasm.Pages.AddRecipe;

public partial class AddRecipePage : FluxorComponent
{
    [Inject] private IState<EditRecipeState> EditRecipeState { get; set; } = null!;
    [Inject] private IDispatcher Dispatcher { get; set; } = null!;
    
    private Task OnMarkdownValueChanged(string value)
    {
        Dispatcher.Dispatch(new EditRecipeContentUpdatedAction(value));
        return Task.CompletedTask;
    }

    private void AddRecipeStep()
    {
    }
}