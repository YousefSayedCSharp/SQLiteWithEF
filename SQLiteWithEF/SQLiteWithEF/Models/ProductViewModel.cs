using System;
using System.Collections.Generic;
using System.Text;

namespace SQLiteWithEF.Models
{
    public class ProductViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public string Image { get; set; }
        public int CategoryId { get; set; }
        public string CategoryName{ get; set; }
    }
}
