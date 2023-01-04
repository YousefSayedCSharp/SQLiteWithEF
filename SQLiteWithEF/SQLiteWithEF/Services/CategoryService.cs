using Microsoft.EntityFrameworkCore;
using SQLiteWithEF.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SQLiteWithEF.Services
{
    public static class CategoryService
    {
        public static async Task<Category> Find(int id)
        {
            return await App.context.Categories.FindAsync(id);
        }

        public static async Task<List<Category>> AllCategories()
        {
            return await App.context.Categories.ToListAsync();
        }

        public static async void Add(Category category)
        {
            await App.context.Categories.AddAsync(category);
            App.context.SaveChanges();
        }

        public static void Edit(Category category)
        {
            App.context.Categories.Update(category);
            App.context.SaveChanges();
        }

        public static void Delete(Category category)
        {
            App.context.Categories.Remove(category);
            App.context.SaveChanges();
        }
    }
}
