using DiegoG.DnDTools.InventoryManager.Defaults;

namespace DiegoG.DnDTools.Sandbox;

internal class Program
{
    static void Main(string[] args)
    {
        var x = DefaultItems.ManualDelJugador.All.First().ItemFactory.Invoke();
        var buffer = x.CreateJsonDnDEntityBuffer();

        var y = buffer.Deserialize();
    }
}
