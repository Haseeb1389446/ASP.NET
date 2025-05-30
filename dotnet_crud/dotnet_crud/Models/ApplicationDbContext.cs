﻿using Microsoft.EntityFrameworkCore;

namespace dotnet_crud.Models
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<User> users { get; set; }
    }
}
