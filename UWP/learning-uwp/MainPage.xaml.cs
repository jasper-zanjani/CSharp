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

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace learning_uwp
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

        private void MyCheckBox_Tapped(object sender, TappedRoutedEventArgs e)
        {
            CheckBoxResultTextBlock.Text = MyCheckBox.IsChecked.ToString();
        }

        private void Starfleet_Checked(object sender, RoutedEventArgs e)
        {
            Fleet.Text = "Starfleet";
        }

        private void Borg_Checked(object sender, RoutedEventArgs e)
        {
            Fleet.Text = "The Borg";
        }

        private void Era_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
