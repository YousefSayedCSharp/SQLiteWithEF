using SQLiteWithEF.Views;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace SQLiteWithEF.ViewModels
{
    public class SettingVM:BaseVM
    {
        public SettingVM()
        {

        }

        public ICommand btnCategories
        {
            get
            {
                return new Command(()=>
                {
                    App.Current.MainPage.Navigation.PushAsync(new CategoriesView(        ));
                });
            }
        }

        public ICommand btnProducts
        {
            get
            {
                return new Command(() =>
                {
                    App.Current.MainPage.Navigation.PushAsync(new ProductsView());
                });
            }
        }
    }//end class
}//end main
