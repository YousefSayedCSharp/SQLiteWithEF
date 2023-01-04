using SQLiteWithEF.Models;
using SQLiteWithEF.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace SQLiteWithEF.ViewModels
{
    public class ProductSaveVM : BaseVM
    {
        public ProductSaveVM(Product p)
        {
            _categories = CategoryService.AllCategories().Result;
            if (p.Id > 0)
            {
                _selectedCategory = _categories.Where(c => c.Id == p.CategoryId).SingleOrDefault();
                _Id = p.Id;
                _Title = p.Title;
                _Description = p.Description;
                _Price = p.Price;
                _Image = p.Image;
                _CategoryId = p.CategoryId;
            }
        }

        private int _Id;
        public int Id
        {
            get => _Id;
            set { SetValue(ref _Id, value); }
        }

        private String _Title;
        public string Title
        {
            get => _Title;
            set { SetValue(ref _Title, value); }
        }

        private String _Description;
        public string Description
        {
            get => _Description;
            set { SetValue(ref _Description, value); }
        }

        private double _Price;
        public double Price
        {
            get => _Price;
            set { SetValue(ref _Price, value); }
        }

        private string _Image;
        public string Image
        {
            get => _Image;
            set { SetValue(ref _Image, value); }
        }

        private int _CategoryId;
        public int CategoryId
        {
            get => _CategoryId;
            set { SetValue(ref _CategoryId, value); }
        }

        private Category _selectedCategory;
        public Category selectedCategory
        {
            get => _selectedCategory;
            set { SetValue(ref _selectedCategory, value); }
        }

        private List<Category> _categories;
        public List<Category> categories
        {
            get => _categories;
            set { SetValue(ref _categories, value); }
        }

        private string _lblResult;
        public string lblResult
        {
            get => _lblResult;
            set { SetValue(ref _lblResult, value); }
        }

        public ICommand btnBack
        {
            get
            {
                return new Command(() =>
                {
                    App.Current.MainPage.Navigation.PopAsync();
                });
            }
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

        public void SaveCommand()
        {
            lblResult = "";

            if (string.IsNullOrEmpty(_Title))
            {
                lblResult += "لا يمكن ترك حقل الإسم خالي!\n";
                return;
            }

            if (string.IsNullOrEmpty(_Description))
            {
                lblResult += "لا يمكن ترك حقل التفاصيل خالي!\n";
                return;
            }

            if (_Price<=0)
            {
                lblResult += "لا يمكن تسجيل المنتج إلا بعد تحديد سعر أكبر من صفر 0!\n";
                return;
            }

            if (_selectedCategory==null)
            {
                lblResult += "لا يمكن تسجيل المنتج إلى بعد تحديد الصنف الذي ينتمي إليه !\n";
                return;
            }

            Product p = ProductsService.Find(_Id).Result;
            if (p == null)
                p = new Product();

            p.Title = _Title;
            p.Description = _Description;
            p.Price = _Price;
            p.Image = "";
            p.CategoryId = _selectedCategory.Id;

            if (_Id>0)
            {
                ProductsService.Edit(p);
            }
            else
            {
                ProductsService.Add(p);
            }
            Finish();
        }//end saveCommand

        public async void DeleteCommand()
        {
            bool msgConf = await App.Current.MainPage.DisplayAlert("", "سيتم حذف هذا المنتج للتأكيد الرجاء الضغط على نعم وللتراجع الضغط على لا ؟", "نعم", "لا");
            if (!msgConf)
                return;

            ProductsService.Delete(ProductsService.Find(_Id).Result);
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