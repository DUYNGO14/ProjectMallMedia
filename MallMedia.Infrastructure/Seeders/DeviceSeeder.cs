﻿using MallMedia.Domain.Constants;
using MallMedia.Domain.Entities;
using MallMedia.Infrastructure.Persistence;
using MallMedia.Infrastructure.Seeders.Data;
using Microsoft.AspNetCore.Identity;

namespace MallMedia.Infrastructure.Seeders;

internal class DeviceSeeder
{
    private const string DefaultPassword = "Password123!";
    private readonly ApplicationDbContext dbContext;
    private readonly UserManager<User> userManager;
    private readonly RoleManager<IdentityRole> roleManager;

    public DeviceSeeder(ApplicationDbContext dbContext, UserManager<User> userManager, RoleManager<IdentityRole> roleManager)
    {
        this.dbContext = dbContext;
        this.userManager = userManager;
        this.roleManager = roleManager;
    }

    public async Task Seed()
    {
        if (!dbContext.Devices.Any())
        {
            var devicesToAdd = new List<Device>();
            string roleName = UserRoles.Admin;
            if (!await roleManager.RoleExistsAsync(roleName))
            {
                await roleManager.CreateAsync(new IdentityRole(roleName));
            }
            foreach (var device in DeviceData.Devices)
            {
                var user = new User
                {
                    UserName = device.DeviceName,
                    NormalizedUserName = device.DeviceName.ToUpper(),
                    Email = null
                };

                var result = await userManager.CreateAsync(user, DefaultPassword);
                if (result.Succeeded)
                {
                    await userManager.AddToRoleAsync(user, roleName);
                    device.UserId = user.Id;
                    devicesToAdd.Add(device);
                }
                else
                {
                    Console.WriteLine($"Error creating user for device {device.DeviceName}: {string.Join(", ", result.Errors.Select(e => e.Description))}");
                    Console.WriteLine(result.Errors);
                }
            }


            if (devicesToAdd.Any())
            {
                dbContext.Devices.AddRange(devicesToAdd);
                await dbContext.SaveChangesAsync();
            }
        }
    }
}