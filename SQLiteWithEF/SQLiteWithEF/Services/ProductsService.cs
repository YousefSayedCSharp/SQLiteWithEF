using Microsoft.EntityFrameworkCore;
using SQLiteWithEF.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SQLiteWithEF.Services
{
    public static class ProductsService
    {
        public static async Task<Product> Find(int id)
        {
            return await App.context.Products.FindAsync(id);
        }

        public static async Task<List<Product>> AllProducts()
        {
            return await App.context.Products.Include(p => p.Category).ToListAsync();
        }

        public static async void Add(Product product)
        {
            await App.context.Products.AddAsync(product);
            App.context.SaveChanges();
        }

        public static void Edit(Product product)
        {
            App.context.Products.Update(product);
            App.context.SaveChanges();
        }

        public static void Delete(Product product)
        {
            App.context.Products.Remove(product);
            App.context.SaveChanges();
        }
    }
}
