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
    public class ProductSaleVM : BaseVM
    {
        public ProductSaleVM(Card c)
        {
            Card exist = App.context.cards.Where(e => e.ProductId == c.ProductId).FirstOrDefault();
            if (exist != null)
                c = exist;

            _Id= c.Id;
            _ProductId = c.ProductId;
            _Title= c.Title;
            _Description= c.Description;
            _Price= c.Price;
            _Image= c.Image;
            _Count = c.Count;
            _Total = c.Price * c.Count;
        }

        private int _Id;
        public int Id
        {
            get => _Id;
            set { SetValue(ref _Id, value); }
        }

        private int _ProductId;
        public int ProductId
        {
            get => _ProductId;
            set { SetValue(ref _ProductId, value); }
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

        private int _Count;
        public int Count
        {
            get => _Count;
            set {  SetValue(ref _Count, value);Total = _Price*_Count; }
        }
        public void test()
        {
            _Total = _Price* _Count;
        }

        private double _Total;
        public double Total
        {
            get => _Total;
            set { SetValue(ref _Total,value); }
        }

        public ICommand btnAddToCard
        {
            get
            {
                return new Command(()=>
                {
                    saveToCard();
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

        private void saveToCard()
        {
            Card crd = App.context.cards.Where(c => c.Id == _Id).FirstOrDefault();
            if (crd == null)
            {
                crd = new Card();
                crd.ProductId = _ProductId;
                crd.Title= _Title;
                crd.Description= _Description;
                crd.Price= _Price;
                crd.Image= _Image;
                crd.Count= _Count;
                App.context.cards.Add(crd);
                App.context.SaveChanges();
            }
            else
            {
                crd.Count = _Count;
                App.context.cards.Update(crd);
                App.context.SaveChanges();
            }

            string msg = "";
            MessagingCenter.Send("MyCard", "UpdateCollectionView", msg);
            App.Current.MainPage.Navigation.PopAsync();
        }

    }//end class
}//end main
