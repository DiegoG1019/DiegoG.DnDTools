namespace DiegoG.DnDTools.InventoryManager;

public readonly struct Money(ushort copper, ushort silver, ushort electron, ushort gold, ushort platinum)
{
    public ushort Copper { get; init; } = copper;
    public ushort Silver { get; init; } = silver;
    public ushort Electron { get; init; } = electron;
    public ushort Gold { get; init; } = gold;
    public ushort Platinum { get; init; } = platinum;
}
