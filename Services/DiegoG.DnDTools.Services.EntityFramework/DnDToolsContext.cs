using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using DiegoG.DnDTools.Services.Data;
using Microsoft.EntityFrameworkCore;

namespace DiegoG.DnDTools.Services.EntityFramework;

public class DnDToolsContext(DbContextOptions<DnDToolsContext> options) : DbContext(options)
{
    public DbSet<DnDToolsCharacter> Characters => Set<DnDToolsCharacter>();
    public DbSet<DnDToolsCharacterAccess> CharacterAccesses => Set<DnDToolsCharacterAccess>();
    public DbSet<DnDToolsUser> Users => Set<DnDToolsUser>();
    public DbSet<InventoryModel> Inventories => Set<InventoryModel>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
}
