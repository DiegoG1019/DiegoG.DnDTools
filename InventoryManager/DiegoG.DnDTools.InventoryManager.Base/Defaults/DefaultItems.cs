using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DiegoG.DnDTools.InventoryManager.Measures;
using ItemComparer = DiegoG.DnDTools.InventoryManager.Utilities.DefaultItemDescriptionEqualityComparer;

namespace DiegoG.DnDTools.InventoryManager.Defaults;

public static class DefaultItems
{
    [DefaultItemContainer]
    public static class ManualDelJugador
    {
        public const string SourceManualDelJugador = "Manual del Jugador";

        static ManualDelJugador()
        {
            var set = new HashSet<DefaultItemDescription>();
            set.UnionWith(EquipoDeAventurero.Concat(Contenedores).Concat(Herramientas));
            All = set.ToFrozenSet();
        }

        public static FrozenSet<DefaultItemDescription> EquipoDeAventurero { get; }
            = new DefaultItemDescription[] {
            new(() => new ItemDescription
            {
                Name = "Ábaco",
                BasePrice = new(copper: 0, silver: 0, electron: 0, gold: 2, platinum: 0),
                WeightPerItem = new(2, MassUnit.Pound)
            }, SourceManualDelJugador),
            new(() => new ItemDescription
            {
                Name = "Abrojos (bolsa de 20)",
                BasePrice = new(copper: 0, silver: 0, electron: 0, gold: 1, platinum: 0),
                WeightPerItem = new(2, MassUnit.Pound)
            }, SourceManualDelJugador),
            new(() => new ItemDescription
            {
                Name = "Aceite (frasco)",
                BasePrice = new(copper: 0, silver: 1, electron: 0, gold: 0, platinum: 0),
                WeightPerItem = new(1, MassUnit.Pound)
            }, SourceManualDelJugador),
            new(() => new ItemDescription
            {
                Name = "Acido (vial)",
                BasePrice = new(copper: 0, silver: 0, electron: 0, gold: 25, platinum: 0),
                WeightPerItem = new(1, MassUnit.Pound)
            }, SourceManualDelJugador),
            new(() => new ItemDescription
            {
                Name = "Agua bendita (frasco)",
                BasePrice = new(copper: 0, silver: 0, electron: 0, gold: 25, platinum: 0),
                WeightPerItem = new(1, MassUnit.Pound)
            }, SourceManualDelJugador),
            new(() => new ItemDescription
            {
                Name = "Almádena",
                BasePrice = new(copper: 0, silver: 0, electron: 0, gold: 2, platinum: 0),
                WeightPerItem = new(10, MassUnit.Pound)
            }, SourceManualDelJugador),
            new(() => new ItemDescription
            {
                Name = "Antídoto (vial)",
                BasePrice = new(copper: 0, silver: 0, electron: 0, gold: 50, platinum: 0)
            }, SourceManualDelJugador),
            new(() => new ItemDescription
            {
                Name = "Antorcha",
                BasePrice = new(copper: 1, silver: 0, electron: 0, gold: 0, platinum: 0),
                WeightPerItem = new(1, MassUnit.Pound)
            }, SourceManualDelJugador),
            new(() => new ItemDescription
            {
                Name = "Aparejos de pesca",
                BasePrice = new(copper: 0, silver: 0, electron: 0, gold: 1, platinum: 0),
                WeightPerItem = new(4, MassUnit.Pound)
            }, SourceManualDelJugador),
            new(() => new ItemDescription
            {
                Name = "Aparejo de poleas",
                BasePrice = new(copper: 0, silver: 0, electron: 0, gold: 1, platinum: 0),
                WeightPerItem = new(5, MassUnit.Pound)
            }, SourceManualDelJugador),
            new(() => new ItemDescription
            {
                Name = "Ariete portátil",
                BasePrice = new(copper: 0, silver: 0, electron: 0, gold: 4, platinum: 0),
                WeightPerItem = new(35, MassUnit.Pound)
            }, SourceManualDelJugador),
            new(() => new ItemDescription
            {
                Name = "Balanza de mercader",
                BasePrice = new(copper: 0, silver: 0, electron: 0, gold: 5, platinum: 0),
                WeightPerItem = new(3, MassUnit.Pound)
            }, SourceManualDelJugador),
            new(() => new ItemDescription
            {
                Name = "Rodamientos (bolsa de 1000)",
                BasePrice = new(copper: 0, silver: 0, electron: 0, gold: 1, platinum: 0),
                WeightPerItem = new(2, MassUnit.Pound)
            }, SourceManualDelJugador),
            new(() => new ItemDescription
            {
                Name = "Bolsa de componentes",
                BasePrice = new(copper: 0, silver: 0, electron: 0, gold: 25, platinum: 0),
                WeightPerItem = new(2, MassUnit.Pound)
            }, SourceManualDelJugador),
            new(() => new ItemDescription
            {
                Name = "Cadena (10 pies)",
                BasePrice = new(copper: 0, silver: 0, electron: 0, gold: 5, platinum: 0),
                WeightPerItem = new(10, MassUnit.Pound)
            }, SourceManualDelJugador),
            new(() => new ItemDescription
            {
                Name = "Cálamo",
                BasePrice = new(copper: 2, silver: 0, electron: 0, gold: 0, platinum: 0)
            }, SourceManualDelJugador),
            new(() => new ItemDescription
            {
                Name = "Campanilla",
                BasePrice = new(copper: 0, silver: 0, electron: 0, gold: 1, platinum: 0)
            }, SourceManualDelJugador),
            new(() => new ItemDescription
            {
                Name = "Carcaj",
                BasePrice = new(copper: 0, silver: 0, electron: 0, gold: 1, platinum: 0),
                WeightPerItem = new(1, MassUnit.Pound)
            }, SourceManualDelJugador),
            new(() => new ItemDescription
            {
                Name = "Catalejo",
                BasePrice = new(copper: 0, silver: 0, electron: 0, gold: 1000, platinum: 0),
                WeightPerItem = new(1, MassUnit.Pound)
            }, SourceManualDelJugador),
            new(() => new ItemDescription
            {
                Name = "Cerradura",
                BasePrice = new(copper: 0, silver: 0, electron: 0, gold: 10, platinum: 0),
                WeightPerItem = new(1, MassUnit.Pound)
            }, SourceManualDelJugador),
            new(() => new ItemDescription
            {
                Name = "Cuerda, de cáñamo (50 pies)",
                BasePrice = new(copper: 0, silver: 0, electron: 0, gold: 1, platinum: 0),
                WeightPerItem = new(10, MassUnit.Pound)
            }, SourceManualDelJugador),
            new(() => new ItemDescription
            {
                Name = "Cuerda, de seda (50 pies)",
                BasePrice = new(copper: 0, silver: 0, electron: 0, gold: 10, platinum: 0),
                WeightPerItem = new(5, MassUnit.Pound)
            }, SourceManualDelJugador),
            new(() => new ItemDescription
            {
                Name = "Escalera de mano (10 pies)",
                BasePrice = new(copper: 0, silver: 1, electron: 0, gold: 0, platinum: 0),
                WeightPerItem = new(25, MassUnit.Pound)
            }, SourceManualDelJugador),
            new(() => new ItemDescription
            {
                Name = "Espejo, de acero",
                BasePrice = new(copper: 0, silver: 0, electron: 0, gold: 5, platinum: 0),
                WeightPerItem = new(0.5, MassUnit.Pound)
            }, SourceManualDelJugador),
            new(() => new ItemDescription
            {
                Name = "Estuche, de virote de ballesta",
                BasePrice = new(copper: 0, silver: 0, electron: 0, gold: 1, platinum: 0),
                WeightPerItem = new(1, MassUnit.Pound)
            }, SourceManualDelJugador),
            new(() => new ItemDescription
            {
                Name = "Estuche, de mapas o pergaminos",
                BasePrice = new(copper: 0, silver: 0, electron: 0, gold: 1, platinum: 0),
                WeightPerItem = new(1, MassUnit.Pound)
            }, SourceManualDelJugador),
            new(() => new ItemDescription
            {
                Name = "Cetro",
                BasePrice = new(copper: 0, silver: 0, electron: 0, gold: 10, platinum: 0),
                WeightPerItem = new(2, MassUnit.Pound),
                Tags = ["Foco arcano"]
            }, SourceManualDelJugador),
            new(() => new ItemDescription
            {
                Name = "Cristal",
                BasePrice = new(copper: 0, silver: 0, electron: 0, gold: 10, platinum: 0),
                WeightPerItem = new(1, MassUnit.Pound),
                Tags = ["Foco arcano"]
            }, SourceManualDelJugador),
            new(() => new ItemDescription
            {
                Name = "Orbe",
                BasePrice = new(copper: 0, silver: 0, electron: 0, gold: 20, platinum: 0),
                WeightPerItem = new(3, MassUnit.Pound),
                Tags = ["Foco arcano"]
            }, SourceManualDelJugador),
            new(() => new ItemDescription
            {
                Name = "Vara",
                BasePrice = new(copper: 0, silver: 0, electron: 0, gold: 5, platinum: 0),
                WeightPerItem = new(4, MassUnit.Pound),
                Tags = ["Foco arcano"]
            }, SourceManualDelJugador),
            new(() => new ItemDescription
            {
                Name = "Varita",
                BasePrice = new(copper: 0, silver: 0, electron: 0, gold: 10, platinum: 0),
                WeightPerItem = new(1, MassUnit.Pound),
                Tags = ["Foco arcano"]
            }, SourceManualDelJugador),
            new(() => new ItemDescription
            {
                Name = "Ramita de muérdago",
                BasePrice = new(copper: 0, silver: 0, electron: 0, gold: 1, platinum: 0),
                Tags = ["Foco druídico"]
            }, SourceManualDelJugador),
            new(() => new ItemDescription
            {
                Name = "Tótem",
                BasePrice = new(copper: 0, silver: 0, electron: 0, gold: 1, platinum: 0),
                Tags = ["Foco druídico"]
            }, SourceManualDelJugador),
            new(() => new ItemDescription
            {
                Name = "Vara de madera",
                BasePrice = new(copper: 0, silver: 0, electron: 0, gold: 5, platinum: 0),
                WeightPerItem = new(4, MassUnit.Pound),
                Tags = ["Foco druídico"]
            }, SourceManualDelJugador),
            new(() => new ItemDescription
            {
                Name = "Varita de tejo",
                BasePrice = new(copper: 0, silver: 0, electron: 0, gold: 10, platinum: 0),
                WeightPerItem = new(1, MassUnit.Pound),
                Tags = ["Foco druídico"]
            }, SourceManualDelJugador),
            new(() => new ItemDescription
            {
                Name = "Fuego de alquimista (frasco)",
                BasePrice = new(copper: 0, silver: 0, electron: 0, gold: 50, platinum: 0),
                WeightPerItem = new(1, MassUnit.Pound)
            }, SourceManualDelJugador),
            new(() => new ItemDescription
            {
                Name = "Garfio o gancho",
                BasePrice = new(copper: 0, silver: 0, electron: 0, gold: 2, platinum: 0),
                WeightPerItem = new(4, MassUnit.Pound)
            }, SourceManualDelJugador),
            new(() => new ItemDescription
            {
                Name = "Grilletes",
                BasePrice = new(copper: 0, silver: 0, electron: 0, gold: 2, platinum: 0),
                WeightPerItem = new(6, MassUnit.Pound)
            }, SourceManualDelJugador),
            new(() => new ItemDescription
            {
                Name = "Jabón",
                BasePrice = new(copper: 2, silver: 0, electron: 0, gold: 0, platinum: 0)
            }, SourceManualDelJugador),
            new(() => new ItemDescription
            {
                Name = "Kit de escalada",
                BasePrice = new(copper: 0, silver: 0, electron: 0, gold: 25, platinum: 0),
                WeightPerItem = new(12, MassUnit.Pound)
            }, SourceManualDelJugador),
            new(() => new ItemDescription
            {
                Name = "Kit de cocina",
                BasePrice = new(copper: 0, silver: 2, electron: 0, gold: 0, platinum: 0),
                WeightPerItem = new(1, MassUnit.Pound)
            }, SourceManualDelJugador),
            new(() => new ItemDescription
            {
                Name = "Kit de curandero",
                BasePrice = new(copper: 0, silver: 0, electron: 0, gold: 5, platinum: 0),
                WeightPerItem = new(3, MassUnit.Pound)
            }, SourceManualDelJugador),
            new(() => new ItemDescription
            {
                Name = "Lacre",
                BasePrice = new(copper: 0, silver: 5, electron: 0, gold: 0, platinum: 0)
            }, SourceManualDelJugador),
            new(() => new ItemDescription
            {
                Name = "Lámpara",
                BasePrice = new(copper: 0, silver: 5, electron: 0, gold: 0, platinum: 0),
                WeightPerItem = new(1, MassUnit.Pound)
            }, SourceManualDelJugador),
            new(() => new ItemDescription
            {
                Name = "Libro",
                BasePrice = new(copper: 0, silver: 0, electron: 0, gold: 25, platinum: 0),
                WeightPerItem = new(5, MassUnit.Pound)
            }, SourceManualDelJugador),
            new(() => new ItemDescription
            {
                Name = "Libro de conjuros",
                BasePrice = new(copper: 0, silver: 0, electron: 0, gold: 50, platinum: 0),
                WeightPerItem = new(3, MassUnit.Pound)
            }, SourceManualDelJugador),
            new(() => new ItemDescription
            {
                Name = "Linterna, ojo de buey",
                BasePrice = new(copper: 0, silver: 0, electron: 0, gold: 10, platinum: 0),
                WeightPerItem = new(2, MassUnit.Pound)
            }, SourceManualDelJugador),
            new(() => new ItemDescription
            {
                Name = "Linterna, sorda o encapuchada",
                BasePrice = new(copper: 0, silver: 0, electron: 0, gold: 5, platinum: 0),
                WeightPerItem = new(2, MassUnit.Pound)
            }, SourceManualDelJugador),
            new(() => new ItemDescription
            {
                Name = "Lupa",
                BasePrice = new(copper: 0, silver: 0, electron: 0, gold: 100, platinum: 0)
            }, SourceManualDelJugador),
            new(() => new ItemDescription
            {
                Name = "Manta",
                BasePrice = new(copper: 0, silver: 5, electron: 0, gold: 0, platinum: 0),
                WeightPerItem = new(3, MassUnit.Pound)
            }, SourceManualDelJugador),
            new(() => new ItemDescription
            {
                Name = "Martillo",
                BasePrice = new(copper: 0, silver: 0, electron: 0, gold: 1, platinum: 0),
                WeightPerItem = new(3, MassUnit.Pound)
            }, SourceManualDelJugador),
            new(() => new ItemDescription
            {
                Name = "Agujas de cerbatana (50)",
                BasePrice = new(copper: 0, silver: 0, electron: 0, gold: 1, platinum: 0),
                WeightPerItem = new(1, MassUnit.Pound),
                Tags = ["Munición"]
            }, SourceManualDelJugador),
            new(() => new ItemDescription
            {
                Name = "Balas de honda (20)",
                BasePrice = new(copper: 4, silver: 0, electron: 0, gold: 0, platinum: 0),
                WeightPerItem = new(1.5, MassUnit.Pound),
                Tags = ["Munición"]
            }, SourceManualDelJugador),
            new(() => new ItemDescription
            {
                Name = "Flechas (20)",
                BasePrice = new(copper: 0, silver: 0, electron: 0, gold: 1, platinum: 0),
                WeightPerItem = new(1, MassUnit.Pound),
                Tags = ["Munición"]
            }, SourceManualDelJugador),
            new(() => new ItemDescription
            {
                Name = "Virotes de ballesta (20)",
                BasePrice = new(copper: 0, silver: 0, electron: 0, gold: 1, platinum: 0),
                WeightPerItem = new(1.5, MassUnit.Pound),
                Tags = ["Munición"]
            }, SourceManualDelJugador),
            new(() => new ItemDescription
            {
                Name = "Pala",
                BasePrice = new(copper: 0, silver: 0, electron: 0, gold: 2, platinum: 0),
                WeightPerItem = new(5, MassUnit.Pound)
            }, SourceManualDelJugador),
            new(() => new ItemDescription
            {
                Name = "Palanca",
                BasePrice = new(copper: 0, silver: 0, electron: 0, gold: 2, platinum: 0),
                WeightPerItem = new(5, MassUnit.Pound)
            }, SourceManualDelJugador),
            new(() => new ItemDescription
            {
                Name = "Papel (una hoja)",
                BasePrice = new(copper: 0, silver: 2, electron: 0, gold: 0, platinum: 0)
            }, SourceManualDelJugador),
            new(() => new ItemDescription
            {
                Name = "Perfume (vial)",
                BasePrice = new(copper: 0, silver: 0, electron: 0, gold: 5, platinum: 0)
            }, SourceManualDelJugador),
            new(() => new ItemDescription
            {
                Name = "Pergamino (una hoja)",
                BasePrice = new(copper: 0, silver: 1, electron: 0, gold: 0, platinum: 0)
            }, SourceManualDelJugador),
            new(() => new ItemDescription
            {
                Name = "Pértiga (10 pies)",
                BasePrice = new(copper: 5, silver: 0, electron: 0, gold: 0, platinum: 0),
                WeightPerItem = new(7, MassUnit.Pound)
            }, SourceManualDelJugador),
            new(() => new ItemDescription
            {
                Name = "Pico, de minero",
                BasePrice = new(copper: 0, silver: 0, electron: 0, gold: 2, platinum: 0),
                WeightPerItem = new(10, MassUnit.Pound)
            }, SourceManualDelJugador),
            new(() => new ItemDescription
            {
                Name = "Piedra de afilar",
                BasePrice = new(copper: 1, silver: 0, electron: 0, gold: 0, platinum: 0),
                WeightPerItem = new(1, MassUnit.Pound)
            }, SourceManualDelJugador),
            new(() => new ItemDescription
            {
                Name = "Piquetas, de hierro (10)",
                BasePrice = new(copper: 0, silver: 0, electron: 0, gold: 1, platinum: 0),
                WeightPerItem = new(5, MassUnit.Pound)
            }, SourceManualDelJugador),
            new(() => new ItemDescription
            {
                Name = "Pitón",
                BasePrice = new(copper: 5, silver: 0, electron: 0, gold: 0, platinum: 0),
                WeightPerItem = new(0.25, MassUnit.Pound)
            }, SourceManualDelJugador),
            new(() => new ItemDescription
            {
                Name = "Poción de curación",
                BasePrice = new(copper: 0, silver: 0, electron: 0, gold: 50, platinum: 0),
                WeightPerItem = new(0.5, MassUnit.Pound)
            }, SourceManualDelJugador),
            new(() => new ItemDescription
            {
                Name = "Raciones (1 día)",
                BasePrice = new(copper: 0, silver: 5, electron: 0, gold: 0, platinum: 0),
                WeightPerItem = new(2, MassUnit.Pound)
            }, SourceManualDelJugador),
            new(() => new ItemDescription
            {
                Name = "Reloj de arena",
                BasePrice = new(copper: 0, silver: 0, electron: 0, gold: 25, platinum: 0),
                WeightPerItem = new(1, MassUnit.Pound)
            }, SourceManualDelJugador),
            new(() => new ItemDescription
            {
                Name = "Ropa, común",
                BasePrice = new(copper: 0, silver: 5, electron: 0, gold: 0, platinum: 0),
                WeightPerItem = new(3, MassUnit.Pound)
            }, SourceManualDelJugador),
            new(() => new ItemDescription
            {
                Name = "Ropa, a la moda",
                BasePrice = new(copper: 0, silver: 0, electron: 0, gold: 5, platinum: 0),
                WeightPerItem = new(4, MassUnit.Pound)
            }, SourceManualDelJugador),
            new(() => new ItemDescription
            {
                Name = "Ropa, elegante",
                BasePrice = new(copper: 0, silver: 0, electron: 0, gold: 15, platinum: 0),
                WeightPerItem = new(6, MassUnit.Pound)
            }, SourceManualDelJugador),
            new(() => new ItemDescription
            {
                Name = "Ropa, de viaje",
                BasePrice = new(copper: 0, silver: 0, electron: 0, gold: 2, platinum: 0),
                WeightPerItem = new(4, MassUnit.Pound)
            }, SourceManualDelJugador),
            new(() => new ItemDescription
            {
                Name = "Saco de dormir",
                BasePrice = new(copper: 0, silver: 0, electron: 0, gold: 1, platinum: 0),
                WeightPerItem = new(7, MassUnit.Pound)
            }, SourceManualDelJugador),
            new(() => new ItemDescription
            {
                Name = "Sello (anillo)",
                BasePrice = new(copper: 0, silver: 0, electron: 0, gold: 5, platinum: 0)
            }, SourceManualDelJugador),
            new(() => new ItemDescription
            {
                Name = "Silbato de señales",
                BasePrice = new(copper: 5, silver: 0, electron: 0, gold: 0, platinum: 0)
            }, SourceManualDelJugador),
            new(() => new ItemDescription
            {
                Name = "Amuleto",
                BasePrice = new(copper: 0, silver: 0, electron: 0, gold: 5, platinum: 0),
                WeightPerItem = new(1, MassUnit.Pound),
                Tags = ["Símbolo sagrado"]
            }, SourceManualDelJugador),
            new(() => new ItemDescription
            {
                Name = "Emblema",
                BasePrice = new(copper: 0, silver: 0, electron: 0, gold: 5, platinum: 0),
                Tags = ["Símbolo sagrado"]
            }, SourceManualDelJugador),
            new(() => new ItemDescription
            {
                Name = "Relicario",
                BasePrice = new(copper: 0, silver: 0, electron: 0, gold: 5, platinum: 0),
                WeightPerItem = new(2, MassUnit.Pound),
                Tags = ["Símbolo sagrado"]
            }, SourceManualDelJugador),
            new(() => new ItemDescription
            {
                Name = "Tienda, para dos personas",
                BasePrice = new(copper: 0, silver: 0, electron: 0, gold: 2, platinum: 0),
                WeightPerItem = new(20, MassUnit.Pound)
            }, SourceManualDelJugador),
            new(() => new ItemDescription
            {
                Name = "Tinta (botella de 1 onza)",
                BasePrice = new(copper: 0, silver: 0, electron: 0, gold: 10, platinum: 0)
            }, SourceManualDelJugador),
            new(() => new ItemDescription
            {
                Name = "Tiza (trozo)",
                BasePrice = new(copper: 1, silver: 0, electron: 0, gold: 0, platinum: 0)
            }, SourceManualDelJugador),
            new(() => new ItemDescription
            {
                Name = "Trampa de caza",
                BasePrice = new(copper: 0, silver: 0, electron: 0, gold: 5, platinum: 0),
                WeightPerItem = new(25, MassUnit.Pound)
            }, SourceManualDelJugador),
            new(() => new ItemDescription
            {
                Name = "Túnica",
                BasePrice = new(copper: 0, silver: 0, electron: 0, gold: 1, platinum: 0),
                WeightPerItem = new(4, MassUnit.Pound)
            }, SourceManualDelJugador),
            new(() => new ItemDescription
            {
                Name = "Vela",
                BasePrice = new(copper: 1, silver: 0, electron: 0, gold: 0, platinum: 0)
            }, SourceManualDelJugador),
            new(() => new ItemDescription
            {
                Name = "Veneno, básico (vial)",
                BasePrice = new(copper: 0, silver: 0, electron: 0, gold: 100, platinum: 0)
            }, SourceManualDelJugador),
            new(() => new ItemDescription
            {
                Name = "Yesquero",
                BasePrice = new(copper: 0, silver: 5, electron: 0, gold: 0, platinum: 0),
                WeightPerItem = new(1, MassUnit.Pound)
            }, SourceManualDelJugador)
        }.ToFrozenSet(ItemComparer.Instance);

