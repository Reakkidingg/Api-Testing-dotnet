
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using System;
using UnitTestAPI.Models;

namespace UnitTestAPI.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }
        public DbSet<Category> Category { get; set; }
    }
}
