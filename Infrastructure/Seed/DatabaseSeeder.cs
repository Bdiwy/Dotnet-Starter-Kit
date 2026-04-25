using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Seed;
public class DatabaseSeeder(ApplicationDbContext context)
{
    public async Task SeedAsync()
    {
        await SeedOwnerRole();
    }

    private async Task SeedOwnerRole()
    {
        // Check if the Owner role already exists
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
    }

    private async Task AsignAllPermissionsTo(Guid RoleId)
    {
        //   in Future you will use it for all permtions 
        var allPermissions = await context.Permissions.ToListAsync();

        allPermissions.ForEach(e=> 
            context.RolePermissions.Add(new RolePermission { 
                RoleId = RoleId, 
                PermissionId = e.Id 
            })
        );

        await context.SaveChangesAsync();
    }
}