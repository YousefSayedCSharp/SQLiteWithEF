using SQLiteWithEF.Models;
using SQLiteWithEF.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SQLiteWithEF.ViewModels
{
    public class MyCardVM : BaseVM
    {
        public MyCardVM()
        {
            List<Card> AllCards = App.context.cards.ToList();

            List<MyCardViewModel> cardvm = new List<MyCardViewModel>();
            foreach (Card item in AllCards)
            {
                cardvm.Add(new MyCardViewModel
                {
                    Id=item.Id,
                    ProductId=item.ProductId,
                    Title=item.Title,
                    Description= item.Description,
                    Price= item.Price,
                    Image= item.Image,
                    Count=item.Count,
                    Total=item.Price*item.Count
                });
            }

            _TotalPrice = cardvm.Sum(cr=>cr.Total);

            _cards = cardvm;
        }

        private List<MyCardViewModel> _cards;
        public List<MyCardViewModel> cards
        {
            get => _cards;
            set { SetValue(ref _cards, value); }
        }

        private double _TotalPrice;
        public double TotalPrice
        {
            get => _TotalPrice;
            set { SetValue(ref _TotalPrice,value); }
        }

        private MyCardViewModel _selectedItem;
        public MyCardViewModel selectedItem
        {
            get => _selectedItem;
            set
            {
                if (value == null)
                    return;

                SetValue(ref _selectedItem, value);

                Card cr = new Card
                {
                    Id=_selectedItem.Id,
                    ProductId= _selectedItem.ProductId,
                    Title= _selectedItem.Title,
                    Description= _selectedItem.Description,
                    Price= _selectedItem.Price,
                    Image= _selectedItem.Image,
                    Count= _selectedItem.Count,
                };

                App.Current.MainPage.Navigation.PushAsync(new ProductSaleView(cr));
                SetValue(ref _selectedItem, null);
                //end
            }
        }

    }//end class
}//end main
