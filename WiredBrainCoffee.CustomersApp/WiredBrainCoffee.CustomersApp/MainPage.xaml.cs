using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using System;
using WiredBrainCoffee.CustomersApp.DataProvider;
using Windows.ApplicationModel;
using System.Linq;
using WiredBrainCoffee.CustomersApp.Model;


// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace WiredBrainCoffee.CustomersApp
{
  public sealed partial class MainPage : Page
  {
    private CustomerDataProvider _customerDataProvider;
    public MainPage()
    {
      this.InitializeComponent();
      this.Loaded += MainPage_Loaded;
      _customerDataProvider = new CustomerDataProvider();
      App.Current.Suspending += App_Suspending;
    }

    private async void MainPage_Loaded(object sender, RoutedEventArgs e)
    {
      customerListView.Items.Clear();

      var customers = await _customerDataProvider.LoadCustomersAsync();
      foreach (var customer in customers)
      {
        customerListView.Items.Add(customer);
      }
    }
    private async void App_Suspending(object sender, SuspendingEventArgs e)
    {
      var deferral = e.SuspendingOperation.GetDeferral();
      await _customerDataProvider.SaveCustomersAsync(customerListView.Items.OfType<Customer>());
      deferral.Complete();
    }

    private void Flip_Click(object sender, RoutedEventArgs e)
    {
      int column = Grid.GetColumn(customerListGrid);
      int newcolumn = column == 0 ? 2 : 0;
      Grid.SetColumn(customerListGrid, newcolumn);
      flipIcon.Symbol = newcolumn == 0 ? Symbol.Forward : Symbol.Back;
    }

    private void Del_Click(object sender, RoutedEventArgs e)
    {
      var customer = customerListView.SelectedItem as Customer;
      if (customer !=null)
      {
        customerListView.Items.Remove(customer);
      }
    }

    private void Add_Click(object sender, RoutedEventArgs e)
    {
      var customer = new Customer { FirstName = "New" };
      customerListView.Items.Add(customer);
      customerListView.SelectedItem = customer;
    }

    private void CustomerListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
      var customer = customerListView.SelectedItem as Customer;
      txtFirstName.Text = customer?.FirstName ?? ""; // if null, assign empty string
      txtLastName.Text = customer?.LastName ?? "";
      chkIsDeveloper.IsChecked = customer?.IsDeveloper;
    }

    private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
    {
      UpdateCustomer();
    }

    private void CheckBox_IsCheckedChanged(object sender, RoutedEventArgs e)
    {
      UpdateCustomer();
    }

    private void UpdateCustomer()
    {
      var customer = customerListView.SelectedItem as Customer;
      if (customer != null)
      {
        customer.FirstName = txtFirstName.Text;
        customer.LastName = txtLastName.Text;
        customer.IsDeveloper = chkIsDeveloper.IsChecked.GetValueOrDefault();
      }
    }
  }
}
