using System;
using Microsoft.EntityFrameworkCore;
using StudentApp.Data.Models;

namespace StudentApp.Data;

public class ApplicationDbContext : DbContext
{
    protected override void OnConfiguring(DbContextOptionsBuilder options) => options.UseSqlite("DataSource=Main.db");

    public DbSet<School> Schools { get; set; }
		public DbSet<Student> Students { get; set; }
}

