using Fluxor;

namespace Yarm.Wasm.Store.Edit;

public static class EditRecipeReducers
{
    [ReducerMethod]
    public static EditRecipeState OnEditRecipeContentUpdatedAction(EditRecipeState state,
        EditRecipeContentUpdatedAction action) =>
        state with
        {
            Content = action.UpdatedContent
        };
}