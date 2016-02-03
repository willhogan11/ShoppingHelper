using System;
using System.Diagnostics;
using System.IO;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Input;


// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace CloudContactApplication
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
            path = Path.Combine(Windows.Storage.ApplicationData.Current.LocalFolder.Path, "db.sqlite"); 
            conn = new SQLite.Net.SQLiteConnection(new SQLite.Net.Platform.WinRT.SQLitePlatformWinRT(), path);
            conn.CreateTable<Item>();

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
            var addItem = conn.Insert(new Item()
            {
                itemName = itemTextBlock.Text, 
                itemQuantity = Convert.ToInt32(quantityTextBlock.Text), 
                itemPrice = Convert.ToDouble(priceTextBlock.Text)
            });
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
            
        }

        private void Edit_Tapped(object sender, TappedRoutedEventArgs e)
        {

        }

        private void Delete_Tapped(object sender, TappedRoutedEventArgs e)
        {

        }

        private void goBack_Tapped(object sender, TappedRoutedEventArgs e)
        {
            Frame.Navigate(typeof(MainPage));
        }



        // Set up for testing purposes, these dynamically show details as they are typed on screen 
        //private void itemNameTextBlock_TextChanged(object sender, TextChangedEventArgs e)
        //{
        //    outputItemName.Text = itemTextBlock.Text;
        //}

        //private void itemQuantityTextBlock_TextChanged(object sender, TextChangedEventArgs e)
        //{
        //    outputItemQuantity.Text = quantityTextBlock.Text.ToString();
        //}

        //private void itemPriceTextBlock_TextChanged(object sender, TextChangedEventArgs e)
        //{
        //    outputItemPrice.Text = priceTextBlock.Text;
        //}
    }
}
