using System.Collections.ObjectModel;
using System.Windows.Input;
namespace Test.ViewModels.Employee
{
    public class AddEmployeePageViewModel : BaseViewModel
    {
        ObservableCollection<Models.SQLiteDB.Department> list1 = new ObservableCollection<Models.SQLiteDB.Department>(); 
        public ObservableCollection<Models.SQLiteDB.Department> List1
        {
            get { return list1; }
            set { SetProperty(ref list1, value); }
        }
        bool isVisibleList1 = false;
        public bool IsVisibleList1
        {
            get { return isVisibleList1; }
            set { SetProperty(ref isVisibleList1, value); }
        }
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
        string dateOfJoining = DateTime.Now.ToString("dd/MM/yyyy");
        public string DateOfJoining
        {
            get { return dateOfJoining; }
            set { SetProperty(ref dateOfJoining, value); }
        }
        string dateBirth = DateTime.Now.ToString("dd/MM/yyyy");
        public string DateBirth
        {
            get { return dateBirth; }
            set { SetProperty(ref dateBirth, value); }
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
        Models.SQLiteDB.Department SelectedItemList1Object = new Models.SQLiteDB.Department();
        Models.SQLiteDB.Department _selectedItemList1 = new Models.SQLiteDB.Department();
        public Models.SQLiteDB.Department SelectedItemList1
        {
            get => _selectedItemList1;
            set
            {
                SetProperty(ref _selectedItemList1, value);
                OnItemList1Selected(value);
            }
        }
        public Command<Models.SQLiteDB.Department> ItemList1Tapped { get; }
        public AddEmployeePageViewModel()
        {
            ItemList1Tapped = new Command<Models.SQLiteDB.Department>(OnItemList1Selected);
            GetDataCommand?.Execute(null);
        }
        public ICommand GetDataCommand => new Command((e) => { ExecuteGetDataCommandAsync(); });
        private async void ExecuteGetDataCommandAsync()
        {
            if (!IsBusy)
            {
                IsBusy = true;
                var Result = await SQLiteDB.GetDepartmentAsync();
                if (!Result.Error && Result.Data != null)
                {
                    List1 = new ObservableCollection<Models.SQLiteDB.Department>(Result.Data);
                }
                IsBusy = false;
            }
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
                var EmployeeId = Guid.NewGuid();
                var PaymentMethod = string.Empty;
                if(Cash && !Transfer)
                {
                    PaymentMethod = "Efectivo";
                }
                else
                {
                    PaymentMethod = "Transferencia";
                }
                var Result1 = await SQLiteDB.PostEmployeeAsync(new Models.SQLiteDB.Employee
                {
                    Name = Name,
                    DateBirth = Convert.ToDateTime(DateBirth),
                    DateOfJoining = Convert.ToDateTime(DateOfJoining),
                    DepartmentId = SelectedItemList1Object.DepartmentId,
                    EmployeeId = EmployeeId
                });
                if(Result1.Data && !Result1.Error)
                {
                    var Result2 = await SQLiteDB.PostSalaryAsync(new Models.SQLiteDB.Salary
                    {
                        EmployeeId = EmployeeId,
                        MonthlySalary = MonthlySalary,
                        PaymentMethod = PaymentMethod
                    });
                    if(Result2.Data && !Result2.Error)
                    {
                        await Shell.Current.Navigation.PopAsync();
                    }
                }
                IsBusy = false;
            }
        }
        public ICommand ToggleList1 => new Command((e) => { ExecuteToggleList1(); });
        private void ExecuteToggleList1()
        {
            if (!IsBusy)
            {
                IsBusy = true;
                Department = "Seleccione una opción";
                IsVisibleList1 = !IsVisibleList1;
                IsBusy = false;
            }
        }
        void OnItemList1Selected(Models.SQLiteDB.Department Item)
        {
            SelectedItemList1Object = Item;
            Department = Item.Description;
            IsVisibleList1 = false;
        }
    }
}
