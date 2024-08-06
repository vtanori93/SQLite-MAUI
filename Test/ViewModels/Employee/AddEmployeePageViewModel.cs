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
    }
}
