
using System.Collections.ObjectModel;

namespace Test.ViewModels.Exercise
{
    public class Exercise7PageViewModel : BaseViewModel
    {
        ObservableCollection<Models.Exercise.Exercise7> data = new ObservableCollection<Models.Exercise.Exercise7>();
        public ObservableCollection<Models.Exercise.Exercise7> Data
        {
            get { return data; }
            set { SetProperty(ref data, value); }
        }
        public Exercise7PageViewModel()
        {
        }
    }
}
