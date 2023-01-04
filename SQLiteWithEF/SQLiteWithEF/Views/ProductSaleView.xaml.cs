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
    public partial class ProductSaleView : ContentPage
    {
        public ProductSaleView(Card card)
        {
            InitializeComponent();
            
            BindingContext = new ProductSaleVM(card);
        }

    }//end class
}//end main