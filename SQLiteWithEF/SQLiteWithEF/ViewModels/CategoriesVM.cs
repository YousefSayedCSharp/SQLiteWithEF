using SQLiteWithEF.Models;
using SQLiteWithEF.Services;
using SQLiteWithEF.Views;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Input;
using Xamarin.Forms;

namespace SQLiteWithEF.ViewModels
{
    public class CategoriesVM : BaseVM
    {
        public CategoriesVM()
        {
            _categories = CategoryService.AllCategories().Result;
        }

        private List<Category> _categories;
        public List<Category> categories
        {
            get => _categories;
            set { SetValue(ref _categories, value); }
        }

        private Category _selectedItem;
        public Category selectedItem
        {
            get => _selectedItem;
            set
            {
                if (value == null)
                    return;

                SetValue(ref _selectedItem, value);
                //App.Current.MainPage.Navigation.PushAsync(new ItemV(_selectedItem));
                App.Current.MainPage.Navigation.PushAsync(new CategoryActionsView(_selectedItem));
                SetValue(ref _selectedItem, null);
                //end
            }
        }

        public ICommand btnShowActions
        {
            get
            {
                return new Command(()=>
                {
                    App.Current.MainPage.Navigation.PushAsync(new CategoryActionsView(new Category { }));     
                });
            }
        }
        
    }//end class
}//end main