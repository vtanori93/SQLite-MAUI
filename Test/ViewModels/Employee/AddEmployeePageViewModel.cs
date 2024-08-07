using System.Windows.Input;
namespace Test.ViewModels.Employee
{
    public class AddEmployeePageViewModel : BaseViewModel
    {
        bool transfer = false;
        public bool Transfer
        {
            get { return transfer; }
            set { SetProperty(ref transfer, value); }
        }
        bool cash = true;
        public bool Cash
        {
            get { return cash; }
            set { SetProperty(ref cash, value); }
        }
        string name = string.Empty;
        public string Name
        {
            get { return name; }
            set { SetProperty(ref name, value); }
        }
        string employeeKey = string.Empty;
        public string EmployeeKey
        {
            get { return employeeKey; }
            set { SetProperty(ref employeeKey, value); }
        }
        string dateOfJoining = string.Empty;
        public string DateOfJoining
        {
            get { return dateOfJoining; }
            set { SetProperty(ref dateOfJoining, value); }
        }
        string birthDate = string.Empty;
        public string BirthDate
        {
            get { return birthDate; }
            set { SetProperty(ref birthDate, value); }
        }
        string monthlySalary = string.Empty;
        public string MonthlySalary
        {
            get { return monthlySalary; }
            set { SetProperty(ref monthlySalary, value); }
        }
        string department = "Seleccione una opción";
        public string Department
        {
            get { return department; }
            set { SetProperty(ref department, value); }
        }
        public ICommand ToggleTransferCommand => new Command((e) => { ExecuteToggleTransferCommand(); });
        private void ExecuteToggleTransferCommand()
        {
            if (!IsBusy)
            {
                IsBusy = true;
                Transfer = !Transfer;
                Cash = false;
                IsBusy = false;
            }
        }
        public ICommand ToggleCashCommand => new Command((e) => { ExecuteToggleCashCommand(); });
        private void ExecuteToggleCashCommand()
        {
            if (!IsBusy)
            {
                IsBusy = true;
                Transfer = false;
                Cash = !Cash;
                IsBusy = false;
            }
        }
        public ICommand SaveCommand => new Command(async (e) => { await ExecuteSaveCommandAsync(); });
        private async Task ExecuteSaveCommandAsync()
        {
            if (!IsBusy)
            {
                IsBusy = true;

                IsBusy = false;
            }
        }
    }
}
