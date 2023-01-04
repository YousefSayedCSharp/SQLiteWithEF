using Microsoft.EntityFrameworkCore;
using SQLiteWithEF.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Xamarin.Essentials;

namespace SQLiteWithEF
{
    public class ApplicationDbContext: DbContext
    {
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Card> cards{ get; set; }

        public ApplicationDbContext()
        {
            SQLitePCL.Batteries_V2.Init();

            this.Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string dbPath = Path.Combine(FileSystem.AppDataDirectory, "ProductsManagementDB.db3");

            optionsBuilder
                .UseSqlite($"Filename={dbPath}");
        }

    }//end class
}//end main