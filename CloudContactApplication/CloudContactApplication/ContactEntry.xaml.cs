using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Input;


// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace ShoppingHelper
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    /// 

    public sealed partial class ContactEntry : Page
    {
        // Setup a path and a new sqlite connection
        string path;
        SQLite.Net.SQLiteConnection conn;


        // Constructor:
        // Initalise the path variable
        // Create a new Database called 'db.sqlite' 
        // Assign a new Connection to the SQLite database
        // Create a table based on the 'Item' class in this project
        public ContactEntry()
        {
            this.InitializeComponent();
            path = Path.Combine(Windows.Storage.ApplicationData.Current.LocalFolder.Path, "db.shoppingHelperSqlite"); 
            conn = new SQLite.Net.SQLiteConnection(new SQLite.Net.Platform.WinRT.SQLitePlatformWinRT(), path);
            conn.CreateTable<Item>();

            closeDBconnection();

            // Write the path to the sqlite database to the output screen
#if DEBUG
            Debug.WriteLine(path);
#endif
        }


        // Add an Item:
        // Create a variable 'addItem' that holds an SQLite Insert statement
        // Set each instance variable in the Item class with values from each TextBox
        // Clear each textBox after operations have been completed
        private void Add_Tapped(object sender, TappedRoutedEventArgs e)
        {
            conn = new SQLite.Net.SQLiteConnection(new SQLite.Net.Platform.WinRT.SQLitePlatformWinRT(), path);
            var addItem = conn.Insert(new Item()
            {
                itemName = itemTextBlock.Text, 
                itemQuantity = Convert.ToInt32(quantityTextBlock.Text), 
                itemPrice = Convert.ToDouble(priceTextBlock.Text)
            });
            Show_Tapped(sender, e);
            closeDBconnection();

            clearTextBoxes();
        } // End Function



        // Function to clear TextBoxes, after an item has been added
        private void clearTextBoxes()
        {
            itemTextBlock.Text = "";
            quantityTextBlock.Text = "";
            priceTextBlock.Text = ""; 
        }
        

        private void Show_Tapped(object sender, TappedRoutedEventArgs e)
        {
            conn = new SQLite.Net.SQLiteConnection(new SQLite.Net.Platform.WinRT.SQLitePlatformWinRT(), path);
            List<string> items = new List<string>();
            var listItems = conn.Table<Item>();
            string result = string.Empty;


            foreach (var item in listItems)
            {
                result = string.Format("ItemNo: {0} Item: {1} Qty: {2} Price: €{3}c", item.id,
                                                                                item.itemName,
                                                                                item.itemQuantity,
                                                                                item.itemPrice);
                items.Add(result);
#if DEBUG
                Debug.WriteLine(item); // Test output of Items in list
#endif
            }
            retrieveData.DataContext = items;

            selListBoxVal.Text = "";
            closeDBconnection();
        }



        private void Delete_Tapped(object sender, TappedRoutedEventArgs e)
        {
            conn = new SQLite.Net.SQLiteConnection(new SQLite.Net.Platform.WinRT.SQLitePlatformWinRT(), path);

            var listItems = conn.Table<Item>();

            List<string> items = new List<string>();

            foreach (var item in listItems)
            {
                String compareResult = string.Format("ItemNo: {0} Item: {1} Qty: {2} Price: €{3}c", item.id, item.itemName, item.itemQuantity, item.itemPrice);

                if (retrieveData.SelectedValue.Equals(compareResult))
                {
                    conn.Delete<Item>(item.id);
                    selListBoxVal.Text = "Record Deleted";
                }
            }
            Show_Tapped(sender, e); // Completes a Refresh / Asynchronous Call to the database that updates the Displayed listbox with Remaining items 
            closeDBconnection();

        } //  End Delete_Tapped Function



        private void goBack_Tapped(object sender, TappedRoutedEventArgs e)
        {
            Frame.Navigate(typeof(MainPage));
        }

        private void Exit_Tapped(object sender, TappedRoutedEventArgs e)
        {
            // Is this really a requirement??
            Windows.UI.Xaml.Application.Current.Exit();
        }

        // Close / Dispose the DB connections for each operation
        private void closeDBconnection()
        {
            conn.Commit();
            conn.Dispose();
            conn.Close();
        }
    }
}