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
        Models.SQLiteDB.Employee selectedEmployee = new Models.SQLiteDB.Employee();
        public Models.SQLiteDB.Employee SelectedEmployee
        {
            get => selectedEmployee;
            set
            {
                SetProperty(ref selectedEmployee, value);
                OnItemEmployeeSelected(value);
            }
        }
        public Command<Models.SQLiteDB.Employee> ItemEmployeeTapped { get; }
        public EmployeesPageViewModel()
        {
            ItemEmployeeTapped = new Command<Models.SQLiteDB.Employee>(OnItemEmployeeSelected);
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
        public ICommand AddEmployeeCommand => new Command(async (e) => { await ExecuteAddEmployeeCommandAsync(); });
        private async Task ExecuteAddEmployeeCommandAsync()
        {
            if (!IsBusy)
            {
                IsBusy = true;
                await Shell.Current.Navigation.PushAsync(new Pages.Employee.AddEmployeePage());
                IsBusy = false;
            }
        }
        async void OnItemEmployeeSelected(Models.SQLiteDB.Employee Value)
        {
            var Result = await Helpers.Function.QuestionAsync("¿Está seguro de que desea eliminar el empleado: " + Value.Name + "?");
            if (Result)
            {
                var DeleteResult = await SQLiteDB.DeleteEmployeeAsync(Value.EmployeeId);
                if (DeleteResult.Data)
                {
                    await ExecuteGetDataCommandAsync();
                    await Helpers.Function.ShowMessageAsync("El empleado se eliminó correctamente.");
                }
                else
                {
                    await Helpers.Function.ShowMessageAsync(DeleteResult.Message);
                }
            }
        }
    }
}
