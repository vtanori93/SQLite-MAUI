using IntelliJ.Lang.Annotations;
using System.Windows.Input;

namespace Test.ViewModels.Home
{
    public class HomePageViewModel : BaseViewModel
    {
        public ICommand DeparmentsCommand => new Command(async (e) => { await ExecuteDeparmentsCommandAsync(); });
        private async Task ExecuteDeparmentsCommandAsync()
        {
            if (!IsBusy)
            {
                IsBusy = true;
                await Shell.Current.Navigation.PushAsync(new Pages.Department.DepartmentsPage());
                IsBusy = false;
            }
        }
        public ICommand EmployessCommand => new Command(async (e) => { await ExecuteEmployessCommandAsync(); });
        private async Task ExecuteEmployessCommandAsync()
        {
            if (!IsBusy)
            {
                IsBusy = true;
                await Shell.Current.Navigation.PushAsync(new Pages.Employee.EmployeesPage());
                IsBusy = false;
            }
        }
    }
}
