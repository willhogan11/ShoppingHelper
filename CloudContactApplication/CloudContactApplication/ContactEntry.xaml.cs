using System;
using System.Collections.Generic;
using System.IO;
using Windows.UI.Xaml;
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

        //string path;
        //SQLite.Net.SQLiteConnection conn;
        

        public ContactEntry()
        {
            this.InitializeComponent();
            //path = Path.Combine(Windows.Storage.ApplicationData.Current.LocalFolder.Path, "db.sqlite");
            //conn = new SQLite.Net.SQLiteConnection(new SQLite.Net.Platform.WinRT.SQLitePlatformWinRT(), path);
            //conn.CreateTable<Message>();
        }

        Item item = new Item();
        List<string> items;

        private void itemNameTextBlock_TextChanged(object sender, TextChangedEventArgs e)
        {
            outputItemName.Text = itemTextBlock.Text;
        }

        private void itemQuantityTextBlock_TextChanged(object sender, TextChangedEventArgs e)
        {
            outputItemQuantity.Text = quantityTextBlock.Text.ToString();
        }

        private void itemPriceTextBlock_TextChanged(object sender, TextChangedEventArgs e)
        {
            outputItemPrice.Text = priceTextBlock.Text;
        }


        private void Show_Tapped(object sender, TappedRoutedEventArgs e)
        {
            
        }

        private void Add_Tapped(object sender, TappedRoutedEventArgs e)
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
    }
}
