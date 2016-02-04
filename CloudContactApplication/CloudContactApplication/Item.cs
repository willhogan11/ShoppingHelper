using SQLite.Net.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingHelper
{
    public class Item
    {
        [PrimaryKey, AutoIncrement]
        public int id { get; set; }
        public string itemName { get; set; }
        public int itemQuantity { get; set; }
        public double itemPrice { get; set; }
    }
}
