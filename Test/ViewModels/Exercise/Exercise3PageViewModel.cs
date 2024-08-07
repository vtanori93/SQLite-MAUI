using System.Collections.ObjectModel;

namespace Test.ViewModels.Exercise
{
    public class Exercise3PageViewModel : BaseViewModel
    {
        ObservableCollection<Models.Exercise.Exercise3> data = new ObservableCollection<Models.Exercise.Exercise3>();
        public ObservableCollection<Models.Exercise.Exercise3> Data
        {
            get { return data; }
            set { SetProperty(ref data, value); }
        }
        public Exercise3PageViewModel()
        {
        }
    }
}
