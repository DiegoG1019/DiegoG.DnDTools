using DiegoG.DnDTools.Services.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DiegoG.DnDTools.Services.EntityFramework.Configurations;

public class DnDToolsCharacterConfiguration : IEntityTypeConfiguration<DnDToolsCharacter>
{
    public void Configure(EntityTypeBuilder<DnDToolsCharacter> builder)
    {
        builder.HasKey(x => x.Id);
        builder.HasIndex(x => x.Name).IsUnique(false);
        builder.Property(x => x.Name).HasMaxLength(DnDToolsCharacter.CharacterNameMaxLength);
        builder.HasMany(x => x.Inventories).WithOne(x => x.Character).HasForeignKey(x => x.CharacterId);
        builder.ToTable("Characters");
    }
}
