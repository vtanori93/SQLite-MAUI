using System.Collections.ObjectModel;

namespace Test.ViewModels.Exercise
{
    public class Exercise4PageViewModel : BaseViewModel
    {
        ObservableCollection<Models.Exercise.Exercise4> data = new ObservableCollection<Models.Exercise.Exercise4>();
        public ObservableCollection<Models.Exercise.Exercise4> Data
        {
            get { return data; }
            set { SetProperty(ref data, value); }
        }
        public Exercise4PageViewModel()
        {
        }
    }
}
