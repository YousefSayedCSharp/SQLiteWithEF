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
    public partial class MyCardView : ContentPage
    {
        public MyCardView()
        {
            InitializeComponent();
            BindingContext = new MyCardVM();
        }

        protected override void OnAppearing()
        {
            MessagingCenter.Subscribe<string, string>("MyCard", "UpdateCollectionView", (sender, result) =>
            {
                BindingContext = new MyCardVM();
            });
        }

        protected override void OnDisappearing()
        {
            //base.OnDisappearing();
            MessagingCenter.Unsubscribe<MainPage>(this, "UpdateCollectionView");
        }

    }//end class
}//end maind