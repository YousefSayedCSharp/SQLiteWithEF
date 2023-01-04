using SQLiteWithEF.Models;
using SQLiteWithEF.Services;
using SQLiteWithEF.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SQLiteWithEF
{
    public partial class App : Application
    {
        //start get Connection string Path
        private static ApplicationDbContext _context;
        public static ApplicationDbContext context
        {
            get
            {
                if (_context == null)
                    _context = new ApplicationDbContext();

                return _context;
            }
        }
        //end Get Connection String PathConn

        public App()
        {
            InitializeComponent();

            if(context.Categories.Count()==0)
            {
                context.Categories.Add(new Category
                {
                    Id = 1,
                    Name = "مشويات",
                    Image = ""
                });

                context.Categories.Add(new Category
                {
                    Id = 2,
                    Name = "كربات",
                    Image = ""
                });
                context.Categories.Add(new Category
                {
                    Id=3,
                    Name = "سندوتشات",
                    Image = ""
                });
                
                if (context.Products.Count()==0)
                {
                    context.Products.Add(new Product
                    {
                        Title = "فرخة تكة",
                        Description = "تقدم مع 3 صلطة خضرة و3 صلطة طحينة و 5 أرغفة عيش بلدي",
                        Price = 115,
                        Image = "",
                        CategoryId = 1
                    });
                    context.Products.Add(new Product
                    {
                        Title = "كفتة مشوية على الفحم",
                        Description = "يقدم مع كيلو الكفتة 3  علب صلطة خضرة وطحينة و5 أرغفة من العيش",
                        Price = 150,
                        Image = "",
                        CategoryId = 1
                    });
                    context.Products.Add(new Product
                    {
                        Title = "كريب بنيه",
                        Description = "خضار وجبن وزتون مع قطع البنيه اللذيذة",
                        Price = 35,
                        Image = "",
                        CategoryId = 2
                    });
                    context.Products.Add(new Product
                    {
                        Title = "ساندويتش بنيه",
                        Description = "قطع البنيه المقلية في عيش فرنساوي وصط",
                        Price = 15,
                        Image = "",
                        CategoryId = 3
                    });
                    context.Products.Add(new Product
                    {
                        Title = "سندويتش كبدة",
                        Description = "قطع الكبدة اللذيذة المقلية بالرضة في عيش فرنساوي",
                        Price = 15,
                        Image = "",
                        CategoryId = 3
                    });
                }
                context.SaveChanges();
            }

            if(context.cards.Count()>0)
            {
                context.cards.RemoveRange(context.cards);
                context.SaveChanges();
            }

            if(context.Categories.Count()>0)
                MainPage = new NavigationPage(new HomeView());
            else
                MainPage = new NavigationPage(new CategoriesView());
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
