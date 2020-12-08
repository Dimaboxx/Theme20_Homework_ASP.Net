using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Theme_20_Homework_fromEmpty.Models;

namespace Theme_20_Homework_fromEmpty.ContextFolder
{
    public class DataContext : DbContext
    {

        public DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(
                @"Server=(localdb)\MSSQLLocalDB;
                  DataBase=Theme21_Games;
                  Trusted_Connection=True;"
                );

        }
    }
}
