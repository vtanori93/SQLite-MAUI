using System.Collections.ObjectModel;

namespace Test.ViewModels.Exercise
{
    public class Exercise2PageViewModel : BaseViewModel
    {
        ObservableCollection<Models.Exercise.Exercise2> data = new ObservableCollection<Models.Exercise.Exercise2>();
        public ObservableCollection<Models.Exercise.Exercise2> Data
        {
            get { return data; }
            set { SetProperty(ref data, value); }
        }
        public Exercise2PageViewModel()
        {
        }
    }
}
