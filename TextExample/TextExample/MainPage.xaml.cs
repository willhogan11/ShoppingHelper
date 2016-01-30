﻿using System;
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

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace TextExample
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            //TextBox txt;
            //txt = new TextBox();
            //// ... Get control that raised this event.
            //// var textBox = sender as TextBox;
            //// ... Change Window Title.
            //txt.HorizontalAlignment = HorizontalContentAlignment;
            //// txt.Text = textBox.Text + "[Length = " + textBox.Text.Length.ToString() + "]";
            //resultBlock.Text = txt.ToString();

            resultBlock.Text = txtEntered.Text;
        }

        private void resultBtn_Click(object sender, RoutedEventArgs e)
        {
            //TextBox enteredTxt;
            //enteredTxt = new TextBox();
            //enteredTxt.HorizontalAlignment = HorizontalContentAlignment;
            //resultBlock.Text = txtEntered.ToString();


            resultBlock.Text = txtEntered.Text;
        }

        private void txtEntered_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
