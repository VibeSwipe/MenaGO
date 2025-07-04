﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Internal;
using Microsoft.Extensions.DependencyInjection;
using ProjectManager.Domain.Contracts;
using ProjectManager.Domain.Entities;
using ProjectManager.Infrastructure.Persistence;

namespace ProjectManager.Infrastructure.Seeders
{
    public class UserRolesSeeder : IDataSeeder
    {
        public int Priority => 1;
        private readonly RoleManager<IdentityRole> _roleManager;

        public UserRolesSeeder(RoleManager<IdentityRole> roleManager)
        {
            _roleManager = roleManager;
        }

        public async Task SeedAsync()
        {
            var roles = new[] { "Admin", "User" };

            foreach (var role in roles)
            {
                if (!await _roleManager.RoleExistsAsync(role)) await _roleManager.CreateAsync(new IdentityRole(role));
            }
        }
    }
}