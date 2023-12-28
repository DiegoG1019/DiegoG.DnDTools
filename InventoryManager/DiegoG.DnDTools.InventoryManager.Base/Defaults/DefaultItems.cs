using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DiegoG.DnDTools.InventoryManager.Measures;
using DiegoG.DnDTools.InventoryManager.ReadOnly;

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
            set.UnionWith(EquipoDeAventurero.Concat(Contenedores).Concat(Herramientas).Concat(Armas).Concat(Armaduras));
            All = set.ToFrozenSet();
        }

        public static FrozenSet<DefaultItemDescription> Armas { get; }
            = new DefaultItemDescription[]
            {
                new(new ReadOnlyWeaponItemDescription
                {
                    Name = "Bastón",
                    Description = "",
                    DamageThrow = "1d6",
                    DamageType = "Contundente",
                    WeaponCategory = "Simple",
                    Range = "5",
                    GraspType = "Una mano",
                    VersatileDamage = "1d8",
                    BasePrice = new(copper: 0, silver: 2, electron: 0, gold: 0, platinum: 0),
                    WeightPerItem = new(4, MassUnit.Pound),
                    Tags = [ "Versátil" ]
                }, SourceManualDelJugador),
                
                new(new ReadOnlyWeaponItemDescription
                {
                    Name = "Daga",
                    Description = "",
                    DamageThrow = "1d4",
                    DamageType = "Perforante",
                    WeaponCategory = "Simple",
                    ThrownRange = "20/30",
                    Range = "5",
                    GraspType = "Una mano",
                    BasePrice = new(copper: 0, silver: 0, electron: 0, gold: 2, platinum: 0),
                    WeightPerItem = new(1, MassUnit.Pound),
                    Tags = [ "Arrojadiza", "Ligera", "Sutil" ]
                }, SourceManualDelJugador),
                
                new(new ReadOnlyWeaponItemDescription
                {
                    Name = "Gran clava",
                    Description = "",
                    DamageThrow = "1d8",
                    DamageType = "Contundente",
                    WeaponCategory = "Simple",
                    Range = "5",
                    GraspType = "Dos manos",
                    BasePrice = new(copper: 0, silver: 2, electron: 0, gold: 0, platinum: 0),
                    WeightPerItem = new(10, MassUnit.Pound)
                }, SourceManualDelJugador),
                
                new(new ReadOnlyWeaponItemDescription
                {
                    Name = "Hacha de mano",
                    Description = "",
                    DamageThrow = "1d6",
                    DamageType = "Cortante",
                    WeaponCategory = "Simple",
                    ThrownRange = "20/60",
                    Range = "5",
                    GraspType = "Una mano",
                    BasePrice = new(copper: 0, silver: 0, electron: 0, gold: 5, platinum: 0),
                    WeightPerItem = new(2, MassUnit.Pound),
                    Tags = [ "Arrojadiza", "Ligera" ]
                }, SourceManualDelJugador),
                
                new(new ReadOnlyWeaponItemDescription
                {
                    Name = "Hoz",
                    Description = "",
                    DamageThrow = "1d4",
                    DamageType = "Cortante",
                    WeaponCategory = "Simple",
                    Range = "5",
                    GraspType = "Una mano",
                    BasePrice = new(copper: 0, silver: 0, electron: 0, gold: 1, platinum: 0),
                    WeightPerItem = new(2, MassUnit.Pound),
                    Tags = [ "Ligera" ]
                }, SourceManualDelJugador),
                
                new(new ReadOnlyWeaponItemDescription
                {
                    Name = "Jabalina",
                    Description = "",
                    DamageThrow = "1d6",
                    DamageType = "Perforante",
                    WeaponCategory = "Simple",
                    ThrownRange = "30/120",
                    Range = "5",
                    GraspType = "Una mano",
                    BasePrice = new(copper: 0, silver: 5, electron: 0, gold: 0, platinum: 0),
                    WeightPerItem = new(3, MassUnit.Pound),
                    Tags = [ "Arrojadiza" ]
                }, SourceManualDelJugador),
                
                new(new ReadOnlyWeaponItemDescription
                {
                    Name = "Lanza",
                    Description = "",
                    DamageThrow = "1d6",
                    DamageType = "Perforante",
                    WeaponCategory = "Simple",
                    ThrownRange = "20/60",
                    Range = "5",
                    GraspType = "Una mano",
                    VersatileDamage = "1d8",
                    BasePrice = new(copper: 0, silver: 0, electron: 0, gold: 1, platinum: 0),
                    WeightPerItem = new(3, MassUnit.Pound),
                    Tags = [ "Arrojadiza", "Versátil" ]
                }, SourceManualDelJugador),
                
                new(new ReadOnlyWeaponItemDescription
                {
                    Name = "Martillo ligero",
                    Description = "",
                    DamageThrow = "1d4",
                    DamageType = "Contundente",
                    WeaponCategory = "Simple",
                    ThrownRange = "20/60",
                    Range = "5",
                    GraspType = "Una mano",
                    BasePrice = new(copper: 0, silver: 0, electron: 0, gold: 2, platinum: 0),
                    WeightPerItem = new(2, MassUnit.Pound),
                    Tags = [ "Arrojadiza", "Ligera" ]
                }, SourceManualDelJugador),
                
                new(new ReadOnlyWeaponItemDescription
                {
                    Name = "Maza",
                    Description = "",
                    DamageThrow = "1d6",
                    DamageType = "Contundente",
                    WeaponCategory = "Simple",
                    Range = "5",
                    GraspType = "Una mano",
                    BasePrice = new(copper: 0, silver: 0, electron: 0, gold: 5, platinum: 0),
                    WeightPerItem = new(4, MassUnit.Pound)
                }, SourceManualDelJugador),
                
                new(new ReadOnlyWeaponItemDescription
                {
                    Name = "Clava",
                    Description = "",
                    DamageThrow = "1d4",
                    DamageType = "Contundente",
                    WeaponCategory = "Simple",
                    Range = "5",
                    GraspType = "Una mano",
                    BasePrice = new(copper: 0, silver: 1, electron: 0, gold: 0, platinum: 0),
                    WeightPerItem = new(2, MassUnit.Pound),
                    Tags = [ "Ligera" ]
                }, SourceManualDelJugador),
                
                new(new ReadOnlyWeaponItemDescription
                {
                    Name = "Arco corto",
                    Description = "",
                    DamageThrow = "1d6",
                    DamageType = "Perforante",
                    WeaponCategory = "Simple",
                    ThrownRange = "80/320",
                    GraspType = "Dos manos",
                    MunitionType = "Flechas",
                    BasePrice = new(copper: 0, silver: 0, electron: 0, gold: 25, platinum: 0),
                    WeightPerItem = new(2, MassUnit.Pound),
                    Tags = [ "Munición" ]
                }, SourceManualDelJugador),
                
                new(new ReadOnlyWeaponItemDescription
                {
                    Name = "Ballesta ligera",
                    Description = "",
                    DamageThrow = "1d8",
                    DamageType = "Perforante",
                    WeaponCategory = "Simple",
                    ThrownRange = "80/320",
                    GraspType = "Dos manos",
                    MunitionType = "Birutas",
                    BasePrice = new(copper: 0, silver: 0, electron: 0, gold: 25, platinum: 0),
                    WeightPerItem = new(5, MassUnit.Pound),
                    Tags = [ "Munición", "Recarga" ]
                }, SourceManualDelJugador),
                
                new(new ReadOnlyWeaponItemDescription
                {
                    Name = "Dardo",
                    Description = "",
                    DamageThrow = "1d4",
                    DamageType = "Perforante",
                    WeaponCategory = "Simple",
                    ThrownRange = "20/60",
                    Range = "5",
                    GraspType = "Una mano",
                    BasePrice = new(copper: 5, silver: 0, electron: 0, gold: 0, platinum: 0),
                    WeightPerItem = new(.25, MassUnit.Pound),
                    Tags = [ "Arrojadiza" ]
                }, SourceManualDelJugador),
                
                new(new ReadOnlyWeaponItemDescription
                {
                    Name = "Honda",
                    Description = "",
                    DamageThrow = "1d4",
                    DamageType = "Contundente",
                    WeaponCategory = "Simple",
                    ThrownRange = "30/120",
                    GraspType = "Una mano",
                    MunitionType = "Piedras",
                    BasePrice = new(copper: 0, silver: 1, electron: 0, gold: 0, platinum: 0),
                    Tags = [ "Munición" ]
                }, SourceManualDelJugador),
                
                new(new ReadOnlyWeaponItemDescription
                {
                    Name = "Alabarda",
                    Description = "",
                    DamageThrow = "1d10",
                    DamageType = "Cortante",
                    WeaponCategory = "Marcial",
                    Range = "10",
                    GraspType = "Dos manos",
                    BasePrice = new(copper: 0, silver: 0, electron: 0, gold: 20, platinum: 0),
                    WeightPerItem = new(6, MassUnit.Pound),
                    Tags = [ "Pesada" ]
                }, SourceManualDelJugador),
                
                new(new ReadOnlyWeaponItemDescription
                {
                    Name = "Atarraga",
                    Description = "",
                    DamageThrow = "2d6",
                    DamageType = "Contundente",
                    WeaponCategory = "Marcial",
                    Range = "5",
                    GraspType = "Dos manos",
                    BasePrice = new(copper: 0, silver: 0, electron: 0, gold: 10, platinum: 0),
                    WeightPerItem = new(10, MassUnit.Pound),
                    Tags = [ "Pesada" ]
                }, SourceManualDelJugador),
                
                new(new ReadOnlyWeaponItemDescription
                {
                    Name = "Cimitarra",
                    Description = "",
                    DamageThrow = "1d6",
                    DamageType = "Cortante",
                    WeaponCategory = "Marcial",
                    Range = "5",
                    GraspType = "Una mano",
                    BasePrice = new(copper: 0, silver: 0, electron: 0, gold: 25, platinum: 0),
                    WeightPerItem = new(3, MassUnit.Pound),
                    Tags = [ "Ligera", "Sutil" ]
                }, SourceManualDelJugador),
                
                new(new ReadOnlyWeaponItemDescription
                {
                    Name = "Espada corta",
                    Description = "",
                    DamageThrow = "1d6",
                    DamageType = "Cortante",
                    WeaponCategory = "Marcial",
                    Range = "5",
                    GraspType = "Una mano",
                    BasePrice = new(copper: 0, silver: 0, electron: 0, gold: 10, platinum: 0),
                    WeightPerItem = new(2, MassUnit.Pound),
                    Tags = [ "Ligera", "Sutil" ]
                }, SourceManualDelJugador),
                
                new(new ReadOnlyWeaponItemDescription
                {
                    Name = "Espada larga",
                    Description = "",
                    DamageThrow = "1d8",
                    DamageType = "Cortante",
                    WeaponCategory = "Marcial",
                    Range = "5",
                    GraspType = "Una mano",
                    VersatileDamage = "1d10",
                    BasePrice = new(copper: 0, silver: 0, electron: 0, gold: 15, platinum: 0),
                    WeightPerItem = new(3, MassUnit.Pound),
                    Tags = [ "Versátil" ]
                }, SourceManualDelJugador),
                
                new(new ReadOnlyWeaponItemDescription
                {
                    Name = "Espadón",
                    Description = "",
                    DamageThrow = "2d6",
                    DamageType = "Cortante",
                    WeaponCategory = "Marcial",
                    Range = "5",
                    GraspType = "Dos manos",
                    BasePrice = new(copper: 0, silver: 0, electron: 0, gold: 50, platinum: 0),
                    WeightPerItem = new(6, MassUnit.Pound),
                    Tags = [ "Pesada" ]
                }, SourceManualDelJugador),
                
                new(new ReadOnlyWeaponItemDescription
                {
                    Name = "Estoque",
                    Description = "",
                    DamageThrow = "1d8",
                    DamageType = "Perforante",
                    WeaponCategory = "Marcial",
                    Range = "5",
                    GraspType = "Una mano",
                    BasePrice = new(copper: 0, silver: 0, electron: 0, gold: 25, platinum: 0),
                    WeightPerItem = new(2, MassUnit.Pound),
                    Tags = [ "Sutil" ]
                }, SourceManualDelJugador),
                
                new(new ReadOnlyWeaponItemDescription
                {
                    Name = "Hacha de batalla",
                    Description = "",
                    DamageThrow = "1d8",
                    DamageType = "Cortante",
                    WeaponCategory = "Marcial",
                    Range = "5",
                    GraspType = "Una mano",
                    VersatileDamage = "1d10",
                    BasePrice = new(copper: 0, silver: 0, electron: 0, gold: 10, platinum: 0),
                    WeightPerItem = new(4, MassUnit.Pound),
                    Tags = [ "Versátil" ]
                }, SourceManualDelJugador),
                
                new(new ReadOnlyWeaponItemDescription
                {
                    Name = "Gran hacha",
                    Description = "",
                    DamageThrow = "1d12",
                    DamageType = "Cortante",
                    WeaponCategory = "Marcial",
                    Range = "5",
                    GraspType = "Dos manos",
                    BasePrice = new(copper: 0, silver: 0, electron: 0, gold: 30, platinum: 0),
                    WeightPerItem = new(7, MassUnit.Pound),
                    Tags = [ "Pesada" ]
                }, SourceManualDelJugador),
                
                new(new ReadOnlyWeaponItemDescription
                {
                    Name = "Guja",
                    Description = "",
                    DamageThrow = "1d10",
                    DamageType = "Cortante",
                    WeaponCategory = "Marcial",
                    Range = "10",
                    GraspType = "Dos manos",
                    BasePrice = new(copper: 0, silver: 0, electron: 0, gold: 20, platinum: 0),
                    WeightPerItem = new(6, MassUnit.Pound),
                    Tags = [ "Pesada" ]
                }, SourceManualDelJugador),
                
                new(new ReadOnlyWeaponItemDescription
                {
                    Name = "Lanza de Caballeria",
                    Description = "Tienes desventaja cuando se utiliza para atacar a un objetivo dentro de un radio de 5 pies cerca de ti. Además, requiere dos manos para empuñarla cuando no estás montado.",
                    DamageThrow = "1d12",
                    DamageType = "Perforante",
                    WeaponCategory = "Marcial",
                    Range = "10",
                    GraspType = "Una mano",
                    BasePrice = new(copper: 0, silver: 0, electron: 0, gold: 10, platinum: 0),
                    WeightPerItem = new(6, MassUnit.Pound),
                    Tags = [ "Especial" ]
                }, SourceManualDelJugador),
                
                new(new ReadOnlyWeaponItemDescription
                {
                    Name = "Látigo",
                    Description = "",
                    DamageThrow = "1d4",
                    DamageType = "Cortante",
                    WeaponCategory = "Marcial",
                    Range = "10",
                    GraspType = "Una mano",
                    BasePrice = new(copper: 0, silver: 0, electron: 0, gold: 2, platinum: 0),
                    WeightPerItem = new(3, MassUnit.Pound),
                    Tags = [ "Sutil" ]
                }, SourceManualDelJugador),
                
                new(new ReadOnlyWeaponItemDescription
                {
                    Name = "Lucero del alba",
                    Description = "",
                    DamageThrow = "1d8",
                    DamageType = "Perforante",
                    WeaponCategory = "Marcial",
                    Range = "5",
                    GraspType = "Una mano",
                    BasePrice = new(copper: 0, silver: 0, electron: 0, gold: 15, platinum: 0),
                    WeightPerItem = new(4, MassUnit.Pound)
                }, SourceManualDelJugador),
                
                new(new ReadOnlyWeaponItemDescription
                {
                    Name = "Martillo de Guerra",
                    Description = "",
                    DamageThrow = "1d8",
                    DamageType = "Contundente",
                    WeaponCategory = "Marcial",
                    Range = "5",
                    GraspType = "Una mano",
                    VersatileDamage = "1d10",
                    BasePrice = new(copper: 0, silver: 0, electron: 0, gold: 15, platinum: 0),
                    WeightPerItem = new(2, MassUnit.Pound),
                    Tags = [ "Versátil" ]
                }, SourceManualDelJugador),
                
                new(new ReadOnlyWeaponItemDescription
                {
                    Name = "Mayal",
                    Description = "",
                    DamageThrow = "1d8",
                    DamageType = "Contundente",
                    WeaponCategory = "Marcial",
                    Range = "5",
                    GraspType = "Una mano",
                    BasePrice = new(copper: 0, silver: 0, electron: 0, gold: 10, platinum: 0),
                    WeightPerItem = new(2, MassUnit.Pound)
                }, SourceManualDelJugador),
                
                new(new ReadOnlyWeaponItemDescription
                {
                    Name = "Pica",
                    Description = "",
                    DamageThrow = "1d10",
                    DamageType = "Perforante",
                    WeaponCategory = "Marcial",
                    Range = "10",
                    GraspType = "Dos manos",
                    BasePrice = new(copper: 0, silver: 0, electron: 0, gold: 5, platinum: 0),
                    WeightPerItem = new(18, MassUnit.Pound),
                    Tags = [ "Pesada" ]
                }, SourceManualDelJugador),
                
                new(new ReadOnlyWeaponItemDescription
                {
                    Name = "Pica de Guerra",
                    Description = "",
                    DamageThrow = "1d8",
                    DamageType = "Perforante",
                    WeaponCategory = "Marcial",
                    Range = "5",
                    GraspType = "Una mano",
                    BasePrice = new(copper: 0, silver: 0, electron: 0, gold: 5, platinum: 0),
                    WeightPerItem = new(2, MassUnit.Pound)
                }, SourceManualDelJugador),
                
                new(new ReadOnlyWeaponItemDescription
                {
                    Name = "Tridente",
                    Description = "",
                    DamageThrow = "1d6",
                    DamageType = "Perforante",
                    WeaponCategory = "Marcial",
                    ThrownRange = "20/60",
                    Range = "5",
                    GraspType = "Una mano",
                    VersatileDamage = "1d8",
                    BasePrice = new(copper: 0, silver: 0, electron: 0, gold: 5, platinum: 0),
                    WeightPerItem = new(4, MassUnit.Pound),
                    Tags = [ "Arrojadiza", "Versátil" ]
                }, SourceManualDelJugador),
                
                new(new ReadOnlyWeaponItemDescription
                {
                    Name = "Arco largo",
                    Description = "",
                    DamageThrow = "1d8",
                    DamageType = "Perforante",
                    WeaponCategory = "Marcial",
                    ThrownRange = "150/600",
                    GraspType = "Dos manos",
                    MunitionType = "Flechas",
                    BasePrice = new(copper: 0, silver: 0, electron: 0, gold: 50, platinum: 0),
                    WeightPerItem = new(2, MassUnit.Pound),
                    Tags = [ "Munición", "Pesada" ]
                }, SourceManualDelJugador),
                
                new(new ReadOnlyWeaponItemDescription
                {
                    Name = "Ballesta de mano",
                    Description = "",
                    DamageThrow = "1d6",
                    DamageType = "Perforante",
                    WeaponCategory = "Marcial",
                    ThrownRange = "30/120",
                    GraspType = "Una mano",
                    MunitionType = "Birutas",
                    BasePrice = new(copper: 0, silver: 0, electron: 0, gold: 75, platinum: 0),
                    WeightPerItem = new(3, MassUnit.Pound),
                    Tags = [ "Munición", "Ligera", "Recarga" ]
                }, SourceManualDelJugador),
                
                new(new ReadOnlyWeaponItemDescription
                {
                    Name = "Ballesta pesada",
                    Description = "",
                    DamageThrow = "1d10",
                    DamageType = "Perforante",
                    WeaponCategory = "Marcial",
                    ThrownRange = "100/400",
                    GraspType = "Dos manos",
                    MunitionType = "Birutas",
                    BasePrice = new(copper: 0, silver: 0, electron: 0, gold: 50, platinum: 0),
                    WeightPerItem = new(18, MassUnit.Pound),
                    Tags = [ "Munición", "Pesada", "Recarga" ]
                }, SourceManualDelJugador),
                
                new(new ReadOnlyWeaponItemDescription
                {
                    Name = "Cerbatana",
                    Description = "",
                    DamageThrow = "1",
                    DamageType = "Perforante",
                    WeaponCategory = "Marcial",
                    ThrownRange = "25/100",
                    GraspType = "Una mano",
                    BasePrice = new(copper: 0, silver: 0, electron: 0, gold: 10, platinum: 0),
                    WeightPerItem = new(1, MassUnit.Pound),
                    Tags = [ "Munición", "Recarga" ]
                }, SourceManualDelJugador),
                
                new(new ReadOnlyWeaponItemDescription
                {
                    Name = "Red",
                    Description = "Una criatura grande o más pequeño impactada por una red es retenida hasta que se libere. Una red no tiene efecto en criaturas sin forma o criaturas enormes o muy grandes. Una criatura puede utilizar su acción para realizar una prueba de Fuerza a CD 10, liberándose a sí mismo o a otra criatura dentro su alcance de éxito. Haciendo 5 puntos de daño cortante a la red (CA 10) también libera a la criatura sin dañarla, terminando el efecto y destruyendo la red. Cuando se utiliza una acción, acción adicional o reacción para atacar con una red, solo puedes hacer un ataque sin importar el número de ataques que puedas hacer normalmente.",
                    WeaponCategory = "Marcial",
                    ThrownRange = "5/15",
                    GraspType = "Una mano",
                    BasePrice = new(copper: 0, silver: 0, electron: 0, gold: 1, platinum: 0),
                    WeightPerItem = new(3, MassUnit.Pound),
                    Tags = [ "Munición", "Especial" ]
                }, SourceManualDelJugador)
            }.ToFrozenSet();

        public static FrozenSet<DefaultItemDescription> Armaduras { get; }
            = new DefaultItemDescription[]
            {
                // Ligera
                
                new(new ReadOnlyArmorItemDescription
                {
                    Name = "Armadura Acolchada",
                    BasePrice = new(0, 0, 0, 5, 0),
                    ArmorClass = "11 + Des",
                    Detriments = "Desventaja: Sigilo",
                    WeightPerItem = new Mass(8, MassUnit.Pound),
                    ArmorCategory = "Ligera",
                    Description = "La armadura acolchada consiste en capas de tela acolchadas y reforzada."
                }, SourceManualDelJugador),
                
                new(new ReadOnlyArmorItemDescription
                {
                    Name = "Armadura de Cuero",
                    BasePrice = new(0, 0, 0, 10 ,0),
                    ArmorClass = "11 + Des",
                    WeightPerItem = new Mass(10, MassUnit.Pound),
                    ArmorCategory = "Ligera",
                    Description = "Las protecciones para el pecho y los hombros de esta armadura están hechas de cuero endurecido en aceite hirviendo. Las demás partes de la armadura son de cuero más blando y flexible."
                }, SourceManualDelJugador),
                
                new(new ReadOnlyArmorItemDescription
                {
                    Name = "Armadura de Cuero Tachonado",
                    BasePrice = new(0, 0, 0, 45 ,0),
                    ArmorClass = "12 + Des",
                    WeightPerItem = new Mass(13, MassUnit.Pound),
                    ArmorCategory = "Ligera",
                    Description = "Esta armadura está fabricada de cuero, resistente y flexible y reforzada con remaches metálicos entrelazados."
                }, SourceManualDelJugador),

                // Media
                
                new(new ReadOnlyArmorItemDescription
                {
                    Name = "Armadura de Pieles",
                    BasePrice = new(0, 0, 0, 10, 0),
                    ArmorClass = "12 + Des (max. +2)",
                    WeightPerItem = new Mass(12, MassUnit.Pound),
                    ArmorCategory = "Media",
                    Description = "Esta vasta armadura está compuesta por varias capas de cuero y pieles de animales. Es comúnmente usada por las tribus bárbaras, humanoides malignos, y otra gente que no tienen acceso a las herramientas y materiales necesarios para crear armaduras mejores."
                }, SourceManualDelJugador),
                
                new(new ReadOnlyArmorItemDescription
                {
                    Name = "Camisote de Mallas",
                    BasePrice = new(0, 0, 0, 50, 0),
                    ArmorClass = "13 + Des (max. +2)",
                    WeightPerItem = new Mass(20, MassUnit.Pound),
                    ArmorCategory = "Media",
                    Description = "Hecho de anillos metálicos entrelazados, se pone entre capas de ropa o cuero. Esta armadura ofrece una protección modesta para la parte superior del cuerpo del usuario y permite que el sonido del roce de los anillos entre sí sea amortiguado por las capas externas."
                }, SourceManualDelJugador),
                
                new(new ReadOnlyArmorItemDescription
                {
                    Name = "Cota de Escamas",
                    BasePrice = new(0, 0, 0, 50, 0),
                    ArmorClass = "14 + Des (max. +2)",
                    Detriments = "Desventaja: Sigilo",
                    WeightPerItem = new Mass(45, MassUnit.Pound),
                    ArmorCategory = "Media",
                    Description = "Una armadura formada por cota y grebas de cuero (y quizás un faldar separado) cubiertas con piezas de metal superpuestas a modo de escamas de pez. Incluye guantes."
                }, SourceManualDelJugador),
                
                new(new ReadOnlyArmorItemDescription
                {
                    Name = "Coraza",
                    BasePrice = new(0, 0, 0, 400, 0),
                    ArmorClass = "14 + Des (max. +2)",
                    WeightPerItem = new Mass(20, MassUnit.Pound),
                    ArmorCategory = "Media",
                    Description = "Esta armadura se compone de una pieza de metal en el pecho equipada con cuero flexible debajo. Aunque deja las piernas y los brazos relativamente sin protección, esta armadura proporciona una buena protección para los órganos vitales del usuario, dejando al usuario relativamente no comprometido."
                }, SourceManualDelJugador),
                
                new(new ReadOnlyArmorItemDescription
                {
                    Name = "Armadura de Semiplacas",
                    BasePrice = new(0, 0, 0, 750, 0),
                    ArmorClass = "15 + Des (max. +2)",
                    Detriments = "Desventaja: Sigilo",
                    WeightPerItem = new Mass(40, MassUnit.Pound),
                    ArmorCategory = "Media",
                    Description = "Se compone de placas de metal de forma que cubren la mayor parte de cuerpo del usuario. No incluye protección para las piernas más allá de simples grebas que se fijan con tiras de cuero."
                }, SourceManualDelJugador),

                // Pesada
                
                new(new ReadOnlyArmorItemDescription
                {
                    Name = "Cota de Anillas",
                    BasePrice = new(0, 0, 0, 30, 0),
                    ArmorClass = "14",
                    Detriments = "Desventaja: Sigilo",
                    WeightPerItem = new Mass(40, MassUnit.Pound),
                    ArmorCategory = "Pesada",
                    Description = "Esta armadura es una armadura de cuero con anillas pesadas cosidas en ella. Las anillas ayudan a reforzar la armadura contra los golpes de las espadas y hachas. La Cota de anillas es inferior a la cota de malla, y por lo general es usada sólo por aquellos que no se pueden permitir una armadura mejor."
                }, SourceManualDelJugador),
                
                new(new ReadOnlyArmorItemDescription
                {
                    Name = "Cota de Mallas",
                    BasePrice = new(0, 0, 0, 750, 0),
                    Requirement = "Fue 13",
                    ArmorClass = "16",
                    Detriments = "Desventaja: Sigilo",
                    WeightPerItem = new Mass(55, MassUnit.Pound),
                    ArmorCategory = "Pesada",
                    Description = "Esta armadura está compuesta de anillas de acero entrelazadas. Un forro acolchado impide que haya irritación y amortigua los golpes. Incluye los guanteletes."
                }, SourceManualDelJugador),
                
                new(new ReadOnlyArmorItemDescription
                {
                    Name = "Armadura de Bandas",
                    BasePrice = new(0, 0, 0, 200, 0),
                    Requirement = "Fue 15",
                    ArmorClass = "17",
                    Detriments = "Desventaja: Sigilo",
                    WeightPerItem = new Mass(60, MassUnit.Pound),
                    ArmorCategory = "Pesada",
                    Description = "Esta armadura está hecha de tiras verticales estrechas de metal remachadas a un soporte de cuero que se coloca debajo de tela acolchada. Una Cota de malla flexible protege las articulaciones."
                }, SourceManualDelJugador),
                
                new(new ReadOnlyArmorItemDescription
                {
                    Name = "Armadura de Placas",
                    BasePrice = new(0, 0, 0, 1500, 0),
                    Requirement = "Fue 15",
                    ArmorClass = "18",
                    Detriments = "Desventaja: Sigilo",
                    WeightPerItem = new Mass(65, MassUnit.Pound),
                    ArmorCategory = "Pesada",
                    Description = "Esta armadura está compuesta de placas metálicas, remachadas y ajustadas para cubrir completamente el cuerpo. Incluye guanteletes, botas pesadas de cuero y yelmo con visera. Debajo se lleva un acolchado grueso (incluido). Las correas y hebillas hacen que el peso esté distribuido de forma equilibrada."
                }, SourceManualDelJugador),

                // Escudo
                
                new(new ReadOnlyArmorItemDescription
                {
                    Name = "Escudo",
                    BasePrice = new(0, 0, 0, 10, 0),
                    ArmorClass = "+2",
                    WeightPerItem = new Mass(6, MassUnit.Pound),
                    ArmorCategory = "Escudo",
                    Description = "Un escudo está hecho de madera o metal y se lleva en una mano. Empuñando un escudo aumenta tu Clase de Armadura en 2."
                }, SourceManualDelJugador),
            }.ToFrozenSet();

        public static FrozenSet<DefaultItemDescription> EquipoDeAventurero { get; }
            = new DefaultItemDescription[] {
                new(new("Ábaco", null, null, null, new(copper: 0, silver: 0, electron: 0, gold: 2, platinum: 0), null, new(2, MassUnit.Pound), null, null), SourceManualDelJugador),
            
                new(new("Abrojos (bolsa de 20)", null, null, null, new(copper: 0, silver: 0, electron: 0, gold: 1, platinum: 0), null, new(2, MassUnit.Pound), null, null), SourceManualDelJugador),
            
                new(new("Aceite (frasco)", null, null, null, new(copper: 0, silver: 1, electron: 0, gold: 0, platinum: 0), null, new(1, MassUnit.Pound), null, null), SourceManualDelJugador),
            
                new(new("Acido (vial)", null, null, null, new(copper: 0, silver: 0, electron: 0, gold: 25, platinum: 0), null, new(1, MassUnit.Pound), null, null), SourceManualDelJugador),
            
                new(new("Agua bendita (frasco)", null, null, null, new(copper: 0, silver: 0, electron: 0, gold: 25, platinum: 0), null, new(1, MassUnit.Pound), null, null), SourceManualDelJugador),
            
                new(new("Almádena", null, null, null, new(copper: 0, silver: 0, electron: 0, gold: 2, platinum: 0), null, new(10, MassUnit.Pound), null, null), SourceManualDelJugador),
            
                new(new("Antídoto (vial)", null, null, null, new(copper: 0, silver: 0, electron: 0, gold: 50, platinum: 0), null, null, null, null), SourceManualDelJugador),
            
                new(new("Antorcha", null, null, null, new(copper: 1, silver: 0, electron: 0, gold: 0, platinum: 0), null, new(1, MassUnit.Pound), null, null), SourceManualDelJugador),
            
                new(new("Aparejos de pesca", null, null, null, new(copper: 0, silver: 0, electron: 0, gold: 1, platinum: 0), null, new(4, MassUnit.Pound), null, null), SourceManualDelJugador),
            
                new(new("Aparejo de poleas", null, null, null, new(copper: 0, silver: 0, electron: 0, gold: 1, platinum: 0), null, new(5, MassUnit.Pound), null, null), SourceManualDelJugador),
            
                new(new("Ariete portátil", null, null, null, new(copper: 0, silver: 0, electron: 0, gold: 4, platinum: 0), null, new(35, MassUnit.Pound), null, null), SourceManualDelJugador),
            
                new(new("Balanza de mercader", null, null, null, new(copper: 0, silver: 0, electron: 0, gold: 5, platinum: 0), null, new(3, MassUnit.Pound), null, null), SourceManualDelJugador),
            
                new(new("Rodamientos (bolsa de 1000)", null, null, null, new(copper: 0, silver: 0, electron: 0, gold: 1, platinum: 0), null, new(2, MassUnit.Pound), null, null), SourceManualDelJugador),
            
                new(new("Bolsa de componentes", null, null, null, new(copper: 0, silver: 0, electron: 0, gold: 25, platinum: 0), null, new(2, MassUnit.Pound), null, null), SourceManualDelJugador),
            
                new(new("Cadena (10 pies)", null, null, null, new(copper: 0, silver: 0, electron: 0, gold: 5, platinum: 0), null, new(10, MassUnit.Pound), null, null), SourceManualDelJugador),
            
                new(new("Cálamo", null, null, null, new(copper: 2, silver: 0, electron: 0, gold: 0, platinum: 0), null, null, null, null), SourceManualDelJugador),
            
                new(new("Campanilla", null, null, null, new(copper: 0, silver: 0, electron: 0, gold: 1, platinum: 0), null, null, null, null), SourceManualDelJugador),
            
                new(new("Carcaj", null, null, null, new(copper: 0, silver: 0, electron: 0, gold: 1, platinum: 0), null, new(1, MassUnit.Pound), null, null), SourceManualDelJugador),
            
                new(new("Catalejo", null, null, null, new(copper: 0, silver: 0, electron: 0, gold: 1000, platinum: 0), null, new(1, MassUnit.Pound), null, null), SourceManualDelJugador),
            
                new(new("Cerradura", null, null, null, new(copper: 0, silver: 0, electron: 0, gold: 10, platinum: 0), null, new(1, MassUnit.Pound), null, null), SourceManualDelJugador),
            
                new(new("Cuerda, de cáñamo (50 pies)", null, null, null, new(copper: 0, silver: 0, electron: 0, gold: 1, platinum: 0), null, new(10, MassUnit.Pound), null, null), SourceManualDelJugador),
            
                new(new("Cuerda, de seda (50 pies)", null, null, null, new(copper: 0, silver: 0, electron: 0, gold: 10, platinum: 0), null, new(5, MassUnit.Pound), null, null), SourceManualDelJugador),
            
                new(new("Escalera de mano (10 pies)", null, null, null, new(copper: 0, silver: 1, electron: 0, gold: 0, platinum: 0), null, new(25, MassUnit.Pound), null, null), SourceManualDelJugador),
            
                new(new("Espejo, de acero", null, null, null, new(copper: 0, silver: 0, electron: 0, gold: 5, platinum: 0), null, new(0.5, MassUnit.Pound), null, null), SourceManualDelJugador),
            
                new(new("Estuche, de virote de ballesta", null, null, null, new(copper: 0, silver: 0, electron: 0, gold: 1, platinum: 0), null, new(1, MassUnit.Pound), null, null), SourceManualDelJugador),
            
                new(new("Estuche, de mapas o pergaminos", null, null, null, new(copper: 0, silver: 0, electron: 0, gold: 1, platinum: 0), null, new(1, MassUnit.Pound), null, null), SourceManualDelJugador),
            
                new(new("Cetro", null, null, null, new(copper: 0, silver: 0, electron: 0, gold: 10, platinum: 0), null, new(2, MassUnit.Pound), null, ["Foco arcano"]), SourceManualDelJugador),
            
                new(new("Cristal", null, null, null, new(copper: 0, silver: 0, electron: 0, gold: 10, platinum: 0), null, new(1, MassUnit.Pound), null, ["Foco arcano"]), SourceManualDelJugador),
            
                new(new("Orbe", null, null, null, new(copper: 0, silver: 0, electron: 0, gold: 20, platinum: 0), null, new(3, MassUnit.Pound), null, ["Foco arcano"]), SourceManualDelJugador),
            
                new(new("Vara", null, null, null, new(copper: 0, silver: 0, electron: 0, gold: 5, platinum: 0), null, new(4, MassUnit.Pound), null, ["Foco arcano"]), SourceManualDelJugador),
            
                new(new("Varita", null, null, null, new(copper: 0, silver: 0, electron: 0, gold: 10, platinum: 0), null, new(1, MassUnit.Pound), null, ["Foco arcano"]), SourceManualDelJugador),
            
                new(new("Ramita de muérdago", null, null, null, new(copper: 0, silver: 0, electron: 0, gold: 1, platinum: 0), null, null, null, ["Foco druídico"]), SourceManualDelJugador),
            
                new(new("Tótem", null, null, null, new(copper: 0, silver: 0, electron: 0, gold: 1, platinum: 0), null, null, null, ["Foco druídico"]), SourceManualDelJugador),
            
                new(new("Vara de madera", null, null, null, new(copper: 0, silver: 0, electron: 0, gold: 5, platinum: 0), null, new(4, MassUnit.Pound), null, ["Foco druídico"]), SourceManualDelJugador),
            
                new(new("Varita de tejo", null, null, null, new(copper: 0, silver: 0, electron: 0, gold: 10, platinum: 0), null, new(1, MassUnit.Pound), null, ["Foco druídico"]), SourceManualDelJugador),
            
                new(new("Fuego de alquimista (frasco)", null, null, null, new(copper: 0, silver: 0, electron: 0, gold: 50, platinum: 0), null, new(1, MassUnit.Pound), null, null), SourceManualDelJugador),
            
                new(new("Garfio o gancho", null, null, null, new(copper: 0, silver: 0, electron: 0, gold: 2, platinum: 0), null, new(4, MassUnit.Pound), null, null), SourceManualDelJugador),
            
                new(new("Grilletes", null, null, null, new(copper: 0, silver: 0, electron: 0, gold: 2, platinum: 0), null, new(6, MassUnit.Pound), null, null), SourceManualDelJugador),
            
                new(new("Jabón", null, null, null, new(copper: 2, silver: 0, electron: 0, gold: 0, platinum: 0), null, null, null, null), SourceManualDelJugador),
            
                new(new("Kit de escalada", null, null, null, new(copper: 0, silver: 0, electron: 0, gold: 25, platinum: 0), null, new(12, MassUnit.Pound), null, null), SourceManualDelJugador),
            
                new(new("Kit de cocina", null, null, null, new(copper: 0, silver: 2, electron: 0, gold: 0, platinum: 0), null, new(1, MassUnit.Pound), null, null), SourceManualDelJugador),
            
                new(new("Kit de curandero", null, null, null, new(copper: 0, silver: 0, electron: 0, gold: 5, platinum: 0), null, new(3, MassUnit.Pound), null, null), SourceManualDelJugador),
            
                new(new("Lacre", null, null, null, new(copper: 0, silver: 5, electron: 0, gold: 0, platinum: 0), null, null, null, null), SourceManualDelJugador),
            
                new(new("Lámpara", null, null, null, new(copper: 0, silver: 5, electron: 0, gold: 0, platinum: 0), null, new(1, MassUnit.Pound), null, null), SourceManualDelJugador),
            
                new(new("Libro", null, null, null, new(copper: 0, silver: 0, electron: 0, gold: 25, platinum: 0), null, new(5, MassUnit.Pound), null, null), SourceManualDelJugador),
            
                new(new("Libro de conjuros", null, null, null, new(copper: 0, silver: 0, electron: 0, gold: 50, platinum: 0), null, new(3, MassUnit.Pound), null, null), SourceManualDelJugador),
            
                new(new("Linterna, ojo de buey", null, null, null, new(copper: 0, silver: 0, electron: 0, gold: 10, platinum: 0), null, new(2, MassUnit.Pound), null, null), SourceManualDelJugador),
            
                new(new("Linterna, sorda o encapuchada", null, null, null, new(copper: 0, silver: 0, electron: 0, gold: 5, platinum: 0), null, new(2, MassUnit.Pound), null, null), SourceManualDelJugador),
            
                new(new("Lupa", null, null, null, new(copper: 0, silver: 0, electron: 0, gold: 100, platinum: 0), null, null, null, null), SourceManualDelJugador),
            
                new(new("Manta", null, null, null, new(copper: 0, silver: 5, electron: 0, gold: 0, platinum: 0), null, new(3, MassUnit.Pound), null, null), SourceManualDelJugador),
            
                new(new("Martillo", null, null, null, new(copper: 0, silver: 0, electron: 0, gold: 1, platinum: 0), null, new(3, MassUnit.Pound), null, null), SourceManualDelJugador),
            
                new(new("Agujas de cerbatana (50)", null, null, null, new(copper: 0, silver: 0, electron: 0, gold: 1, platinum: 0), null, new(1, MassUnit.Pound), null, ["Munición"]), SourceManualDelJugador),
            
                new(new("Balas de honda (20)", null, null, null, new(copper: 4, silver: 0, electron: 0, gold: 0, platinum: 0), null, new(1.5, MassUnit.Pound), null, ["Munición"]), SourceManualDelJugador),
            
                new(new("Flecha", null, null, null, new(copper: 5, silver: 0, electron: 0, gold: 0, platinum: 0), null, new(0.05, MassUnit.Pound), null, ["Munición"]), SourceManualDelJugador),
            
                new(new("Flechas (20)", null, null, null, new(copper: 0, silver: 0, electron: 0, gold: 1, platinum: 0), null, new(1, MassUnit.Pound), null, ["Munición"]), SourceManualDelJugador),
            
                new(new("Virotes de ballesta (20)", null, null, null, new(copper: 0, silver: 0, electron: 0, gold: 1, platinum: 0), null, new(1.5, MassUnit.Pound), null, ["Munición"]), SourceManualDelJugador),
            
                new(new("Pala", null, null, null, new(copper: 0, silver: 0, electron: 0, gold: 2, platinum: 0), null, new(5, MassUnit.Pound), null, null), SourceManualDelJugador),
            
                new(new("Palanca", null, null, null, new(copper: 0, silver: 0, electron: 0, gold: 2, platinum: 0), null, new(5, MassUnit.Pound), null, null), SourceManualDelJugador),
            
                new(new("Papel (una hoja)", null, null, null, new(copper: 0, silver: 2, electron: 0, gold: 0, platinum: 0), null, null, null, null), SourceManualDelJugador),
            
                new(new("Perfume (vial)", null, null, null, new(copper: 0, silver: 0, electron: 0, gold: 5, platinum: 0), null, null, null, null), SourceManualDelJugador),
            
                new(new("Pergamino (una hoja)", null, null, null, new(copper: 0, silver: 1, electron: 0, gold: 0, platinum: 0), null, null, null, null), SourceManualDelJugador),
            
                new(new("Pértiga (10 pies)", null, null, null, new(copper: 5, silver: 0, electron: 0, gold: 0, platinum: 0), null, new(7, MassUnit.Pound), null, null), SourceManualDelJugador),
            
                new(new("Pico, de minero", null, null, null, new(copper: 0, silver: 0, electron: 0, gold: 2, platinum: 0), null, new(10, MassUnit.Pound), null, null), SourceManualDelJugador),
            
                new(new("Piedra de afilar", null, null, null, new(copper: 1, silver: 0, electron: 0, gold: 0, platinum: 0), null, new(1, MassUnit.Pound), null, null), SourceManualDelJugador),
            
                new(new("Piquetas, de hierro (10)", null, null, null, new(copper: 0, silver: 0, electron: 0, gold: 1, platinum: 0), null, new(5, MassUnit.Pound), null, null), SourceManualDelJugador),
            
                new(new("Pitón", null, null, null, new(copper: 5, silver: 0, electron: 0, gold: 0, platinum: 0), null, new(0.25, MassUnit.Pound), null, null), SourceManualDelJugador),
            
                new(new("Poción de curación", null, null, null, new(copper: 0, silver: 0, electron: 0, gold: 50, platinum: 0), null, new(0.5, MassUnit.Pound), null, null), SourceManualDelJugador),
            
                new(new("Raciones (1 día)", null, null, null, new(copper: 0, silver: 5, electron: 0, gold: 0, platinum: 0), null, new(2, MassUnit.Pound), null, null), SourceManualDelJugador),
            
                new(new("Reloj de arena", null, null, null, new(copper: 0, silver: 0, electron: 0, gold: 25, platinum: 0), null, new(1, MassUnit.Pound), null, null), SourceManualDelJugador),
            
                new(new("Ropa, común", null, null, null, new(copper: 0, silver: 5, electron: 0, gold: 0, platinum: 0), null, new(3, MassUnit.Pound), null, null), SourceManualDelJugador),
            
                new(new("Ropa, a la moda", null, null, null, new(copper: 0, silver: 0, electron: 0, gold: 5, platinum: 0), null, new(4, MassUnit.Pound), null, null), SourceManualDelJugador),
            
                new(new("Ropa, elegante", null, null, null, new(copper: 0, silver: 0, electron: 0, gold: 15, platinum: 0), null, new(6, MassUnit.Pound), null, null), SourceManualDelJugador),
            
                new(new("Ropa, de viaje", null, null, null, new(copper: 0, silver: 0, electron: 0, gold: 2, platinum: 0), null, new(4, MassUnit.Pound), null, null), SourceManualDelJugador),
            
                new(new("Saco de dormir", null, null, null, new(copper: 0, silver: 0, electron: 0, gold: 1, platinum: 0), null, new(7, MassUnit.Pound), null, null), SourceManualDelJugador),
            
                new(new("Sello (anillo)", null, null, null, new(copper: 0, silver: 0, electron: 0, gold: 5, platinum: 0), null, null, null, null), SourceManualDelJugador),
            
                new(new("Silbato de señales", null, null, null, new(copper: 5, silver: 0, electron: 0, gold: 0, platinum: 0), null, null, null, null), SourceManualDelJugador),
            
                new(new("Amuleto", null, null, null, new(copper: 0, silver: 0, electron: 0, gold: 5, platinum: 0), null, new(1, MassUnit.Pound), null, ["Símbolo sagrado"]), SourceManualDelJugador),
            
                new(new("Emblema", null, null, null, new(copper: 0, silver: 0, electron: 0, gold: 5, platinum: 0), null, null, null, ["Símbolo sagrado"]), SourceManualDelJugador),
            
                new(new("Relicario", null, null, null, new(copper: 0, silver: 0, electron: 0, gold: 5, platinum: 0), null, new(2, MassUnit.Pound), null, ["Símbolo sagrado"]), SourceManualDelJugador),
            
                new(new("Tienda, para dos personas", null, null, null, new(copper: 0, silver: 0, electron: 0, gold: 2, platinum: 0), null, new(20, MassUnit.Pound), null, null), SourceManualDelJugador),
            
                new(new("Tinta (botella de 1 onza)", null, null, null, new(copper: 0, silver: 0, electron: 0, gold: 10, platinum: 0), null, null, null, null), SourceManualDelJugador),
            
                new(new("Tiza (trozo)", null, null, null, new(copper: 1, silver: 0, electron: 0, gold: 0, platinum: 0), null, null, null, null), SourceManualDelJugador),
            
                new(new("Trampa de caza", null, null, null, new(copper: 0, silver: 0, electron: 0, gold: 5, platinum: 0), null, new(25, MassUnit.Pound), null, null), SourceManualDelJugador),
            
                new(new("Túnica", null, null, null, new(copper: 0, silver: 0, electron: 0, gold: 1, platinum: 0), null, new(4, MassUnit.Pound), null, null), SourceManualDelJugador),
            
                new(new("Vela", null, null, null, new(copper: 1, silver: 0, electron: 0, gold: 0, platinum: 0), null, null, null, null), SourceManualDelJugador),
            
                new(new("Veneno, básico (vial)", null, null, null, new(copper: 0, silver: 0, electron: 0, gold: 100, platinum: 0), null, null, null, null), SourceManualDelJugador),
            
                new(new("Yesquero", null, null, null, new(copper: 0, silver: 5, electron: 0, gold: 0, platinum: 0), null, new(1, MassUnit.Pound), null, null), SourceManualDelJugador)
        }.ToFrozenSet();

        public static FrozenSet<DefaultItemDescription> Contenedores { get; }
            = new DefaultItemDescription[] {
                new(new ReadOnlyContainerItemDescription("Mochila", null, "Puedes atar con una correa objetos, como un saco de dormir o un rollo de cuerda, en el exterior de una mochila.", null, new(copper: 0, silver: 0, electron: 0, gold: 2, platinum: 0), null, new(5, MassUnit.Pound), null, null, new(30, MassUnit.Pound), new(1, AreaUnit.Foot, 3), null), SourceManualDelJugador),
                
                new(new ReadOnlyContainerItemDescription("Barril", null, null, null, new(copper: 0, silver: 0, electron: 0, gold: 1, platinum: 0), null, new(2, MassUnit.Pound), null, null, null, new(4, AreaUnit.Foot, 3), new(40, QuantityUnit.Gallon)), SourceManualDelJugador),
                
                new(new ReadOnlyContainerItemDescription("Cesta", null, null, null, new(copper: 0, silver: 4, electron: 0, gold: 0, platinum: 0), null, new(2, MassUnit.Pound), null, null, new(40, MassUnit.Kilogram), new(2, AreaUnit.Foot), null), SourceManualDelJugador),
                
                new(new ReadOnlyContainerItemDescription("Botella", null, null, null, new(copper: 0, silver: 0, electron: 0, gold: 2, platinum: 0), null, new(2, MassUnit.Pound), null, null, null, null, new(1.5, QuantityUnit.Pint)), SourceManualDelJugador),
                
                new(new ReadOnlyContainerItemDescription("Cubo", null, null, null, new(copper: 5, silver: 0, electron: 0, gold: 0, platinum: 0), null, new(2, MassUnit.Pound), null, null, null, new(.5, AreaUnit.Foot), new(3, QuantityUnit.Gallon)), SourceManualDelJugador),
                
                new(new ReadOnlyContainerItemDescription("Cofre", null, null, null, new(copper: 0, silver: 0, electron: 0, gold: 5, platinum: 0), null, new(22, MassUnit.Pound), null, null, new(300, MassUnit.Pound), new(12, AreaUnit.Foot), null), SourceManualDelJugador),
                
                new(new ReadOnlyContainerItemDescription("Frasco o taza", null, null, null, new(copper: 2, silver: 0, electron: 0, gold: 0, platinum: 0), null, new(1, MassUnit.Pound), null, null, null, null, new(1, QuantityUnit.Pint)), SourceManualDelJugador),
                
                new(new ReadOnlyContainerItemDescription("Jarra", null, null, null, new(copper: 2, silver: 0, electron: 0, gold: 0, platinum: 0), null, new(4, MassUnit.Pound), null, null, null, null, new(1, QuantityUnit.Gallon)), SourceManualDelJugador),
                
                new(new ReadOnlyContainerItemDescription("Olla, de hierro", null, null, null, new(copper: 0, silver: 0, electron: 0, gold: 2, platinum: 0), null, new(10, MassUnit.Pound), null, null, null, null, new(1, QuantityUnit.Gallon)), SourceManualDelJugador),
                
                new(new ReadOnlyContainerItemDescription("Bolsa", null, null, null, new(copper: 0, silver: 5, electron: 0, gold: 0, platinum: 0), null, new(1, MassUnit.Pound), null, null, new(6, MassUnit.Pound), new(1/5d, AreaUnit.Foot), null), SourceManualDelJugador),
                
                new(new ReadOnlyContainerItemDescription("Saco", null, null, null, new(copper: 1, silver: 0, electron: 0, gold: 0, platinum: 0), null, new(.5, MassUnit.Pound), null, null, new(30, MassUnit.Pound), new(1, AreaUnit.Foot), null), SourceManualDelJugador),
                
                new(new ReadOnlyContainerItemDescription("Vial", null, null, null, new(copper: 0, silver: 0, electron: 0, gold: 1, platinum: 0), null, new(10, MassUnit.Pound), null, null, null, null, new(4, QuantityUnit.LiquidOunce)), SourceManualDelJugador),
                
                new(new ReadOnlyFillableContainerItemDescription("Odre", null, null, null, new(copper: 0, silver: 0, electron: 0, gold: 2, platinum: 0), null, new(10, MassUnit.Pound), null, null, null, null, new(4, QuantityUnit.Pint), new(10, MassUnit.Pound)), SourceManualDelJugador)
            }.ToFrozenSet();

        public static FrozenSet<DefaultItemDescription> Herramientas { get; }
            = new DefaultItemDescription[] {
                new(new("Herramientas de carpintero", null, null, null, new(copper: 0, silver: 0, electron: 0, gold: 8, platinum: 0), null, new(6, MassUnit.Pound), null, ["Herramientas de artesano"]), SourceManualDelJugador),
            
                new(new("Herramientas de cartógrafo", null, null, null, new(copper: 0, silver: 0, electron: 0, gold: 15, platinum: 0), null, new(6, MassUnit.Pound), null, ["Herramientas de artesano"]), SourceManualDelJugador),
            
                new(new("Herramientas de zapatero", null, null, null, new(copper: 0, silver: 0, electron: 0, gold: 5, platinum: 0), null, new(5, MassUnit.Pound), null, ["Herramientas de artesano"]), SourceManualDelJugador),
            
                new(new("Herramientas de alfarero", null, null, null, new(copper: 0, silver: 0, electron: 0, gold: 10, platinum: 0), null, new(3, MassUnit.Pound), null, ["Herramientas de artesano"]), SourceManualDelJugador),
            
                new(new("Herramientas de herrero", null, null, null, new(copper: 0, silver: 0, electron: 0, gold: 20, platinum: 0), null, new(8, MassUnit.Pound), null, ["Herramientas de artesano"]), SourceManualDelJugador),
            
                new(new("Herramientas de hojalatero", null, null, null, new(copper: 0, silver: 0, electron: 0, gold: 50, platinum: 0), null, new(10, MassUnit.Pound), null, ["Herramientas de artesano"]), SourceManualDelJugador),
            
                new(new("Herramientas de tejedor", null, null, null, new(copper: 0, silver: 0, electron: 0, gold: 1, platinum: 0), null, new(5, MassUnit.Pound), null, ["Herramientas de artesano"]), SourceManualDelJugador),
            
                new(new("Herramientas de tallista", null, null, null, new(copper: 0, silver: 0, electron: 0, gold: 1, platinum: 0), null, new(5, MassUnit.Pound), null, ["Herramientas de artesano"]), SourceManualDelJugador),
            
                new(new("Herramientas de soplador de vidrio", null, null, null, new(copper: 0, silver: 0, electron: 0, gold: 30, platinum: 0), null, new(5, MassUnit.Pound), null, ["Herramientas de artesano"]), SourceManualDelJugador),
            
                new(new("Herramientas de joyero", null, null, null, new(copper: 0, silver: 0, electron: 0, gold: 25, platinum: 0), null, new(2, MassUnit.Pound), null, ["Herramientas de artesano"]), SourceManualDelJugador),
            
                new(new("Herramientas de peletero", null, null, null, new(copper: 0, silver: 0, electron: 0, gold: 5, platinum: 0), null, new(5, MassUnit.Pound), null, ["Herramientas de artesano"]), SourceManualDelJugador),
            
                new(new("Herramientas de albañil", null, null, null, new(copper: 0, silver: 0, electron: 0, gold: 10, platinum: 0), null, new(8, MassUnit.Pound), null, ["Herramientas de artesano"]), SourceManualDelJugador),
            
                new(new("Materiales de pintor", null, null, null, new(copper: 0, silver: 0, electron: 0, gold: 10, platinum: 0), null, new(5, MassUnit.Pound), null, ["Herramientas de artesano"]), SourceManualDelJugador),
            
                new(new("Materiales alquímicos", null, null, null, new(copper: 0, silver: 0, electron: 0, gold: 50, platinum: 0), null, new(8, MassUnit.Pound), null, ["Herramientas de artesano"]), SourceManualDelJugador),
            
                new(new("Materiales de cervecería", null, null, null, new(copper: 0, silver: 0, electron: 0, gold: 20, platinum: 0), null, new(9, MassUnit.Pound), null, ["Herramientas de artesano"]), SourceManualDelJugador),
            
                new(new("Materiales de caligrafía", null, null, null, new(copper: 0, silver: 0, electron: 0, gold: 10, platinum: 0), null, new(5, MassUnit.Pound), null, ["Herramientas de artesano"]), SourceManualDelJugador),
            
                new(new("Utensilios de cocina", null, null, null, new(copper: 0, silver: 0, electron: 0, gold: 1, platinum: 0), null, new(8, MassUnit.Pound), null, ["Herramientas de artesano"]), SourceManualDelJugador),
            
                new(new("Herramientas de ladrón", null, null, null, new(copper: 0, silver: 0, electron: 0, gold: 25, platinum: 0), null, new(1, MassUnit.Pound), null, null), SourceManualDelJugador),
            
                new(new("Herramientas de navegación", null, null, null, new(copper: 0, silver: 0, electron: 0, gold: 25, platinum: 0), null, new(2, MassUnit.Pound), null, null), SourceManualDelJugador),
            
                new(new("Caramillo", null, null, null, new(copper: 0, silver: 0, electron: 0, gold: 2, platinum: 0), null, new(1, MassUnit.Pound), null, ["Instrumento musical"]), SourceManualDelJugador),
            
                new(new("Cuerno", null, null, null, new(copper: 0, silver: 0, electron: 0, gold: 3, platinum: 0), null, new(2, MassUnit.Pound), null, ["Instrumento musical"]), SourceManualDelJugador),
            
                new(new("Dulcimer", null, null, null, new(copper: 0, silver: 0, electron: 0, gold: 25, platinum: 0), null, new(10, MassUnit.Pound), null, ["Instrumento musical"]), SourceManualDelJugador),
            
                new(new("Flauta", null, null, null, new(copper: 0, silver: 0, electron: 0, gold: 2, platinum: 0), null, new(1, MassUnit.Pound), null, ["Instrumento musical"]), SourceManualDelJugador),
            
                new(new("Flauta de pan", null, null, null, new(copper: 0, silver: 0, electron: 0, gold: 12, platinum: 0), null, new(2, MassUnit.Pound), null, ["Instrumento musical"]), SourceManualDelJugador),
            
                new(new("Gaita", null, null, null, new(copper: 0, silver: 0, electron: 0, gold: 30, platinum: 0), null, new(6, MassUnit.Pound), null, ["Instrumento musical"]), SourceManualDelJugador),
            
                new(new("Laúd", null, null, null, new(copper: 0, silver: 0, electron: 0, gold: 35, platinum: 0), null, new(2, MassUnit.Pound), null, ["Instrumento musical"]), SourceManualDelJugador),
            
                new(new("Lira", null, null, null, new(copper: 0, silver: 0, electron: 0, gold: 30, platinum: 0), null, new(2, MassUnit.Pound), null, ["Instrumento musical"]), SourceManualDelJugador),
            
                new(new("Tambor", null, null, null, new(copper: 0, silver: 0, electron: 0, gold: 6, platinum: 0), null, new(3, MassUnit.Pound), null, ["Instrumento musical"]), SourceManualDelJugador),
            
                new(new("Viola", null, null, null, new(copper: 0, silver: 0, electron: 0, gold: 30, platinum: 0), null, new(1, MassUnit.Pound), null, ["Instrumento musical"]), SourceManualDelJugador),
            
                new(new("Kit de disfraz", null, null, null, new(copper: 0, silver: 0, electron: 0, gold: 25, platinum: 0), null, new(3, MassUnit.Pound), null, null), SourceManualDelJugador),
            
                new(new("Kit de envenenador", null, null, null, new(copper: 0, silver: 0, electron: 0, gold: 50, platinum: 0), null, new(2, MassUnit.Pound), null, null), SourceManualDelJugador),
            
                new(new("Kit de falsificación", null, null, null, new(copper: 0, silver: 0, electron: 0, gold: 15, platinum: 0), null, new(5, MassUnit.Pound), null, null), SourceManualDelJugador),
            
                new(new("Kit de herboristería", null, null, null, new(copper: 0, silver: 0, electron: 0, gold: 5, platinum: 0), null, new(3, MassUnit.Pound), null, null), SourceManualDelJugador),
            
                new(new("Set de ajedrez de dragón", null, null, null, new(copper: 0, silver: 0, electron: 0, gold: 1, platinum: 0), null, new(0.5, MassUnit.Pound), null, ["Set de juego"]), SourceManualDelJugador),
            
                new(new("Set de baraja de cartas", null, null, null, new(copper: 0, silver: 5, electron: 0, gold: 0, platinum: 0), null, null, null, ["Set de juego"]), SourceManualDelJugador),
            
                new(new("Set de dados", null, null, null, new(copper: 0, silver: 1, electron: 0, gold: 0, platinum: 0), null, null, null, ["Set de juego"]), SourceManualDelJugador),
            
                new(new("Set de tres dragones", null, null, null, new(copper: 0, silver: 0, electron: 0, gold: 1, platinum: 0), null, null, null, ["Set de juego"]), SourceManualDelJugador)
        }.ToFrozenSet();

        public static FrozenSet<DefaultItemDescription> All { get; }
    }
}
