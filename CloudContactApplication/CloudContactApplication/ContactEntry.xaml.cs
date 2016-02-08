using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
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
        // Instance Variables that are required to Setup a path and a new sqlite Database connection
        private string path;
        private SQLite.Net.SQLiteConnection conn;


        // --CONSTRUCTOR--
        // Initalise the path variable
        // Create a new Database called 'db.shoppingHelperSqlite' 
        // Assign a new Connection to the SQLite database
        // Create a table based on the 'Item' class in this project
        // Close the Database Connection
        public ContactEntry()
        {
            this.InitializeComponent();
            path = Path.Combine(Windows.Storage.ApplicationData.Current.LocalFolder.Path, "db.shoppingHelperSqlite");
            dbConnection();
            conn.CreateTable<Item>();
            closeDBconnection();

// Write the path to the sqlite database to the output screen
#if DEBUG
            Debug.WriteLine(path);
#endif
        } // End contructor


        // --ADD AN ITEM--
        // Create a variable 'addItem' that holds an SQLite Insert statement
        // Set each instance variable in the Item class with values from each TextBox
        // Call the Show_Tapped function to Asynchronously update page
        // Close the DB Connection
        // Clear each textBox after operations have been completed
        private void Add_Tapped(object sender, TappedRoutedEventArgs e)
        {
            dbConnection();
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


        
        // --SHOW / RETRIEVE ALL ITEMS--
        // Connect to the DB
        // Create a list and populate it with values from the Item table
        // Display in ListBox
        // Close the DB Connection
        private void Show_Tapped(object sender, TappedRoutedEventArgs e)
        {
            dbConnection();
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
        } // End Function



        // --DELETE ITEM--
        // Connect to DB
        // Populate ListItems with values from the Item table
        // Use compareResult to store result that's checked in DB against the Selected Item Tapped in the ListBox
        // If there is a mtach Delete the item from the DB
        // Inform user that record was deleted
        // Call the Show_Tapped function to Asynchronously update page
        // Close the DB Connection
        private void Delete_Tapped(object sender, TappedRoutedEventArgs e)
        {
            dbConnection();
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
            Show_Tapped(sender, e);
            selListBoxVal.Text = "";
            closeDBconnection();
        } //  End Function


        // DB connection function that holds the initialised value of the conn variable, complete with path and connection information
        private void dbConnection()
        {
            conn = new SQLite.Net.SQLiteConnection(new SQLite.Net.Platform.WinRT.SQLitePlatformWinRT(), path);
        }


        // Transfers the user back to th main page 
        private void goBack_Tapped(object sender, TappedRoutedEventArgs e)
        {
            Frame.Navigate(typeof(MainPage));
        }

        // Exits the Application
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

        // Function to clear TextBoxes, after an item has been added
        private void clearTextBoxes()
        {
            itemTextBlock.Text = "";
            quantityTextBlock.Text = "";
            priceTextBlock.Text = "";
        }

    } // End ContactEntry : Page

} // End namespace ShoppingHelper