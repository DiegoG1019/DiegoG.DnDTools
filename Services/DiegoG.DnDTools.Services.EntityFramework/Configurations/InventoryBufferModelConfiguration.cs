using DiegoG.DnDTools.Services.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DiegoG.DnDTools.Services.EntityFramework.Configurations;

public class InventoryModelConfiguration : IEntityTypeConfiguration<InventoryModel>
{
    public void Configure(EntityTypeBuilder<InventoryModel> builder)
    {
        builder.Property(x => x.StoredItemsTotalValueCopper)
            .HasComputedColumnSql(GetBasePriceQuery("BasePriceCopper"), stored: true);

        builder.Property(x => x.StoredItemsTotalValueSilver)
            .HasComputedColumnSql(GetBasePriceQuery("BasePriceSilver"), stored: true);

        builder.Property(x => x.StoredItemsTotalValueElectron)
            .HasComputedColumnSql(GetBasePriceQuery("BasePriceElectron"), stored: true);

        builder.Property(x => x.StoredItemsTotalValueGold)
            .HasComputedColumnSql(GetBasePriceQuery("BasePriceGold"), stored: true);

        builder.Property(x => x.StoredItemsTotalValuePlatinum)
            .HasComputedColumnSql(GetBasePriceQuery("BasePricePlatinum"), stored: true);

        builder.Property(x => x.StoredItemsTotalStandardWeight)
            .HasComputedColumnSql(""""
            SELECT SUM(
                CASE 
                    WHEN [Items].[StandardWeightPerItemValue] = null 
                    THEN 0 
                    ELSE [Items].[StandardWeightPerItemValue]
                END
            ) 
            FROM [Items]
            WHERE [Items].[ContainerInventoryId] = [Id]
            """", stored: true);

        builder.HasKey(x => x.Id);
        builder.HasMany(x => x.Items).WithOne(x => x.ContainerInventory).HasForeignKey(x => x.ContainerInventoryId);

        builder.HasIndex(x => x.Name).IsUnique(false);

        builder.ToTable("Inventories");
    }

    private static string GetBasePriceQuery(string columnName)
        => $""""
            SELECT SUM(
                CASE 
                    WHEN [Items].[{columnName}] = null 
                    THEN 0 
                    ELSE [Items].[{columnName}]
                END
            ) 
            FROM [Items]
            WHERE [Items].[ContainerInventoryId] = [Id]
            """";
}
