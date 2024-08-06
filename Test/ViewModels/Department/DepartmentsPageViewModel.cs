using System.Diagnostics;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace Test.ViewModels.Department
{
    public class DepartmentsPageViewModel : BaseViewModel
    {
        ObservableCollection<Models.SQLiteDB.Department> data = new ObservableCollection<Models.SQLiteDB.Department>();
        public ObservableCollection<Models.SQLiteDB.Department> Data
        {
            get { return data; }
            set { SetProperty(ref data, value); }
        }
        Models.SQLiteDB.Department selectedDepartment = new Models.SQLiteDB.Department();
        public Models.SQLiteDB.Department SelectedDepartment
        {
            get => selectedDepartment;
            set
            {
                SetProperty(ref selectedDepartment, value);
                OnItemDepartmentSelected(value);
            }
        }
        public Command<Models.SQLiteDB.Department> ItemDepartmentTapped { get; }
        public DepartmentsPageViewModel()
        {
            ItemDepartmentTapped = new Command<Models.SQLiteDB.Department>(OnItemDepartmentSelected);
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
                    var Result = await SQLiteDB.GetDepartmentAsync();
                    if (Result.Data != null)
                    {
                        Data = new ObservableCollection<Models.SQLiteDB.Department>(Result.Data);
                    }
                }
                catch (Exception Ex)
                {
                    Debug.WriteLine(Ex.ToString());
                }
                IsRefreshing = false;
                IsBusy = false;
            }
        }
        public ICommand AddDeparmentCommand => new Command(async (e) => { await ExecuteAddDeparmentCommandAsync(); });
        private async Task ExecuteAddDeparmentCommandAsync()
        {
            if (!IsBusy)
            {
                IsBusy = true;
                await Shell.Current.Navigation.PushAsync(new Pages.Department.AddDepartmentPage());
                IsBusy = false;
            }
        }
        async void OnItemDepartmentSelected(Models.SQLiteDB.Department Value)
        {
            var Result = await Helpers.Function.QuestionAsync("¿Está seguro de que desea eliminar el Departamento de "+ Value.Description +"?");
            if (Result)
            {
                var DeleteResult = await SQLiteDB.DeleteDepartmentAsync(Value.DepartmentId);
                if (DeleteResult.Data)
                {
                    await ExecuteGetDataCommandAsync();
                    await Helpers.Function.ShowMessageAsync("El departamento se eliminó correctamente.");
                }
                else
                {
                    await Helpers.Function.ShowMessageAsync(DeleteResult.Message);
                }
            }
        }
    }
}
