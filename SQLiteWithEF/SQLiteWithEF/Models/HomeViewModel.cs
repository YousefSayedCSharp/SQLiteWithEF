using System;
using System.Collections.Generic;
using System.Text;

namespace SQLiteWithEF.Models
{
    public class HomeViewModel: List<Product>
    {
        public  string GroupTitle { get; set; }
        public HomeViewModel(string Title)
        {
            this.GroupTitle = Title;
        }


    }
}