        public static FrozenSet<DefaultItemDescription> Contenedores { get; }
            = new DefaultItemDescription[] {
                new(() => new ContainerItemDescription()
                {
                    Name = "Mochila",
                    Notes = "Puedes atar con una correa objetos, como un saco de dormir o un rollo de cuerda, en el exterior de una mochila.",
                    AreaCapacity = new(1, AreaUnit.Foot, 3),
                    WeightCapacity = new(30, MassUnit.Pound),
                    BasePrice = new(copper: 0, silver: 0, electron: 0, gold: 2, platinum: 0),
                    WeightPerItem = new(5, MassUnit.Pound)
                }, SourceManualDelJugador),
                new(() => new ContainerItemDescription()
                {
                    Name = "Barril",
                    AreaCapacity = new(4, AreaUnit.Foot, 3),
                    QuantityCapacity = new(40, QuantityUnit.Gallon),
                    BasePrice = new(copper: 0, silver: 0, electron: 0, gold: 1, platinum: 0),
                    WeightPerItem = new(2, MassUnit.Pound)
                }, SourceManualDelJugador),
                new(() => new ContainerItemDescription()
                {
                    Name = "Cesta",
                    AreaCapacity = new(2, AreaUnit.Foot),
                    WeightCapacity = new(40, MassUnit.Kilogram),
                    BasePrice = new(copper: 0, silver: 4, electron: 0, gold: 0, platinum: 0),
                    WeightPerItem = new(2, MassUnit.Pound)
                }, SourceManualDelJugador),
                new(() => new ContainerItemDescription()
                {
                    Name = "Botella",
                    QuantityCapacity = new(1.5, QuantityUnit.Pint),
                    BasePrice = new(copper: 0, silver: 0, electron: 0, gold: 2, platinum: 0),
                    WeightPerItem = new(2, MassUnit.Pound)
                }, SourceManualDelJugador),
                new(() => new ContainerItemDescription()
                {
                    Name = "Cubo",
                    AreaCapacity = new(.5, AreaUnit.Foot),
                    QuantityCapacity = new(3, QuantityUnit.Gallon),
                    BasePrice = new(copper: 5, silver: 0, electron: 0, gold: 0, platinum: 0),
                    WeightPerItem = new(2, MassUnit.Pound)
                }, SourceManualDelJugador),
                new(() => new ContainerItemDescription()
                {
                    Name = "Cofre",
                    AreaCapacity = new(12, AreaUnit.Foot),
                    WeightCapacity = new(300, MassUnit.Pound),
                    BasePrice = new(copper: 0, silver: 0, electron: 0, gold: 5, platinum: 0),
                    WeightPerItem = new(22, MassUnit.Pound)
                }, SourceManualDelJugador),
                new(() => new ContainerItemDescription()
                {
                    Name = "Frasco o taza",
                    QuantityCapacity = new(1, QuantityUnit.Pint),
                    BasePrice = new(copper: 2, silver: 0, electron: 0, gold: 0, platinum: 0),
                    WeightPerItem = new(1, MassUnit.Pound)
                }, SourceManualDelJugador),
                new(() => new ContainerItemDescription()
                {
                    Name = "Jarra",
                    QuantityCapacity = new(1, QuantityUnit.Gallon),
                    BasePrice = new(copper: 2, silver: 0, electron: 0, gold: 0, platinum: 0),
                    WeightPerItem = new(4, MassUnit.Pound)
                }, SourceManualDelJugador),
                new(() => new ContainerItemDescription()
                {
                    Name = "Olla, de hierro",
                    QuantityCapacity = new(1, QuantityUnit.Gallon),
                    BasePrice = new(copper: 0, silver: 0, electron: 0, gold: 2, platinum: 0),
                    WeightPerItem = new(10, MassUnit.Pound)
                }, SourceManualDelJugador),
                new(() => new ContainerItemDescription()
                {
                    Name = "Bolsa",
                    AreaCapacity = new(1/5d, AreaUnit.Foot),
                    WeightCapacity = new(6, MassUnit.Pound),
                    BasePrice = new(copper: 0, silver: 5, electron: 0, gold: 0, platinum: 0),
                    WeightPerItem = new(1, MassUnit.Pound)
                }, SourceManualDelJugador),
                new(() => new ContainerItemDescription()
                {
                    Name = "Saco",
                    AreaCapacity = new(1, AreaUnit.Foot),
                    WeightCapacity = new(30, MassUnit.Pound),
                    BasePrice = new(copper: 1, silver: 0, electron: 0, gold: 0, platinum: 0),
                    WeightPerItem = new(.5, MassUnit.Pound)
                }, SourceManualDelJugador),
                new(() => new ContainerItemDescription()
                {
                    Name = "Vial",
                    QuantityCapacity = new(4, QuantityUnit.LiquidOunce),
                    BasePrice = new(copper: 0, silver: 0, electron: 0, gold: 1, platinum: 0),
                    WeightPerItem = new(10, MassUnit.Pound)
                }, SourceManualDelJugador),
                new(() => new FillableContainerItemDescription()
                {
                    Name = "Odre",
                    QuantityCapacity = new(4, QuantityUnit.Pint),
                    BasePrice = new(copper: 0, silver: 0, electron: 0, gold: 2, platinum: 0),
                    WeightWhenFull = new(10, MassUnit.Pound),
                    WeightPerItem = new(10, MassUnit.Pound)
                }, SourceManualDelJugador)
            }.ToFrozenSet(ItemComparer.Instance);

