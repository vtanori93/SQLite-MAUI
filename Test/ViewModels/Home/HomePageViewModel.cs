using System.Diagnostics;
using System.Windows.Input;
using Newtonsoft.Json;
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
        public ICommand Exercise1Command => new Command(async (e) => { await ExecuteExercise1CommandAsync(); });
        private async Task ExecuteExercise1CommandAsync()
        {
            if (!IsBusy)
            {
                IsBusy = true;
                var Result = await SQLiteDB.GetExercise1Async();
                if(Result.Data != null && !Result.Error)
                {
                    Debug.WriteLine("Exercise 1 - Result: " + JsonConvert.SerializeObject(Result.Data));
                }
                IsBusy = false;
            }
        }
        public ICommand Exercise2Command => new Command(async (e) => { await ExecuteExercise2CommandAsync(); });
        private async Task ExecuteExercise2CommandAsync()
        {
            if (!IsBusy)
            {
                IsBusy = true;
                var Result = await SQLiteDB.GetExercise2Async();
                if (Result.Data != null && !Result.Error)
                {
                    Debug.WriteLine("Exercise 2 - Result: " + JsonConvert.SerializeObject(Result.Data));
                }
                IsBusy = false;
            }
        }
        public ICommand Exercise3Command => new Command(async (e) => { await ExecuteExercise3CommandAsync(); });
        private async Task ExecuteExercise3CommandAsync()
        {
            if (!IsBusy)
            {
                IsBusy = true;
                var Result = await SQLiteDB.GetExercise3Async();
                if (Result.Data != null && !Result.Error)
                {
                    Debug.WriteLine("Exercise 3 - Result: " + JsonConvert.SerializeObject(Result.Data));
                }
                IsBusy = false;
            }
        }
        public ICommand Exercise4Command => new Command(async (e) => { await ExecuteExercise4CommandAsync(); });
        private async Task ExecuteExercise4CommandAsync()
        {
            if (!IsBusy)
            {
                IsBusy = true;
                var Result = await SQLiteDB.GetExercise4Async();
                if (Result.Data != null && !Result.Error)
                {
                    Debug.WriteLine("Exercise 4 - Result: " + JsonConvert.SerializeObject(Result.Data));
                }
                IsBusy = false;
            }
        }
        public ICommand Exercise5Command => new Command(async (e) => { await ExecuteExercise5CommandAsync(); });
        private async Task ExecuteExercise5CommandAsync()
        {
            if (!IsBusy)
            {
                IsBusy = true;
                var Result = await SQLiteDB.GetExercise5Async();
                if (Result.Data != null && !Result.Error)
                {
                    Debug.WriteLine("Exercise 5 - Result: " + JsonConvert.SerializeObject(Result.Data));
                }
                IsBusy = false;
            }
        }
        public ICommand Exercise6Command => new Command(async (e) => { await ExecuteExercise6CommandAsync(); });
        private async Task ExecuteExercise6CommandAsync()
        {
            if (!IsBusy)
            {
                IsBusy = true;
                var Result = await SQLiteDB.GetExercise6Async();
                if (Result.Data != null && !Result.Error)
                {
                    Debug.WriteLine("Exercise 6 - Result: " + JsonConvert.SerializeObject(Result.Data));
                }
                IsBusy = false;
            }
        }
        public ICommand Exercise7Command => new Command(async (e) => { await ExecuteExercise7CommandAsync(); });
        private async Task ExecuteExercise7CommandAsync()
        {
            if (!IsBusy)
            {
                IsBusy = true;
                var Result = await SQLiteDB.GetExercise7Async(Guid.NewGuid());
                if (Result.Data != null && !Result.Error)
                {
                    Debug.WriteLine("Exercise 7 - Result: " + JsonConvert.SerializeObject(Result.Data));
                }
                IsBusy = false;
            }
        }
    }
}
