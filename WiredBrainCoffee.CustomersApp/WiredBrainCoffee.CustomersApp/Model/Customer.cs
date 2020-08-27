using WiredBrainCoffee.CustomersApp.Base;

namespace WiredBrainCoffee.CustomersApp.Model
{
  public class Customer : Observable
  {
    private string _firstName;
    private string lastName;
    private bool isDeveloper;

    public string FirstName
    {
      get => _firstName;
      set
      {
        _firstName = value;
        // OnPropertyChanged("FirstName");
        // Alternatively, use the `nameof` keyword:
        // OnPropertyChange(nameof(FirstName));
        OnPropertyChanged();

      }
    }
    public string LastName
    {
      get => lastName;
      set
      {
        lastName = value;
        OnPropertyChanged();
      }
    }
    public bool IsDeveloper
    {
      get => isDeveloper; 
      set
      {
        isDeveloper = value;
        OnPropertyChanged();
      }
    }
  }
}