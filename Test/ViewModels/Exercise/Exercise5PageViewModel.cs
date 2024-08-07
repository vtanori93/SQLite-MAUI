using System.Collections.ObjectModel;

namespace Test.ViewModels.Exercise
{
    public class Exercise5PageViewModel : BaseViewModel
    {
        ObservableCollection<Models.Exercise.Exercise5> data = new ObservableCollection<Models.Exercise.Exercise5>();
        public ObservableCollection<Models.Exercise.Exercise5> Data
        {
            get { return data; }
            set { SetProperty(ref data, value); }
        }
        public Exercise5PageViewModel()
        {
        }
    }
}
