using HW12.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW12.Repository;

public class AppDBContext : DbContext
{
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(Configuration.Configuration.ConnectionString);
        base.OnConfiguring(optionsBuilder);
    }

    public DbSet<Tassk> tassks { get; set; }
    public DbSet<User> users { get; set; }
}
