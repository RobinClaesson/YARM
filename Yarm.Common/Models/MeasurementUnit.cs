namespace Yarm.Common.Models;

public enum MeasurementUnit
{
    None,
    Pieces,
    Milliliter,
    Centiliter,
    Deciliter,
    Liter,
    SpiceMeasure,
    TeaSpoon,
    TableSpoon,
    Gram,
    Hectogram,
    Kilogram,
}

public enum MeasurementUnitType
{
    None,
    Volume,
    Mass,
}

public static class MeasurementUnitsExtensions
{
    extension(MeasurementUnit unit)
    {
        public MeasurementUnitType GetUnitType() => unit switch
        {
            MeasurementUnit.None or
                MeasurementUnit.Pieces => MeasurementUnitType.None,

            MeasurementUnit.Milliliter or
                MeasurementUnit.Centiliter or
                MeasurementUnit.Deciliter or
                MeasurementUnit.Liter or
                MeasurementUnit.SpiceMeasure or
                MeasurementUnit.TeaSpoon or
                MeasurementUnit.TableSpoon => MeasurementUnitType.Volume,

            MeasurementUnit.Gram or
                MeasurementUnit.Hectogram or
                MeasurementUnit.Kilogram => MeasurementUnitType.Mass,

            _ => throw new ArgumentOutOfRangeException(nameof(unit), unit, null)
        };
    }
}