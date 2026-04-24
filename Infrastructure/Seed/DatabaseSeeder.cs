using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Seed;
public class DatabaseSeeder(ApplicationDbContext context)
{
public async Task SeedAsync()
{
    // 1. Check if the Owner role already exists
    string ownerRoleName = Role.COFOUNDERS.OWNER.ToString(); 
    if (!await context.Roles.AnyAsync(r => r.Name == ownerRoleName))
    {
        var ownerRole = new Role 
        { 
            Name = ownerRoleName 
        };
        context.Roles.Add(ownerRole);
        await context.SaveChangesAsync();
    }



    // in Future you will use it for all permtions 
        // var allPermissions = await context.Permissions.ToListAsync();
    // foreach(var permission in allPermissions)
    // {
        // context.RolePermissions.Add(new RolePermission { 
            // RoleId = ownerRole.Id, 
            // PermissionId = permission.Id 
        // });
    // }
    // await context.SaveChangesAsync();
}
}