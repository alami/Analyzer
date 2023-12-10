﻿using Analyzer.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Analyzer.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<Device> Device { get; set; }
        public DbSet<Component> Component { get; set; }
        public DbSet<DeviceComponent> DeviceComponent { get; set; }
    }
}
