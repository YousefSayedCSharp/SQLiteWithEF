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
    public class ProductsVM : BaseVM
    {
        List<Product> AllProducts;

        public ProductsVM()
        {
            AllProducts = ProductsService.AllProducts().Result;
            //List<Category> AllCategories= CategoryService.AllCategories().Result;
            List<Category> AllCategories = new List<Category>();

            FillProducts();
            _categories = AllCategories;
        }

        private void FillProducts()
        {
            List<ProductViewModel> ProductsIncluded = new List<ProductViewModel>();
            foreach (Product item in AllProducts)
            {
                ProductsIncluded.Add(new ProductViewModel
                {
                    Id = item.Id,
                    Title = item.Title,
                    Description = item.Description,
                    Price = item.Price,
                    Image = item.Image,
                    CategoryId = item.CategoryId,
                    CategoryName = item.Category.Name
                });
            }

            _products = ProductsIncluded;
        }

        private List<ProductViewModel> _products;
        public List<ProductViewModel> products
        {
            get => _products;
            set { SetValue(ref _products, value); }
        }

        private ProductViewModel _selectedItem;
        public ProductViewModel selectedItem
        {
            get => _selectedItem;
            set
            {
                if (value == null)
                    return;

                SetValue(ref _selectedItem, value);
                //App.Current.MainPage.Navigation.PushAsync(new ItemV(_selectedItem));
                //App.Current.MainPage.Navigation.PushAsync(new CategoryActionsView(_selectedItem));
                Product _p = ProductsService.Find(_selectedItem.Id).Result;
                //App.Current.MainPage.DisplayAlert("", _p.Title, "OK");
                App.Current.MainPage.Navigation.PushAsync(new ProductActionsView(_p));
                SetValue(ref _selectedItem, null);
                //end
            }
        }

        public ICommand btnShowActions
        {
            get
            {
                return new Command(() =>
                {
                    App.Current.MainPage.Navigation.PushAsync(new ProductActionsView(new Product { }));
                });
            }
        }

        private List<Category> _categories;
        public List<Category> categories
        {
            get => _categories;
            set { SetValue(ref _categories, value); }
        }

        private Category _selectedItemCategory;
        public Category selectedItemCategory
        {
            get => _selectedItemCategory;
            set
            {
                if (value == null)
                    return;

                SetValue(ref _selectedItemCategory, value);
                FillProducts();
                int id = value.Id;
                var customProducts = _products.Where(p => p.CategoryId == id).ToList();
                products = customProducts;
                //App.Current.MainPage.DisplayAlert("",value.Id+""+ _products.Count,"OK");
                //end
            }
        }

    }//end class
}//end maind
