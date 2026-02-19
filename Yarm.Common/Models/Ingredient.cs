namespace Yarm.Common.Models;

public class Ingredient
{
    public required string Name { get; set; }
    public required double Quantity { get; set; }
    public required MeasurementUnit Unit { get; set; }

    public MeasurementUnitType UnitType => Unit.GetUnitType();
}