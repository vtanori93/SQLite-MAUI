using System.Collections.ObjectModel;

namespace Test.ViewModels.Exercise
{
    public class Exercise1PageViewModel : BaseViewModel
    {
        ObservableCollection<Models.Exercise.Exercise1> data = new ObservableCollection<Models.Exercise.Exercise1>();
        public ObservableCollection<Models.Exercise.Exercise1> Data
        {
            get { return data; }
            set { SetProperty(ref data, value); }
        }
        public Exercise1PageViewModel() 
        { 
        }
    }
}
