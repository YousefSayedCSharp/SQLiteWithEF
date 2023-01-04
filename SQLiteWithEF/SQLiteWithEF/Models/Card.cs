using System;
using System.Collections.Generic;
using System.Text;

namespace SQLiteWithEF.Models
{
    public class Card
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public string Image { get; set; }
        public int Count { get; set; } = 1;
    }
}
