using SQLiteWithEF.Models;
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
    public partial class CategoriesView : ContentPage
    {
        public CategoriesView()
        {
            InitializeComponent();
            BindingContext = new CategoriesVM();
        }

        protected override void OnAppearing()
        {
            //base.OnAppearing();
            //            Xamarin.Forms.MessagingCenter.Subscribe<Page2, string>(this, "SendingMessage", (sender, message) =>
            //MessagingCenter.Subscribe<MainPage,string>(this,"UpdateCollectionView"=>
            MessagingCenter.Subscribe<string, string>("MyApp", "UpdateCollectionView", (sender, result) =>
            {
                BindingContext = new CategoriesVM();
            });
        }

        protected override void OnDisappearing()
        {
            //base.OnDisappearing();
            MessagingCenter.Unsubscribe<MainPage>(this, "UpdateCollectionView");
        }

    }//end class
}//end maind