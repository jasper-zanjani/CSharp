using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using System;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace WiredBrainCoffee.CustomersApp
{
  public sealed partial class MainPage : Page
  {
    public MainPage()
    {
      this.InitializeComponent();
    }

    private async void Add_Click(object sender, RoutedEventArgs e)
    {
      var messageDialog = new MessageDialog("Customer added!");
      await messageDialog.ShowAsync();
    }


    private void Flip_Click(object sender, RoutedEventArgs e)
    {
      int column = (int)customerListGrid.GetValue(Grid.ColumnProperty);
      int newcolumn = column == 0 ? 2 : 0;
      customerListGrid.SetValue(Grid.ColumnProperty, newcolumn);
      flipIcon.Symbol = newcolumn == 0 ? Symbol.Forward : Symbol.Back;
      }

    private void Del_Click(object sender, RoutedEventArgs e)
    {

    }
  }
}
