using SQLiteWithEF.Models;
using SQLiteWithEF.Services;
using SQLiteWithEF.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SQLiteWithEF.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ProductsView : ContentPage
    {
        public ProductsView()
        {
            InitializeComponent();
            BindingContext = new ProductsVM();
            //ProductsService.Add(new Product { Title = "Product 1", Description = "description 1", Price = 33.35, CategoryId = CategoryService.AllCategories().Result[0].Id });
            //ProductsService.Add(new Product { Title = "Product 2", Description = "description 2", Price = 53.35, CategoryId = CategoryService.AllCategories().Result[1].Id });
            //ProductsService.Add(new Product { Title = "Product 3", Description = "description 3", Price = 13.35, CategoryId = CategoryService.AllCategories().Result[0].Id });
            //var prods = from p in ProductsService.AllProducts().Result
            //            select new
            //            {
            //                p.Title,
            //                p.Category.Name
            //            };
            //cv.ItemsSource = prods;
            //DisplayAlert("",prods.ToList().Count+"","OK");
        }

        protected override void OnAppearing()
        {
            //base.OnAppearing();
            //            Xamarin.Forms.MessagingCenter.Subscribe<Page2, string>(this, "SendingMessage", (sender, message) =>
            //MessagingCenter.Subscribe<MainPage,string>(this,"UpdateCollectionView"=>
            MessagingCenter.Subscribe<string, string>("MyApp", "UpdateCollectionView", (sender, result) =>
            {
                BindingContext = new ProductsVM();
            });
        }

        protected override void OnDisappearing()
        {
            //base.OnDisappearing();
            MessagingCenter.Unsubscribe<MainPage>(this, "UpdateCollectionView");
        }

    }//end class
}//end maind