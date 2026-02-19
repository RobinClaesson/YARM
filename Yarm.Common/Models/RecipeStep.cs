namespace Yarm.Common.Models;

public class RecipeStep
{
    public string? StepTitle { get; set; }
    public List<string> StepInstructions { get; set; } = [];
}