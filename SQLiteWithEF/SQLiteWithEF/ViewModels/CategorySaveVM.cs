using SQLiteWithEF.Models;
using SQLiteWithEF.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace SQLiteWithEF.ViewModels
{
     public class CategorySaveVM:BaseVM
    {
        public CategorySaveVM(Category category)
        {
            _category = category;
        }

        private Category _category;
        public Category category
        {
            get => _category;
            set { SetValue(ref _category,value); }
        }

        private string _lblResult;
        public string lblResult
        {
            get => _lblResult;
            set { SetValue(ref _lblResult,value); }
        }

        public ICommand btnSave
        {
            get
            {
                return new Command(()=>
                {
                    SaveCommand();        
                });
            }
        }

        public ICommand btnDelete
        {
            get
            {
                return new Command(()=>
                {
                    DeleteCommand();                
                });
            }
        }

        public ICommand btnBack
        {
            get
            {
                return new Command(()=>
                {
                    App.Current.MainPage.Navigation.PopAsync();
                });
            }
        }

        public void SaveCommand()
        {
            lblResult = "";

            if (string.IsNullOrEmpty(category.Name))
            {
                lblResult+= "لا يمكن ترك حقل الإسم خالي!\n";
                return;
            }

            if (category.Id>0)
            {
                CategoryService.Edit(category);
            }
            else
            {
                CategoryService.Add(category);
            }
            Finish();
        }//end saveCommand

        public async void DeleteCommand()
        {
            bool msgConf = await App.Current.MainPage.DisplayAlert("", "سيتم حذف هذا الصنف للتأكيد الرجاء الضغط على نعم وللتراجع الضغط على لا ؟", "نعم", "لا");
            if (!msgConf)
                return;

            CategoryService.Delete(category);
            Finish();
        }

        public async void Finish()
        {
            string msg = "";
            MessagingCenter.Send("MyApp", "UpdateCollectionView", msg);
            await App.Current.MainPage.Navigation.PopAsync();
        }

    }//end class
}//end main