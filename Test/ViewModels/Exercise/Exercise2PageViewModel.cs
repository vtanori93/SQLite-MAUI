using CommunityToolkit.Mvvm.Messaging;
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
            WeakReferenceMessenger.Default.Unregister<List<Models.Exercise.Exercise2>>(this);
            WeakReferenceMessenger.Default.Register<List<Models.Exercise.Exercise2>>(this, async (r, m) =>
            {
                await Task.Delay(250);
                Data = new ObservableCollection<Models.Exercise.Exercise2>(m);
            });
        }
    }
}
