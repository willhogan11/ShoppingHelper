using SQLite.Net.Attributes;

namespace ShoppingHelper
{
    // --Item Class--
    // Bean class that holds all Item getters and setters functions
    // Primary Key and Auto Increment facilities used in conjunction with Sqlite DB
    public class Item
    {
        [PrimaryKey, AutoIncrement]
        public int id { get; set; }
        public string itemName { get; set; }
        public int itemQuantity { get; set; }
        public double itemPrice { get; set; }
    }
}
