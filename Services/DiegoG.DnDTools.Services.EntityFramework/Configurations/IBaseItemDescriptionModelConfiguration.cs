using DiegoG.DnDTools.Services.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DiegoG.DnDTools.Services.EntityFramework.Configurations;

public class IBaseItemDescriptionModelConfiguration
    : IEntityTypeConfiguration<IBaseItemDescriptionModel>, 
      IEntityTypeConfiguration<ItemDescriptionModel>,
      IEntityTypeConfiguration<FillableContainerItemDescriptionModel>,
      IEntityTypeConfiguration<ContainerItemDescriptionModel>,
      IEntityTypeConfiguration<WeaponItemDescriptionModel>,
      IEntityTypeConfiguration<ArmorItemDescriptionModel>
{
    public void Configure(EntityTypeBuilder<IBaseItemDescriptionModel> builder)
    {
        builder.HasKey(x => x.Id);
        builder.HasDiscriminator(x => x.EntityType);
        builder.HasIndex(x => x.Name).IsUnique(false);
        builder.HasIndex(x => x.Category).IsUnique(false);
        builder.ToTable("BaseItemDescriptions");
    }

    public void Configure(EntityTypeBuilder<ItemDescriptionModel> builder)
    {
        builder.UseTpcMappingStrategy();
        builder.ToTable("ItemDescriptions");
    }

    public void Configure(EntityTypeBuilder<FillableContainerItemDescriptionModel> builder)
    {
        builder.UseTpcMappingStrategy();
        builder.ToTable("FillableContainerItemDescriptions");
    }

    public void Configure(EntityTypeBuilder<ContainerItemDescriptionModel> builder)
    {
        builder.UseTpcMappingStrategy();
        builder.ToTable("ContainerItemDescriptions");
    }

    public void Configure(EntityTypeBuilder<WeaponItemDescriptionModel> builder)
    {
        builder.UseTpcMappingStrategy();
        builder.ToTable("WeaponItemDescriptions");
    }

    public void Configure(EntityTypeBuilder<ArmorItemDescriptionModel> builder)
    {
        builder.UseTpcMappingStrategy();
        builder.ToTable("ArmorItemDescriptions");
    }
}
