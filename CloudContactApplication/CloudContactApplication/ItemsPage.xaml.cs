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

    public sealed partial class ItemPage : Page
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
        public ItemPage()
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
        // Check to ensure that there is values in each textBox and that they are valid values, if not deal with accordingly
        // Create a Sqlite Database connection
        // Create a variable 'addItem' that holds an SQLite Insert statement
        // Set each instance variable in the Item class with values from each TextBox
        // Display in that Regional language with use of Globalisation settings
        // Call the Show_Tapped function to Asynchronously update page
        // Close the DB Connection
        // Clear each textBox after operations have been completed
        private void Add_Tapped(object sender, TappedRoutedEventArgs e)
        {
            selListBoxVal.Text = "";

            try
            {
                if (!IsPresent(itemTextBlock) || !IsPresent(quantityTextBlock) || !IsPresent(priceTextBlock) ||
                    !IsDecimal(quantityTextBlock) || !IsDecimal(priceTextBlock))
                {
                    if (Language.Equals("de-DE"))
                    {
                        selListBoxVal.Text = "Gueltigen Artikel eingeben!";
                    }
                    else
                    {
                        selListBoxVal.Text = "Enter a valid item!";
                    }
                }
                else
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
                }
            }
            catch (Exception)
            {
                throw;
            }

        } // End Function

        


        // --SHOW / RETRIEVE ALL ITEMS--
        // Connect to the DB
        // Create a list and populate it with values from the Item table
        // Display in ListBox ALong with Item Count and Total Price
        // Display in that Regional language with use of Globalisation settings
        // Close the DB Connection
        private void Show_Tapped(object sender, TappedRoutedEventArgs e)
        {
            try
            {
                dbConnection();
                List<string> items = new List<string>();
                var listItems = conn.Table<Item>();
                string result = string.Empty;
                double totalCost = 0;

                foreach (var item in listItems)
                {
                    result = string.Format("{0}     [Qty]: {1}     [Price]: €{2}c", item.itemName, item.itemQuantity, item.itemPrice);
                    items.Add(result);
                    totalCost += Convert.ToDouble(item.itemPrice);
                }

                if (items.Count == 0)
                {
                    if (Language.Equals("de-DE"))
                    {
                        selListBoxVal.Text = "Ihre liste ist Lehr";
                    }
                    else
                    {
                        selListBoxVal.Text = "Your List is Empty!";
                    }
                }
                else if (items.Count > 0)
                {
                    selListBoxVal.Text = "";
                }
                retrieveData.DataContext = items;

                if (Language.Equals("de-DE"))
                {
                    selListBoxVal2.Text = ("Artikel Anzahl: " + Convert.ToString(items.Count));
                    selListBoxVal.Text = ("Gesamt Summe: €" + totalCost);
                }
                else
                {
                    selListBoxVal2.Text = ("Item Count: " + Convert.ToString(items.Count));
                    selListBoxVal.Text = ("Total Cost: €" + totalCost);
                }
                 
                closeDBconnection();
            }
            catch (Exception)
            {
                throw;
            }

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
            try
            {
                dbConnection();
                var listItems = conn.Table<Item>();
                List<string> items = new List<string>();
                foreach (var item in listItems)
                {
                    string compareResult = string.Format("{0}     [Qty]: {1}     [Price]: €{2}c", item.itemName, item.itemQuantity, item.itemPrice);

                    if (retrieveData.SelectedValue.Equals(compareResult))
                    {
                        conn.Delete<Item>(item.id);
                    }
                }
                Show_Tapped(sender, e);
                closeDBconnection();
            }
            catch (Exception)
            {
                throw;
            }
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

        private void retrieveData_GotFocus(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            Delete.IsEnabled = true;
        }

        private void retrieveData_LostFocus(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            Delete.IsEnabled = false;
        }


        // --Validation-- 
        // Checks to ensure that only Numeric data is allowed in Qty and Price Fields, returns false if not
        private bool IsDecimal(TextBox textBox)
        {
            try
            {
                Convert.ToDecimal(textBox.Text);
                return true;
            }
            catch (FormatException)
            {
                return false;
            }
        }


        // Checks to Ensure that all fields have data in them, returns false if not
        private bool IsPresent(TextBox textBox)
        {
            if (textBox.Text == "")
                return false;
            else
                return true;
        }


    } // End ContactEntry : Page

} // End namespace ShoppingHelper