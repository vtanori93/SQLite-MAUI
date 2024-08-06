using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Windows.Input;

namespace Test.ViewModels.Department
{
    public class AddDepartmentPageViewModel : BaseViewModel
    {
        string description = string.Empty;
        public string Description
        {
            get { return description; }
            set { SetProperty(ref description, value); }
        }
        public ICommand SaveCommand => new Command(async (e) => { await ExecuteSaveCommandAsync(); });
        private async Task ExecuteSaveCommandAsync()
        {
            if (!IsBusy)
            {
                IsBusy = true;
                if (string.IsNullOrEmpty(Description.TrimStart().TrimEnd()))
                {
                    await Helpers.Function.ShowMessageAsync("Para continuar, ingresa un nombre de departamento válido.\r\n\r\n\r\n\r\n\r\n\r\n\r\n");
                    IsBusy = false;
                    return;
                }
                try
                {
                    var Result = await SQLiteDB.PostDepartmentAsync(new Models.SQLiteDB.Department
                    {
                        DepartmentId = Guid.NewGuid(),
                        Description = Description,
                    });
                    if (Result.Data)
                    {
                        await Shell.Current.Navigation.PopAsync();
                    }
                    else
                    {
                        await Helpers.Function.ShowMessageAsync(Result.Message);
                    }
                }
                catch(Exception Ex)
                {
                    Debug.WriteLine(Ex.ToString());
                }
                IsBusy = false;
            }
        }
    }
}
