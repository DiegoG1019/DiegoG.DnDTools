using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DiegoG.DnDTools.Services.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DiegoG.DnDTools.Services.EntityFramework.Configurations;

public class DnDToolsUserConfiguration : IEntityTypeConfiguration<DnDToolsUser>
{
    public void Configure(EntityTypeBuilder<DnDToolsUser> builder)
    {
        builder.HasKey(x => x.Id);
        
        builder.HasIndex(x => x.NormalizedUserName).IsUnique(true);
        builder.Property(x => x.NormalizedUserName).IsRequired(true).HasMaxLength(DnDToolsUser.UserNameMaxLength);

        builder.HasIndex(x => x.NormalizedEmail).IsUnique(true);
        builder.Property(x => x.NormalizedEmail).IsRequired(true).HasMaxLength(DnDToolsUser.EmailMaxLength);

        var access = builder.HasMany(x => x.AccesibleCharacters).WithMany().UsingEntity<DnDToolsCharacterAccess>(
            right => right.HasOne(x => x.Character).WithMany().HasForeignKey(x => x.CharacterId),
            left => left.HasOne(x => x.User).WithMany().HasForeignKey(x => x.UserId)
        );

        builder.HasMany(x => x.OwnedCharacters).WithOne(x => x.Owner).HasForeignKey(x => x.OwnerId);

        access.HasKey(x => new { x.CharacterId, x.UserId });

        builder.ToTable("Users");
    }
}
