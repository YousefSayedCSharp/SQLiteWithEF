using SQLiteWithEF.Models;
using SQLiteWithEF.Services;
using SQLiteWithEF.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace SQLiteWithEF.ViewModels
{
    public class HomeVM : BaseVM
    {
        public HomeVM()
        {
            List<Category> categories = CategoryService.AllCategories().Result.OrderBy(c => c.Name).ToList();
            List<Product> products = ProductsService.AllProducts().Result;
            List<HomeViewModel> AllGroups = new List<HomeViewModel>();
            foreach (Category c in categories)
                {
                List<Product> g = products.Where(p => p.CategoryId == c.Id).ToList();
                HomeViewModel h = new HomeViewModel(c.Name);
                foreach (Product p in products.Where(pr=>pr.CategoryId==c.Id))
                {
                    h.Add(p);
                }
                AllGroups.Add(h);
            }
            _group = AllGroups;
        }

        private List<HomeViewModel> _group;
        public List<HomeViewModel> group
        {
            get => _group;
            set { SetValue(ref _group, value); }
        }

        private Product _selectedItem;
        public Product selectedItem
        {
            get => _selectedItem;
            set
            {
                if (value == null)
                    return;

                SetValue(ref _selectedItem, value);
                Card c = new Card
                {
                    ProductId=_selectedItem.Id,
                    Title= _selectedItem.Title,
                    Description= _selectedItem.Description,
                    Price= _selectedItem.Price,
                    Image= _selectedItem.Image,
                    Count=1
                };
                App.Current.MainPage.Navigation.PushAsync(new ProductSaleView(c));
                SetValue(ref _selectedItem, null);
                //end
            }
        }

        public ICommand btnSetting
        {
            get
            {
                return new Command(()=>
                {
                    App.Current.MainPage.Navigation.PushAsync(new SettingView());
                });
            }
        }

        public ICommand btn
        {
            get
            {
                return new Command(()=>
                {
                    App.Current.MainPage.Navigation.PushAsync(new MyCardView());
                });
            }
        }

    }//end class
}//end main
