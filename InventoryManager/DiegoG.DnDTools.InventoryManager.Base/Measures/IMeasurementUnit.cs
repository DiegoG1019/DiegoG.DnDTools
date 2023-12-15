namespace DiegoG.DnDTools.InventoryManager.Measures;

internal interface IMeasurementUnit<TStruct, TUnit>
    where TStruct : struct
    where TUnit : unmanaged, Enum
{
    public double Value { get; }
    public TUnit Unit { get; }
}