        public static FrozenSet<DefaultItemDescription> Herramientas { get; }
            = new DefaultItemDescription[] {
            new (() => new ItemDescription
            {
                Name = "Herramientas de carpintero",
                BasePrice = new(copper: 0, silver: 0, electron: 0, gold: 8, platinum: 0),
                WeightPerItem = new(6, MassUnit.Pound),
                Tags = ["Herramientas de artesano"]
            }, SourceManualDelJugador),
            new(() => new ItemDescription
            {
                Name = "Herramientas de cartógrafo",
                BasePrice = new(copper: 0, silver: 0, electron: 0, gold: 15, platinum: 0),
                WeightPerItem = new(6, MassUnit.Pound),
                Tags = ["Herramientas de artesano"]
            }, SourceManualDelJugador),
            new(() => new ItemDescription
            {
                Name = "Herramientas de zapatero",
                BasePrice = new(copper: 0, silver: 0, electron: 0, gold: 5, platinum: 0),
                WeightPerItem = new(5, MassUnit.Pound),
                Tags = ["Herramientas de artesano"]
            }, SourceManualDelJugador),
            new(() => new ItemDescription
            {
                Name = "Herramientas de alfarero",
                BasePrice = new(copper: 0, silver: 0, electron: 0, gold: 10, platinum: 0),
                WeightPerItem = new(3, MassUnit.Pound),
                Tags = ["Herramientas de artesano"]
            }, SourceManualDelJugador),
            new(() => new ItemDescription
            {
                Name = "Herramientas de herrero",
                BasePrice = new(copper: 0, silver: 0, electron: 0, gold: 20, platinum: 0),
                WeightPerItem = new(8, MassUnit.Pound),
                Tags = ["Herramientas de artesano"]
            }, SourceManualDelJugador),
            new(() => new ItemDescription
            {
                Name = "Herramientas de hojalatero",
                BasePrice = new(copper: 0, silver: 0, electron: 0, gold: 50, platinum: 0),
                WeightPerItem = new(10, MassUnit.Pound),
                Tags = ["Herramientas de artesano"]
            }, SourceManualDelJugador),
            new(() => new ItemDescription
            {
                Name = "Herramientas de tejedor",
                BasePrice = new(copper: 0, silver: 0, electron: 0, gold: 1, platinum: 0),
                WeightPerItem = new(5, MassUnit.Pound),
                Tags = ["Herramientas de artesano"]
            }, SourceManualDelJugador),
            new(() => new ItemDescription
            {
                Name = "Herramientas de tallista",
                BasePrice = new(copper: 0, silver: 0, electron: 0, gold: 1, platinum: 0),
                WeightPerItem = new(5, MassUnit.Pound),
                Tags = ["Herramientas de artesano"]
            }, SourceManualDelJugador),
            new(() => new ItemDescription
            {
                Name = "Herramientas de soplador de vidrio",
                BasePrice = new(copper: 0, silver: 0, electron: 0, gold: 30, platinum: 0),
                WeightPerItem = new(5, MassUnit.Pound),
                Tags = ["Herramientas de artesano"]
            }, SourceManualDelJugador),
            new(() => new ItemDescription
            {
                Name = "Herramientas de joyero",
                BasePrice = new(copper: 0, silver: 0, electron: 0, gold: 25, platinum: 0),
                WeightPerItem = new(2, MassUnit.Pound),
                Tags = ["Herramientas de artesano"]
            }, SourceManualDelJugador),
            new(() => new ItemDescription
            {
                Name = "Herramientas de peletero",
                BasePrice = new(copper: 0, silver: 0, electron: 0, gold: 5, platinum: 0),
                WeightPerItem = new(5, MassUnit.Pound),
                Tags = ["Herramientas de artesano"]
            }, SourceManualDelJugador),
            new(() => new ItemDescription
            {
                Name = "Herramientas de albañil",
                BasePrice = new(copper: 0, silver: 0, electron: 0, gold: 10, platinum: 0),
                WeightPerItem = new(8, MassUnit.Pound),
                Tags = ["Herramientas de artesano"]
            }, SourceManualDelJugador),
            new(() => new ItemDescription
            {
                Name = "Materiales de pintor",
                BasePrice = new(copper: 0, silver: 0, electron: 0, gold: 10, platinum: 0),
                WeightPerItem = new(5, MassUnit.Pound),
                Tags = ["Herramientas de artesano"]
            }, SourceManualDelJugador),
            new(() => new ItemDescription
            {
                Name = "Materiales alquímicos",
                BasePrice = new(copper: 0, silver: 0, electron: 0, gold: 50, platinum: 0),
                WeightPerItem = new(8, MassUnit.Pound),
                Tags = ["Herramientas de artesano"]
            }, SourceManualDelJugador),
            new(() => new ItemDescription
            {
                Name = "Materiales de cervecería",
                BasePrice = new(copper: 0, silver: 0, electron: 0, gold: 20, platinum: 0),
                WeightPerItem = new(9, MassUnit.Pound),
                Tags = ["Herramientas de artesano"]
            }, SourceManualDelJugador),
            new(() => new ItemDescription
            {
                Name = "Materiales de caligrafía",
                BasePrice = new(copper: 0, silver: 0, electron: 0, gold: 10, platinum: 0),
                WeightPerItem = new(5, MassUnit.Pound),
                Tags = ["Herramientas de artesano"]
            }, SourceManualDelJugador),
            new(() => new ItemDescription
            {
                Name = "Utensilios de cocina",
                BasePrice = new(copper: 0, silver: 0, electron: 0, gold: 1, platinum: 0),
                WeightPerItem = new(8, MassUnit.Pound),
                Tags = ["Herramientas de artesano"]
            }, SourceManualDelJugador),
            new(() => new ItemDescription
            {
                Name = "Herramientas de ladrón",
                BasePrice = new(copper: 0, silver: 0, electron: 0, gold: 25, platinum: 0),
                WeightPerItem = new(1, MassUnit.Pound)
            }, SourceManualDelJugador),
            new(() => new ItemDescription
            {
                Name = "Herramientas de navegación",
                BasePrice = new(copper: 0, silver: 0, electron: 0, gold: 25, platinum: 0),
                WeightPerItem = new(2, MassUnit.Pound)
            }, SourceManualDelJugador),
            new(() => new ItemDescription
            {
                Name = "Caramillo",
                BasePrice = new(copper: 0, silver: 0, electron: 0, gold: 2, platinum: 0),
                WeightPerItem = new(1, MassUnit.Pound),
                Tags = ["Instrumento musical"]
            }, SourceManualDelJugador),
            new(() => new ItemDescription
            {
                Name = "Cuerno",
                BasePrice = new(copper: 0, silver: 0, electron: 0, gold: 3, platinum: 0),
                WeightPerItem = new(2, MassUnit.Pound),
                Tags = ["Instrumento musical"]
            }, SourceManualDelJugador),
            new(() => new ItemDescription
            {
                Name = "Dulcimer",
                BasePrice = new(copper: 0, silver: 0, electron: 0, gold: 25, platinum: 0),
                WeightPerItem = new(10, MassUnit.Pound),
                Tags = ["Instrumento musical"]
            }, SourceManualDelJugador),
            new(() => new ItemDescription
            {
                Name = "Flauta",
                BasePrice = new(copper: 0, silver: 0, electron: 0, gold: 2, platinum: 0),
                WeightPerItem = new(1, MassUnit.Pound),
                Tags = ["Instrumento musical"]
            }, SourceManualDelJugador),
            new(() => new ItemDescription
            {
                Name = "Flauta de pan",
                BasePrice = new(copper: 0, silver: 0, electron: 0, gold: 12, platinum: 0),
                WeightPerItem = new(2, MassUnit.Pound),
                Tags = ["Instrumento musical"]
            }, SourceManualDelJugador),
            new(() => new ItemDescription
            {
                Name = "Gaita",
                BasePrice = new(copper: 0, silver: 0, electron: 0, gold: 30, platinum: 0),
                WeightPerItem = new(6, MassUnit.Pound),
                Tags = ["Instrumento musical"]
            }, SourceManualDelJugador),
            new(() => new ItemDescription
            {
                Name = "Laúd",
                BasePrice = new(copper: 0, silver: 0, electron: 0, gold: 35, platinum: 0),
                WeightPerItem = new(2, MassUnit.Pound),
                Tags = ["Instrumento musical"]
            }, SourceManualDelJugador),
            new(() => new ItemDescription
            {
                Name = "Lira",
                BasePrice = new(copper: 0, silver: 0, electron: 0, gold: 30, platinum: 0),
                WeightPerItem = new(2, MassUnit.Pound),
                Tags = ["Instrumento musical"]
            }, SourceManualDelJugador),
            new(() => new ItemDescription
            {
                Name = "Tambor",
                BasePrice = new(copper: 0, silver: 0, electron: 0, gold: 6, platinum: 0),
                WeightPerItem = new(3, MassUnit.Pound),
                Tags = ["Instrumento musical"]
            }, SourceManualDelJugador),
            new(() => new ItemDescription
            {
                Name = "Viola",
                BasePrice = new(copper: 0, silver: 0, electron: 0, gold: 30, platinum: 0),
                WeightPerItem = new(1, MassUnit.Pound),
                Tags = ["Instrumento musical"]
            }, SourceManualDelJugador),
            new(() => new ItemDescription
            {
                Name = "Kit de disfraz",
                BasePrice = new(copper: 0, silver: 0, electron: 0, gold: 25, platinum: 0),
                WeightPerItem = new(3, MassUnit.Pound)
            }, SourceManualDelJugador),
            new(() => new ItemDescription
            {
                Name = "Kit de envenenador",
                BasePrice = new(copper: 0, silver: 0, electron: 0, gold: 50, platinum: 0),
                WeightPerItem = new(2, MassUnit.Pound)
            }, SourceManualDelJugador),
            new(() => new ItemDescription
            {
                Name = "Kit de falsificación",
                BasePrice = new(copper: 0, silver: 0, electron: 0, gold: 15, platinum: 0),
                WeightPerItem = new(5, MassUnit.Pound)
            }, SourceManualDelJugador),
            new(() => new ItemDescription
            {
                Name = "Kit de herboristería",
                BasePrice = new(copper: 0, silver: 0, electron: 0, gold: 5, platinum: 0),
                WeightPerItem = new(3, MassUnit.Pound)
            }, SourceManualDelJugador),
            new(() => new ItemDescription
            {
                Name = "Set de ajedrez de dragón",
                BasePrice = new(copper: 0, silver: 0, electron: 0, gold: 1, platinum: 0),
                WeightPerItem = new(0.5, MassUnit.Pound),
                Tags = ["Set de juego"]
            }, SourceManualDelJugador),
            new(() => new ItemDescription
            {
                Name = "Set de baraja de cartas",
                BasePrice = new(copper: 0, silver: 5, electron: 0, gold: 0, platinum: 0),
                Tags = ["Set de juego"]
            }, SourceManualDelJugador),
            new(() => new ItemDescription
            {
                Name = "Set de dados",
                BasePrice = new(copper: 0, silver: 1, electron: 0, gold: 0, platinum: 0),
                Tags = ["Set de juego"]
            }, SourceManualDelJugador),
            new(() => new ItemDescription
            {
                Name = "Set de tres dragones",
                BasePrice = new(copper: 0, silver: 0, electron: 0, gold: 1, platinum: 0),
                Tags = ["Set de juego"]
            }, SourceManualDelJugador)
        }.ToFrozenSet(ItemComparer.Instance);

        public static FrozenSet<DefaultItemDescription> All { get; }
    }
}
