using System.Text.Json;
using Fluxor;
using Fluxor.Blazor.Web.Components;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using Yarm.Wasm.RecipeSources;
using Yarm.Wasm.Store.Recipe;

namespace Yarm.Wasm.Pages.Home;

public partial class HomePage : FluxorComponent
{
    [Inject] public IState<RecipeState> RecipeState { get; set; } = null!;
    [Inject] public IDispatcher Dispatcher { get; set; } = null!;

    public void TestButton()
    {
    }
}