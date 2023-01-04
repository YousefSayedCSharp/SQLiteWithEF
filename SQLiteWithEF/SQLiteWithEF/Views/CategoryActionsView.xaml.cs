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
    public partial class CategoryActionsView : ContentPage
    {
        public CategoryActionsView(Category category)
        {
            InitializeComponent();

            if(category.Id>0)
            {
                lblTitle.Text = "تعديل الصنف";
                txtName.Placeholder = category.Name;
                btnSave.Text = "حفظ";
            }
            else
            {
                btnDelete.IsVisible = false;
                lblTitle.Text = "إضافة صنف";
                btnSave.Text = "إضافة";
            }

            BindingContext = new CategorySaveVM(category);
        }
    }
}