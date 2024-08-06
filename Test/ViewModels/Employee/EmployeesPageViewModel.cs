using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Windows.Input;

namespace Test.ViewModels.Employee
{
    public class EmployeesPageViewModel : BaseViewModel
    {
        ObservableCollection<Models.SQLiteDB.Employee> data = new ObservableCollection<Models.SQLiteDB.Employee>();
        public ObservableCollection<Models.SQLiteDB.Employee> Data
        {
            get { return data; }
            set { SetProperty(ref data, value); }
        }
        public EmployeesPageViewModel()
        {
            GetDataCommand?.Execute(null);
        }
        public ICommand GetDataCommand => new Command(async (e) => { await ExecuteGetDataCommandAsync(); });
        private async Task ExecuteGetDataCommandAsync()
        {
            if (!IsBusy)
            {
                IsBusy = true;
                try
                {
                    var Result = await SQLiteDB.GetEmployeeAsync();
                    if(Result.Data != null)
                    {
                        Data = new ObservableCollection<Models.SQLiteDB.Employee>(Result.Data);
                    }
                }
                catch(Exception Ex)
                {
                    Debug.WriteLine(Ex.ToString());
                }
                IsRefreshing = false;
                IsBusy = false;
            }
        }
    }
}
