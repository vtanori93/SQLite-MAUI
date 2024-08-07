using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.Messaging;

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
            WeakReferenceMessenger.Default.Unregister<List<Models.Exercise.Exercise1>>(this);
            WeakReferenceMessenger.Default.Register<List<Models.Exercise.Exercise1>>(this, (r, m) =>
            {
                Data = new ObservableCollection<Models.Exercise.Exercise1>(m);
            });
        }
    }
}
