using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace CloudContactApplication
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    /// 

    //public class CloudContact
    //{
    //    public int Id { get; set; }

    //    [DataMember(Name = "nameTextBlock")]
    //    public String Text { get; set; }

    //    [DataMember(Name = "phoneTextBlock")]
    //    public String Complete { get; set; }
    //}

    public sealed partial class ContactEntry : Page
    {
        public ContactEntry()
        {
            this.InitializeComponent();
        }

        private void submitButton_Click(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            // Send to server code
        }

        private void nameTextBlock_TextChanged(object sender, TextChangedEventArgs e)
        {
           outputContactName.Text = nameTextBlock.Text;
        }

        private void phoneTextBlock_TextChanged(object sender, TextChangedEventArgs e)
        {
            outputContactPhone.Text = phoneTextBlock.Text.ToString();
        }

        private void emailTextBlock_TextChanged(object sender, TextChangedEventArgs e)
        {
            outputContactEmail.Text = emailTextBlock.Text;
        }





        //private MobileServiceCollectionView<CloudContact> contactItems;
        // private MobileServiceCollection<CloudContact, CloudContact> contactItems;

        //private async void InsertContactItem(CloudContact cloudContact)
        //{
        //    await App.MobileService.GetTable<CloudContact>().InsertAsync(cloudContact);
        //    contactItems.Add(cloudContact);
        //}

        //private void submitButton_Click(object sender, RoutedEventArgs e)
        //{
        //    var cloudContact = new CloudContact { Text = nameTextBlock.Text };
        //    InsertContactItem(cloudContact);
        //}
    }
}
