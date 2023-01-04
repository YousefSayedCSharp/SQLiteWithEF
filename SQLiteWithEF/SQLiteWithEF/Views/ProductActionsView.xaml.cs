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
    public partial class ProductActionsView : ContentPage
    {
        public ProductActionsView(Product product)
        {
            InitializeComponent();
            if (product == null)
                product = new Product { };

            if (product.Id > 0)
            {
                lblTitle.Text = "تعديل منتج";
                txtTitle.Placeholder = product.Title;
                btnSave.Text = "حفظ";
            }
            else
            {
                btnDelete.IsVisible = false;
                lblTitle.Text = "إضافة منتج";
                btnSave.Text = "إضافة";
            }
            //pic.ItemsSource = CategoryService.AllCategories().Result;
            BindingContext = new ProductSaveVM(product);
        }
    }//end class
}//end main