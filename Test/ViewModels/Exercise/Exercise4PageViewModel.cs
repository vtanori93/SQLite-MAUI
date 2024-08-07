using CommunityToolkit.Mvvm.Messaging;
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
            WeakReferenceMessenger.Default.Unregister<List<Models.Exercise.Exercise4>>(this);
            WeakReferenceMessenger.Default.Register<List<Models.Exercise.Exercise4>>(this, (r, m) =>
            {
                Data = new ObservableCollection<Models.Exercise.Exercise4>(m);
            });
        }
    }
}
